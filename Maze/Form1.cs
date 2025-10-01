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

namespace Maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog upload = new OpenFileDialog())
            {
                upload.Filter = "Txt Files|*.txt";
                upload.Title = "Select File";
                if (upload.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = upload.FileName;
                
                Maze maze = new Maze(filePath);
            }
        }
    }
}
