namespace Dungeon_Creator
{
    partial class Form2
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
            this.maphtml = new System.Windows.Forms.WebBrowser();
            this.EncounterList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // maphtml
            // 
            this.maphtml.Location = new System.Drawing.Point(529, 12);
            this.maphtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.maphtml.Name = "maphtml";
            this.maphtml.Size = new System.Drawing.Size(250, 290);
            this.maphtml.TabIndex = 1;
            // 
            // EncounterList
            // 
            this.EncounterList.FormattingEnabled = true;
            this.EncounterList.Location = new System.Drawing.Point(12, 12);
            this.EncounterList.Name = "EncounterList";
            this.EncounterList.Size = new System.Drawing.Size(235, 290);
            this.EncounterList.TabIndex = 2;
            this.EncounterList.SelectedIndexChanged += new System.EventHandler(this.EncounterList_SelectedIndexChanged);
            this.EncounterList.DoubleClick += new System.EventHandler(this.Hello);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(253, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(270, 130);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Описание";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(253, 148);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(270, 154);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "Исходы";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EncounterList);
            this.Controls.Add(this.maphtml);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser maphtml;
        private System.Windows.Forms.ListBox EncounterList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}