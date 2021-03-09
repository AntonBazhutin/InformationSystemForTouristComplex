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
    public partial class TouristRegisterForm : Form
    {
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-";
        private bool IsFilled { get; set; }
        private Tourist tourist;
        public Tourist AddingTourist { get { return tourist; } set { tourist = value; } }
        public TouristRegisterForm(int room_id)
        {
            AddingTourist = new Tourist(room_id);
            IsFilled = false;
            InitializeComponent();
        }

        public TouristRegisterForm(Tourist t)
        {
            AddingTourist = t;
            IsFilled = true;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingTourist = new Tourist(txtBxLogin.Text, txtBxPassword.Text, txtBxName.Text, txtBxSurname.Text, txtBxThirdname.Text, dateTimeDateOfBirth.Text,
                   txtBxEmail.Text, dateTimeComing.Text, dateTimeLeaving.Text, txtBxCountry.Text, int.Parse(textBxRoom_id.Text));
        }

        private void TouristRegisterForm_Load(object sender, EventArgs e)
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
            textBxRoom_id.ReadOnly = true;
            if (IsFilled)
            {
                txtBxCountry.Text = AddingTourist.Country;
                dateTimeDateOfBirth.Text = AddingTourist.DateOfBirth;
                dateTimeComing.Text = AddingTourist.DateOfComing;
                dateTimeLeaving.Text = AddingTourist.DateOfLeaving;
                txtBxEmail.Text = AddingTourist.Email;
                txtBxLogin.Text = AddingTourist.Login;
                txtBxName.Text = AddingTourist.Name;
                txtBxPassword.Text = AddingTourist.Password;
                textBxRoom_id.Text = AddingTourist.Room_id.ToString();
                txtBxSurname.Text = AddingTourist.Surname;
                txtBxThirdname.Text = AddingTourist.Thirdname;
                txtBxPassword.ReadOnly = true;
                txtBxLogin.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                textBxRoom_id.Text = AddingTourist.Room_id.ToString();
                Text = "Заселение туриста";
                btnSubmit.Text = "Заселить";
            }
        }

        private void TouristRegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void txtBxName_TextChanged(object sender, EventArgs e)
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
    }
}
