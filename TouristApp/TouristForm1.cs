using AppIS;
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
    public partial class TouristForm1 : Form
    {
        public List<object> shoppingCart = new List<object>();
        private SqlConnection sqlcon;
        public object CurrentObject { get; set; }

        private const string connectionString = @"Data Source=АНТОН-ПК;Initial Catalog=TouristComplex;Integrated Security=True;";
        private void Connect()
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = connectionString;
            try
            {
                sqlcon.Open();
            }
            catch (Exception)
            {

            }
        }
        public Tourist PersonalInfo { get; set; }

        public TouristForm1(Tourist addingTourist)
        {
            PersonalInfo = addingTourist;

            Connect();

            InitializeComponent();
        }
        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Товары";
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(добавитьToolStripMenuItem);
            CurrentObject = new Product();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            var cmd = new SqlCommand("Select * from Products", sqlcon);
            dataGridView1.Columns.Add("", "Код продукта");
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.Columns.Add("", "Описание");
            dataGridView1.Columns.Add("", "Тип");
            dataGridView1.Columns.Add("", "Кол-во в наличии");

            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["description"].ToString(), dr["type"].ToString(), dr["quantity"].ToString() });
                    dataGridView1.Rows[i].Tag = new Product(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["type"].ToString(), int.Parse(dr["quantity"].ToString()));
                    i++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tooStripTxtBxName.Text = PersonalInfo.Surname + " " + PersonalInfo.Name + " " + PersonalInfo.Thirdname;
            товарыToolStripMenuItem_Click(this, e);
        }

        private void мероприятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Мероприятия";
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(добавитьToolStripMenuItem);
            CurrentObject = new Event();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            var cmd = new SqlCommand("Select * from Events", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.Columns.Add("", "Кол-во билетов");
            dataGridView1.Columns.Add("", "Описание");
            dataGridView1.Columns.Add("", "Дата проведения");
            dataGridView1.Columns.Add("", "Код места проведения");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["quantity"].ToString(), dr["description"].ToString(), dr["date"].ToString(), dr["workPlace_id"].ToString() });
                    dataGridView1.Rows[i].Tag = new Event(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["date"].ToString(), int.Parse(dr["workPlace_id"].ToString()), int.Parse(dr["quantity"].ToString()));
                    i++;
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0 && (CurrentObject is Product || CurrentObject is Event))
            {
                ShoppingCart cart = null;
                Product product = null;
                Event ev = null;
                CountChoosingForm ccf = null;
                int quantity = 0;

                if (CurrentObject is Product)
                {
                    product = dataGridView1.CurrentRow.Tag as Product;
                    ccf = new CountChoosingForm(product.Quantity);
                }
                if (CurrentObject is Event)
                {
                    ev = dataGridView1.CurrentRow.Tag as Event;
                    ccf = new CountChoosingForm(ev.Quantity);
                }

                if (ccf.ShowDialog() == DialogResult.OK)
                {
                    quantity = ccf.Count;

                    var cmd = new SqlCommand("Select * from ShoppingCart where @product_id=product_id", sqlcon);
                    if (product != null)
                        cmd.Parameters.AddWithValue("@product_id", product.Id);
                    if (ev != null)
                        cmd.Parameters.AddWithValue("@product_id", ev.Id);

                    cmd.ExecuteNonQuery();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cart = new ShoppingCart(int.Parse(dr["product_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), bool.Parse(dr["isEvent"].ToString()));
                        }
                    }

                    if (cart != null)
                    {
                        cart.Quantity += quantity;

                        if (product != null)
                        {
                            cart.Cost = cart.Quantity * product.Price;
                        }
                        if (ev != null)
                        {
                            cart.Cost = cart.Quantity * ev.Price;
                        }

                        cmd = new SqlCommand(
                        "delete from ShoppingCart where product_id=@product_id"
                        , sqlcon);

                        cmd.Parameters.AddWithValue("@product_id", cart.Product_id);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (product != null)
                        {
                            cart = new ShoppingCart(product.Id, quantity, product.Price * quantity, false);
                        }
                        if (ev != null)
                        {
                            cart = new ShoppingCart(product.Id, quantity, product.Price * quantity, true);
                        }
                    }

                    cmd = new SqlCommand(
                              "Insert into ShoppingCart(product_id,quantity,cost,isEvent) " +
                              "Values(@product_id,@quantity,@cost,@isEvent)"
                              , sqlcon);

                    cmd.Parameters.AddWithValue("@product_id", cart.Product_id);
                    cmd.Parameters.AddWithValue("@quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@cost", cart.Cost);
                    cmd.Parameters.AddWithValue("@isEvent", cart.IsEvent);
                    cmd.ExecuteNonQuery();
                    if (product != null)
                        товарыToolStripMenuItem_Click(this, e);
                    if (ev != null)
                        мероприятияToolStripMenuItem_Click(this, e);
                }
            }
        }

        private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Корзина";
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);

            List<ShoppingCart> cart = new List<ShoppingCart>();
            CurrentObject = new ShoppingCart();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            var cmd = new SqlCommand("Select * from ShoppingCart", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Название продукта");
            dataGridView1.Columns.Add("", "Кол-во");
            dataGridView1.Columns.Add("", "Цена");
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    cart.Add(new ShoppingCart(int.Parse(dr["product_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), bool.Parse(dr["isEvent"].ToString())));
                }
            }

            foreach (var item in cart)
            {
                if (item.IsEvent == false)
                {
                    cmd = new SqlCommand("Select * from Products where id=@id", sqlcon);
                    cmd.Parameters.AddWithValue("@id", item.Product_id);
                }
                else
                {
                    cmd = new SqlCommand("Select * from Events where id=@id", sqlcon);
                    cmd.Parameters.AddWithValue("@id", item.Product_id);
                }

                var tag = from c in cart where item.Product_id == c.Product_id && item.IsEvent == c.IsEvent select c;
                int i = 0;
                cmd.ExecuteNonQuery();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(new object[] { item.Product_id, dr["name"].ToString(), item.Quantity, item.Cost });
                        dataGridView1.Rows[i].Tag = tag;
                        i++;
                    }
                }
            }
        }

        private void историяПокупокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            label1.Text = "История покупок";
            contextMenuStrip1.Items.Clear();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                ShoppingCart deleteElem = dataGridView1.CurrentRow.Tag as ShoppingCart;
                var cmd = new SqlCommand("delete * from ShoppingCart where product_id=@product_id", sqlcon);
                cmd.Parameters.AddWithValue("@product_id", deleteElem.Product_id);

                dataGridView1.Rows.RemoveAt(index);
                корзинаToolStripMenuItem_Click(this, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

