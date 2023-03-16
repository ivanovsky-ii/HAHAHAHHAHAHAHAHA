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

       

        private void sort_btn_Click(object sender, RoutedEventArgs e)
        {
            decimal low_price = Convert.ToDecimal(low_price_tb.Text);
            decimal high_price = Convert.ToDecimal(high_price_tb.Text);
            int low_amount_rooms = Convert
            .ToInt32(low_price_tb.Text);
            int high_amount_rooms = Convert
            .ToInt32(high_amount_rooms_tb.Text);

            viewLV.ItemsSource = conn.en.flat.Where(i => i.rent_price <= high_price && i.rent_price >= low_price && i.amount_rooms >= low_amount_rooms&& i.amount_rooms <= high_amount_rooms).OrderByDescending(i => i.rent_price).ToList();

            //view_window w = new view_window();
            //w.Show();
            //this.Close();
        }
    }
}
