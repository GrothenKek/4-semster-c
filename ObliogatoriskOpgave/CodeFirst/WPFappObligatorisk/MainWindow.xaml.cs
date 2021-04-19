using CodeFirst.DataContext;
using CodeFirst.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFappObligatorisk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RentServiceContext context = new RentServiceContext();
        public MainWindow()
        {
            
            InitializeComponent();
            InitGridPane();


            DataContext = this;



        }


        private void RentalPicked(object sender, SelectionChangedEventArgs e)
        {
            var SelectedItem = ReservationView.SelectedItem;

            if (SelectedItem is Reservation)
            {
                Reservation res = (Reservation)SelectedItem;
                Tool tool = context.Tools.Find(res.ToolId);
                Customer customer = context.Customers.Find(res.CustomerId);
                InitCombo(res);

                CustomerName.Text = customer.Name;
                ToolName.Text = tool.Name;
                PricePrDay.Text = tool.PricePrDay.ToString();
                TotalDays.Text = (res.EndDate - res.StartDate).Days.ToString();
                double Between = (res.EndDate - res.StartDate).Days;
                TotalPrice.Text = (Between * tool.PricePrDay).ToString();
                if(res.Price == 0)
                {
                    res.Price = (int)(Between * tool.PricePrDay);
                    context.SaveChanges();

                }


                
                


            }


        }
        private void StatusChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedItem = ComboStatus.SelectedItem;
            var SelectedRes = ReservationView.SelectedItem;
            Reservation res = (Reservation)SelectedRes;
            

            
                if (SelectedItem == ComboRes)
                {
                    res.StorageStatus = ResStatus.Reserved;
                    context.SaveChanges();
                }
                if (SelectedItem == ComboCon)
                {
                    res.StorageStatus = ResStatus.Consigned;
                    context.SaveChanges();
                }
                if (SelectedItem == ComboRet)
                {
                    res.StorageStatus = ResStatus.Returned;
                    context.SaveChanges();
                }

            context.SaveChanges();
            context.Reservations.Load();
            ReservationView.Items.Refresh();
            
           

                






        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            context.Reservations.Load();
            String Search = SearchField.Text;

            if(ReservationView.Items != null)
            {
                this.ReservationView.Items.Clear();

            }
            
            

            foreach (Reservation r in context.Reservations)
            {
                if (r.CustomerId.ToLower().Equals(Search.ToLower()))
                {
                    Tool tool = context.Tools.Find(r.ToolId);
                    this.ReservationView.Items.Add(r  );
                   
                }

            }

        }

        private void InitGridPane()
        {
            var gridView = new GridView();
            this.ReservationView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ResId",
                DisplayMemberBinding = new Binding("ResId")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ToolId",
                DisplayMemberBinding = new Binding("ToolId")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "StorageStatus",
                DisplayMemberBinding = new Binding("StorageStatus")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Start",
                DisplayMemberBinding = new Binding("StartDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "End",
                DisplayMemberBinding = new Binding("EndDate")
            });





        }

        private void InitCombo(Reservation res)
        {
            if (res.StorageStatus == ResStatus.Reserved) 
            {
                this.ComboStatus.SelectedIndex = 0;
            }
            if (res.StorageStatus == ResStatus.Consigned)
            {
                this.ComboStatus.SelectedIndex = 1;
            }
            if (res.StorageStatus == ResStatus.Returned)
            {
                this.ComboStatus.SelectedIndex = 2;
            }


        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            var SelectedRes = ReservationView.SelectedItem;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this reservation?","Do you want to delete this?" ,MessageBoxButton.YesNoCancel);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Reservation will be deleted");
                    break;


                case MessageBoxResult.No:
                    MessageBox.Show("Reservation wont be deleted");
                    break;

                case MessageBoxResult.Cancel:
                    break;



            }



        }
    }
}
