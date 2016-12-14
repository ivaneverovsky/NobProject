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
            int selectedIndex = type.SelectedIndex;

            int x = 0;
            string[] a = name.ToString().Split(' ');
            string[] b = surname.ToString().Split(' ');
            string[] c = Login.ToString().Split(' ');
            string[] d = password.ToString().Split(' ');

            if (a.Length == 2)
            {
                x = x + 1;
                label1.Visibility = Visibility.Hidden;
            }
            else
            {
                label1.Visibility = Visibility.Visible;
            }

            if (b.Length == 2)
            {
                x = x + 1;
                label2.Visibility = Visibility.Hidden;
            }
            else
            {
                label2.Visibility = Visibility.Visible;
            }

            if (c.Length == 2)
            {
                label3.Visibility = Visibility.Hidden;
                if (Comparing(c[1]))
                {
                    x = x + 1;
                    label5.Visibility = Visibility.Hidden;
                }
                else
                {
                    label5.Visibility = Visibility.Visible;
                }
            }
            else
            {
                label3.Visibility = Visibility.Visible;
            }

            if (d.Length == 2)
            {
                x = x + 1;
                label4.Visibility = Visibility.Hidden;
            }
            else
            {
                label4.Visibility = Visibility.Visible;
            }


            //Разделяю данные в ListOrders
            if (x == 4)
            {
                using (var g = new Context())
                {
                    switch (selectedIndex)
                    {
                        case 2:
                            g.Suppliers.Add(new Supplier
                            {

                                Name = a[1],
                                Surname = b[1],
                                login = c[1],
                                password = d[1]
                            }
                            );
                            break;
                        case 3:
                            g.Admins.Add(new Admin
                            {

                                Name = a[1],
                                Surname = b[1],
                                login = c[1],
                                password = d[1]
                            }
                            );
                            break;
                        default:
                            g.Clients.Add(new Client
                            {

                                Name = a[1],
                                Surname = b[1],
                                login = c[1],
                                password = d[1]
                            }
                            );
                            break;
                    }
                    g.SaveChanges();
                }
                MessageBox.Show("Пользователь сохранен");

                //при нажатии данные отправляются в бд и записываются
                //возвращение к окну входа(логин), после записи данных в бд!
                login log = new login();
                Close();
                log.ShowDialog();
            }
        }

        private void Cancel_Click_1(object sender, RoutedEventArgs e)
        {
            //возвращение к окну входа(логин)
            login log = new login();
            Close();
            log.ShowDialog();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private static bool Comparing(string NewLogin)
        {
            bool k = true;

            List<string> ListLogins = new List<string>();

            using (var context = new Context())
            {
                foreach (var login in context.Clients)
                {
                    var a = login.login.ToString();
                    ListLogins.Add(a);
                }
                foreach (var login in context.Suppliers)
                {
                    var a = login.login.ToString();
                    ListLogins.Add(a);
                }
                foreach (var login in context.Admins)
                {
                    var a = login.login.ToString();
                    ListLogins.Add(a);
                }
            }

            foreach (string item in ListLogins)
            {
                if (item == NewLogin)
                {
                    k = false;
                }
            }
            return k;
        }
    }
}
