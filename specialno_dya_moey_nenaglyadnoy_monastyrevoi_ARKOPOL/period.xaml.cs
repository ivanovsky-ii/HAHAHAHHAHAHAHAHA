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
    /// Логика взаимодействия для period.xaml
    /// </summary>
    public partial class period : Window
    {
        public period()
        {
            InitializeComponent();
        }

        private void check_period_btn_Click(object sender, RoutedEventArgs e)
        {
            var rent_of_cost = conn.en.haha.ToList();

             List <string> GAP = new List<string>();

            foreach (haha ha in rent_of_cost)
            {
                GAP.Add($"{ha.adress} принесла прибыль от аренды: {ha.rent_price}");
            }

            string final_sting = "";

            foreach (string str in GAP)
            {
                final_sting += str + "\n";
            }

            var summary_price = conn.en.haha.Sum(o => o.rent_price).ToString();

            MessageBox.Show($"{final_sting} \n общая прибыль:{summary_price}");
 

        }

        private void start_period_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var start_money = (DateTime)start_period.SelectedDate;
        }

        private void end_period_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var end_money = (DateTime)end_period.SelectedDate;
        }

        private void back_to_market_view_btn_Click(object sender, RoutedEventArgs e)
        {
            view_market vm = new view_market();
            vm.Show();
            this.Close();
        }
    }
}
