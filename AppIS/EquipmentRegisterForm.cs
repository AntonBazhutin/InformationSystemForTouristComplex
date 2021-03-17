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
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";
        List<int> profession_ids = new List<int>();
        public bool IsFilled { get; set; }
        private Equipment equipment;
        public Equipment AddingEquipment { get { return equipment; } set { equipment = value; } }
        public EquipmentRegisterForm(int id, List<int> professions)
        {
            profession_ids = professions;
            AddingEquipment = new Equipment(id);
            InitializeComponent();
            IsFilled = false;
        }
        public EquipmentRegisterForm(Equipment equipment, List<int> professions)
        {
            profession_ids = professions;
            AddingEquipment = equipment;
            InitializeComponent();
            IsFilled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingEquipment = new Equipment(int.Parse(txtBxId.Text), txtBxName.Text, int.Parse(numericUpDown1.Text),
                int.Parse(comboBxProfession_id.SelectedItem.ToString()));
        }

        private void EquipmentRegisterForm_Load(object sender, EventArgs e)
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
            foreach (var item in profession_ids)
            {
                comboBxProfession_id.Items.Add(item);
            }

            if (IsFilled)
            {
                txtBxId.Text = AddingEquipment.Id.ToString();
                txtBxName.Text = AddingEquipment.Name;
                comboBxProfession_id.Text = AddingEquipment.ProfessionId.ToString();
                numericUpDown1.Text = AddingEquipment.Quantity.ToString();
                txtBxId.ReadOnly = true;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
            }
            else
            {
                comboBxProfession_id.Text = profession_ids[0].ToString();
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
