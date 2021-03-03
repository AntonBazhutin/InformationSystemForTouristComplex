using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public int MaxCount { get; set; }
        public CountChoosingForm(int quantity)
        {
            MaxCount = quantity;
            InitializeComponent();
        }

        private void CountChoosingForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = MaxCount;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Count = int.Parse(numericUpDown1.Value.ToString());
        }
    }
}
