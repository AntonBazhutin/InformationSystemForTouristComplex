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
    public partial class UserPowerRegisterForm : Form
    {
        public bool IsFilled { get; set; }
        public UserPower AddingPower { get; set; }
        List<int> Professions = new List<int>();
        public UserPowerRegisterForm(List<int> professions)
        {
            IsFilled = false;
            Professions = professions;
            InitializeComponent();
        }
        public UserPowerRegisterForm(UserPower power)
        {
            IsFilled = true;
            AddingPower = power;
            InitializeComponent();
        }
        private void UserPowerRegisterForm_Load(object sender, EventArgs e)
        {

            if (IsFilled)
            {
                textBox1.Text = AddingPower.Profession_id.ToString();
                comboBoxId.Visible = false;
                if (AddingPower.LimitPower == true)
                    comboBoxRights.Text = "Ограниченные";
                else
                    comboBoxRights.Text = "Полные";

                comboBoxId.Text = AddingPower.Profession_id.ToString();
                comboBoxId.Enabled = false;
            }
            else
            {
                textBox1.Visible = false;
                foreach (var item in Professions)
                {
                    comboBoxId.Items.Add(item);
                }

                comboBoxRights.Text = comboBoxRights.Items[0].ToString();
                comboBoxId.Text = comboBoxId.Items[0].ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool res = false;
            if (comboBoxRights.SelectedItem.ToString() == "Ограниченные")
                res = true;
            else
                res = false;

            if (IsFilled)
                AddingPower = new UserPower(AddingPower.Profession_id, res);
            else
                AddingPower = new UserPower(int.Parse(comboBoxId.SelectedItem.ToString()), res);
        }
    }
}
