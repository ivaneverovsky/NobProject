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
        profile_Client clientInfo = new profile_Client();

        private void EmailLoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailPassBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SentButton_Click(object sender, RoutedEventArgs e)
        {
            var a = clientInfo.listBox_orders;
            string name = clientInfo.labelName.Content.ToString();
            string surname = clientInfo.labelSurname.Content.ToString();

            string to = EmailLoginBox.Text;
            string from = "thenobproject@gmail.com";
            string password = "Missisippi";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Your Order!";
            message.Body = string.Format("Dear {0} {1}! Your order have been accepted!\n\n Details: \n\n {2}\n\n", name, surname, a);
            message.To.Add(new MailAddress(to));
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            try
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
            }
            catch (Exception v)
            {
                throw new Exception("Mail: " + v.Message);
            }
            MessageBox.Show("Письмо было отправлено Вам на почту!");
            Close();
        }
    }
}
