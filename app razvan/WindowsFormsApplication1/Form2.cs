using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1 f = new Form1();
            f.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
              
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    while (true)
    {
        if (keyData == Keys.W)
        {
            //MessageBox.Show("w");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + url + "/Razvan" + "?" + "username=w");
            break;
        }

        else if (keyData == Keys.A)
        {
            MessageBox.Show("a");
            break;
        }

        else if (keyData == Keys.S)
        {
            MessageBox.Show("s");
            break;
        }

        else if (keyData == Keys.D)
        {
            MessageBox.Show("d");
            break;
        }
    }

    // Call the base class
    return base.ProcessCmdKey(ref msg, keyData);
}

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

        
    }
   
}
