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
    public partial class BookedTicketRegisterForm : Form
    {
        public BookedTicket AddingTicket { get; set; }
        public BookedTicketRegisterForm(BookedTicket addingTicket)
        {
            AddingTicket = addingTicket;
            InitializeComponent();
        }

        private void txtBxOrder_id_TextChanged(object sender, EventArgs e)
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

        private void BookedTicketRegisterForm_Load(object sender, EventArgs e)
        {
            txtBxCost.Text = AddingTicket.Cost.ToString();
            txtBxEvent_id.Text = AddingTicket.Event_id.ToString();
            txtBxLogin.Text = AddingTicket.Login;
            txtBxOrder_id.Text = AddingTicket.Item_id.ToString();
            txtBxPaid.Text = AddingTicket.isPaid.ToString();
            txtBxQuantity.Text = AddingTicket.Quantity.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingTicket = new BookedTicket(int.Parse(txtBxOrder_id.Text),
                int.Parse(txtBxEvent_id.Text), int.Parse(txtBxQuantity.Text), decimal.Parse(txtBxCost.Text), txtBxLogin.Text, bool.Parse(txtBxPaid.Text));
        }
    }
}
