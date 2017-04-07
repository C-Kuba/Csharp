using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyplom_csharp_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private string path;

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "RTD|*.rtd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                MessageBox.Show("Załadowano ...");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            App.Application app = new App.Application();

            if(app.start(path))
            {
                MessageBox.Show("Success ...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
