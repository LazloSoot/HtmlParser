namespace HtmlParser
{
    partial class ParsingSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUrl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxSource = new System.Windows.Forms.GroupBox();
            this.txtbMarkup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbUrl = new System.Windows.Forms.TextBox();
            this.gBoxTags = new System.Windows.Forms.GroupBox();
            this.chlb_Tags = new System.Windows.Forms.CheckedListBox();
            this.gBoxAttr = new System.Windows.Forms.GroupBox();
            this.chlbAttr = new System.Windows.Forms.CheckedListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parserTypeCmb = new System.Windows.Forms.ComboBox();
            this.gBoxSource.SuspendLayout();
            this.gBoxTags.SuspendLayout();
            this.gBoxAttr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUrl.Location = new System.Drawing.Point(144, 19);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(68, 13);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Введите Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(193, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Настройки нового парсинга";
            // 
            // gBoxSource
            // 
            this.gBoxSource.Controls.Add(this.txtbMarkup);
            this.gBoxSource.Controls.Add(this.label3);
            this.gBoxSource.Controls.Add(this.txtbUrl);
            this.gBoxSource.Controls.Add(this.lblUrl);
            this.gBoxSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gBoxSource.Location = new System.Drawing.Point(12, 26);
            this.gBoxSource.Name = "gBoxSource";
            this.gBoxSource.Size = new System.Drawing.Size(394, 308);
            this.gBoxSource.TabIndex = 6;
            this.gBoxSource.TabStop = false;
            this.gBoxSource.Text = "Выберите источник данных";
            // 
            // txtbMarkup
            // 
            this.txtbMarkup.Location = new System.Drawing.Point(7, 74);
            this.txtbMarkup.Multiline = true;
            this.txtbMarkup.Name = "txtbMarkup";
            this.txtbMarkup.Size = new System.Drawing.Size(381, 224);
            this.txtbMarkup.TabIndex = 2;
            this.txtbMarkup.TextChanged += new System.EventHandler(this.txtbMarkup_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(91, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Или поместите текст разметки в поле: ";
            // 
            // txtbUrl
            // 
            this.txtbUrl.Location = new System.Drawing.Point(6, 35);
            this.txtbUrl.Name = "txtbUrl";
            this.txtbUrl.Size = new System.Drawing.Size(381, 21);
            this.txtbUrl.TabIndex = 1;
            this.txtbUrl.TextChanged += new System.EventHandler(this.txtbUrl_TextChanged);
            // 
            // gBoxTags
            // 
            this.gBoxTags.Controls.Add(this.chlb_Tags);
            this.gBoxTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gBoxTags.Location = new System.Drawing.Point(412, 26);
            this.gBoxTags.Name = "gBoxTags";
            this.gBoxTags.Size = new System.Drawing.Size(237, 100);
            this.gBoxTags.TabIndex = 7;
            this.gBoxTags.TabStop = false;
            this.gBoxTags.Text = "Отметьте искомые теги";
            // 
            // chlb_Tags
            // 
            this.chlb_Tags.ColumnWidth = 112;
            this.chlb_Tags.FormattingEnabled = true;
            this.chlb_Tags.Items.AddRange(new object[] {
            "<title>",
            "<meta>",
            "<link>",
            "<a>",
            "<img>",
            "<h1>",
            "<h2>",
            "<h3>",
            "<h4>",
            "<h5>",
            "<h6>",
            "<p>",
            "<strong>",
            "<em>"});
            this.chlb_Tags.Location = new System.Drawing.Point(0, 19);
            this.chlb_Tags.MultiColumn = true;
            this.chlb_Tags.Name = "chlb_Tags";
            this.chlb_Tags.Size = new System.Drawing.Size(228, 79);
            this.chlb_Tags.TabIndex = 3;
            // 
            // gBoxAttr
            // 
            this.gBoxAttr.Controls.Add(this.chlbAttr);
            this.gBoxAttr.Location = new System.Drawing.Point(412, 130);
            this.gBoxAttr.Name = "gBoxAttr";
            this.gBoxAttr.Size = new System.Drawing.Size(238, 113);
            this.gBoxAttr.TabIndex = 8;
            this.gBoxAttr.TabStop = false;
            this.gBoxAttr.Text = "Отметьте искомые атрибуты тегов";
            // 
            // chlbAttr
            // 
            this.chlbAttr.ColumnWidth = 112;
            this.chlbAttr.FormattingEnabled = true;
            this.chlbAttr.Items.AddRange(new object[] {
            "Name",
            "Content",
            "Href",
            "Src",
            "Class",
            "TagId",
            "TextContent"});
            this.chlbAttr.Location = new System.Drawing.Point(0, 19);
            this.chlbAttr.MultiColumn = true;
            this.chlbAttr.Name = "chlbAttr";
            this.chlbAttr.Size = new System.Drawing.Size(231, 94);
            this.chlbAttr.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(412, 302);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 32);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(493, 302);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 32);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Отмена";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(574, 302);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 32);
            this.btnParse.TabIndex = 5;
            this.btnParse.Text = "Парсить";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parserTypeCmb);
            this.groupBox1.Location = new System.Drawing.Point(412, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 47);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите тип парсера";
            // 
            // parserTypeCmb
            // 
            this.parserTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parserTypeCmb.FormattingEnabled = true;
            this.parserTypeCmb.Items.AddRange(new object[] {
            "Html Agility Pack",
            "AngleSharp"});
            this.parserTypeCmb.Location = new System.Drawing.Point(0, 26);
            this.parserTypeCmb.Name = "parserTypeCmb";
            this.parserTypeCmb.Size = new System.Drawing.Size(231, 21);
            this.parserTypeCmb.TabIndex = 0;
            // 
            // ParsingSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gBoxAttr);
            this.Controls.Add(this.gBoxTags);
            this.Controls.Add(this.gBoxSource);
            this.Controls.Add(this.label2);
            this.Name = "ParsingSettingsForm";
            this.Text = "NewParsing";
            this.gBoxSource.ResumeLayout(false);
            this.gBoxSource.PerformLayout();
            this.gBoxTags.ResumeLayout(false);
            this.gBoxAttr.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gBoxSource;
        private System.Windows.Forms.TextBox txtbMarkup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbUrl;
        private System.Windows.Forms.GroupBox gBoxTags;
        private System.Windows.Forms.CheckedListBox chlb_Tags;
        private System.Windows.Forms.GroupBox gBoxAttr;
        private System.Windows.Forms.CheckedListBox chlbAttr;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox parserTypeCmb;
    }
}