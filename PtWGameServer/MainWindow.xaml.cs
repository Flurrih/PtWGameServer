using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace PtWGameServer
{
    /// <summary>
    /// Interaction CommandLine.WriteLineic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Server server = new Server();
            server.Start();
            onlinePlayers.AppendText("id:username");
            onlinePlayers.IsReadOnly = true;
            logger.IsReadOnly = true;
        }
        
        private bool _autoScroll = true;
        private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange == 0)
            {
                _autoScroll = ScrollViewer.VerticalOffset == ScrollViewer.ScrollableHeight;
            }

            if (_autoScroll && e.ExtentHeightChange != 0)
            {
                ScrollViewer.ScrollToVerticalOffset(ScrollViewer.ExtentHeight);
            }
        }
    }
}
