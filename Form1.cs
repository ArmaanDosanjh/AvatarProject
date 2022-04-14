using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Avatar
{
    public partial class Form1 : Form
    {
        SoundPlayer ost = new SoundPlayer("create.wav");

        List<string> actions = new List<string>();
        


        // Word bank used to link the ToolStripMenuItems to the PictureBox's

        #region Dictionary
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "helmet", "sakai" },
            { "mask", "sakai" },
            { "body", "sakai" },
            { "legs", "sakai" },
            { "bow", "half" },
            { "stance", "stone" },
        };
        #endregion

        public Form1()
        {
            InitializeComponent();
            ost.PlayLooping();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region ToolStripMenuItem Code
        private void change(object sender, EventArgs e)
        {
            ToolStripMenuItem picked = (ToolStripMenuItem)sender;
            string[] broken = picked.Name.Split('_');
            data.Remove(broken[0]);
            data.Add(broken[0], broken[1]);
            // actions.Add code adds the various images that I was changing on a list
            if (actions.Count > 0)
            actions.Add(picked.Name);
            // Call the picturechange Subroutine so that pictures actually change
            picturechange(broken[0], broken[1]);
        }
        #endregion

        // Code to change the various pictures on the form between another

        #region Change Pictures in the ToolStrip
        private void picturechange(string aKey, string aValue)
        {
            switch (aKey)
            {
                #region Helmets (Working)
                case "helmet":
                    switch (aValue)
                    {
                        case "sakai":
                            pbHead.Image = Properties.Resources.sakai_head;
                            break;

                        case "ghost":
                            pbHead.Image = Properties.Resources.ghost_head;
                            break;

                        case "fundoshi":
                            pbHead.Image = Properties.Resources.fundoshi_head;
                            break;
                    }
                    break;
                #endregion

                #region Masks (Working)
                case "mask":
                    switch (aValue)
                    {
                        case "sakai":
                            pbMask.Image = Properties.Resources.sakai_mask;
                            break;

                        case "ghost":
                            pbMask.Image = Properties.Resources.ghost_mask;
                            break;

                        case "thief":
                            pbMask.Image = Properties.Resources.thief_mask;
                            break;
                    }
                    break;
                #endregion

                #region Body (Working)
                case "body":
                    switch (aValue)
                    {
                        case "sakai":
                            pbBody.Image = Properties.Resources.sakai_body;
                            break;

                        case "ghost":
                            pbBody.Image = Properties.Resources.ghost_body;
                            break;

                        case "fundoshi":
                            pbBody.Image = Properties.Resources.fundoshi_body;
                            break;
                    }
                    break;
                #endregion

                #region Legs (Working)
                case "legs":
                    switch (aValue)
                    {
                        case "sakai":
                            pbLegs.Image = Properties.Resources.sakai_legs;
                            break;

                        case "ghost":
                            pbLegs.Image = Properties.Resources.ghost_legs;
                            break;

                        case "fundoshi":
                            pbLegs.Image = Properties.Resources.fundoshi_legs;
                            break;
                    }
                    break;
                #endregion

                #region Bows (Working)
                case "bow":
                    switch (aValue)
                    {
                        case "half":
                            pbBow.Image = Properties.Resources.bow;
                            break;

                        case "long":
                            pbBow.Image = Properties.Resources.longbow;
                            break;
                    }
                    break;
                #endregion

                #region Stances (Working)
                case "stance":
                    switch (aValue)
                    {
                        case "stone":
                            MessageBox.Show("A stance worthy against the Mongol Swordsmen");
                            pbStance.Image = Properties.Resources.stonestance;
                            break;

                        case "water":
                            MessageBox.Show("A stance worthy against the Mongol Shieldsmen.");
                            pbStance.Image = Properties.Resources.waterstance;
                            break;

                        case "wind":
                            MessageBox.Show("A stance worthy against the Mongol Spearmen.");
                            pbStance.Image = Properties.Resources.windstance;
                            break;

                        case "moon":
                            MessageBox.Show("A stance worthy against the Mongol Brutes.");
                            pbStance.Image = Properties.Resources.moonstance;
                            break;

                        case "ghost":
                            MessageBox.Show("This will be brutal for the Mongols.");
                            pbStance.Image = Properties.Resources.ghoststance;
                            break;
                    }
                    break;
                    #endregion
            }
        }
        #endregion

        // Code for working Undo Button

        #region Undo Button
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ud();
            
        }
        #endregion

        private void ud()
        {
            int undo = actions.Count - 1;

            if (undo > 0)
            {
                actions.RemoveAt(undo);
                undo--;
                if (undo > -1)
                {
                    string[] broken = actions[undo].Split('_');
                    picturechange(broken[0], broken[1]);
                }
            }
        }

        // After clicking on the confirm picture box, certain messages will appear

        #region Confirm Hero

        // Nothing in here works no need to look in ehre
        private void confirm(object sender, EventArgs e)
        {     
            if (helmet_fundoshi.Selected && body_fundoshi.Selected && legs_fundoshi.Selected)
            {
                MessageBox.Show("'A true samurai needs no clothes.' - Jin Sakai after too much sake.");
            }
        }
        #endregion

       

    

        private void goherekey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)
            {
                ud();
            }
            if (e.KeyCode == Keys.M)
            {
                Application.Exit();
            }
        }

        private void fileToolStrip_Click(object sender, EventArgs e)
        {
            string file = "";
            //foreach (string entry in )
            {
              //  file = file + entry + "\n";
            }
        }
        
        
        
        
        
        
        
        
        
        
        
        
         // Literally useless code it was mostly if not everything was just a double click on pictureboxes and toolstrips on the form
        
        #region Useless Stuff
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void pbLegs_Click(object sender, EventArgs e)
        {

        }

        private void pbBody_Click(object sender, EventArgs e)
        {

        }

        private void pbHead_Click(object sender, EventArgs e)
        {

        }

        private void pbBow_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
