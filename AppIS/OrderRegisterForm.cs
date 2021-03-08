using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppIS
{
    public partial class OrderRegisterForm : Form
    {

        public Order AddingOrder { get; set; }
        public OrderRegisterForm(Order addingOrder)
        {
            AddingOrder = addingOrder;
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool resBool = false;
            if (comboBox1.SelectedItem.ToString() == "Да")
                resBool = true;
            else
                resBool = false;
            AddingOrder = new Order(int.Parse(txtBxOrder_id.Text), int.Parse(txtBxProduct_id.Text),
                int.Parse(txtBxQuantity.Text), decimal.Parse(txtBxCost.Text), txtBxDateOrder.Text, txtBxLogin.Text, resBool);
        }

        private void txtBxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderRegisterForm_Load(object sender, EventArgs e)
        {
            bool res = bool.Parse(AddingOrder.IsDone.ToString());
            if (res == true)
            {
                comboBox1.Enabled = false;
                comboBox1.Text = "Да";
            }
            else
            {
                comboBox1.Enabled = true;
                comboBox1.Text = "Нет";
            }

            txtBxDateOrder.Text = AddingOrder.DateOrder.ToString();
            txtBxCost.Text = AddingOrder.Cost.ToString();
            txtBxLogin.Text = AddingOrder.Login;
            txtBxOrder_id.Text = AddingOrder.Order_id.ToString();
            txtBxProduct_id.Text = AddingOrder.Product_id.ToString();
            txtBxQuantity.Text = AddingOrder.Quantity.ToString();
        }
    }
}
