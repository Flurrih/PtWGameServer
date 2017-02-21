using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PtWGameServer
{
    class CommandLine
    {
        public static void WriteLine(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)Application.Current.MainWindow).logger.AppendText("\n[" + DateTime.Now + "] " + message);
            });
        }
        public static void WriteLine(int message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)Application.Current.MainWindow).logger.AppendText("\n[" + DateTime.Now + "] " + message.ToString());
            });
        }
        public static void Write(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)Application.Current.MainWindow).logger.AppendText(message);
            });
        }
        public static void Write(int message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)Application.Current.MainWindow).logger.AppendText(message.ToString());
            });
        }
        public static void Clear()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)Application.Current.MainWindow).logger.Clear();
            });
        }
    }
}
