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

        public registration()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {

            string[] a = name.ToString().Split(' ');
            string[] b = surname.ToString().Split(' ');
            string[] c = login.ToString().Split(' ');
            string[] d = password.ToString().Split(' ');

            //Разделяю данные в ListOrders
            using (var g = new Context())
            {
                g.Clients.Add(new Client
                {
                        
                        Name = a[1],
                        Surname = b[1],
                        login = c[1],
                        password = d[1]
                }
                );
                g.SaveChanges();
            }
                MessageBox.Show("Пользователь сохранен");
            

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
