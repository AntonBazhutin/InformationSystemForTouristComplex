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
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";
        List<int> workPlace_ids = new List<int>();
        public bool IsFilled { get; set; }
        private Event event_;
        public Event AddingEvent { get { return event_; } set { event_ = value; } }
        public EventRegisterForm(int id, List<int> workplace_ids)
        {
            this.workPlace_ids = workplace_ids;
            IsFilled = false;
            AddingEvent = new Event(id);
            InitializeComponent();
        }
        public EventRegisterForm(Event ev, List<int> workplace_ids)
        {
            this.workPlace_ids = workplace_ids;
            AddingEvent = ev;
            IsFilled = true;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingEvent = new Event(int.Parse(txtBxEventId.Text), txtBxName.Text,
                decimal.Parse(numericUpDownPrice.Text), txtBxDescription.Text, dateTimePicker1.Text,
                int.Parse(comboBoxWorkPlace_id.SelectedItem.ToString()), int.Parse(numericUpDownCountOfTickets.Text));
        }

        private void EventRegisterForm_Load(object sender, EventArgs e)
        {
            if (!IsFilled)
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
                    labelWarning.Visible = false;
                    btnSubmit.Enabled = true;
                }
                else
                {
                    labelWarning.Visible = true;
                    btnSubmit.Enabled = false;
                }
            }
            foreach (var item in workPlace_ids)
            {
                comboBoxWorkPlace_id.Items.Add(item);
            }
            comboBoxWorkPlace_id.Text = comboBoxWorkPlace_id.Items[0].ToString();
            if (IsFilled)
            {
                txtBxDescription.Text = AddingEvent.Description;
                txtBxName.Text = AddingEvent.Name;
                numericUpDownPrice.Text = AddingEvent.Price.ToString();
                txtBxEventId.Text = AddingEvent.Id.ToString();
                dateTimePicker1.Text = AddingEvent.Date;
                comboBoxWorkPlace_id.Text = AddingEvent.WorkPlace_id.ToString();
                txtBxEventId.ReadOnly = true;
                numericUpDownCountOfTickets.Text = AddingEvent.Quantity.ToString();
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
