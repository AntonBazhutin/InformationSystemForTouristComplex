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
            AddingOrder = new Order(int.Parse(txtBxOrder_id.Text), int.Parse(txtBxProduct_id.Text),
                int.Parse(txtBxQuantity.Text), decimal.Parse(txtBxCost.Text), txtBxDateOrder.Text, txtBxLogin.Text, bool.Parse(txtBxCompleted.Text));
        }

        private void txtBxId_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtbx = c as TextBox;
                    if (txtbx.Text == string.Empty)
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                labelWarning.Visible = false;
                btnSubmit.Enabled = true;
            }
            else
            {
                labelWarning.Visible = true;
                btnSubmit.Enabled = false;
            }
        }

        private void OrderRegisterForm_Load(object sender, EventArgs e)
        {
            txtBxCompleted.Text = AddingOrder.IsDone.ToString();
            txtBxDateOrder.Text = AddingOrder.DateOrder.ToString();
            txtBxCost.Text = AddingOrder.Cost.ToString();
            txtBxLogin.Text = AddingOrder.Login;
            txtBxOrder_id.Text = AddingOrder.Order_id.ToString();
            txtBxProduct_id.Text = AddingOrder.Product_id.ToString();
            txtBxQuantity.Text = AddingOrder.Quantity.ToString();
        }
    }
}
