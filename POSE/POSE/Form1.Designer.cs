namespace POSE
{
    partial class Pos
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitButton = new System.Windows.Forms.Button();
            this.CostLabel = new System.Windows.Forms.Label();
            this.CostTextBox = new System.Windows.Forms.TextBox();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.TotalBox = new System.Windows.Forms.TextBox();
            this.EditeButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.oder = new System.Windows.Forms.DataGridView();
            this.commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commodityQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commodityCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.Label();
            this.QuantitytextBox = new System.Windows.Forms.TextBox();
            this.commoditytextBox = new System.Windows.Forms.TextBox();
            this.commodityLable = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oder)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1107, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(92, 54);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "離開";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.Exit_Click);
            // 
            // CostLabel
            // 
            this.CostLabel.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CostLabel.Location = new System.Drawing.Point(494, 12);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(91, 36);
            this.CostLabel.TabIndex = 1;
            this.CostLabel.Text = "金額:";
            // 
            // CostTextBox
            // 
            this.CostTextBox.Enabled = false;
            this.CostTextBox.Location = new System.Drawing.Point(591, 12);
            this.CostTextBox.Multiline = true;
            this.CostTextBox.Name = "CostTextBox";
            this.CostTextBox.Size = new System.Drawing.Size(89, 39);
            this.CostTextBox.TabIndex = 2;
            // 
            // TotalLabel
            // 
            this.TotalLabel.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TotalLabel.Location = new System.Drawing.Point(686, 12);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(98, 39);
            this.TotalLabel.TabIndex = 3;
            this.TotalLabel.Text = "總額:";
            // 
            // TotalBox
            // 
            this.TotalBox.Enabled = false;
            this.TotalBox.Location = new System.Drawing.Point(790, 12);
            this.TotalBox.Multiline = true;
            this.TotalBox.Name = "TotalBox";
            this.TotalBox.Size = new System.Drawing.Size(89, 39);
            this.TotalBox.TabIndex = 4;
            // 
            // EditeButton
            // 
            this.EditeButton.Location = new System.Drawing.Point(899, 4);
            this.EditeButton.Name = "EditeButton";
            this.EditeButton.Size = new System.Drawing.Size(98, 54);
            this.EditeButton.TabIndex = 5;
            this.EditeButton.Text = "修改";
            this.EditeButton.UseVisualStyleBackColor = true;
            this.EditeButton.Click += new System.EventHandler(this.EditeButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(1003, 4);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(98, 54);
            this.CheckButton.TabIndex = 6;
            this.CheckButton.Text = "確認";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // oder
            // 
            this.oder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commodity,
            this.commodityQuantity,
            this.commodityCost});
            this.oder.Location = new System.Drawing.Point(16, 65);
            this.oder.Name = "oder";
            this.oder.RowTemplate.Height = 24;
            this.oder.Size = new System.Drawing.Size(472, 373);
            this.oder.TabIndex = 7;
            // 
            // commodity
            // 
            this.commodity.HeaderText = "商品";
            this.commodity.MinimumWidth = 10;
            this.commodity.Name = "commodity";
            this.commodity.Width = 143;
            // 
            // commodityQuantity
            // 
            this.commodityQuantity.HeaderText = "數量";
            this.commodityQuantity.Name = "commodityQuantity";
            this.commodityQuantity.Width = 143;
            // 
            // commodityCost
            // 
            this.commodityCost.HeaderText = "價錢";
            this.commodityCost.Name = "commodityCost";
            this.commodityCost.Width = 143;
            // 
            // Quantity
            // 
            this.Quantity.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Quantity.Location = new System.Drawing.Point(302, 12);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(91, 36);
            this.Quantity.TabIndex = 8;
            this.Quantity.Text = "數量:";
            // 
            // QuantitytextBox
            // 
            this.QuantitytextBox.Enabled = false;
            this.QuantitytextBox.Location = new System.Drawing.Point(399, 12);
            this.QuantitytextBox.Multiline = true;
            this.QuantitytextBox.Name = "QuantitytextBox";
            this.QuantitytextBox.Size = new System.Drawing.Size(89, 39);
            this.QuantitytextBox.TabIndex = 9;
            this.QuantitytextBox.Click += new System.EventHandler(this.NumberButtons_Click);
            // 
            // commoditytextBox
            // 
            this.commoditytextBox.Enabled = false;
            this.commoditytextBox.Location = new System.Drawing.Point(209, 12);
            this.commoditytextBox.Multiline = true;
            this.commoditytextBox.Name = "commoditytextBox";
            this.commoditytextBox.Size = new System.Drawing.Size(89, 39);
            this.commoditytextBox.TabIndex = 11;
            // 
            // commodityLable
            // 
            this.commodityLable.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.commodityLable.Location = new System.Drawing.Point(112, 12);
            this.commodityLable.Name = "commodityLable";
            this.commodityLable.Size = new System.Drawing.Size(91, 36);
            this.commodityLable.TabIndex = 10;
            this.commodityLable.Text = "飲料:";
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(510, 65);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(369, 109);
            this.EnterButton.TabIndex = 12;
            this.EnterButton.Text = "結帳";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EntterButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(508, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 38);
            this.label1.TabIndex = 13;
            this.label1.Text = "總共:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(595, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = " 0";
            // 
            // Pos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.commoditytextBox);
            this.Controls.Add(this.commodityLable);
            this.Controls.Add(this.QuantitytextBox);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.oder);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.EditeButton);
            this.Controls.Add(this.TotalBox);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.CostTextBox);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pos";
            this.Text = "POS";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.oder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.TextBox CostTextBox;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.TextBox TotalBox;
        private System.Windows.Forms.Button EditeButton;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.DataGridView oder;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodityQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodityCost;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.TextBox QuantitytextBox;
        private System.Windows.Forms.TextBox commoditytextBox;
        private System.Windows.Forms.Label commodityLable;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

