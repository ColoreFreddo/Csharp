using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

namespace Ping_viola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TextBox[] txtms = new TextBox[10];
        TextBox[] txtIP = new TextBox[10];
        TextBox[] txtStatus = new TextBox[10];
        private void btnCarica_Click(object sender, EventArgs e)
        {

        }
        string nomefile="viola.si";
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader File = new StreamReader(nomefile);
            string trmm=File.ReadToEnd();
            string[] campi = trmm.Split('|');
            //generazione tabelle
            for (int i = 0; i < 10; i++)
            {
                txtIP[i] = new TextBox();
                txtIP[i].Top = (int)(i / 2) * 50 + 80;
                txtIP[i].Left = i % 2 * 500 + 100;
                txtIP[i].Text = campi[i].ToString();
                this.Controls.Add(txtIP[i]);
                txtStatus[i] = new TextBox();
                txtStatus[i].Top = (int)(i / 2) * 50 + 80;
                txtStatus[i].Left = i % 2 * 500 + 100 + 100;
                
                this.Controls.Add(txtStatus[i]);
                txtms[i] = new TextBox();
                txtms[i].Top = (int)(i / 2) * 50 + 80;
                txtms[i].Left = i % 2 * 500 + 200 + 100;
               
                this.Controls.Add(txtms[i]);
            }
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                string Indirizzo = txtIP[i].Text;

                Ping pinger = new Ping();
                PingReply reply = pinger.Send(Indirizzo);
                string status = reply.Status.ToString();
                string millisec = reply.RoundtripTime.ToString();
                txtStatus[i].Text = status;
                txtms[i].Text = millisec;
                this.Cursor = Cursors.Arrow;
                if (txtStatus[i].Text== "Success")
                {
                    txtStatus[i].BackColor = Color.Green;
                }
                else
                {
                    txtStatus[i].BackColor = Color.Red;
                }
            }
        }
    }
}
