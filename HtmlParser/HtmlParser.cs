using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HtmlParser
{
    interface IView
    {
        event EventHandler NewParcing;
        event EventHandler SaveData;
        event EventHandler ReadAllData;
        void ShowForm();
        /// <summary>
        /// Binds data to specific dataGrid
        /// </summary>
        /// <param name="data">Data wich will be binded</param>
        /// <param name="target">Target dataGrid</param>
        void BindData(DataTable data, DataGrid target);
        /// <summary>
        /// Resets the form
        /// </summary>
        void Reset();
        /// <summary>
        /// Writes the line to the listBox 'Console'
        /// </summary>
        /// <param name="text">Input text</param>
        void Write(string text);
        IWin32Window GetForm();
        /// <summary>
        /// Turn off ToolStripMenu items when some work in progress
        /// </summary>
        /// <param name="isBusy">Flag that identifies that program is busy</param>
        void ToggleToolStripBusy(bool isBusy);
    }
    public partial class HtmlParser : Form, IView
    {
        public event EventHandler NewParcing;
        public event EventHandler SaveData;
        public event EventHandler ReadAllData;
        List<DataTable> _tags;
        List<DataTable> _responces;
        static readonly CancellationTokenSource _cancelationTokenSource = new CancellationTokenSource();
        static readonly CancellationToken _cancelationToken = _cancelationTokenSource.Token;
        int _currentColumnID = 0;
        string _parsingPKColumn = null;
        bool _isDataRead = false;

        public HtmlParser()
        {
            _tags = new List<DataTable>();
            _responces = new List<DataTable>();
            InitializeComponent();
            Parsings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ParsingResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Responses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }
        
        public void Write(string text)
        {
            Console.Items.Add(text);
            Console.Update();
            Console.TopIndex = Console.Items.Count - 1;
            Console.Update();
        }

        public void ShowForm()
        {
            this.Show();
        }

        public IWin32Window GetForm()
        {
            return this as IWin32Window;
        }

        public void BindData(DataTable data, DataGrid target)
        {
            switch (target)
            {
                case DataGrid.Responce:
                    {
                        if (_isDataRead)
                        {
                            _responces.Add(data);
                            if (_responces.Count > 1)
                            {
                                //"НЕ ОТОБРАЖАЕМ"
                                break;
                            }
                        }
                        Responses.DataSource = data;
                        break;
                    }
                case DataGrid.Result:
                    {
                        if (_isDataRead)
                        {
                            _tags.Add(data);
                            if (_tags.Count > 1)
                            {
                                //"НЕ ОТОБРАЖАЕМ"
                                break;
                            }
                        }
                        ParsingResult.DataSource = data;
                        break;
                    }
                default:
                    {
                        if (_isDataRead)
                        {
                            _parsingPKColumn = data.PrimaryKey[0].ColumnName;
                            _currentColumnID = 1;
                        }
                            Parsings.DataSource = data;
                        break;
                    }
            }
            
        }

        public void Reset()
        {
            _isDataRead = false;
            _currentColumnID = 0;
            _parsingPKColumn = null;
            _tags = new List<DataTable>();
            _responces = new List<DataTable>();
        }

        public void ToggleToolStripBusy(bool isBusy)
        {
            if (isBusy)
            {
                newToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                openToolStripMenuItem.Enabled = false;
            }
            else
            {
                newToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolStripBusy(true);
            NewParcing?.Invoke(this, null);
        }

        private void HtmlParser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolStripBusy(true);
            richTextBox1.Text = "";
            SaveData?.Invoke(this, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolStripBusy(true);
            richTextBox1.Text = "";
            ReadAllData?.Invoke(this, null);
            _isDataRead = true;
        }

        private void Parsings_DataSourceChanged(object sender, EventArgs e)
        {
            _tags = new List<DataTable>();
            _responces = new List<DataTable>();
        }

        private void Parsings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_isDataRead || String.IsNullOrEmpty(_parsingPKColumn))
                return;

            int currentId = (int)Parsings.SelectedRows[0].Cells[_parsingPKColumn].Value;
            if (_currentColumnID == currentId)
                return;
            _currentColumnID = currentId;
            DataTable table = null;
            foreach (var tag in _tags)
            {
                var findQuery = (from DataRow dr in tag.Rows
                         where Convert.ToInt32(dr[_parsingPKColumn]) == currentId
                                 select dr).FirstOrDefault();

                if (findQuery != null)
                {
                    table = tag;
                    break;
                }
            }
            if (table != null)
                ParsingResult.DataSource = table;

            table = null;
            foreach (var responce in _responces)
            {
                var findQuery = (from DataRow dr in responce.Rows
                                 where Convert.ToInt32(dr[_parsingPKColumn]) == currentId
                                 select dr).FirstOrDefault();

                if (findQuery != null)
                {
                    table = responce;
                    break;
                }
            }
            if (table != null)
                Responses.DataSource = table;
            else
                Responses.DataSource = null;


            DataGridViewRow row = Parsings.SelectedRows[0];
            string url = row.Cells["Url"].Value.ToString();

            richTextBox1.Text = $"Парсинг \n Url: {url}";
        }

        private void ParsingResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ParsingResult.SelectedRows[0];
            DataGridViewCellCollection cells = row.Cells;
            StringBuilder text = new StringBuilder();
            foreach (DataGridViewColumn col in ParsingResult.Columns)
            {
                text.Append(col.HeaderText).Append(" : ").Append(cells[col.Name].Value).Append(Environment.NewLine);
            }
            richTextBox1.Text = text.ToString();
        }

        private void Responses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Responses.SelectedRows[0];
            DataGridViewCellCollection cells = row.Cells;
            StringBuilder text = new StringBuilder();
            foreach (DataGridViewColumn col in Responses.Columns)
            {
                text.Append(col.HeaderText).Append(" : ").Append(cells[col.Name].Value).Append(Environment.NewLine);
            }
            richTextBox1.Text = text.ToString();
        }

        private void ParsingResult_DataSourceChanged(object sender, EventArgs e)
        {
            if (!_isDataRead)
            {
                ParsingResult.Columns["ID"].Visible = false;
                ParsingResult.Columns["ParsingID"].Visible = false;
            }
            ParsingResult.Columns["Description"].Visible = false;
            int descrIndex = ParsingResult.Columns["Description"].Index;
            foreach (DataGridViewRow row in ParsingResult.Rows)
            {
                    if (!String.IsNullOrEmpty(row.Cells[descrIndex].Value?.ToString()))
                    {
                        richTextBox2.ForeColor = Color.Black;
                        richTextBox2.Text = "Описание страницы : " + row.Cells[descrIndex].Value.ToString();
                        return;
                    }
            }

            richTextBox2.ForeColor = Color.Red;
            richTextBox2.Text = "Описание страницы отсутствует!!!";
        }

        private void HtmlParser_Shown(object sender, EventArgs e)
        {
            NewParcing?.Invoke(this, null);
        }
    }

    public enum DataGrid { Result, Responce, Parsing }
}
