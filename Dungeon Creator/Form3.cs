using System;
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
       // public  Location..Encounter[] Encounter = new Location.Encounter[1];
        public Location.Dungeon[] Dungeon = new Location.Dungeon[0];
        Boolean enc = true;
        Boolean isActions = false;
        string path;
        int dungeonSave = 0;
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
            if (listBox1.SelectedIndex!=-1)
            {
               

                int i = Dungeon[listBox1.SelectedIndex].Encounters.Length;
               
                Array.Resize(ref Dungeon[listBox1.SelectedIndex].Encounters, i+=1);
               //MessageBox.Show(Convert.ToString(i));
                i--;// было 0 стало 1 спросить
                //MessageBox.Show(Dungeon[listBox1.SelectedIndex].name);

                Dungeon[listBox1.SelectedIndex].Encounters[i].name = Convert.ToString(i+1);
                Dungeon[listBox1.SelectedIndex].Encounters[i].Actions = new Location.Dungeon.Encounter.Action[4]; 
                listBox2.Items.Add(Dungeon[listBox1.SelectedIndex].Encounters[i].name);
               
                Array.Resize(ref Dungeon[listBox1.SelectedIndex ].Encounters[i].Actions, 4);

                for (int j = 0; j < Dungeon[listBox1.SelectedIndex].Encounters[i].Actions.Length; j++)
                {
                    Dungeon[listBox1.SelectedIndex].Encounters[i].Actions[j].name = "Действие" + " " + (j + 1);
                }
            }
        }
        public void list1DoubleClick(object sender, EventArgs e)
        {
            int j = Dungeon.Length;
            j++;
            Array.Resize(ref Dungeon, j);
            Dungeon[j-1].name = VB.InputBox("Name");
            Dungeon[j-1].Encounters = new Location.Dungeon.Encounter[0];

            listBox1.Items.Add(Dungeon[j-1].name);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) {
                if (listBox2.SelectedIndex != -1){ listBox2.SetSelected(listBox2.SelectedIndex, false);}
                label5.Text = "Енкаунтеры";
                enc = true;
                listBox2.Items.Clear();
                dungeonSave = listBox1.SelectedIndex;
                if (Dungeon[listBox1.SelectedIndex].Encounters.Length != 0)
                {
                    for (int i = 0; i <= Dungeon[listBox1.SelectedIndex].Encounters.Length - 1; i++)
                    {
                        listBox2.Items.Add(Dungeon[dungeonSave].Encounters[i].name);
                    }
                }
                label7.Text = "Описание";
                richTextBox2.Text = Dungeon[dungeonSave].description;
                label8.Text = "Условие Входа";
                richTextBox0.Text = Dungeon[dungeonSave].entrance;
                label9.Text = "Ответ";
                richTextBox1.Text = Dungeon[dungeonSave].answer;
            }
            
        }
        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int save = 0;
            
            if (enc)
            {

                if (listBox2.SelectedIndex != -1)
                {
                    
                    label5.Text = "Действия";
                    if (listBox1.SelectedIndex != -1)
                    {
                        //dungeonSave = listBox1.SelectedIndex;
                        listBox1.SetSelected(listBox1.SelectedIndex, false);
                    }

                   
                    //MessageBox.Show(Convert.ToString(listBox1.SelectedIndex));
                    save = listBox2.SelectedIndex;
                    listBox2.Items.Clear();
                    
                    for (int i = 0; i < 4; i++)
                    {
                        listBox2.Items.Add(Dungeon[dungeonSave].Encounters[save].Actions[i].name);
                    }
                    enc = false;
                   
                }
            }
            else
            {
               // MessageBox.Show("1234");
                if (listBox2.SelectedIndex != -1)
                {
                    
                    if (listBox1.SelectedIndex != -1)
                    {
                       // dungeonSave = listBox1.SelectedIndex;
                        listBox1.SetSelected(listBox1.SelectedIndex, false);
                        richTextBox1.Text = "";
                    }
                    chousenenc = save;
                    chousenaaction = listBox2.SelectedIndex; label7.Text = "Описание";
                    richTextBox2.Text = Dungeon[dungeonSave].Encounters[save].Actions[listBox2.SelectedIndex].dis;
                    label8.Text = "Последствия";
                    richTextBox0.Text = Dungeon[dungeonSave].Encounters[save].Actions[listBox2.SelectedIndex].cons;
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
            if (listBox1.SelectedIndex != -1)
            {
                OpenFileDialog FD = new OpenFileDialog();
                if (FD.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fs = new FileInfo(FD.FileName);
                    Dungeon[listBox1.SelectedIndex].imgPath = FD.FileName;
                    Dungeon[listBox1.SelectedIndex].imgName = fs.Name;
                    MessageBox.Show(fs.Name);
                }
                MessageBox.Show(Dungeon[listBox1.SelectedIndex].imgPath);
            }
            else
            {
                MessageBox.Show("Выберите данж для создания файла карты");
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            String save = richTextBox2.Text;
            if ((listBox1.SelectedIndex != -1)&(save != ""))
            {
                Dungeon[listBox1.SelectedIndex].description = richTextBox2.Text;
            }
            else
            {
                Dungeon[dungeonSave].Encounters[chousenenc].Actions[chousenaaction].dis = richTextBox2.Text;// пофиксить
            }
        }
        private void richTextBox0_TextChanged(object sender, EventArgs e)
        {
            String save = richTextBox0.Text;
            if ((listBox1.SelectedIndex != -1) &(save != ""))
            {
                Dungeon[listBox1.SelectedIndex].entrance = richTextBox0.Text;
            }
            else
            {
                Dungeon[dungeonSave].Encounters[chousenenc].Actions[chousenaaction].cons = richTextBox0.Text; //защитить
            }
        }
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Dungeon[listBox1.SelectedIndex].answer = richTextBox1.Text;
            }
           // enc=true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NewLocation.LocationName = textBox1.Text;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            for (int i = 0; i <= Dungeon[ dungeonSave ].Encounters.Length - 1; i++)
            {
                listBox2.Items.Add(Dungeon[dungeonSave].Encounters[i].name);
            }
            label5.Text = "Енкаунтеры";
            enc = true;
        }
    }

    //Классы-----------------------------------------------------
    public class Location
    {
        public String LocationName;
        public String[] Dungeons;
       
        public struct Dungeon
        {
            public string name;
            public string answer;
            public string description;
            public string entrance;
            public String imgPath;
            public String imgName;
            public Encounter[] Encounters;

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
}
