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

        //по кнопке показываю базу данных Админу
        private void button_Show_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                listBox_myCatalogue.Items.Clear();
                listBox_Orders.Items.Clear();

                ListCatalogue = c.Catalogue.ToList();
                ListOrders = c.Orders.ToList();

                //сказочный цикл :)
                //foreach (var item in ListCatalogue)
                //{
                //    foreach (var deleteditem in repo.DeletedItems)
                //    {
                //        var a = deleteditem.ToString();
                //        string[] split = a.Split(' ');
                //        var newshit = split[0];

                //        for (int i = 0; i < ListCatalogue.Count; i++)
                //        {
                //            if (ListCatalogue[i].ItemName == newshit)
                //            {
                //                ListCatalogue.Remove(item);
                //            }
                //        }
                //    }
                //}

                //показываю лист бд админу
                foreach (Catalogue item in ListCatalogue)
                {
                    listBox_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
                }
                //показываю заказы админу
                foreach (Orders item in ListOrders)
                {
                    string itemname = item.ItemName.ItemName;
                    //string nameClient = item.Client.Name;
                    //string nameAdmin = item.Admin.Name;

                    listBox_Orders.Items.Add(/*nameClient +*/" " + itemname + " " + item.Cost + "$ " + item.Status + " "/* + nameAdmin*/);
                }
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            //(1) оформляю ItemName
            var strItemname = textBox_newItem.Text.ToString();

            //удаляю пробелы в строке
            var str = strItemname;
            var newstr = str.Replace(" ", "");

            while (textBox_newItem.Text == "" || textBox_newItem.Text == " " || textBox_newItem.Text == null)
            {
                MessageBox.Show("Error in ItemName");
                textBox_newItem.Clear();
                return;
            }
            //пробую отправить в строку
            string itemname = Convert.ToString(newstr);

            //(2) оформляю Price
            var strPrice = textBox_newPrice.Text.ToString();

            //удаляю пробелы
            var pr = strPrice;
            var newpr = pr.Replace(" ", "");

            //отправляю в инт
            string price = newpr;

            int n;

            while (!int.TryParse(price, out n))
            {
                MessageBox.Show("error in Price");
                textBox_newPrice.Clear();
                return;
            }

            //добавляю в базу
            using (var c = new Context())
            {
                c.Catalogue.Add(new Catalogue
                {
                    ItemName = itemname,
                    Price = n
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

            //добавляем новый элемент в лист бд
            foreach (Catalogue item in ListCatalogue)
            {
                listBox_myCatalogue.Items.Add(item.ItemName + " " + item.Price);
            }
        }

        private void listBox_myCatalogue_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //удаление выбраных элементов по двойному щелчку мыши из листбокса и из листа Каталога

            foreach (var item in listBox_myCatalogue.SelectedItems)
            {
                //получаю индекс выбранного айтэма и удаляю из листа

                int index = listBox_myCatalogue.Items.IndexOf(item);
                ListCatalogue.RemoveAt(index);

                //добавляю в лист удаленных (строку)
                string deletedstr = item.ToString();
                repo.DeletedItems.Add(deletedstr);

                //удаляю из листбокса
                listBox_myCatalogue.Items.Remove(item);
                listBox_myCatalogue.Items.Refresh();

                
                //вызвать обязательно в конце цикла, а то падает
                break;
                //базу трогать не стал (много тонкостей), код оставлю закоменченным

                //int newID = index + 1;
                //using (var c = new Context())
                //{
                //    //ищет по айди элемент и удалает его (можно сделать наверное поиск по имени и цене, например)
                //    var ItemToRemove = c.Catalogue.SingleOrDefault(x => x.Id == newID);
                //    c.Catalogue.Remove(ItemToRemove);
                //    c.SaveChanges();
                //}


                //делим строку, берем два элемента, имя товара и цену
                //string[] newItem = a.Split(' ');
                //MessageBox.Show(newItem[0] + " for " + newItem[1] + "$");

                //var str1 = newItem[0];
                //var str2 = newItem[1];
                //}
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in repo.DeletedItems)
            {
                var a = item.ToString();
                MessageBox.Show(a);
            }
        }
    }
}
