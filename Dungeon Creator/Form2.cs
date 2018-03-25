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

namespace Dungeon_Creator
{
    public partial class Form2 : Form
    {
        int mass = 0;
        String[] encounters = new String[0];
        //принял путь до подземелья
        public Form2(String q)
        {
            InitializeComponent();
            Text = q;
            String[] actions = Directory.GetDirectories(q); //"C:/Users/Pavlo/Desktop/Учеба");
            if (actions.Length != 0)
            {
                for (int i = 0; i <= actions.Length - 1; i++)
                {
                    EncounterList.Items.Add(actions[i]);
                }

            }
            else {
                // кусок если нет активностей
                MessageBox.Show("Нет действий");
            }


        }

        void Hello(object sender, EventArgs e) {
            MessageBox.Show("Click*2 on list");
        }

        private void EncounterList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
