using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Threading;

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

        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        



        

       protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
            
        
  while (true)
  {
      if (keyData == Keys.W)
      {
            
          MessageBox.Show("w");
            
              HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.10.0.32/Razvan" + "?" + "comanda=w");
              HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
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
      System.Threading.Thread.Sleep(199);
  }

  // Call the base class
  return base.ProcessCmdKey(ref msg, keyData);
}

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_KeyDown()
        {
           
        
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

     

        
    }
   
}
