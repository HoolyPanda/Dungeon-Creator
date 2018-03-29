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
        public Location NewLocation = new Location();
        Location.Encounter[] Encounter = new Location.Encounter[1];
        Location.Dungeon[] Dungeon = new Location.Dungeon[1];
        public Form3()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        public void listBoxDoubleClick(object sender, EventArgs e)
        {
            int i = Encounter.Length;
            i++;
            Array.Resize(ref Encounter,i);
            Encounter[i-1].name = VB.InputBox("Name");
            listBox2.Items.Add(Encounter[i-1].name);
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
                listBox2.SetSelected(listBox2.SelectedIndex, false);
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
            if (listBox2.SelectedIndex != -1) {
                if (listBox1.SelectedIndex != -1) { listBox1.SetSelected(listBox1.SelectedIndex, false); }   
                label7.Text = "Описание";
                richTextBox2.Text = Encounter[listBox2.SelectedIndex].dis;
                label8.Text = "Последствия";
                richTextBox0.Text = Encounter[listBox2.SelectedIndex].couns;
            }  
        }
        private void button1_Click(object sender, EventArgs e)
        {

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
        void AddEncounter()
        {

        }
        void AddDis() {

        }
        void AddCons()
        {

        }
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
        }
    }
}
