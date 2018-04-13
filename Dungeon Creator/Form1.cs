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
        String chousenDungeon;
        Boolean rewriteAllow;
        String chousenLoc;
        String chiusenEncounter= "";
        String chousenActivity= "";
        History History= new History();
        public Form1()
        {

           
            InitializeComponent();
            //Form1.SetDesktopLocation(1, 1);

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
            NewLocSettings.SetDesktopLocation(100,100);
            NewLocSettings.ShowDialog();
            string path = path1;
            //Делаем локацию
            path += "/" + NewLocSettings.NewLocation.LocationName;
            Int32 n = Locations.Length;
            Array.Resize(ref Locations, n + 1);
            Locations[Locations.Length - 1] = path;
            Directory.CreateDirectory(path);
            
            //Делаем данж
            String[] dungeon = new String[0];
            Int32 o = NewLocSettings.Dungeon.Length; 
            Array.Resize(ref dungeon, o);
           
            for (int i = 0; i < o ; i++)
            {
                dungeon[i] = NewLocSettings.Dungeon[i].name;
                Directory.CreateDirectory(path + "/" + dungeon[i]);
                Directory.CreateDirectory(path + "/" + dungeon[i]+"/"+"Map");
                try
                {
                    //MessageBox.Show(NewLocSettings.Dungeon[i-1].imgPath);
                    File.Copy(NewLocSettings.Dungeon[i].imgPath , path + "/" + dungeon[i] + "/" + "Map" + "/"+ "img");
                    using (FileStream fs = File.Create(path + "/" + dungeon[i] + "/" + "Map" + "/" + "map.html"))
                    {
                        String s = "<body style=\"background-color:#000000;\" > <img src=\" " + "img" + "\" /></body>";
                        AddText(fs, s);
                    }
                }
                catch
                {
                }
               
                File.WriteAllText(path + "/" + dungeon[i]+  "/"+ "answer.txt",NewLocSettings.Dungeon[i].answer , Encoding.Default);
                File.WriteAllText(path + "/" + dungeon[i] +  "/" + "description.txt", NewLocSettings.Dungeon[i].description , Encoding.Default);
                File.WriteAllText(path + "/" + dungeon[i] +  "/" + "entrance.txt", NewLocSettings.Dungeon[i].entrance, Encoding.Default);
                //Делаем енкаунтеры
                for (int j = 0; j != NewLocSettings.Dungeon[i].Encounters.Length; j++)
                {
                      Directory.CreateDirectory(path + "/" + dungeon[i] + "/Encounters/" + (j+1));
                    File.WriteAllText(path + "/" + dungeon[i] + "/Encounters/" + (j + 1) + "/" +  "dis.txt", NewLocSettings.Dungeon[i].Encounters[j].dis, Encoding.Default);
                    //MessageBox.Show("Miss me?2");
                    for (int k = 0; k < 4; k++)
                    {

                        //Здесь вытаскиваем описание и последствия 
                        Directory.CreateDirectory(path + "/" + dungeon[i] + "/Encounters/" + (j + 1) + "/" + "Действие" + (k + 1));
                        try
                        {
                            if ((!NewLocSettings.Dungeon[i].Encounters[j].Actions[k].dis.Equals("")) & (!NewLocSettings.Dungeon[i].Encounters[j].Actions[k].cons.Equals("")))
                            {
                                

                                File.WriteAllText(path + "/" + dungeon[i] + "/Encounters/" + (j + 1) + "/" + "Действие" + (k + 1) + "/" + "dis.txt", NewLocSettings.Dungeon[i].Encounters[j].Actions[k].dis, Encoding.Default);
                                //MessageBox.Show("Miss me?");
                                File.WriteAllText(path + "/" + dungeon[i] + "/Encounters/" + (j + 1) + "/" + "Действие" + (k + 1) + "/" + "cons.txt", NewLocSettings.Dungeon[i].Encounters[j].Actions[k].cons, Encoding.Default);
                            }
                        }
                        catch { }
                         
                    }
                }
            }
            NewLocSettings.Dispose();
            RefreshLocations(ListBox1, path1);
        }

        public void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selecteditm;
            if (ListBox1.SelectedIndex != -1)
            {
                selecteditm = Convert.ToString(ListBox1.Items[ListBox1.SelectedIndex]);
                if ((File.Exists(currentdir + "/" + selecteditm + "/" + "dis.txt")) & (selecteditm.Contains("Действие")))
                {
                    rewriteAllow = false;
                    try
                    {
                        String act = "/" + selecteditm + "/dis.txt";
                        byte[] info = File.ReadAllBytes(currentdir + act);
                        string str = Encoding.Default.GetString(info, 0, info.Length);
                        chousenActivity = currentdir + "/" + selecteditm;
                        richTextBox4.Text = str;
                    }
                    finally
                    {
                        label6.Text = "Описание действия";
                    }

                    try
                    {
                        String act = "/" + selecteditm + "/cons.txt";
                        byte[] info = File.ReadAllBytes(currentdir + act);
                        string str = Encoding.Default.GetString(info, 0, info.Length);

                        richTextBox5.Text = str;

                    }
                    finally
                    {
                        label7.Text = "Последствия выбора действия";
                    }
                    currentdir += "/" + selecteditm;
                    //History.ChooseHistory[5] = currentdir;
                    //MessageBox.Show(currentdir);
                    rewriteAllow = true;
                    getStep();

                }
                else if ((File.Exists(currentdir + "/" + selecteditm + "/" + "dis.txt")) & (currentdir.Contains("Encounters")))
                {
                    rewriteAllow = false;
                    try
                    {
                        String act = "/" + selecteditm + "/dis.txt";
                        byte[] info = File.ReadAllBytes(currentdir + act);
                        string str = Encoding.Default.GetString(info, 0, info.Length);
                        richTextBox3.Text = str;
                        chiusenEncounter = currentdir + act;
                    }
                    finally
                    {
                        label5.Text = "Описание енкаунтера номер  " + selecteditm;
                    }

                    currentdir += "/" + selecteditm;
                    rewriteAllow = true;

                    getStep();
                }
                else if (File.Exists(currentdir + "/" + selecteditm + "/" + "answer.txt") || File.Exists(currentdir + "/" + selecteditm + "/" + "description.txt") || File.Exists(currentdir + "/" + selecteditm + "/" + "entrance.txt"))
                {
                    rewriteAllow = false;
                    chousenDungeon = currentdir + "/" + selecteditm;

                    try
                    {
                        String act = "/" + selecteditm + "/answer.txt";

                        byte[] info = File.ReadAllBytes(currentdir + act);
                        string str = Encoding.Default.GetString(info, 0, info.Length);
                        richTextBox2.Text = str;
                    }
                    finally
                    {
                        label3.Text = "Ответ";
                    }
                    try
                    {
                        String act = "/" + selecteditm + "/description.txt";
                        // String pathTodescription = act;

                        byte[] info = File.ReadAllBytes(currentdir + act);

                        string str = Encoding.Default.GetString(info, 0, info.Length);
                        richTextBox0.Text = str;
                    }
                    finally
                    {
                        label2.Text = "Описание";
                    }
                    try
                    {
                        String act = "/" + selecteditm + "/entrance.txt";

                        byte[] info = File.ReadAllBytes(currentdir + act);
                        string str = Encoding.Default.GetString(info, 0, info.Length);
                        richTextBox1.Text = str;
                    }
                    finally
                    {
                        label4.Text = "Условие входа";
                    }

                   // MessageBox.Show(History.ChooseHistory[1] +"/"+selecteditm+ "/Map/" + "map.html");
                    //MessageBox.Show(History.ChooseHistory[1] + "/Map/" + "map.html");
                    webBrowser1.Url = new Uri(History.ChooseHistory[1] + "/" + selecteditm +"/Map/" + "map.html");
                   
                    if (!webBrowser1.DocumentText.Equals("<body style=\"background-color:#000000;\" > <img src=\" " + "img" + "\" /></body>"))
                    {
                        button1.Text = "Добавить карту";
                    }



                    currentdir += "/" + selecteditm;
                    rewriteAllow = true;
                    getStep();
                }
                else if (currentdir == path1)
                {
                        currentdir += "/" + selecteditm;
                        History.ChooseHistory[1] = currentdir;
                        getStep();
                }
                else
                {
                    currentdir = currentdir + "/" + selecteditm.Replace(currentdir, "").Replace("/", "").Replace(@"\", "");
                    getStep();
                }
                
            }
        }

        private void RefreshLocations(ListBox ListBox11, String path1)
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

                    //MessageBox.Show("Нет действий");
                }
                History.ClickCounter -= 1;
            }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (rewriteAllow)
            {
                File.WriteAllText(chiusenEncounter.Replace("dis.txt", "") + "dis.txt", richTextBox3.Text, Encoding.Default);
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(chousenDungeon + "/" + "answer.txt", richTextBox2.Text, Encoding.Default);
            
        }
        public void getStep()
        {
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
               // MessageBox.Show("Нет действий");
                currentdir = History.ChooseHistory[History.ClickCounter - 1];
                History.ChooseHistory[History.ClickCounter] = "";
                History.ClickCounter -= 1;
            }
        }

        private void richTextBox0_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(chousenDungeon + "/" + "description.txt", richTextBox0.Text, Encoding.Default);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           File.WriteAllText(chousenDungeon + "/" + "entrance.txt", richTextBox1.Text, Encoding.Default);
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            //  MessageBox.Show(History.ChooseHistory[4]+"--"+ History.ChooseHistory[5]+"--"+ History.ChooseHistory[6]);
            try
            {
                File.WriteAllText(History.ChooseHistory[4] + "/Действие " + (ListBox1.SelectedIndex + 1) + "/dis.txt", richTextBox4.Text, Encoding.Default);
            }
            catch { }
         
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(chousenActivity);
            try
            {
                File.WriteAllText(History.ChooseHistory[4] + "/Действие " + (ListBox1.SelectedIndex + 1) + "/cons.txt", richTextBox5.Text, Encoding.Default);
                
            }
            catch
            {
                //MessageBox.Show("error");
            }
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //сделать создание файлов 
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                FileInfo fs = new FileInfo(FD.FileName);
                try
                {
                    File.Delete(chousenDungeon + "/Map/img");
                    File.Copy(FD.FileName, chousenDungeon + "/Map/img");
                    webBrowser1.Refresh();
                    String a= webBrowser1.DocumentText;
                    if (webBrowser1.DocumentText.Equals("<body style=\"background-color:#000000;\" > <img src=\" " + "img" + "\" /></body>"))
                    {
                        
                    }
                    else
                    {
                        File.WriteAllText(chousenDungeon + "/Map/map.html", "<body style=\"background-color:#000000;\" > <img src=\" " + "img" + "\" /></body>", Encoding.Default);
                        webBrowser1.Refresh();
                    }
                }
                catch
                {
                    
                }

                // MessageBox.Show(fs.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //новый данж
            try
            {
            DirectoryInfo dirinf = new DirectoryInfo(History.ChooseHistory[1]);
            //dirinf.Name;
            String chousenLocation= History.ChooseHistory[1];
            String newDung = VB.InputBox("Имя нового Данжа");
            Directory.CreateDirectory(chousenLocation + "/" +newDung+"/Encounters/1");
            for (int i = 0;i < 4;i++)
            {
                Directory.CreateDirectory(chousenLocation + "/" +newDung + "/Encounters/1/"+"Действие "+(i + 1));
               // File.WriteAllText(chousenLocation + "/" + newDung + "/" + "entrance.txt", "Новое описание", Encoding.Default);
            }
                Directory.CreateDirectory(chousenLocation + "/" + newDung + "/Map");
                File.WriteAllText(chousenLocation + "/" + newDung + "/Encounters/1/dis.txt", "Новое описание енкаунтера", Encoding.Default);
                File.WriteAllText(chousenLocation + "/" + newDung + "/Map/map.html","<body style =\"background-color:#000000;\" > <img src=\" " + "img" + "\" /></body>", Encoding.Default );
                File.WriteAllText(chousenLocation + "/" + newDung + "/" + "answer.txt", "Новый ответ", Encoding.Default);
                File.WriteAllText(chousenLocation + "/" + newDung + "/" + "description.txt", "Новое описание", Encoding.Default);
                File.WriteAllText(chousenLocation + "/" + newDung + "/" + "entrance.txt", "Новое условие входа", Encoding.Default);
                currentdir = History.ChooseHistory[1];
                History.ClickCounter = 1;
                RefreshLocations(ListBox1, History.ChooseHistory[1]);
            }
            catch
            {
                MessageBox.Show("Чтобы создать ноый данж, выберите локацию, в которой он должен находиться");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Новый енкаунтер
            try
            {
            DirectoryInfo dirinf = new DirectoryInfo(History.ChooseHistory[2]+"/Encounters");
            DirectoryInfo[] dirsarray = dirinf.GetDirectories();
            int encsumm = dirsarray.Length; 
            Directory.CreateDirectory(History.ChooseHistory[2] + "/Encounters/" + (encsumm + 1));
            File.WriteAllText(History.ChooseHistory[2] + "/Encounters/" + (encsumm+1) +"/dis.txt", "Новое описание енкаунтера", Encoding.Default);
            for (int i = 0; i < 4; i++)
            {
                Directory.CreateDirectory(History.ChooseHistory[2] + "/Encounters/" + (encsumm+1) + "/Действие " + (i + 1));
            }
                currentdir = History.ChooseHistory[2] + "/Encounters";
                History.ClickCounter = 3;
                RefreshLocations(ListBox1, History.ChooseHistory[2] + "/Encounters");
            }
            catch
            {
                MessageBox.Show("Чтобы добавить новый енкаунтер, вы должны выбрать данж, в котором он будет находиться");
            }
        }
    }
    public class History
    {
        public String[] ChooseHistory= new String[9];
        public Int32 ClickCounter;
    }
    
}
