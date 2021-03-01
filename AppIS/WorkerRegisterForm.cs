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
    public partial class WorkerRegisterForm : Form
    {
        public bool IsFilled { get; set; }
        private Worker worker;
        public Worker AddingWorker { get { return worker; } set { worker = value; } }
        public WorkerRegisterForm(int workPlace_id)
        {
            AddingWorker = new Worker(workPlace_id);
            IsFilled = false;
            InitializeComponent();
        }
        public WorkerRegisterForm(Worker worker)
        {
            AddingWorker = worker;
            IsFilled = true;
            InitializeComponent();
        }
        private void WorkerRegisterForm_Load(object sender, EventArgs e)
        {
            if (IsFilled)
            {
                txtBxDateOfBirth.Text = AddingWorker.DateOfBirth;
                txtBxPhoneNumber.Text = AddingWorker.PhoneNumber;
                txtBxLogin.Text = AddingWorker.Login;
                txtBxName.Text = AddingWorker.Name;
                txtBxPassword.Text = AddingWorker.Password;
                txtBxSurname.Text = AddingWorker.Surname;
                txtBxThirdname.Text = AddingWorker.Thirdname;
                txtBxProfessionId.Text = AddingWorker.Profession_id.ToString();
                txtBxWorkPlaceId.Text = AddingWorker.WorkPlace_id.ToString();
                txtBxPassword.ReadOnly = true;
                txtBxLogin.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                txtBxWorkPlaceId.Text = AddingWorker.WorkPlace_id.ToString();
                Text = "Добавление работника";
                btnSubmit.Text = "Добавить";
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorker = new Worker(txtBxName.Text, txtBxSurname.Text, txtBxThirdname.Text, txtBxDateOfBirth.Text, int.Parse(txtBxProfessionId.Text),
                int.Parse(txtBxWorkPlaceId.Text), txtBxPhoneNumber.Text, txtBxLogin.Text, txtBxPassword.Text);
        }

        private void txtBxName_TextChanged(object sender, EventArgs e)
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
