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
using System.Net;
using System.Net.Mail;
using Company.Data;

namespace Company.UI
{
    /// <summary>
    /// Логика взаимодействия для EmailSenter.xaml
    /// </summary>
    public partial class EmailSenter : Window
    {
        public EmailSenter()
        {
            InitializeComponent();
        }



        private void EmailLoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailPassBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SentButton_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            //беру имя и фамилию зашедшего
            //var name = new List<string>();
            //foreach (var item in repo.DictNameClient().Values)
            //    name.Add(item.ToString());
            //var surname = new List<string>();
            //foreach (var item in repo.DictSurnameClient().Values)
            //    surname.Add(item.ToString());

            ////в строку
            //var namestr = name[0].ToString();
            //var surnamestr = surname[0].ToString();



            try
            {
                string to = EmailLoginBox.Text;
                string from = "thenobproject@gmail.com";
                string password = "Missisippi";
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Your Order!";
                message.Body = string.Format("Dear Client! Your order have been accepted!");
                message.To.Add(new MailAddress(to));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
            }
            catch (Exception)
            {
                MessageBox.Show("You've entered incorrect Email adress!");
                return;
            }
            Hide();
            MessageBox.Show("The confirmation was sent to your Email!");

        }



    }
}
