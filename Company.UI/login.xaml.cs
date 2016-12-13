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
        List<Client> ListClients = new List<Client>();

        public void enter_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            profile_Client client = new profile_Client();
            profile_Admin admin = new profile_Admin();
            profile_Supplier supplier = new profile_Supplier();

            Dictionary<string, string> dictAuthClient = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var login in c.Clients)
                {
                    dictAuthClient.Add(login.login, login.password);
                }
            }
            Dictionary<string, string> dictAuthAdmin = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var login in c.Admins)
                {
                    dictAuthAdmin.Add(login.login, login.password);
                }
            }
            Dictionary<string, string> dictAuthSupplier = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var login in c.Suppliers)
                {
                    dictAuthSupplier.Add(login.login, login.password);
                }
            }
            string test;
            





            //добавить, после настройки пункта enter_Click
            if (dictAuthClient.TryGetValue(loginBox.Text,out test))
            {
                Close();
                client.ShowDialog();
            }
            
            if (dictAuthAdmin.TryGetValue(loginBox.Text,out test))
            {
                Close();
                admin.ShowDialog();
                
            }
            if (dictAuthSupplier.TryGetValue(loginBox.Text,out test))
            {
                Close();
                supplier.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Вы ввели неверные данные, повторите ещё раз");
                // break -надо с этим сделать, а то этот месседж вылезает при закрытии проги
                //  либо не надо)
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
