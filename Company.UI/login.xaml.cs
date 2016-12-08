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

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            
            //должен прочитать инфомацию из текст боксов, отправить ее на сервер,
            //где должен сравнить ее с данными в базе и вернуть значение, которое в дальнейшем откроет профиль пользователя
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            //добавить, после настройки пункта enter_Click

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
