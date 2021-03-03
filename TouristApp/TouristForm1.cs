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
            CurrentObject = new Product();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Visible = true;

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

        private void dataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                foreach (var item in Controls)
                {
                    if (item is Label)
                    {
                        Label lab = item as Label;
                        lab.Visible = false;
                    }
                }
            }
            else
            {
                foreach (var item in Controls)
                {
                    if (item is Label)
                    {
                        Label lab = item as Label;
                        lab.Visible = true;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tooStripTxtBxName.Text = PersonalInfo.Surname + " " + PersonalInfo.Name + " " + PersonalInfo.Thirdname;
        }

        private void мероприятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentObject = new Event();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Events", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.Columns.Add("", "Описание");
            dataGridView1.Columns.Add("", "Дата проведения");
            dataGridView1.Columns.Add("", "Код места проведения");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["description"].ToString(), dr["date"].ToString(), dr["workPlace_id"].ToString() });
                    dataGridView1.Rows[i].Tag = new Event(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["date"].ToString(), int.Parse(dr["workPlace_id"].ToString()));
                    i++;
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (CurrentObject is Product)
                {

                }
                if (CurrentObject is Event)
                {
                    Event selected = dataGridView1.CurrentRow.Tag as Event;
                    Event ev = null;
                    var cmd = new SqlCommand("Select * from ShoppingCart where id=@id", sqlcon);

                    cmd.Parameters.AddWithValue("@id", selected.Id);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ev = new Event(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["date"].ToString(), int.Parse(dr["workPlace_id"].ToString()));
                        }
                    }

                    if (ev != null)
                    {

                    }
                }
            }
        }
    }
}
