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
        //public String a;
        public Location NewLocation = new Location();
         Location.enc[] Encounter= new Location.enc[1];
        //Location.Encounter[] Encounter = new Location.Encounter[1] ;
        // public En
        public Form3()
        {
            InitializeComponent();
            textBox1.Focus();
            
        }
        public void listBoxDoubleClick(object sender, EventArgs e)
        {
            Encounter[0].name = VB.InputBox("Name");
            MessageBox.Show(Encounter[0].name);
            Encounter[0].a();
            //NewLocation.test();
           // Array.Resize<Location.Encounter>(ref Encounter, 2);
            //Encounter[0].Name = "Ghbdtn";
           // MessageBox.Show( Encounter[0].Name);

            //  NewLocation.Encounter.
            // NewLocation.Encounter[] a = new Encounter[1];
            //NewLocation.Encounter.
            // MessageBox.Show(a[0].Name);
            //  NewLocation.EncounterCounter += 1;
            // NewLocation.en

            // Array.Resize(ref NewLocation.Encounters, NewLocation.EncounterCounter+1);
            // MessageBox.Show(Convert.ToString (NewLocation.Encounters[1].Name));
            // NewLocation.Encounters[NewLocation.EncounterCounter - 1].Name;
            //NewLocation.Encounters[NewLocation.EncounterCounter-1].Name =  Convert.ToString(NewLocation.EncounterCounter);
        }
        void ShowEncounterInfo(object a ){

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }

    public class Location   {
        public String LocationName;
        public String[] Dungeons;
        public Int16 EncounterCounter=0 ;

       // public Encounter[] a = new Encounter[1];
      
        public void test() {
            
           // MessageBox.Show(a[0].Name);
        }
        //Location.Encounter Encounter = new Location.Encounter();
        //Encounter.Name=""
        

       // Stack<Encounter> encounters = new Stack<Encounter>();
        //public Encounter[] Encounters= new Encounter[2];
        void AddEncounter() {
          
        }
        void AddDis() {

        }
        void AddCons()
        {

        }

        public class Encounter
        {
            //public String Name;
            //public String couns;
            //public String dis;
        }
        public struct enc
        {
            public string name;
            public string couns;
            public string dis;
           public void a() {
                MessageBox.Show(name);
            }
        }
    }
    
}
