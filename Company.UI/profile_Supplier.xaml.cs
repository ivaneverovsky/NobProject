using Company.Data;
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
using System.Windows.Shapes;

namespace Company.UI
{
    /// <summary>
    /// Логика взаимодействия для profile_Supplier.xaml
    /// </summary>
    public partial class profile_Supplier : Window
    {
        public profile_Supplier()
        {
            InitializeComponent();
        }

        List<Catalogue> ListCatalogue = new List<Catalogue>();
        List<Orders> ListOrders = new List<Orders>();
        Repository repo = new Repository();

        private void listBox_CatalogueOfOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            foreach (var item in listBox_CatalogueOfOrders.SelectedItems)
            {
                

                var a = item.ToString();
                string[] newItem = a.Split(' ');
                MessageBox.Show(newItem[0] + " for " + newItem[1] + "$");

                var str1 = newItem[0];
                var str2 = newItem[1];
                
            }
        }

        private void button_Show_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                listBox_CatalogueOfOrders.Items.Clear();


                ListCatalogue = c.Catalogue.ToList();


                foreach (Catalogue item in ListCatalogue)
                {
                    listBox_CatalogueOfOrders.Items.Add(item.ItemName + " " + item.Price);
                }

            }
        }

        private void button_Show_Orders_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                foreach (var item in repo.ListOfClients())
                {
                    listBox_Clients.Items.Add(item);
                }
                
                ListCatalogue = c.Catalogue.ToList();
                listBox_Orders.Items.Clear();
                ListOrders = c.Orders.ToList();
                foreach (var item in ListOrders)
                {
                   
                    string nameClient = item.Client;
                    string itemname = item.ItemName;
                    listBox_Orders.Items.Add(nameClient + " " + itemname + " " + item.Cost + "$");
                    
                    
                }
               
            }

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            login l = new login();
            l.ShowDialog();
        }
    }
}

