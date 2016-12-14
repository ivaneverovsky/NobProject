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
        { Context cntxt = new Context();
            Repository repo = new Repository();
            profile_Client client = new profile_Client();
            profile_Admin admin = new profile_Admin();
            profile_Supplier supplier = new profile_Supplier();
            //repo.AuthorizationAdmin();
            //repo.AuthorizationAdmin();
            //repo.AuthorizationSupplier();
            Dictionary<string, string> dictSuppliersSurname = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var field in c.Suppliers)
                {
                    dictSuppliersSurname.Add(field.login, field.Name);
                }
            }
            Dictionary<string, string> dictSuppliersName = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var field in c.Suppliers)
                {
                    dictSuppliersName.Add(field.login, field.Surname);
                }
            }
            Dictionary<string, string> dictAdminsName = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var field in c.Admins)
                {
                    dictAdminsName.Add(field.login, field.Name);
                }
            }
            Dictionary<string, string> dictAdminsSurname = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var field in c.Admins)
                {
                    dictAdminsSurname.Add(field.login, field.Surname);
                }
            }
            Dictionary<string, string> dictClientsName = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var field in c.Clients)
                {
                    dictClientsName.Add(field.login, field.Name);
                }
            }
            Dictionary<string, string> dictClientsSurname = new Dictionary<string, string>();
            using (var c = new Context())
            {
                foreach (var field in c.Clients)
                {
                    dictClientsSurname.Add(field.login, field.Surname);
                }
            }
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





            string ClientName;
            string ClientSurname;
            //добавить, после настройки пункта enter_Click
            if (dictAuthClient.TryGetValue(loginBox.Text,out test))
            { 
                foreach (var item in dictClientsName)
                {
                    if (dictClientsName.TryGetValue(loginBox.Text, out ClientName) && dictClientsSurname.TryGetValue(loginBox.Text, out ClientSurname))
                    {
                        client.ClientNameBox.Text = ClientName;
                        client.ClientSurnameNameBox.Text = ClientSurname;
                    }
                }
                  
                
                Close();
                client.ShowDialog();

                return; 
                }

            string AdminName;
            string AdminSurname;
            if (dictAuthAdmin.TryGetValue(loginBox.Text,out test))
            {
                if (dictAdminsName.TryGetValue(loginBox.Text, out AdminName) && dictAdminsSurname.TryGetValue(loginBox.Text, out AdminSurname))
                {
                    admin.AdminNameBox.Text = AdminName;
                    admin.AdminSurnameBox.Text = AdminSurname;
                }

                Close();
                admin.ShowDialog();
                return;
                
            }
            string SupplierName;
            string SupplierSurname;
            if (dictAuthSupplier.TryGetValue(loginBox.Text,out test))
            {
                if (dictSuppliersName.TryGetValue(loginBox.Text, out SupplierName) && dictSuppliersSurname.TryGetValue(loginBox.Text, out SupplierSurname))
                {
                    supplier.SupplierNameBox.Text = SupplierName;
                    supplier.SupplierSurnameBox.Text = SupplierSurname;
                }
                Close();
                supplier.ShowDialog();
                return;
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
