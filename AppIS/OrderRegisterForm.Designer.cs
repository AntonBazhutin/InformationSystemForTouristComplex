
namespace AppIS
{
    partial class OrderRegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBxLogin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBxCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtBxQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxProduct_id = new System.Windows.Forms.TextBox();
            this.txtBxOrder_id = new System.Windows.Forms.TextBox();
            this.txtBxDateOrder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtBxLogin
            // 
            this.txtBxLogin.Location = new System.Drawing.Point(156, 121);
            this.txtBxLogin.Name = "txtBxLogin";
            this.txtBxLogin.ReadOnly = true;
            this.txtBxLogin.Size = new System.Drawing.Size(100, 20);
            this.txtBxLogin.TabIndex = 72;
            this.txtBxLogin.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(17, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "Логин заказчика";
            // 
            // txtBxCost
            // 
            this.txtBxCost.Location = new System.Drawing.Point(156, 92);
            this.txtBxCost.Name = "txtBxCost";
            this.txtBxCost.ReadOnly = true;
            this.txtBxCost.Size = new System.Drawing.Size(100, 20);
            this.txtBxCost.TabIndex = 70;
            this.txtBxCost.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(57, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "Стоимость";
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(103, 225);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 67;
            this.btnSubmit.Text = "ОК";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtBxQuantity
            // 
            this.txtBxQuantity.Location = new System.Drawing.Point(156, 66);
            this.txtBxQuantity.Name = "txtBxQuantity";
            this.txtBxQuantity.ReadOnly = true;
            this.txtBxQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtBxQuantity.TabIndex = 66;
            this.txtBxQuantity.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(83, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 65;
            this.label3.Text = "Кол-во ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(41, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 64;
            this.label2.Text = "Код продукта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(57, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Код заказа";
            // 
            // txtBxProduct_id
            // 
            this.txtBxProduct_id.Location = new System.Drawing.Point(156, 40);
            this.txtBxProduct_id.Name = "txtBxProduct_id";
            this.txtBxProduct_id.ReadOnly = true;
            this.txtBxProduct_id.Size = new System.Drawing.Size(100, 20);
            this.txtBxProduct_id.TabIndex = 62;
            this.txtBxProduct_id.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // txtBxOrder_id
            // 
            this.txtBxOrder_id.Location = new System.Drawing.Point(156, 14);
            this.txtBxOrder_id.Name = "txtBxOrder_id";
            this.txtBxOrder_id.ReadOnly = true;
            this.txtBxOrder_id.Size = new System.Drawing.Size(100, 20);
            this.txtBxOrder_id.TabIndex = 61;
            this.txtBxOrder_id.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // txtBxDateOrder
            // 
            this.txtBxDateOrder.Location = new System.Drawing.Point(156, 147);
            this.txtBxDateOrder.Name = "txtBxDateOrder";
            this.txtBxDateOrder.ReadOnly = true;
            this.txtBxDateOrder.Size = new System.Drawing.Size(100, 20);
            this.txtBxDateOrder.TabIndex = 74;
            this.txtBxDateOrder.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(48, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 73;
            this.label6.Text = "Дата заказа";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(57, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 18);
            this.label7.TabIndex = 75;
            this.label7.Text = "Оплачен?";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Да",
            "Нет"});
            this.comboBox1.Location = new System.Drawing.Point(156, 171);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 76;
            // 
            // OrderRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 278);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBxDateOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBxLogin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBxCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBxQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxProduct_id);
            this.Controls.Add(this.txtBxOrder_id);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(315, 317);
            this.MinimumSize = new System.Drawing.Size(315, 317);
            this.Name = "OrderRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование информации";
            this.Load += new System.EventHandler(this.OrderRegisterForm_Load);
            this.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBxCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtBxQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxProduct_id;
        private System.Windows.Forms.TextBox txtBxOrder_id;
        private System.Windows.Forms.TextBox txtBxDateOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}