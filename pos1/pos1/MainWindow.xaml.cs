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
using System.Collections;
using System.Data;
using System.Collections.ObjectModel;

namespace pos1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt = new DataTable();

        DataColumn commodity = new DataColumn("飲料");
        DataColumn Quantity = new DataColumn("數量");
        DataColumn Cost = new DataColumn("金額");
        public MainWindow()
        {
            InitializeComponent();
            //设置全屏
            this.Left = 0.0;
            this.Top = 0.0;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            QuantitytextBox.AddHandler(TextBox.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.MouseEnter), true);
            CostTextBox.AddHandler(TextBox.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.MouseEnter), true);
            dt.Columns.Add(commodity);
            dt.Columns.Add(Quantity);
            dt.Columns.Add(Cost);
            DynamicOderButton();
        }
        //mysql連線
        public MySqlConnection Connect()
        {
            String connetStr = "server=127.0.0.1;port=3306;user =" + "root" + ";password = " + "H411033" + ";" + " database=store;";
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

        private MySqlDataReader sel(string sql)
        {
            try
            {
                MySqlConnection conn = Connect();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private void buttonNumber(object sender, RoutedEventArgs e)
        {
            if (t != null)
                t.Text += (sender as Button).Content.ToString();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DynamicOderButton()
        {
            ArrayList list = new ArrayList();
            list = getOder("SELECT * FROM inventory GROUP BY commodity", "commodity");
            for (int i = 0; i < list.Count; i++)
            {

                Button button = new Button();
                button.Width = 98;
                button.Height = 54;
                button.Content = list[i].ToString();
                this.OderButton.Children.Add(button);

                button.Click += OderButtons_Click;
            }

        }
        private ArrayList getOder(string str, string m)
        {
            MySqlConnection conn = Connect();
            MySqlDataReader reader = sel(str);
            conn.Close();
            ArrayList list = new ArrayList();
            try
            {
                while (reader.Read())//初始索引是-1，執行讀取下一行資料，返回值是bool
                {
                    list.Add(reader.GetString(m));
                }
            }
            catch(NullReferenceException)
            {
                return null;
            }

            return list;
        }
        private void OderButtons_Click(object sender, EventArgs e)
        {

            ArrayList list = new ArrayList();
            try
            {
                list.Add(getOder("SELECT commodityNumber FROM inventory where(commodity = \"" + (sender as Button).Content + "\" and commodityQuantity > 0)", "commodityNumber")[0]);
                list.Add(getOder("SELECT commodityCost FROM inventory where(commodity = \"" + (sender as Button).Content + "\" and commodityQuantity > 0)", "commodityCost")[0]);
                commoditytextBox.Text = (sender as Button).Content.ToString();
                QuantitytextBox.Text = "1";
                CostTextBox.Text = list[1].ToString();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("沒貨");
            }
        }
        TextBox t;
        private new void MouseEnter(object sender, MouseButtonEventArgs e)
        {
            t = (TextBox)sender;
            (sender as TextBox).Text = null;
        }

        private void Button_Edite_Click(object sender, RoutedEventArgs e)
        {
            QuantitytextBox.IsEnabled = true;
        }

        private void Button_clear_Click(object sender, RoutedEventArgs e)
        {
            commoditytextBox.Text = null;
            QuantitytextBox.Text = null;
            CostTextBox.Text = null;
            TotalBox.Text = null;
            dataGrid.Items.Clear();
        }
        int total = 0;
        private void Button_ok_Click(object sender, RoutedEventArgs e)
        {
            QuantitytextBox.IsEnabled = false;
            CostTextBox.IsEnabled = false;
            ArrayList list = new ArrayList();
            try
            {
                list.Add(getOder("SELECT sum(commodityQuantity) FROM inventory where commodity = \"" + commoditytextBox.Text + "\"", "sum(commodityQuantity)")[0]);
                if (int.Parse(QuantitytextBox.Text) <= int.Parse(list[0].ToString()))
                {
                    dataGrid.Items.Add(new { A = commoditytextBox.Text.ToString(), B = QuantitytextBox.Text.ToString(), C = CostTextBox.Text.ToString() });
                    total += int.Parse(QuantitytextBox.Text) * int.Parse(CostTextBox.Text);
                    TotalBox.Text = total.ToString();
                }
                else
                    MessageBox.Show("庫存數量:"+ list[0].ToString()+"\n超過庫存數量:" + (int.Parse(QuantitytextBox.Text) - int.Parse(list[0].ToString())));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("" + ex);
            }
            list.Clear();
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            string commoditystr, QuantityStr;
            MySqlConnection conn = Connect();
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.dataGrid.Items.Count; i++)
            {
                string text = dataGrid.Items[i].ToString();
                string[] sArray = text.Split(',',' ', '{', 'A', '=','B','C','}');
                commoditystr = sArray[6];
                QuantityStr = sArray[12];
                //MessageBox.Show(getOder("SELECT commodityNumber FROM inventory where(commodity = \'" + commoditystr + "\' and commodityQuantity > 0)", "commodityNumber")[0].ToString());
                list.Add(getOder("SELECT commodityNumber FROM inventory where(commodity = \"" + commoditystr + "\" and commodityQuantity > 0)", "commodityNumber")[0]);
                sql = "update inventory set commodityQuantity = commodityQuantity - " + QuantityStr + " where commodityNumber = " + list[i] + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                //MessageBox.Show(sArray[9]);
            }
            MessageBox.Show("總共:"+ total.ToString(),"謝謝光臨");
            dataGrid.Items.Clear();
            commoditytextBox.Text = null;
            QuantitytextBox.Text = null;
            CostTextBox.Text = null;
            TotalBox.Text = null;
            total = 0;
            
            conn.Close();
        }
    }
}
public class DataGridClass
{
    public string A { get; set; }
    public string B { get; set; }

    public string C { get; set; }
}