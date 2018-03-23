using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
//using System.
using System.Text;
using Microsoft.VisualBasic;
using VB= Microsoft.VisualBasic.Interaction;



namespace Dungeon_Creator
{

    public partial class Form1 : Form{
        public String buffer;
        Boolean flag = false;
        public Form1()
        {
            InitializeComponent();
           /// textBox1.Text = "1123";
           
            //KeyPreview = true;
            //KeyDown += new KeyEventHandler(OnKeyDownHandler);
            Main();
            
        }
       public void Main() {
            String path = @"C:\Users\Pavlo\Desktop\";
           CreateLocation(path);
            
        }
       /* private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buffer = textBox1.Text;
               //textBox1.Text = "You Entered: " + textBox1.Text;
            }
        }*/
        void CreateLocation(string path) {

            path += VB.InputBox("Введите название нового подземелья");
            Directory.CreateDirectory(path);
            CreateDungeons(path);
        }
        void CreateDungeons(string path) {
            int n =Convert.ToInt32 (VB.InputBox("Введите количество подземелий"));
            for (int i = 0; i <= n; i++) {

            }

        }
        void AddSomeText(string path){
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, textBox1.Text);
            }
        }
      
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
           
        }
    }
}
