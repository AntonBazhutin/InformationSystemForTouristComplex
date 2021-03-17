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
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";
        public int CountOfRooms { get; set; }
        public bool IsFilled { get; set; }
        public Building AddinBuilding { get; set; }
        public BuildingRegisterForm(Building building)
        {
            CountOfRooms = building.Rooms;
            IsFilled = true;
            AddinBuilding = building;
            InitializeComponent();
        }
        public BuildingRegisterForm()
        {
            CountOfRooms = 1;
            IsFilled = false;
            InitializeComponent();
        }

        private void BuildingRegisterForm_Load(object sender, EventArgs e)
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
            if (IsFilled)
            {
                txtBxId.Text = AddinBuilding.Id.ToString();
                numericUpDownCountOfRooms.Text = AddinBuilding.Rooms.ToString();
                txtBxId.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
                if (numericUpDownCountOfRooms.Value == 0)
                    checkBox1.Checked = false;
                else
                    checkBox1.Checked = true;
            }
            else
            {
                numericUpDownCountOfRooms.Enabled = false;
                Text = "Добавление здания";
                txtBxId.ReadOnly = false;
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
                labelWarning.Visible = false;
                btnSubmit.Enabled = true;
            }
            else
            {
                labelWarning.Visible = true;
                btnSubmit.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddinBuilding = new Building(txtBxId.Text, int.Parse(numericUpDownCountOfRooms.Text));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                numericUpDownCountOfRooms.Enabled = false;
                numericUpDownCountOfRooms.Minimum = 0;
                numericUpDownCountOfRooms.Value = 0;
            }
            else
            {
                numericUpDownCountOfRooms.Enabled = true;
                numericUpDownCountOfRooms.Minimum = 1;
                numericUpDownCountOfRooms.Value = CountOfRooms;
            }
        }
    }
}
