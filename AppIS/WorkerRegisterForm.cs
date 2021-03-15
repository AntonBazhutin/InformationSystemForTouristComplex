using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppIS
{
    public partial class WorkerRegisterForm : Form
    {
        private string safeString = " 0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";
        List<int> Profession_ids = new List<int>();
        List<int> Workplace_ids = new List<int>();
        public bool IsFilled { get; set; }
        public int workplace_id;
        private Worker worker;
        public Worker AddingWorker { get { return worker; } set { worker = value; } }
        public WorkerRegisterForm(int workPlace_id, List<int> profession_ids, List<int> workplace_ids)
        {
            this.workplace_id = workPlace_id;
            Profession_ids = profession_ids;
            Workplace_ids = workplace_ids;
            AddingWorker = new Worker(workPlace_id);
            IsFilled = false;
            InitializeComponent();
        }
        public WorkerRegisterForm(Worker worker, List<int> profession_ids, List<int> workplace_ids)
        {
            Profession_ids = profession_ids;
            Workplace_ids = workplace_ids;
            AddingWorker = worker;
            IsFilled = true;
            InitializeComponent();
        }
        private void WorkerRegisterForm_Load(object sender, EventArgs e)
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

            foreach (var item in Profession_ids)
            {
                comboBxProfession_id.Items.Add(item);
            }
            comboBxProfession_id.Text = Profession_ids[0].ToString();
            foreach (var item in Workplace_ids)
            {
                comboBxWorkPlace_id.Items.Add(item);
            }
            comboBxWorkPlace_id.Text = workplace_id.ToString();
            if (IsFilled)
            {
                comboBxProfession_id.Text = AddingWorker.Profession_id.ToString();
                comboBxWorkPlace_id.Text = AddingWorker.WorkPlace_id.ToString();
                dateTimePicker1.Text = AddingWorker.DateOfBirth;
                txtBxPhoneNumber.Text = AddingWorker.PhoneNumber;
                txtBxLogin.Text = AddingWorker.Login;
                txtBxName.Text = AddingWorker.Name;
                txtBxPassword.Text = AddingWorker.Password;
                txtBxSurname.Text = AddingWorker.Surname;
                txtBxThirdname.Text = AddingWorker.Thirdname;
                txtBxPassword.ReadOnly = true;
                txtBxLogin.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                Text = "Добавление работника";
                btnSubmit.Text = "Добавить";
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorker = new Worker(txtBxName.Text, txtBxSurname.Text, txtBxThirdname.Text, dateTimePicker1.Text, int.Parse(comboBxProfession_id.SelectedItem.ToString()),
                int.Parse(comboBxWorkPlace_id.SelectedItem.ToString()), txtBxPhoneNumber.Text, txtBxLogin.Text, txtBxPassword.Text);
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
