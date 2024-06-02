using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_send
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            string ipString = "111.111.111.111";
            int port = 111;

            IPAddress ip = IPAddress.Parse(ipString);
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            clientSocket.Connect(endPoint);
            if (clientSocket.Connected)
            {
                clientSocket.Send(Encoding.ASCII.GetBytes(TB1.Text));
            }
            byte[] buf = new byte[1024];
            int n;
            do
            {
                n = clientSocket.Receive(buf);
            } while (n == 0);
            MessageBox.Show("Received bytes count: " + n.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
