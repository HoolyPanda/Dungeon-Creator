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
    public partial class Form1 : Form {
        public String buffer;
        Boolean flag = false;
        public String path1 = "C:/Users/Pavlo/Desktop/DungeonCreator";
        DirectoryInfo dirInfo;
        String[] Locations;

        public Form1()
        {
            InitializeComponent();

            if (Directory.Exists(@"C:\Users\Pavlo\Desktop\DungeonCreator"))
            {

                Locations = Directory.GetDirectories("C:/Users/Pavlo/Desktop/DungeonCreator");
                MessageBox.Show("Продолжаем разговор");
                for (int i = 0; i <= Locations.Length - 1; i++)
                {
                    dirInfo = new DirectoryInfo(Locations[i]);
                    ListBox1.Items.Add(dirInfo.Name);
                }
            }
            else {
                Directory.CreateDirectory(@"C:\Users\Pavlo\Desktop\DungeonCreator");
                MessageBox.Show("Еще не создано не одной локации, начинаем работу");

            }

        }
        void ListBoxRefresh(ListBox ListBox1 ,String[] Items){
            ListBox1.Items.Clear();
            for (int i = 0; i <= Items.Length-1; i++) {
                ListBox1.Items.Add( Items[i].Replace(path1,"").Replace("/", "").Replace(@"\",""));
            }

        }
        public void Main() {
           
           CreateLocation(path1);
            
        }
        void CreateLocation(string path)
        {

            path +="/"+ VB.InputBox("Введите название нового подземелья");
            int n = Locations.Length;
            Array.Resize(ref Locations,n+1); 
            Locations[Locations.Length-1] = path;
            Directory.CreateDirectory(path);
            ListBoxRefresh(ListBox1, Locations);
            //ListBox1.Refresh();
            CreateDungeons(path);
        }
        void CreateDungeons(string path) {

            String[] dungeon = new String[0];
            int n =Convert.ToInt32 (VB.InputBox("Введите количество подземелий"));
            Array.Resize(ref dungeon,n); 
            for (int i = 0; i <= n-1; i++) {

                dungeon[i] = VB.InputBox("Введите название подземелья"+" "+(i+1));
                Directory.CreateDirectory(path + "/" + dungeon[i]);
               // Form1();
            }
            
           
            for (int i = 0; i <= n - 1; i++) {
                Dungeon(path+"/"+dungeon[i]);
            }

        
        }

        void RefreshListBox(object listbox, String newpath) {

        }
        void Dungeon(String path) {
           
        }
        void AddSomeText(string path){
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
            Main();
        }

       public void ListBox1_SelectedIndexChanged(object sender, EventArgs e){
            String path = path1;
            String encounter;
            if (ListBox1.SelectedIndex !=-1) {
                encounter = Convert.ToString(ListBox1.Items[ListBox1.SelectedIndex]);
                String[] actions = Directory.GetDirectories(path1 + "/" + encounter); //"C:/Users/Pavlo/Desktop/Учеба");

                if (actions.Length != 0)
                {
                    ListBox1.Items.Clear();

                    for (int i = 0; i <= actions.Length - 1; i++)
                    {
                        ListBox1.Items.Add(actions[i]);
                    }

                }
                else
                {
                    // кусок если нет активностей
                    MessageBox.Show("Нет действий");
                }
            }
            
           
        }
    }
}
