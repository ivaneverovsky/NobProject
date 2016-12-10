using Company.Data;
using System;
using System.Collections;
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
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile_Client : Window
    {
        public profile_Client()
        {
            InitializeComponent();
        }

        Repository repo = new Repository();

        private void button_show_catalogue_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                //подумать здесь над логикой

                listView_myCatalogue.Items.Clear();
                listView_myCatalogue.Items.Refresh();
                var newList = repo.CompanyCatalogue();
                foreach (var item in newList)
                {
                    listView_myCatalogue.Items.Add(item);
                }
            } 
            //button_show_catalogue.IsEnabled = false;
        }

        private void listView_myCatalogue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //это не нужно, нужно будет найти какую-то ссылку, чтобы это потом удалить, если сейчас убрать, то приложуха падать будет
        }

        private void listView_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //добавление содержимого из списка (бд) в заказ (order) бокс

            DependencyObject obj = (DependencyObject)e.OriginalSource;

            listView_myCatalogue.Items.Refresh();

            while (obj != null && obj != listView_myCatalogue)
            {
                if (obj.GetType() == typeof(ListViewItem))
                {
                    list_myOrders.Items.Add(obj);
                    MessageBox.Show("A List's Item was added to your Order List!");

                    break;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
        }

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            //удалить заказ
            list_myOrders.Items.Clear();
        }

        private void order_botton_Click(object sender, RoutedEventArgs e)
        {
            //конвентирование items из ListViewItem в строку
            //List<string> list_Client_Orders = list_myOrders.Items.Cast<ListViewItem>()
            //        .Select(b => b.ToString())
            //        .ToList();

            //оформить заказ (отправляю новые данные в таблицу бд Orders)

            list_myOrders.Items.Cast<string>().ToList();

            using (var c = new Context())
            {
                //var OrderClientList = list_myOrders.Items.Cast<string>().ToList();

                foreach (var item in list_myOrders.Items)
                {
                    //string a = "INSERT INTO PROCESS_LOGS VALUES (@ItemName, @Cost)";

                }
            }
        }
    }
}
