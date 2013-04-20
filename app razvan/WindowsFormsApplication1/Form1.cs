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


namespace WindowsFormsApplication1
{
    

    public partial class Form1 : Form
    {
        public int Adevarat;
        public string Username;
        public string Password;
        
        public Form1()
        {
            Adevarat = 0;
            InitializeComponent();
            textBox2.Text = "Neconectat";

            
            
            
        }
            
         
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            
        }


        private void button1_Click(object sender, EventArgs e)
        {


            //Adevarat = 1;
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply prep;
                string url = "10.10.0.32";
                prep = p.Send(url);
                if (prep.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    string address = prep.Address.ToString();
                    string time = prep.RoundtripTime.ToString();
                    Adevarat = 1;
                   // MessageBox.Show("ping successfull" + "machine address :" + address + "Round trip time" + time);
                }
                else
                {
                    string status = prep.Status.ToString();
                    MessageBox.Show("not successfull" + status);
                }
                string url1 = "http://"+url+"/Razvan"+"?"+"username="+Username+"&password="+Password;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + url + "/Razvan" + "?" + "username=" + Username + "&password=" + Password);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
                        TextReader reader = new StreamReader(response.GetResponseStream());
                        string text = reader.ReadToEnd();
                        MessageBox.Show(text);
                    
                   
                }

                catch
                {
                    MessageBox.Show("Moloz pe tava");
                }

                //MessageBox.Show(url1, "A");




                if (Adevarat == 0)
                    textBox2.Text = "Neconectat";
                else
                {
                    textBox2.Text = "Connected";
                    Form2 m = new Form2();
                    m.Show();
                    Form1 f = new Form1();
                    this.Visible = false;
                    this.Hide();
                    
                }
          //  MessageBox.Show(Username , "A");
          //  MessageBox.Show(Password, "B");

           
        }
        
            
       

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Adevarat = 0;
            if (Adevarat == 0)
                textBox2.Text = "Neconectat";
            else
                textBox2.Text = "Conectat";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           Username = textBox1.Text;
            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           Password = textBox3.Text;
        }

        

    }
}
