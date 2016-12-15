using System;
using System.Net;
using System.Net.Mail;

namespace Company.Data.EmailNotifier
{
    class EmailNotifier
    {
        private string _mailTo;
        
        public void Notify(StatusChangedEvent ischanged)
        {
            using (var mes = new MailMessage())
            {
                string yourMail = "your_email@gmail.com";
                string password = "***********";
                mes.From = new MailAddress(yourMail);
                mes.To.Add(new MailAddress(_mailTo));
                mes.Subject = "Notification";
                mes.Body = String.Format("On {0} at {1} in {2} you have {3} (i.e. {4})",
                ischanged.DateTime.Date.ToString("dd.MM.yyyy"), ischanged.DateTime.ToString("HH:mm"), ischanged.Place, ischanged.Name, ischanged.Description);
                using (var client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(yourMail, password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mes);
                }
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="adressTo">a receiver's address</param>
        public EmailNotifier(string adressTo)
        {
            _mailTo = adressTo;
        }
    }
}

