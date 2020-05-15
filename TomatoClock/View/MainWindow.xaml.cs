using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TomatoClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private double currentTime = 15;
        //private byte[] charBytesArray = { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainFormViewModel();
        }

        //private void timeSetter_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    byte[] bytes = Encoding.ASCII.GetBytes(timeSetter.Text);
        //    if (bytes.Length < 1) return;
        //    for(int i=0;i<bytes.Length;i++)
        //    {
        //        if(!charBytesArray.Contains(bytes[i]))
        //        {
        //            timeSetter.Text = currentTime.ToString();
        //            return;
        //        }
        //    }
        //    currentTime = Convert.ToDouble(timeSetter.Text);
        //}
    }
}
