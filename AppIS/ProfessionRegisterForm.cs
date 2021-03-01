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
    public partial class ProfessionRegisterForm : Form
    {
        public bool IsFilled { get; set; }

        private Profession profession;
        public Profession AddingProfession
        {
            get { return profession; }
            set { profession = value; }
        }

        public ProfessionRegisterForm(int id)
        {
            AddingProfession = new Profession(id);
            InitializeComponent();
            IsFilled = false;
        }
        public ProfessionRegisterForm(Profession prof)
        {
            IsFilled = true;
            AddingProfession = prof;
            InitializeComponent();
        }

        private void ProfessionRegisterForm_Load(object sender, EventArgs e)
        {
            if (IsFilled)
            {
                txtBxId.Text = AddingProfession.Id.ToString();
                txtBxName.Text = AddingProfession.Name;
                txtBxId.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                txtBxId.Text = AddingProfession.Id.ToString();
                Text = "Добавление профессии";
                txtBxId.ReadOnly = true;
                btnSubmit.Text = "Добавить";
            }
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
