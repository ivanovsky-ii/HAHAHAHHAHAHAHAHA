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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace specialno_dya_moey_nenaglyadnoy_monastyrevoi_ARKOPOL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void au_btn_Click(object sender, RoutedEventArgs e)
        {
            var usr = conn.en.login.Where(i => i.login1 == login_tbx.Text && i.password == password_pbx.Password).FirstOrDefault();

            if (usr != null)
            {
                if(usr.role == "rent")
                {
                    MessageBox.Show($"вы вошли как менеджер по аренде");
                    view_market r = new view_market();
                    r.Show();
                    this.Close();
                }
                else if (usr.role == "market")
                {
                    MessageBox.Show($"вы вошли как менеджер по продажам");
                    add a = new add();
                    a.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("ты кто такой?!");
            }
        }
    }
}
