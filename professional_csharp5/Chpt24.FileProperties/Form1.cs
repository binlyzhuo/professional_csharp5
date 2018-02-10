using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Chpt24.FileProperties
{
    public partial class Form1 : Form
    {
        private string currentFolderPath;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Enter name of the folder to be examined and click Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo inputDir = new DirectoryInfo(textBoxInput.Text);
            //var subDir = inputDir.GetDirectories();

            DisplayFolderList(textBoxInput.Text);
        }

        protected void DisplayFolderList(string folderFullName)
        {
            DirectoryInfo theFolder = new DirectoryInfo(folderFullName);
            if (!theFolder.Exists)
            {
                throw new DirectoryNotFoundException("Folder not found:"+folderFullName);
            }

            textBoxFolder.Text = theFolder.FullName;
            currentFolderPath = theFolder.FullName;

            foreach (var nextFolder in theFolder.GetDirectories())
            {
                listBoxFolder.Items.Add(nextFolder.Name);
            }

            foreach (var nextFile in theFolder.GetFiles())
            {
                listBoxFiles.Items.Add(nextFile.Name);
            }
        }


    }
}
