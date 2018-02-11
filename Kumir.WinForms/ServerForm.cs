using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Kumir.Model;

namespace Kumir.WinForms
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }
        static Server server; // сервер
        static Thread listenThread; // потока для прослушивания
        private void start_Click(object sender, EventArgs e)
        {

          
            try
            {
                server = new Server();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); //старт потока

                var clients = server.GetListClient;
                MessageBox.Show(Convert.ToString(clients.Count));
                foreach (var client in clients)
                {
                    MessageBox.Show(client.name);
                }
               // MessageBox.Show("Client is connect");
            }
            catch (Exception ex)
            {
                //    server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            server.Disconnect();
        }

    }
}
