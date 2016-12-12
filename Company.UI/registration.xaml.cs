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
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {

        List<string> ListNewUser = new List<string>();

        public registration()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var a = name.ToString();
            ListNewUser.Add(a);

            var b = surname.ToString();
            ListNewUser.Add(b);

            var c = login.ToString();
            ListNewUser.Add(c);

            var d = password.ToString();
            ListNewUser.Add(d);

            //Разделяю данные в ListOrders
            using (var g = new Context())
            {
                foreach (string item in ListNewUser)
                {
                    //отделяю элементы
                    string[] f = item.Split(' ');
                    //int price = Convert.ToInt32(f[1]);
                    //var itemname = new Catalogue { ItemName = f[0] };

                    g.Orders.Add(new Orders
                    {
                        //ItemName = itemname,
                        //Cost = price
                    });
                    g.SaveChanges();
                }
                MessageBox.Show("Пользователь сохранен");
                ListNewUser.Clear();
            }

            //при нажатии данные отправляются в бд и записываются
            //возвращение к окну входа(логин), после записи данных в бд!
            login log = new login();
            Close();
            log.ShowDialog();
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
