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
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";

        List<string> building_ids = new List<string>();
        List<string> place_ids = new List<string>();
        public bool IsFilled { get; set; }

        private WorkPlace workplace;
        public WorkPlace AddingWorkPlace
        {
            get { return workplace; }
            set { workplace = value; }
        }
        public WorkPlaceRegisterForm(int id, List<string> buildings)
        {
            building_ids = buildings;
            IsFilled = false;
            AddingWorkPlace = new WorkPlace(id);
            InitializeComponent();
        }
        public WorkPlaceRegisterForm(WorkPlace addingWorkPlace, List<string> buildings)
        {
            building_ids = buildings;
            IsFilled = true;
            AddingWorkPlace = addingWorkPlace;
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingWorkPlace = new WorkPlace(int.Parse(txtBxId.Text), comboBxBuilding_id.SelectedItem.ToString(), txtBxPlace_id.Text);
        }

        private void WorkPlaceRegisterForm_Load(object sender, EventArgs e)
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
            foreach (var item in building_ids)
            {
                comboBxBuilding_id.Items.Add(item);
            }

            comboBxBuilding_id.Text = building_ids[0];

            if (IsFilled)
            {
                comboBxBuilding_id.Text = AddingWorkPlace.Building_id;
                txtBxId.Text = AddingWorkPlace.Id.ToString();
                txtBxPlace_id.Text = AddingWorkPlace.Place_id;
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
