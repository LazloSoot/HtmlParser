using System;
using HtmlParser.Bl;
using System.Data;

namespace HtmlParser
{
    class MainPresenter
    {
        private readonly IView _view;
        private readonly IViewSettings _parseSettings;
        private readonly IMessageService _messageService;
        private IParserController _parserController;
        private readonly System.Windows.Forms.IWin32Window _mainForm;
        ParserSettings _settings;
        public MainPresenter(IView view, IViewSettings parseSettings, IMessageService messageService)
        {
            _view = view;
            _parseSettings = parseSettings;
            _messageService = messageService;

            _parseSettings.Start += _parseSettings_Start;
            _parseSettings.Close += _parseSettings_Closing;
            _view.NewParcing += _view_NewParcing;
            _view.SaveData += _view_SaveData;
            _view.ReadAllData += _view_ReadData;

            _mainForm = _view.GetForm();
            _parserController = ParserControllerBuilder.GetController<DataTable>("mock", null, null, ParserType.Agility);
            _parserController.NewDataReceived += _parserController_NewDataReceived;
        }

        private async void _view_ReadData(object sender, EventArgs e)
        {
            _view.Write(DateTime.UtcNow.ToLongTimeString() + "  || Выполняется запрос к базе данных....");
            bool queryState = false;
            try
            {
                await _parserController.ReadDataAsync();
                queryState = true;
            }
            catch (ArgumentNullException ex)
            {
                _messageService.ShowError(ex.Message);
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  ---- Во время запроса к базе возникла ошибка!");
                queryState = false;
            }
            finally
            {
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  ||Запрос " + ((queryState) ? "успешно " : "не ") + "выполнен");
                _view.ToggleToolStripBusy(false);
            }
        }

        private async void _view_SaveData(object sender, EventArgs e)
        {
            _view.Write(DateTime.UtcNow.ToLongTimeString() + "  || Выполняется запрос на сохранение информации в базу данных....");
            bool queryState = false;
            try
            {
                await _parserController.SaveDataAsync();
                queryState = true;
            }
            catch (ArgumentNullException ex)
            {
                _messageService.ShowError(ex.Message);
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  ---- Во время запроса возникла ошибка!");
                queryState = false;
            }
            finally
            {
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  || Сохранение данных " + ((queryState) ? "успешно " : "не ") + "выполнено");
                _view.ToggleToolStripBusy(false);
            }
        }

        private async void _parseSettings_Start(object sender, ParsingSettings e)
        {
            if (String.IsNullOrWhiteSpace(e.Url) && string.IsNullOrWhiteSpace(e.Source))
            {
                _messageService.ShowError("Данные для парсинга отсутствуют!");
                return;
            }
            else
            if (e.Tags.Length == 0)
            {
                _messageService.ShowError("Теги для парсинга отсутствуют!");
                return;
            }
            else
            if (e.Attributes.Length == 0)
            {
                _messageService.ShowError("Атрибуты для парсинга отсутствуют!");
                return;
            }
            else
                if (string.IsNullOrWhiteSpace(e.Source) & !(Uri.TryCreate(e.Url, UriKind.Absolute, out Uri uri)))
            {
                _messageService.ShowError("Данный URL не валидный!");
                return;
            }


            string[] attrs = e.Attributes;
            _settings = new ParserSettings(e.Tags, attrs);
            ParserType parserType;

            try
            {
                parserType = (ParserType)e.ParserType;
            }
            catch (InvalidCastException ex)
            {
                _messageService.ShowError(ex.Message);
                return;
            }

            try
            {
                _parserController = ParserControllerBuilder.GetController<DataTable>(e.Url, e.Source, _settings, parserType);
                _parserController.NewDataReceived += _parserController_NewDataReceived;
            }
            catch (NotSupportedException ex)
            {
                _messageService.ShowError(ex.Message);
                return;
            }
            catch (NullReferenceException ex)
            {
                _messageService.ShowError(ex.Message);
                return;
            }

            _parseSettings.HideForm();
            bool parsingState = false;

            try
            {
                _view.Reset();
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  || Выполняется парсинг....");
                await _parserController.ParseAsync();
                parsingState = true;
            }
            catch (ArgumentNullException ex)
            {
                _messageService.ShowError(ex.Message);
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  ---- Во время парсинга возникла ошибка!");
                parsingState = false;
            }
            finally
            {
                _view.Write(DateTime.UtcNow.ToLongTimeString() + "  || Парсинг " + ((parsingState) ? "успешно " : "не ") + "выполнен");
                _view.ToggleToolStripBusy(false);
            }
        }

        private void _parserController_NewDataReceived(object sender, ParsingData e)
        {
            if (Enum.TryParse(e.Name, out DataGrid myStatus))
            {
                _view.BindData(e.Data, myStatus);
            }
            else
            {
                _messageService.ShowError("Недоступный тип DataGrid!");
            }
        }

        private void _view_NewParcing(object sender, EventArgs e)
        {
            try
            {
                _parseSettings.ShowModal(_mainForm);
            }
            catch (NullReferenceException ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _parseSettings_Closing(object sender, EventArgs e)
        {
            _parseSettings.HideForm();
        }

    }
}
