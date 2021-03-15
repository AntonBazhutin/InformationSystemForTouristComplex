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
        private string safeString = " 0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";

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
                    if (txtbx.Text.Length < 1 || txtbx.Text == string.Empty)
                        count++;
                    for (int i = 0; i < txtbx.Text.Length; i++)
                    {
                        if (!safeString.Contains(txtbx.Text[i]))
                            count++;
                    }
                }
            }

            if (count == 0)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }

        private void BookedTicketRegisterForm_Load(object sender, EventArgs e)
        {
            bool res = bool.Parse(AddingTicket.isPaid.ToString());
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

            int count = 0;
            foreach (var c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtbx = c as TextBox;
                    if (txtbx.Text.Length < 1 || txtbx.Text == string.Empty)
                        count++;
                    for (int i = 0; i < txtbx.Text.Length; i++)
                    {
                        if (!safeString.Contains(txtbx.Text[i]))
                            count++;
                    }
                }
            }

            if (count == 0)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }

            txtBxCost.Text = AddingTicket.Cost.ToString();
            txtBxEvent_id.Text = AddingTicket.Event_id.ToString();
            txtBxLogin.Text = AddingTicket.Login;
            txtBxOrder_id.Text = AddingTicket.Item_id.ToString();
            txtBxQuantity.Text = AddingTicket.Quantity.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool resBool = false;
            if (comboBox1.SelectedItem.ToString() == "Да")
                resBool = true;
            else
                resBool = false;

            AddingTicket = new BookedTicket(int.Parse(txtBxOrder_id.Text),
                int.Parse(txtBxEvent_id.Text), int.Parse(txtBxQuantity.Text), decimal.Parse(txtBxCost.Text), txtBxLogin.Text, resBool);
        }
    }
}
