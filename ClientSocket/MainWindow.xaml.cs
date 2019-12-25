using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace ClientSocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendNetMessage(object sender, RoutedEventArgs e)
        {
            using(var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("10.1.4.46"), 8080);
                socket.Connect(endpoint);
                var buffer = System.Text.Encoding.UTF8.GetBytes(messageTB.Text);
                socket.Send(buffer);
                socket.Shutdown(SocketShutdown.Both);
            }
        }
    }
}
