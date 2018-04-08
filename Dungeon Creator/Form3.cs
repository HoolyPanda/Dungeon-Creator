﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VB = Microsoft.VisualBasic.Interaction;

namespace Dungeon_Creator
{

    public partial class Form3 : Form
    {
        public Location NewLocation = new Location();
        public  Location.Encounter[] Encounter = new Location.Encounter[1];
        public Location.Dungeon[] Dungeon = new Location.Dungeon[1];
        Boolean enc = true;
        Boolean isActions = false;
        string path;
        int chousenenc;
        int chousenaaction;
        int chousendungeon;
        public Form3()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        public void listBoxDoubleClick(object sender, EventArgs e)
        {
            int i = Encounter.Length;
            Encounter[i-1].name = Convert.ToString(i);
            Encounter[i-1].Actions = new Location.Encounter.Action[4];
            listBox2.Items.Add(Encounter[i-1].name);
            i++;
            Array.Resize(ref Encounter, i);
            Array.Resize(ref Encounter[i - 1].Actions, 4);
            for (int j = 0; j < Encounter[i - 1].Actions.Length; j++)
            {
                Encounter[i - 1].Actions[j].name = "Действие"+ " " + (j + 1);
            }
        }
        public void list1DoubleClick(object sender, EventArgs e)
        {
            int j = Dungeon.Length;
            j++;
            Array.Resize(ref Dungeon, j);
            Dungeon[j- 1].name = VB.InputBox("Name");
            listBox1.Items.Add(Dungeon[j-1].name);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) {
                if (listBox2.SelectedIndex != -1){ listBox2.SetSelected(listBox2.SelectedIndex, false);}
                label7.Text = "Описание";
                richTextBox2.Text = Dungeon[listBox1.SelectedIndex].description;
                label8.Text = "Условие Входа";
                richTextBox0.Text = Dungeon[listBox1.SelectedIndex].entrance;
                label9.Text = "Ответ";
                richTextBox1.Text = Dungeon[listBox1.SelectedIndex].answer;
            }
            
        }
        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int save = 0;
            if (enc == true)
            {
                if (listBox2.SelectedIndex != -1)
                {
                    if (listBox1.SelectedIndex != -1)
                    {
                        listBox1.SetSelected(listBox1.SelectedIndex, false);
                    }
                    save = listBox2.SelectedIndex + 1;
                    listBox2.Items.Clear();
                    for (int i = 0; i != 4; i++)
                    {
                        listBox2.Items.Add(Encounter[save].Actions[i].name);
                    }
                    enc = false;
                    isActions = true;
                }
            }
            else
            {
                if (listBox2.SelectedIndex != -1)
                {
                    if (listBox1.SelectedIndex != -1) { listBox1.SetSelected(listBox1.SelectedIndex, false); richTextBox1.Text = ""; }
                    chousenenc = save;
                    chousenaaction = listBox2.SelectedIndex; label7.Text = "Описание";
                    richTextBox2.Text = Encounter[save].Actions[listBox2.SelectedIndex].dis;
                    label8.Text = "Последствия";
                    richTextBox0.Text = Encounter[save].Actions[listBox2.SelectedIndex].cons;
                }
                
            }
        }
        void AddSomeText(string path)
        {
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "<head>Это сгенерированная страница</head>");
            }
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD= new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                
            }
            path = FD.FileName;
            MessageBox.Show(path);
            using (StreamReader test = new StreamReader(path))
            {
                string a = test.ReadToEnd();
                richTextBox1.Text = a;
                test.Close();
                test.Dispose();
            }
         }
        void richTextBox0DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {

            }
            path = FD.FileName;
            byte[] info = File.ReadAllBytes(path);
            string str = Encoding.Default.GetString(info, 0, info.Length);
            richTextBox0.Text = str;
        }
        void richTextBox2DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {

            }
            path = FD.FileName;
            byte[] info = File.ReadAllBytes(path);
            string str = Encoding.Default.GetString(info, 0, info.Length);
            richTextBox2.Text = str;
        }
        void richTextBox1DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {

            }
            path = FD.FileName;
            byte[] info = File.ReadAllBytes(path);
            string str = Encoding.Default.GetString(info, 0, info.Length);
            richTextBox1.Text = str;
        } 
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {

            }
            
            FileInfo  fs = new FileInfo(FD.FileName);
            NewLocation.imgPath = FD.FileName;
            NewLocation.imgName = fs.Name;
            MessageBox.Show(fs.Name);
            MessageBox.Show(NewLocation.imgPath);
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Dungeon[listBox1.SelectedIndex].description = richTextBox2.Text;
            }
            else
            {
                Encounter[chousenenc].Actions[chousenaaction].dis = richTextBox2.Text;
            }
        }

        private void richTextBox0_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Dungeon[listBox1.SelectedIndex].entrance = richTextBox0.Text;
            }
            else
            {
               Encounter[chousenenc].Actions[chousenaaction].cons = richTextBox0.Text;//защитить
            }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Dungeon[listBox1.SelectedIndex].answer = richTextBox1.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NewLocation.LocationName = textBox1.Text;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }

    //Классы-----------------------------------------------------
    public class Location
    {
        public String LocationName;
        public String[] Dungeons;
        public String imgPath;
        public String imgName;
        public struct Dungeon
        {
            public string name;
            public string answer;
            public string description;
            public string entrance;
        }
        public struct Encounter
        {
            public string name;
            public string couns;
            public string counsPath;
            public string dis;
            public string disPath;
            public Action[] Actions;
          
            public struct Action
            {
                public String name;
                public String cons;
                public String dis;
            }
        }
    }
}
