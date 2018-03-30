using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VB = Microsoft.VisualBasic.Interaction;

namespace Dungeon_Creator
{

    public partial class Form3 : Form
    {

        void doDatShiet(Int32 left, Int32 right)
        {
            for (int i = left; i != right - 1; i++)
            {
                for (int j = left + 1; j != right; j++)
                {
                    Console.WriteLine(i * i + j * j);
                }

            }
        }
        public Location NewLocation = new Location();
        Location.Encounter[] Encounter = new Location.Encounter[1];
        Location.Dungeon[] Dungeon = new Location.Dungeon[1];
        Boolean enc = true;
       // Location.Encounter.Action[] Actions = new Location.Encounter.Action[4];
        public Form3()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        public void listBoxDoubleClick(object sender, EventArgs e)
        {
            int i = Encounter.Length;
            MessageBox.Show(Convert.ToString(i-1));
            Encounter[i-1].name = Convert.ToString(i);//VB.InputBox("Name");
            Encounter[i-1].Actions = new Location.Encounter.Action[4];
            listBox2.Items.Add(Encounter[i-1].name);
            i++;
            Array.Resize(ref Encounter, i);
            Array.Resize(ref Encounter[i - 1].Actions, 4);
            Array.Resize(ref Encounter, i);

            for (int j = 0; j < Encounter[i - 1].Actions.Length; j++)
            {
                Encounter[i - 1].Actions[j].name = "Действие"+( i - 1 )+ " " + (j + 1);
                //MessageBox.Show(Encounter[1].Actions[0].name);

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
                MessageBox.Show(Convert.ToString(listBox1.SelectedIndex));
                label7.Text = "Описание";
                richTextBox2.Text = Dungeon[listBox1.SelectedIndex].description;
                label8.Text = "Условие Входа";
                richTextBox0.Text = Dungeon[listBox1.SelectedIndex].entrance;
                label9.Text = "Ответ";
                richTextBox1.Text = Dungeon[listBox1.SelectedIndex].answer;
            }
            
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int save = 0;
            if (enc == true)
            {
                if (listBox2.SelectedIndex != -1)
                {
                    if (listBox1.SelectedIndex != -1) { listBox1.SetSelected(listBox1.SelectedIndex, false); }
                    
                    save = listBox2.SelectedIndex + 1;
                    listBox2.Items.Clear();

                    for (int i = 0; i != 4; i++)
                    {
                        listBox2.Items.Add(Encounter[save].Actions[i].name);
                    }
                    enc = false;
                }
                // MessageBox.Show(Encounter[listBox2.SelectedIndex-1].Actions[0].name);

                
            }
            else
            {
                Encounter[save].Actions[listBox2.SelectedIndex].dis = "описание 1 д1";
                Encounter[save].Actions[listBox2.SelectedIndex].cons="последствие 1 д1";
                label7.Text = "Описание";
                richTextBox2.Text = Encounter[save].Actions[listBox2.SelectedIndex].dis;// Encounter[listBox2.SelectedIndex].dis;
                label8.Text = "Последствия";
                richTextBox0.Text = Encounter[save].Actions[listBox2.SelectedIndex].cons;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Int64 Summ= 0;
            for (int i = 1; i != 3; i++) {
               
                Console.WriteLine(Convert.ToString(i));
                Convert.ToString(Summ += i * i);

            }
            Console.Read();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //this.Dispose();
        }
    }

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
