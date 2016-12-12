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
            Client Client = new Client();
            profile_Client client = new profile_Client();
            Admin Admin = new Admin();
            profile_Admin admin = new profile_Admin();
            Supplier Supplier = new Supplier();
            profile_Supplier supplier = new profile_Supplier();
            login Login = new login();
            Context Context = new Context();
            

            

            //добавить, после настройки пункта enter_Click
            if ( loginBox.Text == Context.Clients.ToString() && passwordBox.Text == Context.Clients.ToString())
            {
                Close();
                client.ShowDialog();

            }
            if (loginBox.Text == Admin.login && passwordBox.Text == Admin.password )
            {
                Close();
                admin.ShowDialog();
            }
            if (loginBox.Text == Supplier.login && passwordBox.Text == Supplier.password)
            {
                Close();
                supplier.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы ввели неверные данные, повторите ещё раз");
                //break - надо с этим сделать, а то этот месседж вылезает при закрытии проги
                //либо не надо)
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
