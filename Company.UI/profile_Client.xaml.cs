using Company.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Company.UI
{
    /// <summary>
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile_Client : Window
    {
        public profile_Client()
        {
            InitializeComponent();
        }

        Repository repo = new Repository();
        List<Catalogue> ListCatalogue = new List<Catalogue>();
        List<string> ListMyCart = new List<string>();
        List<string> ListOrders = new List<string>();
        EmailSenter senter = new EmailSenter();

        private async void button_show_catalogue_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                //скачивание данных из базы и показ в листвью каталога
                listView_myCatalogue.Items.Clear();
                listView_myCatalogue.Items.Refresh();

                ListCatalogue = await c.Catalogue.ToListAsync();

                foreach (Catalogue item in ListCatalogue)
                {
                    listView_myCatalogue.Items.Add(new
                    {
                        Name = item.ItemName,
                        Price = item.Price
                    });
                }
            }
        }

        private void listView_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //добавление содержимого из списка каталога в корзину
            foreach (var item in listView_myCatalogue.SelectedItems)
            {
                //все данные в строку, форматирую их и отправляю их в лист
                var a = item.ToString();
                var removeStr = new string[] { "{", "}", "Name", "=", "Price", "," };
                foreach (var c in removeStr)
                {
                    a = a.Replace(c, string.Empty);
                }
                a = a.Remove(0, 3);

                string[] words = a.Split(' ');

                ListMyCart.Add(words[0] + " " + words[3]);
                
                //добавляю данные в листбокс заказов
                list_myCart.Items.Add(new
                {
                    Name = words[0],
                    Price = words[3]
                });

                MessageBox.Show("item was added");
            }
            int purchase = 0;
            foreach (var item in ListMyCart)
            {
                string[] el = item.Split(' ');
                int price = Convert.ToInt32(el[1]);
                purchase += price;
            }
            sum.Content = purchase.ToString() + "$";

        }

        //удаление всего заказа
        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            //удалить заказ (удаляет весь список, позже можно настроить, чтобы поштучно удалял)
            if (list_myCart.Items.Count == 0)
            {
                MessageBox.Show("you haven't choose any item!");
                return;
            }
            sum.Content = "0" + "$";
            list_myCart.Items.Clear();
            ListMyCart.Clear();
        }

        //сделать заказ
        private void order_botton_Click(object sender, RoutedEventArgs e)
        {

            Catalogue itemname = new Catalogue();
            //оформить заказ (отправляю новые данные в таблицу бд Orders)
            int purchase = 0;

            using (var c = new Context())
            {
                string clientName = labelName.Content.ToString();
                var clientLogin = (from names in c.Clients
                                   where names.Name == clientName
                                   select names.login).FirstOrDefault();

                foreach (string item in ListMyCart)
                {
                    ListOrders.Add(item);
                    //отрываю название от цены)
                    string[] a = item.Split(' ');
                    int price = Convert.ToInt32(a[1]);
                    itemname.ItemName = a[0];

                    listBox_orders.Items.Add(a[0] + " " + price.ToString() + "$");

                    string tovar = a[0];

                    c.Orders.Add(new Orders
                    {
                        Client = clientLogin,
                        ItemName = a[0],
                        Cost = price,
                        Date = DateTime.Now
                    });
                    c.SaveChanges();
                    purchase += price;
                }
                totalCost.Content = purchase.ToString() + "$";
                if (list_myCart.Items.Count == 0)
                {
                    MessageBox.Show("You haven't choose any item!");
                    return;
                }
                MessageBox.Show("The order was done");
                list_myCart.Items.Clear();
                sum.Content = 0;
                ListOrders.Clear();
                ListMyCart.Clear();
            }
            try
            {
                senter.ShowDialog();
            }
            catch (InvalidOperationException)
            {
                return;
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

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            login l = new login();
            l.ShowDialog();
        }

        private void btn_exl_Click(object sender, RoutedEventArgs e)
        {
            if (!(listBox_orders.Items.Count == 0))
            {
                StreamWriter sw = new StreamWriter(@"..\..\..\path.txt");
                List<object> orderList = new List<object>();
                foreach (var order in listBox_orders.Items)
                {
                    orderList.Add(order);
                    sw.WriteLine(order);
                }
                sw.WriteLine("the sum of your order is: " + totalCost.Content);
                sw.Close();
                MessageBox.Show("Details of your order was added to a txt file!");
                listBox_orders.Items.Clear();
            }
            else
            {
                MessageBox.Show("you didn't have any orders!");
            }
        }

        private void btn_lng_Click(object sender, RoutedEventArgs e)
        {
            //смена языка, нужно подумать, как менять его в сплывающих сообщениях
            // и как менять язык обратно при повторном нажатии лол

            label_orders.Content = "Мои Заказы";
            label.Content = "Моя Корзина";
            label1.Content = "Мой Каталог";
            button_show_catalogue.Content = "Показать";
            btn_exl.Content = "В Документ";
            clear_button.Content = "Удалить Заказ";
            order_botton.Content = "Заказать"; // лол через "о" написано боттон, а не баттон)0))
            exit.Content = "Выйти";

        }
    }
}


