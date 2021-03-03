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
    public partial class EventRegisterForm : Form
    {
        public bool IsFilled { get; set; }
        private Event event_;
        public Event AddingEvent { get { return event_; } set { event_ = value; } }
        public EventRegisterForm(int id)
        {
            IsFilled = false;
            AddingEvent = new Event(id);
            InitializeComponent();
        }
        public EventRegisterForm(Event ev)
        {
            AddingEvent = ev;
            IsFilled = true;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingEvent = new Event(int.Parse(txtBxEventId.Text), txtBxName.Text,
                decimal.Parse(txtBxPrice.Text), txtBxDescription.Text, txtBxDate.Text, int.Parse(txtBxWorkPlaceId.Text),int.Parse(txtBxTickets.Text));
        }

        private void EventRegisterForm_Load(object sender, EventArgs e)
        {
            if (IsFilled)
            {
                txtBxDescription.Text = AddingEvent.Description;
                txtBxName.Text = AddingEvent.Name;
                txtBxPrice.Text = AddingEvent.Price.ToString();
                txtBxEventId.Text = AddingEvent.Id.ToString();
                txtBxDate.Text = AddingEvent.Date;
                txtBxWorkPlaceId.Text = AddingEvent.WorkPlace_id.ToString();
                txtBxEventId.ReadOnly = true;
                txtBxTickets.Text = AddingEvent.Quantity.ToString();
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                txtBxEventId.ReadOnly = true;
                Text = "Добавление продукт";
                btnSubmit.Text = "Добавить";
                txtBxEventId.Text = AddingEvent.Id.ToString();
            }
        }

        private void txtBxEventId_TextChanged(object sender, EventArgs e)
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
    }
}
