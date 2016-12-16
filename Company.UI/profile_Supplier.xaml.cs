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
        Repository repo = new Repository();
        List<Catalogue> ListCatalogue = new List<Catalogue>();
        List<Orders> ListOrders = new List<Orders>();
        
        private void listBox_CatalogueOfOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //удаление выбраных элементов по двойному щелчку мыши из листбокса и из базы

            //пока не работает
            foreach (var item in listBox_CatalogueOfOrders.SelectedItems)
            {
                //удаляю из листбокса
                //listBox_myCatalogue.Items.Remove(item);

                var a = item.ToString();
                string[] newItem = a.Split(' ');
                MessageBox.Show(newItem[0] + " for " + newItem[1] + "$");

                var str1 = newItem[0];
                var str2 = newItem[1];
                //ListCatalogue.Contains(a);
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
                ListCatalogue = c.Catalogue.ToList();
                listBox_Orders.Items.Clear();
                ListOrders = c.Orders.ToList();
                foreach (Orders item in ListOrders)
                {
                    string itemname = item.ItemName.ItemName;
                    //string nameClient = item.Client.Name;
                    //string nameAdmin = item.Admin.Name;

                    listBox_Orders.Items.Add(/*nameClient +*/" " + itemname + " " + item.Cost + "$ " + item.Status + " "/* + nameAdmin*/);
                }
            }

        }
    }
    }

