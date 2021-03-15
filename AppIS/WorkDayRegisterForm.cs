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
        private string safeString = " 0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";
        List<string> logins = new List<string>();
        public bool IsFilled { get; set; }

        private WorkDay workDay;
        public WorkDay AddingWorkDay
        {
            get { return workDay; }
            set { workDay = value; }
        }
        public WorkDayRegisterForm(int id, List<string> logins)
        {
            this.logins = logins;
            AddingWorkDay = new WorkDay(id);
            IsFilled = false;
            InitializeComponent();
        }
        public WorkDayRegisterForm(WorkDay wd, List<string> logins)
        {
            this.logins = logins;
            AddingWorkDay = wd;
            IsFilled = true;
            InitializeComponent();
        }

        private void WorkDayRegisterForm_Load(object sender, EventArgs e)
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

            txtBxId.ReadOnly = true;

            txtBxId.Text = AddingWorkDay.Id.ToString();

            foreach (var item in logins)
            {
                comboBxWorker_id.Items.Add(item);
            }

            if (IsFilled)
            {
                comboBxWorker_id.Text = AddingWorkDay.WorkerLogin.ToString();
                txtBxDay.Text = AddingWorkDay.WorkDay_;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                comboBxWorker_id.Text = logins[0];
                Text = "Добавление рабочей смены";
                btnSubmit.Text = "Добавить";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorkDay = new WorkDay(int.Parse(comboBxWorker_id.Items.ToString()), txtBxDay.Text, int.Parse(txtBxId.Text));
        }

        private void txtBxId_TextChanged(object sender, EventArgs e)
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
