namespace HtmlParser
{
    partial class HtmlParser
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
            this.Console = new System.Windows.Forms.ListBox();
            this.ParsingResult = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.parcingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Responses = new System.Windows.Forms.DataGridView();
            this.Parsings = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingResult)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Responses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parsings)).BeginInit();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.FormattingEnabled = true;
            this.Console.Location = new System.Drawing.Point(12, 387);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(554, 82);
            this.Console.TabIndex = 0;
            // 
            // ParsingResult
            // 
            this.ParsingResult.AllowUserToOrderColumns = true;
            this.ParsingResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsingResult.Location = new System.Drawing.Point(12, 139);
            this.ParsingResult.Name = "ParsingResult";
            this.ParsingResult.RowTemplate.ReadOnly = true;
            this.ParsingResult.Size = new System.Drawing.Size(554, 244);
            this.ParsingResult.TabIndex = 2;
            this.ParsingResult.DataSourceChanged += new System.EventHandler(this.ParsingResult_DataSourceChanged);
            this.ParsingResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParsingResult_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parcingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // parcingToolStripMenuItem
            // 
            this.parcingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.parcingToolStripMenuItem.Name = "parcingToolStripMenuItem";
            this.parcingToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.parcingToolStripMenuItem.Text = "Parcing";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Read";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // Responses
            // 
            this.Responses.AllowUserToOrderColumns = true;
            this.Responses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Responses.Location = new System.Drawing.Point(571, 139);
            this.Responses.Name = "Responses";
            this.Responses.RowTemplate.ReadOnly = true;
            this.Responses.Size = new System.Drawing.Size(324, 163);
            this.Responses.TabIndex = 4;
            this.Responses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Responses_CellClick);
            // 
            // Parsings
            // 
            this.Parsings.AllowUserToOrderColumns = true;
            this.Parsings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Parsings.Location = new System.Drawing.Point(571, 27);
            this.Parsings.Name = "Parsings";
            this.Parsings.RowTemplate.ReadOnly = true;
            this.Parsings.Size = new System.Drawing.Size(323, 106);
            this.Parsings.TabIndex = 5;
            this.Parsings.DataSourceChanged += new System.EventHandler(this.Parsings_DataSourceChanged);
            this.Parsings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Parsings_CellClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(572, 308);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(323, 161);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(12, 27);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(553, 106);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(320, 61);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.Gray;
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBar1.ProgressWidth = 25;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(304, 320);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 8;
            this.circularProgressBar1.Text = "Please Wait";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 68;
            this.circularProgressBar1.Visible = false;
            // 
            // HtmlParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 474);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Parsings);
            this.Controls.Add(this.Responses);
            this.Controls.Add(this.ParsingResult);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "HtmlParser";
            this.Text = "Html parser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HtmlParser_FormClosed);
            this.Shown += new System.EventHandler(this.HtmlParser_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ParsingResult)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Responses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parsings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.DataGridView ParsingResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parcingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.DataGridView Responses;
        private System.Windows.Forms.DataGridView Parsings;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
    }
}

