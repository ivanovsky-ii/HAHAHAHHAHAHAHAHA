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
            var status_in_sale = conn.en.status.Where(oo => oo.name == "свободна").Select(oo => oo.id).FirstOrDefault();
            var status_in_rent = conn.en.status.Where(oo => oo.name == "арендована").Select(oo => oo.id).FirstOrDefault();
            var status_in_market = conn.en.status.Where(oo => oo.name == "в продаже").Select(oo => oo.id).FirstOrDefault();



            var transactions_cadastr = conn.en.flat.Where(o => o.date_build >= (DateTime)start_period.SelectedDate && o.date_build <= (DateTime)end_period.SelectedDate).Sum(o => o.cad_price).ToString();
            var transactions_market = conn.en.flat.Where(o => o.date_build >= (DateTime)start_period.SelectedDate && o.date_build <= (DateTime)end_period.SelectedDate).Sum(o => o.market_price).ToString();
            var transactions_rent = conn.en.flat.Where(o => o.date_build >= (DateTime)start_period.SelectedDate && o.date_build <= (DateTime)end_period.SelectedDate).Sum(o => o.rent_price).ToString();

            MessageBox.Show($"Общая прибыль за выбранный период: \n За покупки: {Convert.ToDecimal(transactions_market) - Convert.ToDecimal(transactions_cadastr)} \n  За аренду: {transactions_rent}");
            
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
