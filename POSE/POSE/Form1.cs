using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
namespace POSE
{
    public partial class Pos : Form
    {
        private  MySqlConnection conn;
        private int total = 0;
        public Pos()
        {
            InitializeComponent();
            //設定無邊框 NoneBorderStyle
            this.FormBorderStyle = FormBorderStyle.None;
            //設定到最大 windowsState MAX
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            //呼叫動態數字按鈕
            DynamicNumberButton();
            //呼叫動態飲料按鈕
            DynamicOderButton();
            //視窗設定
            WindowsObject();
        }
        //mysql連線
        public MySqlConnection Connect()
        {
            String connetStr = "server=127.0.0.1;port=3306;user =" + "root" + ";password = " + "password" + ";" + " database=store;";
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
        //查詢指令
        private MySqlDataReader sel(string sql)
        {
            MySqlConnection conn = Connect();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        //離開函式
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //編輯函式
        private void EditeButton_Click(object sender, EventArgs e)
        {
            QuantitytextBox.Enabled = true;
            QuantitytextBox.Text = "";
        }
        //確認紐
        private void CheckButton_Click(object sender, EventArgs e)
        {
            QuantitytextBox.Enabled = false;
            DataGridViewRowCollection rows = oder.Rows;
            total+=int.Parse(QuantitytextBox.Text) * int.Parse(CostTextBox.Text);
            rows.Add(new Object[] { commoditytextBox.Text, QuantitytextBox.Text, CostTextBox.Text });
            TotalBox.Text = total.ToString();
        }
        private void DynamicNumberButton()
        {
            int top = 80;
            int left = 1107;

            for (int i = 0; i < 10; i++)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Width = 92;
                button.Height = 54;
                button.Text = i.ToString();
                this.Controls.Add(button);
                button.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                top += button.Height + 2;
                button.Click += new EventHandler(NumberButtons_Click);
            }
        }

        private void DynamicOderButton()
        {
            int top = 80;
            int left = 899;
            ArrayList list = new ArrayList();
            list = getOder("SELECT * FROM inventory GROUP BY commodity", "commodity");
            for (int i = 0; i < list.Count; i++)
            {

                Button button = new Button();
                button.Left = left;
                left = 899;
                button.Top = top;
                button.Width = 98;
                button.Height = 54;
                button.Text = list[i].ToString();
                this.Controls.Add(button);
                button.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                if (i % 2 == 1)
                    top += button.Height + 2;
                else
                    left += button.Width + 2;

                button.Click += new EventHandler(OderButtons_Click);
            }

        }
        private void NumberButtons_Click(object sender, EventArgs e)
        {
            
            QuantitytextBox.Text+=(sender as Button).Text;
        }
        private void OderButtons_Click(object sender, EventArgs e)
        {
            
            ArrayList list = new ArrayList();
            list.Add(getOder("SELECT commodityNumber FROM inventory where(commodity = \"" + (sender as Button).Text +"\" and commodityQuantity > 0)", "commodityNumber")[0]);
            list.Add(getOder("SELECT commodityCost FROM inventory where(commodity = \"" + (sender as Button).Text + "\" and commodityQuantity > 0)", "commodityCost")[0]);
            if (list[0] == null)
                MessageBox.Show("沒貨");
            else
            {
                commoditytextBox.Text = (sender as Button).Text;
                QuantitytextBox.Text = "1";
                CostTextBox.Text = list[1].ToString();
            }
        }
        private void WindowsObject()
        {
            commodityLable.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            commoditytextBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            Quantity.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            QuantitytextBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            CostLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            CostTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            EditeButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            CheckButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ExitButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            oder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            EnterButton.Anchor =  AnchorStyles.Right | AnchorStyles.Top;
            label1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            label2.Anchor = AnchorStyles.Right | AnchorStyles.Top;

        }
        private ArrayList getOder(string str,string m) {
            conn = Connect();
            MySqlDataReader reader = sel(str);
            conn.Close();
            ArrayList list = new ArrayList();
            while (reader.Read())//初始索引是-1，執行讀取下一行資料，返回值是bool
            {
                list.Add(reader.GetString(m));
            }
            return list;
        }

        private void EntterButton_Click(object sender, EventArgs e)
        {
            int i = 0; 
            string sql = "";
            conn = Connect();
            ArrayList list = new ArrayList();
           foreach (DataGridViewRow dr in oder.Rows)
           {
                if (dr.Cells["commodity"].Value != null && dr.Cells["commodityQuantity"].Value != null)
                {
                    list.Add(getOder("SELECT commodityNumber FROM inventory where(commodity = \"" + dr.Cells["commodity"].Value.ToString() + "\" and commodityQuantity > 0)", "commodityNumber")[0]);
                    sql = "update inventory set commodityQuantity = commodityQuantity - " + dr.Cells["commodityQuantity"].Value.ToString() + " where commodityNumber = " + list[i] + ";";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    i++;
                }
            }
            label2.Text = TotalBox.Text;
            MessageBox.Show("完成");
        }
    }
}
