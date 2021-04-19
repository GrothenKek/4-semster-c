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

namespace WpfApp2
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


        private void button_top_Click(object sender, RoutedEventArgs e)
        {
            Text_box.AppendText("Top"+"\n");

        }

        private void Button_left_Click(object sender, RoutedEventArgs e)
        {
            Text_box.AppendText("left" + "\n");

        }

        private void Button_bottom_Click(object sender, RoutedEventArgs e)
        {
            Text_box.AppendText("bottom" + "\n");

        }

        private void Button_right_Click(object sender, RoutedEventArgs e)
        {
            Text_box.AppendText("right" + "\n");

        }
    }
}
