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

namespace TouristApp
{
    public partial class CountChoosingForm : Form
    {
        public int Count { get; set; }
        public int MaxQuantity { get; set; }
        public int CurrentQuantity { get; set; }
        public bool re { get; set; }
        public CountChoosingForm(int maxQuantity, int currentQuantity)
        {
            re = false;
            Text = "Выбор кол-ва";
            MaxQuantity = maxQuantity;
            CurrentQuantity = currentQuantity;
            InitializeComponent();
        }
        public CountChoosingForm(int maxQuantity)
        {
            re = true;
            Text = "Редактирование кол-ва";
            MaxQuantity = maxQuantity;
            InitializeComponent();
        }
        private void CountChoosingForm_Load(object sender, EventArgs e)
        {
            if (re == false)
            {
                if (MaxQuantity - CurrentQuantity >= 0 && MaxQuantity >= CurrentQuantity && MaxQuantity - CurrentQuantity >= int.Parse(numericUpDown1.Value.ToString()))
                {
                    btnOk.Enabled = true;
                }
                else
                {
                    btnOk.Enabled = false;
                }
            }
            else
            {
                if (MaxQuantity >= int.Parse(numericUpDown1.Value.ToString()))
                {
                    btnOk.Enabled = true;
                }
                else
                {
                    btnOk.Enabled = false;
                }
            }

            numericUpDown1.Maximum = MaxQuantity;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Count = int.Parse(numericUpDown1.Value.ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (re == false)
            {
                if (MaxQuantity - CurrentQuantity >= 0 && MaxQuantity >= CurrentQuantity && MaxQuantity - CurrentQuantity >= int.Parse(numericUpDown1.Value.ToString()))
                {
                    btnOk.Enabled = true;
                }
                else
                {
                    btnOk.Enabled = false;
                }
            }
            else
            {
                if (MaxQuantity >= int.Parse(numericUpDown1.Value.ToString()))
                {
                    btnOk.Enabled = true;
                }
                else
                {
                    btnOk.Enabled = false;
                }
            }
        }
    }
}
