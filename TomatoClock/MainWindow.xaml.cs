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

namespace TomatoClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentTime = 15;
        private byte[] charBytesArray = { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Form_Loaded(object sender, RoutedEventArgs e)
        {
            timeSetter.Text = currentTime.ToString();
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Set_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Finish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void timeSetter_TextChanged(object sender, TextChangedEventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(timeSetter.Text);
            if (bytes.Length < 1) return;
            for(int i=0;i<bytes.Length;i++)
            {
                if(!charBytesArray.Contains(bytes[i]))
                {
                    timeSetter.Text = currentTime.ToString();
                    return;
                }
            }
            currentTime = Convert.ToDouble(timeSetter.Text);
        }
    }
}
