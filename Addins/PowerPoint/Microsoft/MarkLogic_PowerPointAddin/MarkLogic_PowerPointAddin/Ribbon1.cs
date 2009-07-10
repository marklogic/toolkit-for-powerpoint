﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace MarkLogic_PowerPointAddin
{
    public partial class Ribbon1 : OfficeRibbon
    {
        public Ribbon1()
        {
            InitializeComponent();
        }

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {  
            Globals.ThisAddIn.myPane.Visible = ((RibbonToggleButton)sender).Checked;

        }

   /*     private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            UserControl1 uc = (UserControl1)Globals.ThisAddIn.myPane.Control;
            uc.saveWithImages();
            //System.Windows.Forms.MessageBox.Show("DOING SOMETHIN");
        }
*/
        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            UserControl1 uc = (UserControl1)Globals.ThisAddIn.myPane.Control;
            string filename = useSaveFileDialog();

            if (!(filename.Equals("") || filename == null))
                uc.saveWithImages(filename,false);

        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            UserControl1 uc = (UserControl1)Globals.ThisAddIn.myPane.Control;
            string filename = useSaveFileDialog();

            if (!(filename.Equals("") || filename == null))
               uc.saveWithImages(filename,true);
        }

        private string useSaveFileDialog()
        {
            Prompt p = new Prompt();
            p.ShowDialog();
            string filename = p.pfilename;
            //System.Windows.Forms.MessageBox.Show(filename);
            return filename;
        }
    }


}
