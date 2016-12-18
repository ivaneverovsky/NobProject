using Company.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    //ListViewItem boxitem = new ListViewItem();
                    listView_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
                }
            }
        }

        private void listView_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //добавление содержимого из списка каталога в корзину

            foreach (var item in listView_myCatalogue.SelectedItems)
            {
                //добавляю данные в листбокс заказов
                list_myCart.Items.Add(item);

                //все данные в строку и отправляю их в лист
                var a = item.ToString();
                ListMyCart.Add(a);

                MessageBox.Show("was added");

            }
        }


        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            //удалить заказ (удаляет весь список, позже можно настроить, чтобы поштучно удалял)
            if (list_myCart.Items.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни одного товара!");
                return;
            }
            list_myCart.Items.Clear();
            ListMyCart.Clear();
        }

        private void order_botton_Click(object sender, RoutedEventArgs e)
        {

            Catalogue itemname = new Catalogue();
            //оформить заказ (отправляю новые данные в таблицу бд Orders)
            int purchase = 0;
            Dictionary<string, int> dictItems = new Dictionary<string, int>();
            using (var c = new Context())
            {
                foreach (string item in ListMyCart)
                { 
                    ListOrders.Add(item);
                    //отрываю название от цены)
                    string[] a = item.Split(' ');
                    int price = Convert.ToInt32(a[1]);
                    itemname.ItemName = a[0];

                    listBox_orders.Items.Add(a[0] + " " + price.ToString() + "$");

                    string tovar = a[0];
                    foreach (var resultItem in c.Orders)
                    {
                        dictItems.Add(resultItem.ItemName, resultItem.Cost);
                    }
                    int outItem;
                   if (dictItems.TryGetValue(tovar, out outItem))
                    {  //не воркает(
                       //result почему-то приходит null

                        //var result = c.Orders.FirstOrDefault(t => (tovar == itemname.ItemName) && (price == t.Cost));

                        /* сюда дописать нужно переменную поиска клиента по логину и все, остальное дописывается из класса Админ */
                        c.SaveChanges();
                    }
                    //c.Orders.Add(new Orders
                    //{

                    //    ItemName = itemname,
                    //    Cost = price
                    //});
                    //c.SaveChanges();
                        purchase += price;
                }
                totalCost.Content = purchase.ToString() + "$";
                if (list_myCart.Items.Count == 0)
                {
                    MessageBox.Show("Вы не выбрали ни одного товара!");
                    return;
                }
                MessageBox.Show("Заказано");
                list_myCart.Items.Clear();



            }

            senter.ShowDialog();
            Close();
        }

        public void ClientNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        public void ClientSurnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in repo.DeletedItems)
            {
                var a = item.ToString();
                MessageBox.Show(a);
            }
        }

        private void list_myCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StatusButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_exl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            login l = new login();
            l.ShowDialog();
        }
    }
}


