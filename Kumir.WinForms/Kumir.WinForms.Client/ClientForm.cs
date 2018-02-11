using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace Kumir.WinForms
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        private void connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                MessageBox.Show("client connect");
                stream = client.GetStream(); // получаем поток

                string message = nameTB.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                
                // запускаем новый поток для получения данных
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потока
                MessageBox.Show("Добро пожаловать, client");
                //SendMessage();
            }
            catch
            {
                MessageBox.Show("no connect");
            }
        }

        static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                   if (message != "" ) MessageBox.Show(message);//вывод сообщения
                }
                catch
                {
                    MessageBox.Show("Подключение прервано!"); //соединение было прервано
                }
            }
        }

        private void ping_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.Unicode.GetBytes("ping");
            stream.Write(data, 0, data.Length);
        }
    }
}
