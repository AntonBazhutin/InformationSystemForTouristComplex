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
    public partial class ProductRegisterForm : Form
    {
        private string safeString = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'@";

        public bool IsFilled { get; set; }
        private Product product;
        public Product AddingProduct { get { return product; } set { product = value; } }
        public ProductRegisterForm(int id)
        {
            AddingProduct = new Product(id);
            InitializeComponent();
            IsFilled = false;
        }
        public ProductRegisterForm(Product pr)
        {
            AddingProduct = pr;
            InitializeComponent();
            IsFilled = true;
        }
        private void ProductRegisterForm_Load(object sender, EventArgs e)
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
                txtBxDescription.Text = AddingProduct.Description;
                txtBxName.Text = AddingProduct.Name;
                numericUpDown1.Text = AddingProduct.Price.ToString();
                txtBxProductId.Text = AddingProduct.Id.ToString();
                txtBxQuantity.Text = AddingProduct.Quantity.ToString();
                txtBxType.Text = AddingProduct.Type;
                Text = "Редатирование информации";
                btnSubmit.Text = "ОК";
                txtBxProductId.ReadOnly = true;
            }
            else
            {
                txtBxProductId.ReadOnly = true;
                Text = "Добавление продукт";
                btnSubmit.Text = "Добавить";
                txtBxProductId.Text = AddingProduct.Id.ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddingProduct = new Product(int.Parse(txtBxProductId.Text),
                txtBxName.Text, decimal.Parse(numericUpDown1.Text),
                txtBxDescription.Text, txtBxType.Text, int.Parse(txtBxQuantity.Text));
        }

        private void txtBxProductId_TextChanged(object sender, EventArgs e)
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
