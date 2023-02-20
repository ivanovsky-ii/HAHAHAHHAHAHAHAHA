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
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : Window
    {
        flat f =new flat();
        public add()
        {
            InitializeComponent();

            winplace_cb.ItemsSource = conn.en.window.ToList();
            toitype_cb.ItemsSource = conn.en.toilet_type.ToList();
            flat_status.ItemsSource = conn.en.status.ToList();
        }

        private void add_new_record_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.floor = Convert.ToInt32(floor_tb.Text);
                f.floor_apart = Convert.ToInt32(floor_apat_tb.Text);
                f.date_build = (DateTime)ya_kalendar.SelectedDate;
                f.window_placement = ((window)winplace_cb.SelectedItem).id;
                f.amount_rooms = Convert.ToInt32(amount_rooms_tb.Text);
                f.amount_toilet = Convert.ToInt32(amount_toilet_tb.Text);
                f.toilet_type = ((toilet_type)toitype_cb.SelectedItem).id;
                f.cad_price = Convert.ToDecimal(cad_price_tb.Text);
                f.have_cond = conditer_chb.IsChecked;
                f.market_price = Convert.ToDecimal(market_price_tb.Text);
                f.rent_price = Convert.ToDecimal(rent_price_tb.Text);
                f.flat_status = ((status)flat_status.SelectedItem).id;


                conn.en.flat.Add(f);
                conn.en.SaveChanges();
                MessageBox.Show("запись создана успешно!");

                floor_tb.Text = ""; 
                floor_apat_tb.Text = "";
                ya_kalendar.Text = "";
                winplace_cb.Text = "";
                amount_rooms_tb.Text = "";
                amount_toilet_tb.Text = "";
                toitype_cb.Text = "";
                cad_price_tb.Text = "";
                conditer_chb.IsChecked = false;
                market_price_tb.Text = "";
                flat_status.Text = "";
            }
            catch
            {
                MessageBox.Show("неудачно! возникла ошибка");
            }
        }

        private void go_to_view_btn_Click(object sender, RoutedEventArgs e)
        {
            view_window i = new view_window();
            i.Show();
        }
    }
}
