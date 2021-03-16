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

        List<string> logins = new List<string>();
        private WorkDay workDay;
        public WorkDay AddingWorkDay
        {
            get { return workDay; }
            set { workDay = value; }
        }
        public WorkDayRegisterForm(List<string> logins)
        {
            this.logins = logins;
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
            dgw.Rows.Add("ПН");
            dgw.Rows.Add("ВТ");
            dgw.Rows.Add("СР");
            dgw.Rows.Add("ЧТ");
            dgw.Rows.Add("ПТ");
            dgw.Rows.Add("СБ");
            dgw.Rows.Add("ВС");

            if (!IsFilled)
            {
                txtBxWorkDays.Text = "ПН";

                foreach (var item in logins)
                {
                    comboBxWorkersLogins.Items.Add(item);
                }
                comboBxWorkersLogins.Text = comboBxWorkersLogins.Items[0].ToString();
            }

            if (IsFilled)
            {
                comboBxWorkersLogins.Items.Add(AddingWorkDay.WorkerLogin);
                comboBxWorkersLogins.SelectedItem = comboBxWorkersLogins.Items[0].ToString();
                comboBxWorkersLogins.Enabled = false;
                txtBxWorkDays.Text = AddingWorkDay.WorkDays;
                Text = "Редактирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                Text = "Добавление рабочей смены";
                btnSubmit.Text = "Добавить";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorkDay = new WorkDay(comboBxWorkersLogins.SelectedItem.ToString(), txtBxWorkDays.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBxWorkDays.Text = "";

            string[] sort = new string[7] { "", "", "", "", "", "", "" };

            for (int i = 0; i < dgw.SelectedRows.Count; i++)
            {
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "ПН")
                    sort[0] = "ПН";
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "ВТ")
                    sort[1] = "ВТ";
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "СР")
                    sort[2] = "СР";
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "ЧТ")
                    sort[3] = "ЧТ";
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "ПТ")
                    sort[4] = "ПТ";
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "СБ")
                    sort[5] = "СБ";
                if (dgw.SelectedRows[i].Cells[0].Value.ToString() == "ВС")
                    sort[6] = "ВС";
            }

            List<string> temp = new List<string>();
            foreach (var item in sort)
            {
                if (item != "")
                    temp.Add(item);
            }

            for (int i = 0; i < temp.Count; i++)
            {
                if (i != temp.Count - 1)
                    txtBxWorkDays.Text += temp[i] + ",";
                if (i == temp.Count - 1)
                    txtBxWorkDays.Text += temp[i];
            }
        }
    }
}
