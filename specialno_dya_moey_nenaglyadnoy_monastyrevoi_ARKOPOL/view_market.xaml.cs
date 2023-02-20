using specialno_dya_moey_nenaglyadnoy_monastyrevoi_ARKOPOL.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для view_market.xaml
    /// </summary>
    public partial class view_market : Window
    {

        public view_market()
        {
            InitializeComponent();

            var status_in_lv = conn.en.status.Where(oo => oo.name == "свободна").Select(oo => oo.id).FirstOrDefault();
            view_market_agent.ItemsSource = conn.en.flat.Where(oo => oo.flat_status == status_in_lv).ToList();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void add_reprice_btn_Click(object sender, RoutedEventArgs e)
        {
            var selected = ((flat)view_market_agent.SelectedItem).id;
            var flat = conn.en.flat.Where(u => u.id == selected).FirstOrDefault();

            flat.cad_price = Convert.ToDecimal(cadpr_tb.Text);
            flat.market_price = Convert.ToDecimal(marketpr_tb.Text);
            flat.rent_price = Convert.ToDecimal(rentpr_tb.Text);

            conn.en.flat.AddOrUpdate(flat);
            conn.en.SaveChanges();
            MessageBox.Show("расценка успешно обновлена");
        }

        private void view_market_agent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cadprice_change = conn.en.flat.Where(i => i.id == ((flat)view_market_agent.SelectedItem).id).Select(i => i.cad_price).FirstOrDefault();
            var marketprice_change = conn.en.flat.Where(i => i.id == ((flat)view_market_agent.SelectedItem).id).Select(i => i.market_price).FirstOrDefault();
            var rentprice_change = conn.en.flat.Where(i => i.id == ((flat)view_market_agent.SelectedItem).id).Select(i => i.rent_price).FirstOrDefault();

            cadpr_tb.Text = Convert.ToString(cadprice_change);
            marketpr_tb.Text = Convert.ToString(marketprice_change);
            rentpr_tb.Text = Convert.ToString(rentprice_change);
        }

        private void check_money_Click(object sender, RoutedEventArgs e)
        {
            period p = new period();
            p.Show();
            this.Close();
        }
    }
}
