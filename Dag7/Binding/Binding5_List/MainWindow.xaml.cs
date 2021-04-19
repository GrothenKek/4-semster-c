using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Binding5_List {


    public class Person : INotifyPropertyChanged
    {
        BindingMode.twoW
        public Person(string name, int age, int score) { Name = name; Age = age; Score = score; }

        private string name;
        public string Name
        {
           
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
            get { return name; }
        }
        private int age;
        public int Age
        {
            set
            {
                age = value;
                NotifyPropertyChanged(nameof(Age));
            }
            get { return age; }
        }

        private int score;
        public int Score
        {
            set
            {
                score = value;
                NotifyPropertyChanged(nameof(Score));
            }
            get { return score; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString()
        {
            return name;
        }

        public string ListBoxToString
        {
            get
            {
                return Name
                    //+ " (" + Age + ")" + "," + Score;
                    ;

            }
        }

    }



    public partial class MainWindow : Window {
        private ObservableCollection<Person> data;

        public MainWindow() {
            InitializeComponent();

            data = new ObservableCollection<Person>() {
                new Person("Tom Clancy",10,100),
                new Person("Stephen King",20,200),
                new Person("Stephen King",20,200),
                new Person("Edgar Allan Poe",30,300),
                new Person("Edgar Allan Poe",50,0),
            };

            //listBox.ItemsSource = data;
            LV.ItemsSource = data;
            gridOuter.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            data.Add(new Person("Claude Shannon", 20,0));            
        }
    }
}
