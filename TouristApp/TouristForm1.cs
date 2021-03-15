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
                    dataGridView1.Rows.Add(new object[] { dr["product_id"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["description"].ToString(), dr["type"].ToString(), dr["quantity"].ToString() });
                    dataGridView1.Rows[i].Tag = new Product(int.Parse(dr["product_id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["type"].ToString(), int.Parse(dr["quantity"].ToString()));
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
            if (dataGridView1.RowCount > 0 && CurrentObject is Product)
            {
                var cmd = new SqlCommand("Select * from Orders", sqlcon);
                cmd.ExecuteNonQuery();
                int count = 0;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        count++;
                    }
                }

                Order orders = null;
                Product product = null;
                CountChoosingForm ccf = null;
                int quantity = 0;

                product = dataGridView1.CurrentRow.Tag as Product;
                if (product.Quantity > 0)
                {
                    cmd = new SqlCommand("Select * from Orders where @product_id=product_id AND login=@login AND @isDone=isDone", sqlcon);
                    cmd.Parameters.AddWithValue("@product_id", product.Id);
                    cmd.Parameters.AddWithValue("@login", PersonalInfo.Login);
                    cmd.Parameters.AddWithValue("@isDone", false);
                    cmd.ExecuteNonQuery();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orders = new Order(int.Parse(dr["order_id"].ToString()), int.Parse(dr["product_id"].ToString()),
                                int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), dr["dateOrder"].ToString(),
                                dr["login"].ToString(), bool.Parse(dr["isDone"].ToString()));
                        }
                    }
                    if (orders == null)
                        ccf = new CountChoosingForm(product.Quantity, 0);
                    else
                        ccf = new CountChoosingForm(product.Quantity, orders.Quantity);

                    if (ccf.ShowDialog() == DialogResult.OK)
                    {
                        quantity = ccf.Count;

                        if (orders != null)
                        {
                            orders.Quantity += quantity;
                            orders.Cost = orders.Quantity * product.Price;
                            cmd = new SqlCommand(
                            "delete from Orders where order_id=@order_id"
                            , sqlcon);
                            cmd.Parameters.AddWithValue("@order_id", orders.Order_id);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            orders = new Order(count + 1, product.Id, quantity, product.Price * quantity, DateTime.Now.ToString(), PersonalInfo.Login, false);
                        }

                        cmd = new SqlCommand(
                                  "Insert into Orders(order_id,product_id,quantity,cost,login,dateOrder,isDone) " +
                                  "Values(@order_id,@product_id,@quantity,@cost,@login,@dateOrder,@isDone)"
                                  , sqlcon);
                        cmd.Parameters.AddWithValue("@order_id", orders.Order_id);
                        cmd.Parameters.AddWithValue("@product_id", orders.Product_id);
                        cmd.Parameters.AddWithValue("@quantity", orders.Quantity);
                        cmd.Parameters.AddWithValue("@cost", orders.Cost);
                        cmd.Parameters.AddWithValue("@login", orders.Login);
                        cmd.Parameters.AddWithValue("@dateOrder", orders.DateOrder);
                        cmd.Parameters.AddWithValue("@isDone", orders.IsDone);
                        cmd.ExecuteNonQuery();

                        if (product != null)
                            товарыToolStripMenuItem_Click(this, e);
                    }
                }
                else
                    MessageBox.Show("Данного товара нет в наличии!");
            }
            if (dataGridView1.RowCount > 0 && CurrentObject is Event)
            {
                var cmd = new SqlCommand("Select * from BookedTickets", sqlcon);
                cmd.ExecuteNonQuery();
                int count = 0;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        count++;
                    }
                }

                BookedTicket bookedTickets = null;
                Event ev = null;
                CountChoosingForm ccf = null;
                int quantity = 0;
                ev = dataGridView1.CurrentRow.Tag as Event;
                if (ev.Quantity > 0)
                {
                    cmd = new SqlCommand("Select * from BookedTickets where @event_id=event_id AND login=@login AND @isPaid=isPaid", sqlcon);
                    cmd.Parameters.AddWithValue("@event_id", ev.Id);
                    cmd.Parameters.AddWithValue("@login", PersonalInfo.Login);
                    cmd.Parameters.AddWithValue("@isPaid", false);
                    cmd.ExecuteNonQuery();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            bookedTickets = new BookedTicket(int.Parse(dr["item_id"].ToString()), int.Parse(dr["event_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), dr["login"].ToString(), bool.Parse(dr["isPaid"].ToString()));
                        }
                    }

                    if (bookedTickets == null)
                        ccf = new CountChoosingForm(ev.Quantity, 0);
                    else
                        ccf = new CountChoosingForm(ev.Quantity, bookedTickets.Quantity);

                    if (ccf.ShowDialog() == DialogResult.OK)
                    {
                        quantity = ccf.Count;

                        if (bookedTickets != null)
                        {
                            bookedTickets.Quantity += quantity;
                            bookedTickets.Cost = bookedTickets.Quantity * ev.Price;
                            cmd = new SqlCommand(
                            "delete from BookedTickets where item_id=@item_id"
                            , sqlcon);
                            cmd.Parameters.AddWithValue("@item_id", bookedTickets.Item_id);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            bookedTickets = new BookedTicket(count + 1, ev.Id, quantity, ev.Price * quantity, PersonalInfo.Login, false);
                        }

                        cmd = new SqlCommand(
                                  "Insert into BookedTickets(item_id,event_id,quantity,cost,login,isPaid) " +
                                  "Values(@item_id,@event_id,@quantity,@cost,@login,@isPaid)"
                                  , sqlcon);
                        cmd.Parameters.AddWithValue("@item_id", bookedTickets.Item_id);
                        cmd.Parameters.AddWithValue("@event_id", bookedTickets.Event_id);
                        cmd.Parameters.AddWithValue("@quantity", bookedTickets.Quantity);
                        cmd.Parameters.AddWithValue("@cost", bookedTickets.Cost);
                        cmd.Parameters.AddWithValue("@login", bookedTickets.Login);
                        cmd.Parameters.AddWithValue("@isPaid", bookedTickets.IsPaid);
                        cmd.ExecuteNonQuery();

                        if (ev != null)
                            мероприятияToolStripMenuItem_Click(this, e);
                    }
                }
                else
                    MessageBox.Show("Данного товара нет в наличии!");
            }
        }

        private void историяПокупокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentObject = new Order();
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            List<Order> orders = new List<Order>();
            dataGridView1.Columns.Add("", "Код заказа");
            dataGridView1.Columns.Add("", "Название товара");
            dataGridView1.Columns.Add("", "Кол-во");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.Columns.Add("", "Дата заказа");
            dataGridView1.Columns.Add("", "Оплачен?");
            var cmd = new SqlCommand("select * from Orders where login=@login", sqlcon);
            cmd.Parameters.AddWithValue("@login", PersonalInfo.Login);
            cmd.ExecuteNonQuery();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    orders.Add(new Order(int.Parse(dr["order_id"].ToString()), int.Parse(dr["product_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), dr["dateOrder"].ToString(), dr["login"].ToString(), bool.Parse(dr["isDone"].ToString())));
                }
            }

            int i = 0;
            foreach (var item in orders)
            {
                cmd = new SqlCommand("select * from Products where product_id=@product_id", sqlcon);
                cmd.Parameters.AddWithValue("@product_id", item.Product_id);
                cmd.ExecuteNonQuery();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(new object[] { item.Product_id, dr["name"].ToString(), item.Quantity, item.Cost, item.DateOrder, item.IsDone });
                        dataGridView1.Rows[i].Tag = item;
                        i++;
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0 && CurrentObject is Order)
            {
                int index = dataGridView1.CurrentRow.Index;
                Order deleteElem = dataGridView1.CurrentRow.Tag as Order;
                var cmd = new SqlCommand("delete from Orders where  order_id=@order_id", sqlcon);
                cmd.Parameters.AddWithValue("@order_id", deleteElem.Order_id);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(index);
            }
            if (dataGridView1.RowCount > 0 && CurrentObject is BookedTicket)
            {
                int index = dataGridView1.CurrentRow.Index;
                BookedTicket deleteElem = dataGridView1.CurrentRow.Tag as BookedTicket;
                var cmd = new SqlCommand("delete from BookedTickets where item_id=@item_id", sqlcon);
                cmd.Parameters.AddWithValue("@item_id", deleteElem.Item_id);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void забронированныеБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentObject = new BookedTicket();
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            List<BookedTicket> bookedTickets = new List<BookedTicket>();
            List<WorkPlace> workPlaces = new List<WorkPlace>();
            dataGridView1.Columns.Add("", "Код мероприятия");
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Кол-во билетов");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.Columns.Add("", "Дата проведения");
            dataGridView1.Columns.Add("", "Место проведения");
            dataGridView1.Columns.Add("", "Оплачено?");
            var cmd = new SqlCommand("select * from BookedTickets where login=@login", sqlcon);
            cmd.Parameters.AddWithValue("@login", PersonalInfo.Login);
            cmd.ExecuteNonQuery();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    bookedTickets.Add(new BookedTicket(int.Parse(dr["item_id"].ToString()), int.Parse(dr["event_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), dr["login"].ToString(), bool.Parse(dr["isPaid"].ToString())));
                }
            }

            cmd = new SqlCommand("select * from WorkPlaces", sqlcon);
            cmd.ExecuteNonQuery();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    workPlaces.Add(new WorkPlace(int.Parse(dr["id"].ToString()), dr["building_id"].ToString(), dr["place_id"].ToString()));
                }
            }

            int i = 0;
            foreach (var item in bookedTickets)
            {
                cmd = new SqlCommand("select * from Events where id=@id", sqlcon);
                cmd.Parameters.AddWithValue("@id", item.Event_id);
                cmd.ExecuteNonQuery();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(new object[] { item.Event_id, dr["name"].ToString(), item.Quantity, item.Cost, dr["date"].ToString(),
                            (from c in workPlaces where c.Id == int.Parse(dr["workPlace_id"].ToString()) select c.Building_id).ToList()[0], item.IsPaid });
                        dataGridView1.Rows[i].Tag = item;
                        i++;
                    }
                }
            }
        }
    }
}

