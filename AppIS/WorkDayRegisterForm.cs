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
    public partial class WorkDayRegisterForm : Form
    {
        public bool IsFilled { get; set; }

        private WorkDay workDay;
        public WorkDay AddingWorkDay
        {
            get { return workDay; }
            set { workDay = value; }
        }
        public WorkDayRegisterForm(int id)
        {
            AddingWorkDay = new WorkDay(id);
            IsFilled = false;
            InitializeComponent();
        }
        public WorkDayRegisterForm(WorkDay wd)
        {
            AddingWorkDay = wd;
            IsFilled = true;
            InitializeComponent();
        }

        private void WorkDayRegisterForm_Load(object sender, EventArgs e)
        {
            if (IsFilled)
            {
                txtBxId.Text = AddingWorkDay.WorkerLogin.ToString();
                txtBxDay.Text = AddingWorkDay.WorkDay_;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                txtBxId.Text = AddingWorkDay.WorkerLogin.ToString();
                Text = "Добавление рабочей смены";
                btnSubmit.Text = "Добавить";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorkDay = new WorkDay(int.Parse(txtBxId.Text), txtBxDay.Text);
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
    }
}
