using specialno_dya_moey_nenaglyadnoy_monastyrevoi_ARKOPOL.DB;
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

namespace specialno_dya_moey_nenaglyadnoy_monastyrevoi_ARKOPOL
{
    /// <summary>
    /// Логика взаимодействия для view_window.xaml
    /// </summary>
    public partial class view_window : Window
    {
        public view_window()
        {
            InitializeComponent();
            viewLV.ItemsSource = conn.en.flat.ToList();
        }

        

        private void price_filter_Checked(object sender, RoutedEventArgs e)
        {
            if (price_filter.IsChecked == true)
            {
                viewLV.ItemsSource = conn.en.flat.OrderByDescending(o => o.cad_price).ToList();
            }
            else
            {
                viewLV.ItemsSource = conn.en.flat.ToList();
            }
        }

        private void amount_rooms_filter_Checked(object sender, RoutedEventArgs e)
        {
            if (amount_rooms_filter.IsChecked == true)
            {
                viewLV.ItemsSource = conn.en.flat.OrderByDescending(o => o.amount_rooms).ToList();
            }
            else
            {
                viewLV.ItemsSource = conn.en.flat.ToList();
            }
        }
    }
}
