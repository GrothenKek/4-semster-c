
using Microsoft.Win32;
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

namespace EX09_WpfApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private MyServiceClient client = null;

        public MainWindow() {
            InitializeComponent();

            client = new MyServiceClient();            
        }

        private void TextBox_num_sum_TextChanged(object sender, TextChangedEventArgs e) {            
            if (textBox_a_sum.Text == null || textBox_a_sum.Text.Length == 0) {
                textBox_res_sum.Text = "-";
                return;
            }
            if (textBox_b_sum.Text == null || textBox_b_sum.Text.Length == 0) {
                textBox_res_sum.Text = "-";
                return;
            }
            int a_num;
            if (textBox_a_sum.Text == "-") {
                textBox_res_sum.Text = "";
                return;
            }
            if (!int.TryParse(textBox_a_sum.Text, out a_num)) {
                textBox_a_sum.Text = "";
                textBox_res_sum.Text = "";
                return;
            }
            int b_num;
            if (textBox_b_sum.Text == "-") {
                textBox_res_sum.Text = "";
                return;
            }
            if (!int.TryParse(textBox_b_sum.Text, out b_num)) {
                textBox_b_sum.Text = "";
                textBox_res_sum.Text = "";
                return;
            }
            textBox_res_sum.Text = client.Sum(a_num,b_num).ToString();
        }
        private void TextBox_num_prod_TextChanged(object sender, TextChangedEventArgs e) {
            if (textBox_a_prod.Text == null || textBox_a_prod.Text.Length == 0) {
                textBox_res_prod.Text = "-";
                return;
            }
            if (textBox_b_prod.Text == null || textBox_b_prod.Text.Length == 0) {
                textBox_res_prod.Text = "-";
                return;
            }
            int a_num;
            if (textBox_a_prod.Text == "-") {
                textBox_res_prod.Text = "";
                return;
            }
            if (!int.TryParse(textBox_a_prod.Text, out a_num)) {
                textBox_a_prod.Text = "";
                textBox_res_prod.Text = "";
                return;
            }
            int b_num;
            if(textBox_b_prod.Text == "-") {
                textBox_res_prod.Text = "";
                return;
            }
            if (!int.TryParse(textBox_b_prod.Text, out b_num)) {
                textBox_b_prod.Text = "";
                textBox_res_prod.Text = "";
                return;
            }
            textBox_res_prod.Text = client.Product(a_num, b_num).ToString();
        }

        private void Window_Closed(object sender, EventArgs e) {
            client.Close();
            client = null;
        }

        private void TextBox_SumOfAllToN_TextChanged(object sender, TextChangedEventArgs e) {
            if (textBox_SumOfAllToN.Text == null || textBox_SumOfAllToN.Text.Length == 0) {
                textBox_SumOfAllToN_res.Text = "-";
                return;
            }            
            int a_num;            
            if (!int.TryParse(textBox_SumOfAllToN.Text, out a_num)) {
                textBox_SumOfAllToN.Text = "";
                textBox_SumOfAllToN_res.Text = "";
                return;
            }
            textBox_SumOfAllToN_res.Text = client.SumOfAllToN(a_num).ToString();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
            //    openFileDialog.InitialDirectory = "c:\\";
            //    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //    openFileDialog.FilterIndex = 2;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK) {
            //        //Get the path of specified file
            //        filePath = openFileDialog.FileName;

            //        //Read the contents of the file into a stream
            //        var fileStream = openFileDialog.OpenFile();

            //        using (StreamReader reader = new StreamReader(fileStream)) {
            //            fileContent = reader.ReadToEnd();
            //        }
            //    }
            //}

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true) {
                textBox.Text = openFileDialog.FileName + " contains:\n";
                string[] lines = client.GetLines(openFileDialog.FileName);
                foreach (var line in lines)
                    textBox.AppendText(line + "\n");
            } else {
                textBox.Text = "No file selected";
            }
        }
    }
}
