using System;
using System.Drawing;
using System.Windows.Forms;

namespace HtmlParser
{
    interface IViewSettings
    {
        event EventHandler Close;
        event EventHandler<ParsingSettings> Start;
        void HideForm();
        void ShowModal(IWin32Window owner);
    }
    public partial class ParsingSettingsForm : Form, IViewSettings
    {
        public new event EventHandler Close;
        public event EventHandler<ParsingSettings> Start;
        readonly GroupBox[] gBoxes;
        public ParsingSettingsForm()
        {
            InitializeComponent();
            gBoxes = new GroupBox[] { gBoxSource, gBoxTags, gBoxAttr };
            ResetForm();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }
        public void HideForm()
        {
            this.Hide();
            this.Visible = false;
            BtnCancel.Enabled = true;
        }

        public void ShowModal(IWin32Window owner)
        {
            this.ShowDialog(owner);
        }
      
        void ResetForm()
        {
            txtbUrl.Text = "";
            chlb_Tags.SetItemChecked(1, true);
            chlb_Tags.SetItemChecked(3, true);
            chlb_Tags.SetItemChecked(4, true);
            chlb_Tags.SetItemChecked(5, true);
            parserTypeCmb.SelectedIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                chlbAttr.SetItemChecked(i, true);
            }

            for (int i = 0; i < gBoxes.Length; i++)
            {
                gBoxes[i].ForeColor = Color.Black;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close?.Invoke(this, null);
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
                string[] _attrs = new string[chlbAttr.CheckedItems.Count],
                _tags = new string[chlb_Tags.CheckedItems.Count];
                string _url = txtbUrl.Text;
                string _source = txtbMarkup.Text;

                chlb_Tags.CheckedItems.CopyTo(_tags, 0);
                chlbAttr.CheckedItems.CopyTo(_attrs, 0);

                int _currentLength = 0;
                for (int i = 0; i < _tags.Length; i++)
                {
                    _currentLength = _tags[i].Length;
                    _tags[i] = _tags[i].Substring(1, _currentLength - 2);
                }
                Start?.Invoke(this, new ParsingSettings() { Url = _url, Source = _source, Attributes = _attrs, Tags = _tags, ParserType = parserTypeCmb.SelectedIndex });
        }
        private void txtbUrl_TextChanged(object sender, EventArgs e)
        {
            txtbMarkup.Text = "";
        }

        private void txtbMarkup_TextChanged(object sender, EventArgs e)
        {
            txtbUrl.Text = "";
        }

    }

    public class ParsingSettings : EventArgs
    {
        public string Url { get; internal set; }
        public string Source { get; internal set; }
        public string[] Tags { get; internal set; }
        public string[] Attributes { get; internal set; }
        public int ParserType { get; internal set; }
    }
}
