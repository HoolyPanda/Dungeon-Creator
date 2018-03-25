namespace Dungeon_Creator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox0 = new System.Windows.Forms.RichTextBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.maphtml0 = new System.Windows.Forms.WebBrowser();
            this.button0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(514, 205);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(270, 154);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "Исходы";
            // 
            // richTextBox0
            // 
            this.richTextBox0.Location = new System.Drawing.Point(514, 32);
            this.richTextBox0.Name = "richTextBox0";
            this.richTextBox0.Size = new System.Drawing.Size(270, 130);
            this.richTextBox0.TabIndex = 8;
            this.richTextBox0.Text = "Описание";
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(17, 80);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(480, 290);
            this.ListBox1.TabIndex = 7;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // maphtml0
            // 
            this.maphtml0.Location = new System.Drawing.Point(534, 80);
            this.maphtml0.MinimumSize = new System.Drawing.Size(20, 20);
            this.maphtml0.Name = "maphtml0";
            this.maphtml0.Size = new System.Drawing.Size(250, 290);
            this.maphtml0.TabIndex = 6;
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(674, 397);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(75, 23);
            this.button0.TabIndex = 10;
            this.button0.Text = "button1";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBox0);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.maphtml0);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox0;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.WebBrowser maphtml0;
        private System.Windows.Forms.Button button0;
    }
}

