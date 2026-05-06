namespace SDAWorshipDraft
{
    partial class AboutForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(188, 21);
            label1.TabIndex = 0;
            label1.Text = "SDA Worship Constructor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "Версия:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 152);
            label3.Name = "label3";
            label3.Size = new Size(260, 15);
            label3.TabIndex = 2;
            label3.Text = "© 2025 Меленко Родион (github: impossiburu)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 91);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Лицензия:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 30);
            label5.Name = "label5";
            label5.Size = new Size(197, 15);
            label5.TabIndex = 5;
            label5.Text = "Конструктор плана богослужений";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 73);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 6;
            label6.Text = "Издание:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(81, 56);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 7;
            label7.Text = "1.2.0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(81, 74);
            label8.Name = "label8";
            label8.Size = new Size(232, 15);
            label8.TabIndex = 8;
            label8.Text = "Community (бесплатно для сообщества)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(81, 91);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 9;
            label9.Text = "MIT";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 176);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AboutForm";
            Text = "О программе";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}