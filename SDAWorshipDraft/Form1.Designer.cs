namespace SDAWorshipDraft
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            LoadFromFileMenuItem = new ToolStripMenuItem();
            LoadFromWebMenuItem = new ToolStripMenuItem();
            AboutMenuItem = new ToolStripMenuItem();
            tabStates = new TabControl();
            tabPageEditor = new TabPage();
            ResetBtn = new Button();
            AddFieldBtn = new Button();
            FieldTypesList = new ComboBox();
            SaveToFileBtn = new Button();
            panel1 = new Panel();
            tabPagePreview = new TabPage();
            panel2 = new Panel();
            PrintBtn = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            menuStrip1.SuspendLayout();
            tabStates.SuspendLayout();
            tabPageEditor.SuspendLayout();
            tabPagePreview.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, AboutMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(747, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { LoadFromFileMenuItem, LoadFromWebMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(97, 20);
            toolStripMenuItem1.Text = "Загрузить из...";
            // 
            // LoadFromFileMenuItem
            // 
            LoadFromFileMenuItem.Name = "LoadFromFileMenuItem";
            LoadFromFileMenuItem.Size = new Size(109, 22);
            LoadFromFileMenuItem.Text = "Файла";
            LoadFromFileMenuItem.Click += LoadFromFileMenuItem_Click;
            // 
            // LoadFromWebMenuItem
            // 
            LoadFromWebMenuItem.Name = "LoadFromWebMenuItem";
            LoadFromWebMenuItem.Size = new Size(109, 22);
            LoadFromWebMenuItem.Text = "Сеть";
            LoadFromWebMenuItem.Click += LoadFromWebMenuItem_Click;
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new Size(94, 20);
            AboutMenuItem.Text = "О программе";
            AboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // tabStates
            // 
            tabStates.Controls.Add(tabPageEditor);
            tabStates.Controls.Add(tabPagePreview);
            tabStates.Location = new Point(12, 27);
            tabStates.Name = "tabStates";
            tabStates.SelectedIndex = 0;
            tabStates.Size = new Size(723, 617);
            tabStates.TabIndex = 1;
            tabStates.SelectedIndexChanged += tabStates_SelectedIndexChanged;
            // 
            // tabPageEditor
            // 
            tabPageEditor.Controls.Add(ResetBtn);
            tabPageEditor.Controls.Add(AddFieldBtn);
            tabPageEditor.Controls.Add(FieldTypesList);
            tabPageEditor.Controls.Add(SaveToFileBtn);
            tabPageEditor.Controls.Add(panel1);
            tabPageEditor.Location = new Point(4, 24);
            tabPageEditor.Name = "tabPageEditor";
            tabPageEditor.Padding = new Padding(3);
            tabPageEditor.Size = new Size(715, 589);
            tabPageEditor.TabIndex = 0;
            tabPageEditor.Text = "Редактор";
            tabPageEditor.UseVisualStyleBackColor = true;
            // 
            // ResetBtn
            // 
            ResetBtn.Location = new Point(96, 16);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(75, 23);
            ResetBtn.TabIndex = 5;
            ResetBtn.Text = "Сбросить";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // AddFieldBtn
            // 
            AddFieldBtn.Location = new Point(634, 16);
            AddFieldBtn.Name = "AddFieldBtn";
            AddFieldBtn.Size = new Size(75, 23);
            AddFieldBtn.TabIndex = 4;
            AddFieldBtn.Text = "Добавить";
            AddFieldBtn.UseVisualStyleBackColor = true;
            AddFieldBtn.Click += AddFieldBtn_Click;
            // 
            // FieldTypesList
            // 
            FieldTypesList.FormattingEnabled = true;
            FieldTypesList.Location = new Point(380, 16);
            FieldTypesList.Name = "FieldTypesList";
            FieldTypesList.Size = new Size(245, 23);
            FieldTypesList.TabIndex = 3;
            // 
            // SaveToFileBtn
            // 
            SaveToFileBtn.Location = new Point(6, 16);
            SaveToFileBtn.Name = "SaveToFileBtn";
            SaveToFileBtn.Size = new Size(75, 23);
            SaveToFileBtn.TabIndex = 1;
            SaveToFileBtn.Text = "Сохранить";
            SaveToFileBtn.UseVisualStyleBackColor = true;
            SaveToFileBtn.Click += SaveToFileBtn_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(6, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 529);
            panel1.TabIndex = 0;
            // 
            // tabPagePreview
            // 
            tabPagePreview.Controls.Add(panel2);
            tabPagePreview.Controls.Add(PrintBtn);
            tabPagePreview.Location = new Point(4, 24);
            tabPagePreview.Name = "tabPagePreview";
            tabPagePreview.Padding = new Padding(3);
            tabPagePreview.Size = new Size(715, 589);
            tabPagePreview.TabIndex = 1;
            tabPagePreview.Text = "Предпросмотр";
            tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Location = new Point(7, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(702, 536);
            panel2.TabIndex = 1;
            // 
            // PrintBtn
            // 
            PrintBtn.Location = new Point(6, 16);
            PrintBtn.Name = "PrintBtn";
            PrintBtn.Size = new Size(75, 23);
            PrintBtn.TabIndex = 0;
            PrintBtn.Text = "Печать";
            PrintBtn.UseVisualStyleBackColor = true;
            PrintBtn.Click += PrintBtn_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 656);
            Controls.Add(tabStates);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "SDA Worship Constructor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabStates.ResumeLayout(false);
            tabPageEditor.ResumeLayout(false);
            tabPagePreview.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem LoadFromFileMenuItem;
        private ToolStripMenuItem LoadFromWebMenuItem;
        private ToolStripMenuItem AboutMenuItem;
        private TabControl tabStates;
        private TabPage tabPageEditor;
        private TabPage tabPagePreview;
        private Panel panel1;
        private Button PrintBtn;
        private ComboBox FieldTypesList;
        private Button SaveToFileBtn;
        private Button AddFieldBtn;
        private Button ResetBtn;
        private Panel panel2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
    }
}
