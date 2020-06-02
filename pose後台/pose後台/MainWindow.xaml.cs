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
using MySql.Data.MySqlClient;
namespace pose後台
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = login.Text;
            string paswd = password.Password;
            String connetStr = "server=127.0.0.1;port=3306;user ="+user +";password = "+paswd+";"+" database=store;";//database是資料庫名字
                                                                                                                     // server=127.0.0.1/localhost 代表本機，埠號port預設是3306可以不寫
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//開啟通道，建立連線，可能出現異常,使用try catch語句
                //在這裡使用程式碼對資料庫進行增刪查改
                Window1 poseManagement = new Window1();
                poseManagement.setUser(user);
                poseManagement.setPaswd(paswd);
                poseManagement.updataSql();
                this.Close();
                poseManagement.Show();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
