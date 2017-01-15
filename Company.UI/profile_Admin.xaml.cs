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
    /// Логика взаимодействия для profile_Admin.xaml
    /// </summary>
    public partial class profile_Admin : Window
    {
        public profile_Admin()
        {
            InitializeComponent();

        }

        Repository repo = new Repository();
        List<Catalogue> ListCatalogue = new List<Catalogue>();
        List<Orders> ListOrders = new List<Orders>();

        //по кнопке показываю базу данных Админу
        private void button_Show_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                listBox_myCatalogue.Items.Clear();

                ListCatalogue = c.Catalogue.ToList();
                ListOrders = c.Orders.ToList();

                //показываю лист бд админу
                foreach (Catalogue item in ListCatalogue)
                {
                    listBox_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
                }
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            //(1) оформляю ItemName
            var strItemname = textBox_newItem.Text.ToString();

            //удаляю пробелы в строке
            var str = strItemname;
            var newstr = str.Replace(" ", "");

            while (textBox_newItem.Text == "" || textBox_newItem.Text == " " || textBox_newItem.Text == null)
            {
                MessageBox.Show("Error in ItemName");
                textBox_newItem.Clear();
                return;
            }
            //пробую отправить в строку
            string itemname = Convert.ToString(newstr);

            //(2) оформляю Price
            var strPrice = textBox_newPrice.Text.ToString();

            //удаляю пробелы
            var pr = strPrice;
            var newpr = pr.Replace(" ", "");

            //отправляю в инт
            string price = newpr;

            int n;

            while (!int.TryParse(price, out n))
            {
                MessageBox.Show("error in Price");
                textBox_newPrice.Clear();
                return;
            }

            //добавляю в базу
            using (var c = new Context())
            {
                c.Catalogue.Add(new Catalogue
                {
                    ItemName = itemname,
                    Price = n
                });
                c.SaveChanges();

                //добавляю в лист
                ListCatalogue = c.Catalogue.ToList();
            }

            //чистим боксы
            textBox_newItem.Clear();
            textBox_newPrice.Clear();

            //чистим листбокс
            listBox_myCatalogue.Items.Clear();

            //добавляем новый элемент в лист бд
            foreach (Catalogue item in ListCatalogue)
            {
                listBox_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
            }
        }

        private void listBox_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //удаление выбраных элементов по двойному щелчку мыши из листбокса и из листа Каталога

            foreach (var item in listBox_myCatalogue.SelectedItems)
            {
                //получаю индекс выбранного айтэма и удаляю из листа

                int index = listBox_myCatalogue.Items.IndexOf(item);
                ListCatalogue.RemoveAt(index);

                //добавляю в лист удаленных (строку)
                string deletedstr = item.ToString();
                repo.DeletedItems.Add(deletedstr);

                //удаляю из листбокса
                listBox_myCatalogue.Items.Remove(item);
                listBox_myCatalogue.Items.Refresh();
                
                break;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in repo.DeletedItems)
            {
                var a = item.ToString();
                MessageBox.Show(a);
            }
        }

        private void ShowOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            labelcost.Visibility = Visibility.Visible;

            listView_Orders.Items.Clear();
            listBox_Clients.Items.Clear();
            CheckBox checkbox = new CheckBox();
            foreach (var item in repo.ListOfClients())
            {
                listBox_Clients.Items.Add(item);
            }
            int cost = 0;
            foreach (Orders item in ListOrders)
            {
                string itemname = item.ItemName;
                string nameClient = item.Client;

                listView_Orders.Items.Add(new
                {
                    Status = "awaits",
                    login = nameClient,
                    Item = itemname,
                    Price = item.Cost + "$ ",
                    Data = item.Date
                });
                cost += item.Cost;
                if (checkbox.IsChecked == true)
                {
                    using (var c = new Context())
                    {
                        foreach (var stat in c.Orders)
                        {
                            stat.Status += 1;
                            
                        }
                    }
                    MessageBox.Show("is checked");
                }
                labelcost.Content = "Total income from sales: " + cost + "$ ";
            }
        }
        private void listBox_Clients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            labelcost.Visibility = Visibility.Visible;

            listView_Orders.Items.Clear();
            foreach (var item in listBox_Clients.SelectedItems)
            {
                string info = item.ToString();
                string[] a = info.Split(' ');
                var b = a[2];
                var newstr = b.Replace("(", "");
                var newstr2 = newstr.Replace(")", "");
                var sortedlist = from z in repo._SortedOrders()
                                 where z.Client == newstr2
                                 select z;
                int cost = 0;
                foreach (Orders element in sortedlist)
                {
                    listView_Orders.Items.Add(new
                    {
                        Status = element.Status,
                        login = element.Client,
                        Item = element.ItemName,
                        Price = element.Cost + "$ ",
                        Data = element.Date
                    });
                    cost += element.Cost;
                }
                labelcost.Content = "Total sum: " + cost + "$ ";
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
