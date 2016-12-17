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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Company.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class login : Window
    {


        public login()
        {
            InitializeComponent();
        }


        public void enter_Click(object sender, RoutedEventArgs e)
        {

            profile_Client client = new profile_Client();
            profile_Admin admin = new profile_Admin();
            profile_Supplier supplier = new profile_Supplier();
            Repository repo = new Repository();

            string test;
            string ClientName;
            string ClientSurname;
            //добавить, после настройки пункта enter_Click
            if (repo.DictAuthClient().TryGetValue(loginBox.Text, out test))
            {


                if (repo.DictNameClient().TryGetValue(loginBox.Text, out ClientName) && repo.DictSurnameClient().TryGetValue(loginBox.Text, out ClientSurname))
                {
                    client.labelName.Content = ClientName;
                    client.labelSurname.Content = ClientSurname;
                }



                if (test == passwordBox.Text)
                {
                    Close();
                    client.ShowDialog();
                    return;
                }


            }

            string AdminName;
            string AdminSurname;
            if (repo.DictAuthAdmin().TryGetValue(loginBox.Text, out test))
            {
                if (repo.DictNameAdmin().TryGetValue(loginBox.Text, out AdminName) && repo.DictSurnameAdmin().TryGetValue(loginBox.Text, out AdminSurname))
                {
                    admin.labelName.Content = AdminName;
                    admin.labelSurname.Content = AdminSurname;
                }

                if (test == passwordBox.Text)
                {
                    Close();
                    admin.ShowDialog();
                    return;
                }


            }
            string SupplierName;
            string SupplierSurname;
            if (repo.DictAuthSupplier().TryGetValue(loginBox.Text, out test))
            {


                if (repo.DictNameSupplier().TryGetValue(loginBox.Text, out SupplierName) && repo.DictSurnameSupplier().TryGetValue(loginBox.Text, out SupplierSurname))
                {
                    supplier.labelName.Content = SupplierName;
                    supplier.labelSurname.Content = SupplierSurname;
                }
                if (test == passwordBox.Text)
                {
                    Close();
                    supplier.ShowDialog();
                }



            }
            else
            {
                MessageBox.Show("Вы ввели неверные данные, повторите ещё раз");
                return;


            }
            //должен прочитать инфомацию из текст боксов, сравнить ее с данными в базе
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration();

            Close();
            reg.ShowDialog();
            //откроет новое окно, пользователь вводит данные и выбирает свой тип профиля,
            //считывается и отправляется на сервер, где данные после вносятся в базу,
            //в этот момент открывается опять окно входа, и по новой (см. выше)
        }

        private void ConnectToServer_Click(object sender, RoutedEventArgs e)
        {
            //подключаемся к серверу
        }
    }
}
