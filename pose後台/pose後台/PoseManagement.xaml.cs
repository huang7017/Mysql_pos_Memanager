using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
namespace pose後台
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>

    public partial class Window1 : Window
    {
        private string user;
        private string paswd;
        private DateTime now = DateTime.Now;
        private string sql,orderNumber = "", commodity = "", PurchaseCost = "", OrderQuantity = "";
        public Window1()
        {
            InitializeComponent();
        }
        public void setUser(string user)
        {
            this.user = user;
        }
        public void setPaswd(string paswd)
        {
            this.paswd = paswd;
        }
        public MySqlConnection Connect()
        {
            String connetStr = "server=127.0.0.1;port=3306;user =" + user + ";password = " + paswd + ";" + " database=store;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//開啟通道，建立連線，可能出現異常,使用try catch語句
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return conn;
        }
        private void sel(string sql)
        {
            MySqlConnection conn = Connect();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void updataSql()
        {
            string sql = "select orderNumber as 訂單編號,commodity as 商品,PurchaseCost as 單一數量成本,OrderQuantity as 訂購數量,orderDate as 日期  from orderform";
            MySqlConnection conn = Connect();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter myDa = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            myDa.Fill(dt);
            DataSql.DataContext = dt;
            sql = "SELECT commodityNumber as 商品編號,commodity as 商品,commodityCost as 價錢,sum(commodityQuantity) as 庫存數量 FROM inventory GROUP BY commodity";
            cmd = new MySqlCommand(sql, conn);
            myDa = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            myDa.Fill(dt);
            DataInventory.DataContext = dt;
            sql = " SELECT  commodityNumber as 商品編號,commodity as 商品,SaleCost as 銷售價錢,QuantitySale as 銷售數量,SaleDate as 日期 FROM store.quantitysale;";
            cmd = new MySqlCommand(sql, conn);
            myDa = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            myDa.Fill(dt);
            DataQuantitySale.DataContext = dt;
            conn.Close();
        }
        //更新按鈕
        private void Updata_Click(object sender, RoutedEventArgs e)
        {
            updataSql();
        }

        private void SaleUpdata_Click(object sender, RoutedEventArgs e)
        {
            updataSql();
        }

        //刪除按鈕
        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            setOrderClass("delete");
        }
        //新增按鈕
        private void Add_Click(object sender, RoutedEventArgs e)
        {
           sql = "insert into orderForm(commodity, PurchaseCost, OrderQuantity,orderDate) values(" + "'" + storeName.Text + "'," + int.Parse(coin.Text) + "," + int.Parse(number.Text) 
                + "," + now.ToString("yyyyMMdd") + ")";
            sel(sql);
            updataSql();
        }
        //更改
        private void Edite_Click(object sender, RoutedEventArgs e)
        {
            setOrderClass("UPDATE");
        }
        private void setOrderClass(string n)
        {
            for (int i = 0; i < this.DataSql.Items.Count; i++)
            {
                var cntr = DataSql.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DataSql.Columns[0].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        if (objElement.GetType().ToString().EndsWith("CheckBox"))
                        {
                            System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                            if (objChk.IsChecked == true)
                            {

                                orderNumber = ((DataRowView)this.DataSql.Items[i])["訂單編號"].ToString();
                                commodity = ((DataRowView)this.DataSql.Items[i])["商品"].ToString();
                                PurchaseCost = ((DataRowView)this.DataSql.Items[i])["單一數量成本"].ToString();
                                OrderQuantity = ((DataRowView)this.DataSql.Items[i])["訂購數量"].ToString();
                                if (n == "delete")
                                   sql = "delete from orderForm where orderNumber='" + int.Parse(orderNumber) + "'";
                                else if(n == "UPDATE")
                                    sql = "UPDATE orderForm Set commodity ='" + commodity + "', PurchaseCost = "
            + int.Parse(PurchaseCost) + ", OrderQuantity =" + int.Parse(OrderQuantity) + ",orderDate = " + now.ToString("yyyyMMdd") + " WHERE orderNumber =" + int.Parse(orderNumber);
                                sel(sql);
                            }
                        }
                    }
                }
            }
            updataSql();
        }
    }
}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}