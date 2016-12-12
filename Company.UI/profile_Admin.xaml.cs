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
    /// Логика взаимодействия для profile_Admin.xaml
    /// </summary>
    public partial class profile_Admin : Window
    {
        public profile_Admin()
        {
            InitializeComponent();
        }

        Repository repo = new Repository();
        List<Catalogue> ListCatalogue = new List<Catalogue>();
        List<Orders> ListOrders = new List<Orders>();

        private void button_Show_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                listBox_myCatalogue.Items.Clear();
                listBox_myCatalogue.Items.Refresh();
                listBox_Orders.Items.Clear();
                listBox_Orders.Items.Refresh();

                ListCatalogue = c.Catalogue.ToList();
                ListOrders = c.Orders.ToList();

                foreach (Catalogue item in ListCatalogue)
                {
                    listBox_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
                }
                foreach (Orders item in ListOrders)
                {
                    listBox_Orders.Items.Add(item.Client + " " + item.ItemName + " " + item.Cost + " " + item.Status + " " + item.Admin);
                }
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            //конвертация тексбоксов в нужный формат, подумать над более оптимальным решением
            //и использовать здесь try catchб ибо падать будет, если не сможет конвертировать
            
            //(1) оформляю ItemName
            var strItemname = textBox_newItem.Text.ToString();

            //удаляю пробелы в строке
            var str = strItemname;
            var newstr = str.Replace(" ", "");

            //пробую отправить в строку
            string itemname = Convert.ToString(newstr);

            //(2) оформляю Price
            var strPrice = textBox_newPrice.Text.ToString();

            //удаляю пробелы
            var pr = strPrice;
            var newpr = pr.Replace(" ", "");

            //отправляю в инт
            int price = Convert.ToInt32(newpr);

            //добавляю в базу
            using (var c = new Context())
            {
                c.Catalogue.Add(new Catalogue
                {
                    ItemName = itemname,
                    Price = price
                });
                c.SaveChanges();

                //добавляю в лист
                ListCatalogue = c.Catalogue.ToList();
            }

            //чистим боксы
            textBox_newItem.Clear();
            textBox_newPrice.Clear();

            //чистим листбокс
            listBox_myCatalogue.Items.Clear();
            listBox_myCatalogue.Items.Refresh();

            //добавляем новый элемент в листбокс
            foreach (Catalogue item in ListCatalogue)
            {
                listBox_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
            }
        }

        private void listBox_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //удаление выбраных элементов по двойному щелчку мыши из листбокса и из базы

            //пока не работает
            foreach (var item in listBox_myCatalogue.SelectedItems)
            {
                //удаляю из листбокса
                //listBox_myCatalogue.Items.Remove(item);

                var a = item.ToString();
                string[] newItem = a.Split(' ');
                MessageBox.Show(newItem[0] +" for "+ newItem [1]+"$");

                var str1 = newItem[0];
                var str2 = newItem[1];

                
                //ListCatalogue.Contains(a);
            }
        }
    }
}
