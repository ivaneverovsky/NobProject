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

        List<object> ListOrders = new List<object>();
        //List<object> listOfItems = new List<object>();

        private void button_show_catalogue_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                //скачивание данных из базы и показ в листвью каталога
                listView_myCatalogue.Items.Clear();
                listView_myCatalogue.Items.Refresh();
                var newList = repo.CompanyCatalogue();

                foreach (var item in newList)
                {
                    listView_myCatalogue.Items.Add(item);


                }

            }
        }

        private void listView_myCatalogue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //это не нужно, нужно будет найти какую-то ссылку, чтобы это потом удалить, если сейчас убрать, то приложуха падать будет
        }

        private void listView_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //добавление содержимого из списка (бд) в заказ (order) бокс

            //возможно потребуется поменять листбокс этот на лист вью, как в каталоге, потому что как разконвертить эту дичь, я не знаю
            //можно сделать также, как и в первом, просто показывать элементы, которые были выбраны, но 
            //выбранные клиентом данные мы будем загружать в лист, объявленный в верху (ListOrders), потому что так надо))
            //вот, и из этого листа мы будем отправлять данные в таблицу заказов

            foreach (var item in listView_myCatalogue.SelectedItems)
            {
                ListOrders.Add(item);
                list_myOrders.Items.Add(item);
                MessageBox.Show("item was added");
            }
        }


        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            //удалить заказ
            list_myOrders.Items.Clear();
        }

        private void order_botton_Click(object sender, RoutedEventArgs e)
        {
            //оформить заказ (отправляю новые данные в таблицу бд Orders)

            //нужно залезть в ListOrders и из него данные присвоить значениям в таблице Orders и отправить их в базу

            for (int i = 0; i < ListOrders.Count; i++)
            {
                using (var c = new Context())
                {
                    c.Orders.Add(new Orders
                    {

                    });
                    c.SaveChanges();


                }
            }
            var ListOfOrders = repo.CompanyOrders();
            foreach (var item in ListOrders)
            {
                ListOfOrders.Add(item);
            }

        }
    }
}
