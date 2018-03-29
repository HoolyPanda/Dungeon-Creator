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
using Microsoft.VisualBasic;
using VB= Microsoft.VisualBasic.Interaction;



namespace Dungeon_Creator
{
    public partial class Form1 : Form
    {
        public String buffer;
        Boolean flag = false;
        public String path1 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/DungeonCreator";
        DirectoryInfo dirInfo;
        String[] Locations;
        //Proba p1 = new Proba();
        String currentdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/DungeonCreator";
        History History= new History();
       


        public Form1()
        {
            InitializeComponent();

            if (Directory.Exists(path1))
            {

                Locations = Directory.GetDirectories(path1);
                MessageBox.Show("Продолжаем разговор");
                for (int i = 0; i <= Locations.Length - 1; i++)
                {
                    dirInfo = new DirectoryInfo(Locations[i]);
                    ListBox1.Items.Add(dirInfo.Name);
                }
            }
            else {
                Directory.CreateDirectory(path1);
                MessageBox.Show("Еще не создано не одной локации, начинаем работу");

            }
            History.ChooseHistory[0] = path1;
            
           
        }
        public void Main()
        {

            CreateLocation(path1);
           // NewLocSettings.ShowDialog();

        }
        void CreateLocation(string path)
        {

            path += "/" + VB.InputBox("Введите название новой локации");
            Int32 n = Locations.Length;
            Array.Resize(ref Locations, n + 1);
            Locations[Locations.Length - 1] = path;
            Directory.CreateDirectory(path);
            Int32 encounterssumm = Convert.ToInt32(VB.InputBox("Введите количество событий"));
            CreateDungeons(path, encounterssumm);

        }
        void CreateDungeons(string path, Int32 encounterssum)
        {

            String[] dungeon = new String[0];
            int n = Convert.ToInt32(VB.InputBox("Введите количество подземелий"));
            Array.Resize(ref dungeon, n);
            for (int i = 0; i <= n - 1; i++)
            {

                dungeon[i] = VB.InputBox("Введите название подземелья" + " " + (i + 1));
                Directory.CreateDirectory(path + "/" + dungeon[i]);


                for (int j = 0; j < encounterssum; j++)
                {
                    Directory.CreateDirectory(path + "/Encounters/" + (j + 1));
                }

            }




        }
        void AddSomeText(string path) {
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "<head>Это сгенерированная страница</head>");//можно и так
            }
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 NewLocSettings = new Form3();
            NewLocSettings.ShowDialog();
          //  if (NewLocSettings.CancelButton)
          
        }

        public void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //String path = currentdir;
            String selecteditm;
            if (ListBox1.SelectedIndex != -1)
            {
                selecteditm = Convert.ToString(ListBox1.Items[ListBox1.SelectedIndex]);

                if (currentdir == path1)
                {
                    currentdir += "/" + selecteditm;
                    History.ChooseHistory[1] = currentdir;
                }
                else { currentdir = currentdir + "/" + selecteditm.Replace(currentdir, "").Replace("/", "").Replace(@"\", ""); }
                History.ClickCounter += 1;
                History.ChooseHistory[History.ClickCounter] = currentdir; 
                String[] actions = Directory.GetDirectories(currentdir);

                if (actions.Length != 0)
                {
                    ListBox1.Items.Clear();

                    for (int i = 0; i <= actions.Length - 1; i++)
                    {
                        ListBox1.Items.Add(actions[i].Replace(currentdir + @"\", ""));
                    }
                   

                }
                else
                {
                    MessageBox.Show("Нет действий");
                    currentdir = History.ChooseHistory[History.ClickCounter-1];
                    History.ChooseHistory[History.ClickCounter] = "";
                    History.ClickCounter -= 1;
                }
            }


        }

        void RefreshLocations(ListBox ListBox11)
        {
            Locations = Directory.GetDirectories(path1);
            ListBox11.Items.Clear();
            for (int i = 0; i <= Locations.Length - 1; i++)
            {
                dirInfo = new DirectoryInfo(Locations[i]);
                ListBox11.Items.Add(dirInfo.Name);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(Convert.ToString(History.ClickCounter));
            if (History.ClickCounter-1 >=0)
            {
                currentdir = History.ChooseHistory[History.ClickCounter - 1];
               
                String[] actions1 = Directory.GetDirectories(currentdir);
                for (int i = 0; i < actions1.Length; i++)
                {
                   // MessageBox.Show(actions1[i]);
                }
                if (actions1.Length != 0)
                {
                    ListBox1.Items.Clear();

                    for (int i = 0; i <= actions1.Length - 1; i++)
                    {
                        ListBox1.Items.Add(actions1[i].Replace(currentdir + @"\", ""));
                    }


                }
                else
                {

                    MessageBox.Show("Нет действий");
                }
                History.ClickCounter -= 1;
            }
           
        }
    }
    

    public class History
    {
        public String[] ChooseHistory= new String[4];
        public Int32 ClickCounter;
    }

}

