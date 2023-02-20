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
    /// Логика взаимодействия для redact.xaml
    /// </summary>
    public partial class redact : Window
    {
        public redact()
        {
            InitializeComponent();

            LV.ItemsSource = conn.en.flat.ToList();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
