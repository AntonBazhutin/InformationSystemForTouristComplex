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
    public partial class BuildingRegisterForm : Form
    {
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_";
        public bool IsFilled { get; set; }
        public Building AddinBuilding { get; set; }
        public BuildingRegisterForm(Building building)
        {
            IsFilled = true;
            AddinBuilding = building;
            InitializeComponent();
        }
        public BuildingRegisterForm()
        {
            IsFilled = false;
            InitializeComponent();
        }

        private void BuildingRegisterForm_Load(object sender, EventArgs e)
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

            if (IsFilled)
            {
                txtBxId.Text = AddinBuilding.Id.ToString();
                numericUpDownCountOfRooms.Text = AddinBuilding.Rooms.ToString();
                txtBxId.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                Text = "Добавление здания";
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddinBuilding = new Building(txtBxId.Text, int.Parse(numericUpDownCountOfRooms.Text));
        }
    }
}
