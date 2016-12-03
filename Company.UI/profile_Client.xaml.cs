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
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile_Client : Window
    {
        public profile_Client()
        {
            InitializeComponent();
        }

        Repository repo = new Repository();

        private void button_show_catalogue_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                listView_myCatalogue.Items.Refresh();

                var newList = repo.CompanyCatalogue();
                foreach (var item in newList)
                {
                    listView_myCatalogue.Items.Add(item);
                }
            }
            button_show_catalogue.IsEnabled = false;
        }

        private void listView_myCatalogue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
