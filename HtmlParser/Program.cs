using System;
using System.Windows.Forms;
using HtmlParser.Bl;

namespace HtmlParser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HtmlParser view = new HtmlParser();
            MessageService messageService = new MessageService();
            ParsingSettingsForm parsingSettings = new ParsingSettingsForm();
            MainPresenter presenter = new MainPresenter(view, parsingSettings, messageService);
            Application.Run(view);
        }
    }
}
