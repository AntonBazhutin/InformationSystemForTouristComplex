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
    public partial class EquipmentRegisterForm : Form
    {
        public bool IsFilled { get; set; }
        private Equipment equipment;
        public Equipment AddingEquipment { get { return equipment; } set { equipment = value; } }
        public EquipmentRegisterForm(int id)
        {
            AddingEquipment = new Equipment(id);
            InitializeComponent();
            IsFilled = false;
        }
        public EquipmentRegisterForm(Equipment equipment)
        {
            AddingEquipment = equipment;
            InitializeComponent();
            IsFilled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingEquipment = new Equipment(int.Parse(txtBxId.Text), txtBxName.Text, int.Parse(txtBxQuantity.Text), txtBxSerialNumber.Text, int.Parse(txtBxProfessionId.Text));
        }

        private void EquipmentRegisterForm_Load(object sender, EventArgs e)
        {
            if (IsFilled)
            {
                txtBxId.Text = AddingEquipment.Id.ToString();
                txtBxName.Text = AddingEquipment.Name;
                txtBxProfessionId.Text = AddingEquipment.ProfessionId.ToString();
                txtBxQuantity.Text = AddingEquipment.Quantity.ToString();
                txtBxSerialNumber.Text = AddingEquipment.SerialNumber;
                txtBxId.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                txtBxId.Text = AddingEquipment.Id.ToString();
                Text = "Добавление инструмента";
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
