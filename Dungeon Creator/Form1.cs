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
        public void button1_Click_1(object sender, EventArgs e)
        {
            Form3 NewLocSettings = new Form3();
            NewLocSettings.ShowDialog();
            string path = path1;
            //Делаем локацию
            path += "/" + NewLocSettings.NewLocation.LocationName;
            Int32 n = Locations.Length;
            Array.Resize(ref Locations, n + 1);
            Locations[Locations.Length - 1] = path;
            Directory.CreateDirectory(path);
            try
            {
                File.Copy(NewLocSettings.NewLocation.imgPath, path + "/" + NewLocSettings.NewLocation.imgName);
                using (FileStream fs = File.Create(path + "/" + "map.html"))
                {
                    String s = "<body style=\"background-color:#000000;\" > <img src=\" " + (NewLocSettings.NewLocation.imgName) + "\" /></body>";
                    AddText(fs, s.Replace('!', '"'));
                }
            }
            catch
            {
            }
            Int32 encounterssumm = NewLocSettings.Encounter.Length;
            
            //Делаем данж
            String[] dungeon = new String[0];
            Int32 o = NewLocSettings.Dungeon.Length; 
            Array.Resize(ref dungeon, o);
           
            for (int i = 1; i < o ; i++)
            {
                dungeon[i] = NewLocSettings.Dungeon[i].name;
                Directory.CreateDirectory(path + "/" + dungeon[i]); 
                File.WriteAllText(path + "/" + dungeon[i]+  "/"+ "answer.txt",NewLocSettings.Dungeon[i-1].answer , Encoding.Default);
                File.WriteAllText(path + "/" + dungeon[i] +  "/" + "description.txt", NewLocSettings.Dungeon[i-1].description , Encoding.Default);
                File.WriteAllText(path + "/" + dungeon[i] +  "/" + "entrance.txt", NewLocSettings.Dungeon[i-1].entrance, Encoding.Default);
                //Делаем енкаунтеры
                for (int j = 1; j != encounterssumm; j++)
                  {
                      Directory.CreateDirectory(path + "/Encounters/" + (j));
                      for (int k = 0; k < 4; k++)
                      {
                          Directory.CreateDirectory(path + "/Encounters/" + (j) + "/" + "Действие" + (k + 1));
                          //Здесь вытаскиваем описание и последствия 
                          File.WriteAllText(path + "/Encounters/" + (j) + "/" + "Действие" + (k + 1) + "/" + "dis.txt", NewLocSettings.Encounter[j - 1].Actions[k].dis, Encoding.Default );
                          File.WriteAllText(path + "/Encounters/" + (j) + "/" + "Действие" + (k + 1) + "/" + "cons.txt", NewLocSettings.Encounter[j - 1].Actions[k].cons, Encoding.Default );
                       }
                  }
            }
            NewLocSettings.Dispose();
            RefreshLocations(ListBox1);
        }

        public void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            String selecteditm;
            if (ListBox1.SelectedIndex != -1)
            {
                selecteditm = Convert.ToString(ListBox1.Items[ListBox1.SelectedIndex]);
                if (selecteditm.Contains("Действие"))
                {
                    label2.Text = "Описание";
                    label3.Text = "Последствия";
                    String act = "/" + selecteditm + "/dis.txt";
                    using (StreamReader fs = File.OpenText(currentdir + act))
                    {
                        string a = fs.ReadToEnd();
                        richTextBox0.Text = a;
                    }

                    act = "/" + selecteditm + "/cons.txt";
                    using (StreamReader fs = File.OpenText(currentdir + act))
                    {
                        string a = fs.ReadToEnd();
                        richTextBox2.Text = a;
                    }
                }
                else if (File.Exists(currentdir+"/"+selecteditm+"/"+"answer.txt")|| File.Exists(currentdir + "/" + selecteditm + "/" + "description.txt") || File.Exists(currentdir + "/" + selecteditm + "/" + "entrance.txt"))
                {
                    try
                    {
                        String act = "/" + selecteditm + "/answer.txt";
                        using (StreamReader fs = File.OpenText(currentdir + act))
                        {
                            string a = fs.ReadToEnd();
                            richTextBox2.Text = a;
                        }
                    }
                    finally
                    {
                        label3.Text = "Ответ";
                    }
                    try
                    {
                        String act = "/" + selecteditm + "/description.txt";
                        using (StreamReader fs = File.OpenText(currentdir + act))
                        {
                            string a = fs.ReadToEnd();
                            richTextBox0.Text = a;
                        }
                    }
                    finally
                    {
                        label2.Text = "Описание";
                    }
                    try
                    {
                        label4.Text = "Условие входа";
                    }
                    finally
                    {
                        String act = "/" + selecteditm + "/entrance.txt";
                        using (StreamReader fs = File.OpenText(currentdir + act))
                        {
                            string a = fs.ReadToEnd();
                            richTextBox1.Text = a;
                        }
                    }
                }
                else
                {
                    if (currentdir == path1)
                    {
                        currentdir += "/" + selecteditm;
                        History.ChooseHistory[1] = currentdir;
                    }
                    else { currentdir = currentdir + "/" + selecteditm.Replace(currentdir, "").Replace("/", "").Replace(@"\", ""); }

                  // MessageBox.Show(currentdir);

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
                        currentdir = History.ChooseHistory[History.ClickCounter - 1];
                        History.ChooseHistory[History.ClickCounter] = "";
                        History.ClickCounter -= 1;
                    }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }


    public class History
    {
        public String[] ChooseHistory= new String[4];
        public Int32 ClickCounter;
    }
}