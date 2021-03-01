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
    public partial class WorkPlaceRegisterForm : Form
    {
        public bool IsFilled { get; set; }

        private WorkPlace workplace;
        public WorkPlace AddingWorkPlace
        {
            get { return workplace; }
            set { workplace = value; }
        }
        public WorkPlaceRegisterForm(int id)
        {
            IsFilled = false;
            AddingWorkPlace = new WorkPlace(id);
            InitializeComponent();
        }
        public WorkPlaceRegisterForm(WorkPlace addingWorkPlace)
        {
            IsFilled = true;
            AddingWorkPlace = addingWorkPlace;
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorkPlace = new WorkPlace(int.Parse(txtBxId.Text), txtBxBuildingId.Text, txtBxPlaceId.Text);
        }

        private void WorkPlaceRegisterForm_Load(object sender, EventArgs e)
        {
            if (IsFilled)
            {
                txtBxBuildingId.Text = AddingWorkPlace.Building_id;
                txtBxId.Text = AddingWorkPlace.Id.ToString();
                txtBxPlaceId.Text = AddingWorkPlace.Place_id;
                txtBxId.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                txtBxId.Text = AddingWorkPlace.Id.ToString();
                Text = "Добавление рабочего места";
                btnSubmit.Text = "Добавить";
                txtBxId.ReadOnly = true;
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
