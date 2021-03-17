using AppIS;
using Microsoft.Office.Interop.Excel;
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
using Application = Microsoft.Office.Interop.Excel.Application;

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
            dataGridView1.Visible = true;
            panel1.Visible = false;
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
            dataGridView1.Visible = true;
            panel1.Visible = false;
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
            dataGridView1.Visible = true;
            panel1.Visible = false; CurrentObject = new Order();
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
            this.Close();
        }
        private void забронированныеБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            panel1.Visible = false; CurrentObject = new BookedTicket();
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
        private void FindTable(string table)
        {

            switch (table)
            {
                case "Работники":
                    {
                        Table = "Workers";
                    }
                    break;
                case "Рабочие места":
                    {
                        Table = "WorkPlaces";
                    }
                    break;
                case "Профессии":
                    {
                        Table = "Professions";
                    }
                    break;
                case "Оборудование":
                    {
                        Table = "Equipment";
                    }
                    break;
                case "Рабочие дни":
                    {
                        Table = "Workdays";
                    }
                    break;
                case "Здания на территории":
                    {
                        Table = "Buildings";
                    }
                    break;
                case "Комнаты":
                    {
                        Table = "Rooms";
                    }
                    break;
                case "Права пользователей":
                    {
                        Table = "UsersPower";
                    }
                    break;
                case "Жильцы":
                    {
                        Table = "Tourists";
                    }
                    break;
                case "Заказы":
                    {
                        Table = "Orders";
                    }
                    break;
                case "Забронированные билеты":
                    {
                        Table = "BookedTickets";
                    }
                    break;
                case "Продукты":
                    {
                        Table = "Products";
                    }
                    break;
                case "Мероприятия":
                    {
                        Table = "Events";
                    }
                    break;
            }
        }
        private void FindAttribute(string tableName, string attribute)
        {
            if (attribute != "Не заполнять")
            {
                switch (tableName)
                {
                    case "Работники":
                        {
                            if (attribute == "Логин")
                                Attribute = "login";
                            if (attribute == "Пароль")
                                Attribute = "password";
                            if (attribute == "Код профессии")
                                Attribute = "profession_id";
                            if (attribute == "Имя")
                                Attribute = "name";
                            if (attribute == "Фамилия")
                                Attribute = "surname";
                            if (attribute == "Отчество")
                                Attribute = "thirdname";
                            if (attribute == "Дата рождения")
                                Attribute = "dateOfBirth";
                            if (attribute == "Код рабочего места")
                                Attribute = "workPlace_id";
                            if (attribute == "Телеф. номер")
                                Attribute = "phoneNumber";
                        }
                        break;
                    case "Рабочие места":
                        {
                            if (attribute == "Код рабочего места")
                                Attribute = "id";
                            if (attribute == "Код места в здании")
                                Attribute = "place_id";
                            if (attribute == "Код здания")
                                Attribute = "building_id";
                        }
                        break;
                    case "Профессии":
                        {
                            if (attribute == "Код профессии")
                                Attribute = "id";
                            if (attribute == "Название")
                                Attribute = "name";
                        }
                        break;
                    case "Оборудование":
                        {
                            if (attribute == "Код оборудования")
                                Attribute = "id";
                            if (attribute == "Название")
                                Attribute = "name";
                            if (attribute == "Количество в наличии")
                                Attribute = "quantity";
                            if (attribute == "Код профессии")
                                Attribute = "profession_id";
                        }
                        break;
                    case "Рабочие дни":
                        {
                            if (attribute == "Логин рабочего")
                                Attribute = "worker_login";
                            if (attribute == "Рабочие дни")
                                Attribute = "workDays";
                        }
                        break;
                    case "Здания на территории":
                        {
                            if (attribute == "Код здания")
                                Attribute = "id";
                            if (attribute == "Количество комнат")
                                Attribute = "rooms";
                        }
                        break;
                    case "Комнаты":
                        {
                            if (attribute == "Номер комнаты")
                                Attribute = "id";
                            if (attribute == "Цена")
                                Attribute = "price";
                            if (attribute == "Количество кроватей")
                                Attribute = "beds";
                            if (attribute == "Занят?")
                                Attribute = "isAvailable";
                            if (attribute == "Код здания")
                                Attribute = "building_id";
                        }
                        break;
                    case "Права пользователей":
                        {
                            if (attribute == "Код профессии")
                                Attribute = "profession_id";
                            if (attribute == "Ограниченные права?")
                                Attribute = "limitPower";
                        }
                        break;
                    case "Жильцы":
                        {
                            if (attribute == "Логин")
                                Attribute = "login";
                            if (attribute == "Пароль")
                                Attribute = "password";
                            if (attribute == "Эл. почта")
                                Attribute = "email";
                            if (attribute == "Имя")
                                Attribute = "name";
                            if (attribute == "Фамилия")
                                Attribute = "surname";
                            if (attribute == "Отчество")
                                Attribute = "thirdname";
                            if (attribute == "Дата рождения")
                                Attribute = "dateOfBirth";
                            if (attribute == "Дата приезда")
                                Attribute = "dateOfComing";
                            if (attribute == "Дата отъезда")
                                Attribute = "dateOfLeaving";
                            if (attribute == "Страна")
                                Attribute = "country";
                            if (attribute == "Номер комнаты")
                                Attribute = "room_id";
                        }
                        break;
                    case "Заказы":
                        {
                            if (attribute == "Код заказа")
                                Attribute = "order_id";
                            if (attribute == "Код продукта")
                                Attribute = "product_id";
                            if (attribute == "Количество")
                                Attribute = "quantity";
                            if (attribute == "Стоимость")
                                Attribute = "cost";
                            if (attribute == "Логин заказчика")
                                Attribute = "login";
                            if (attribute == "Дата оформления")
                                Attribute = "dateOrder";
                            if (attribute == "Оплачен?")
                                Attribute = "isDone";
                        }
                        break;
                    case "Забронированные билеты":
                        {
                            if (attribute == "Код заказа")
                                Attribute = "item_id";
                            if (attribute == "Код мероприятия")
                                Attribute = "event_id";
                            if (attribute == "Количество")
                                Attribute = "quantity";
                            if (attribute == "Стоимость")
                                Attribute = "cost";
                            if (attribute == "Логин заказчика")
                                Attribute = "login";
                            if (attribute == "Оплачен?")
                                Attribute = "isPaid";
                        }
                        break;
                    case "Продукты":
                        {
                            if (attribute == "Код продукта")
                                Attribute = "product_id";
                            if (attribute == "Название")
                                Attribute = "name";
                            if (attribute == "Цена")
                                Attribute = "price";
                            if (attribute == "Описание")
                                Attribute = "description";
                            if (attribute == "Тип")
                                Attribute = "type";
                            if (attribute == "Количество в наличии")
                                Attribute = "quantity";
                        }
                        break;
                    case "Мероприятия":
                        {
                            if (attribute == "Код мероприятия")
                                Attribute = "id";
                            if (attribute == "Название")
                                Attribute = "name";
                            if (attribute == "Цена")
                                Attribute = "price";
                            if (attribute == "Описание")
                                Attribute = "description";
                            if (attribute == "Дата проведения")
                                Attribute = "date";
                            if (attribute == "Код рабочего места")
                                Attribute = "workPlace_id";
                            if (attribute == "Количество в наличии")
                                Attribute = "quantity";
                        }
                        break;
                }
            }
            else
                Attribute = null;
        }
        private void FindExtraAttribute(string tableName, string attribute)
        {

            switch (tableName)
            {
                case "Работники":
                    {
                        if (attribute == "Логин")
                            ExtraAttribute = "login";
                        if (attribute == "Пароль")
                            ExtraAttribute = "password";
                        if (attribute == "Код профессии")
                            ExtraAttribute = "profession_id";
                        if (attribute == "Имя")
                            ExtraAttribute = "name";
                        if (attribute == "Фамилия")
                            ExtraAttribute = "surname";
                        if (attribute == "Отчество")
                            ExtraAttribute = "thirdname";
                        if (attribute == "Дата рождения")
                            ExtraAttribute = "dateOfBirth";
                        if (attribute == "Код рабочего места")
                            ExtraAttribute = "workPlace_id";
                        if (attribute == "Телеф. номер")
                            ExtraAttribute = "phoneNumber";
                    }
                    break;
                case "Рабочие места":
                    {
                        if (attribute == "Код рабочего места")
                            ExtraAttribute = "id";
                        if (attribute == "Код места в здании")
                            ExtraAttribute = "place_id";
                        if (attribute == "Код здания")
                            ExtraAttribute = "building_id";
                    }
                    break;
                case "Профессии":
                    {
                        if (attribute == "Код профессии")
                            ExtraAttribute = "id";
                        if (attribute == "Название")
                            ExtraAttribute = "name";
                    }
                    break;
                case "Оборудование":
                    {
                        if (attribute == "Код оборудования")
                            ExtraAttribute = "id";
                        if (attribute == "Название")
                            ExtraAttribute = "name";
                        if (attribute == "Количество в наличии")
                            ExtraAttribute = "quantity";
                        if (attribute == "Код профессии")
                            ExtraAttribute = "profession_id";
                    }
                    break;
                case "Рабочие дни":
                    {
                        if (attribute == "Логин рабочего")
                            ExtraAttribute = "worker_login";
                        if (attribute == "Рабочие дни")
                            ExtraAttribute = "workDays";
                    }
                    break;
                case "Здания на территории":
                    {
                        if (attribute == "Код здания")
                            ExtraAttribute = "id";
                        if (attribute == "Количество комнат")
                            ExtraAttribute = "rooms";
                    }
                    break;
                case "Комнаты":
                    {
                        if (attribute == "Номер комнаты")
                            ExtraAttribute = "id";
                        if (attribute == "Цена")
                            ExtraAttribute = "price";
                        if (attribute == "Количество кроватей")
                            ExtraAttribute = "beds";
                        if (attribute == "Занят?")
                            ExtraAttribute = "isAvailable";
                        if (attribute == "Код здания")
                            ExtraAttribute = "building_id";
                    }
                    break;
                case "Права пользователей":
                    {
                        if (attribute == "Код профессии")
                            ExtraAttribute = "profession_id";
                        if (attribute == "Ограниченные права?")
                            ExtraAttribute = "limitPower";
                    }
                    break;
                case "Жильцы":
                    {
                        if (attribute == "Логин")
                            ExtraAttribute = "login";
                        if (attribute == "Пароль")
                            ExtraAttribute = "password";
                        if (attribute == "Эл. почта")
                            ExtraAttribute = "email";
                        if (attribute == "Имя")
                            ExtraAttribute = "name";
                        if (attribute == "Фамилия")
                            ExtraAttribute = "surname";
                        if (attribute == "Отчество")
                            ExtraAttribute = "thirdname";
                        if (attribute == "Дата рождения")
                            ExtraAttribute = "dateOfBirth";
                        if (attribute == "Дата приезда")
                            ExtraAttribute = "dateOfComing";
                        if (attribute == "Дата отъезда")
                            ExtraAttribute = "dateOfLeaving";
                        if (attribute == "Страна")
                            ExtraAttribute = "country";
                        if (attribute == "Номер комнаты")
                            ExtraAttribute = "room_id";
                    }
                    break;
                case "Заказы":
                    {
                        if (attribute == "Код заказа")
                            ExtraAttribute = "order_id";
                        if (attribute == "Код продукта")
                            ExtraAttribute = "product_id";
                        if (attribute == "Количество")
                            ExtraAttribute = "quantity";
                        if (attribute == "Стоимость")
                            ExtraAttribute = "cost";
                        if (attribute == "Логин заказчика")
                            ExtraAttribute = "login";
                        if (attribute == "Дата оформления")
                            ExtraAttribute = "dateOrder";
                        if (attribute == "Оплачен?")
                            ExtraAttribute = "isDone";
                    }
                    break;
                case "Забронированные билеты":
                    {
                        if (attribute == "Код заказа")
                            ExtraAttribute = "item_id";
                        if (attribute == "Код мероприятия")
                            ExtraAttribute = "event_id";
                        if (attribute == "Количество")
                            ExtraAttribute = "quantity";
                        if (attribute == "Стоимость")
                            ExtraAttribute = "cost";
                        if (attribute == "Логин заказчика")
                            ExtraAttribute = "login";
                        if (attribute == "Оплачен?")
                            ExtraAttribute = "isPaid";
                    }
                    break;
                case "Продукты":
                    {
                        if (attribute == "Код продукта")
                            ExtraAttribute = "product_id";
                        if (attribute == "Название")
                            ExtraAttribute = "name";
                        if (attribute == "Цена")
                            ExtraAttribute = "price";
                        if (attribute == "Описание")
                            ExtraAttribute = "description";
                        if (attribute == "Тип")
                            ExtraAttribute = "type";
                        if (attribute == "Количество в наличии")
                            ExtraAttribute = "quantity";
                    }
                    break;
                case "Мероприятия":
                    {
                        if (attribute == "Код мероприятия")
                            ExtraAttribute = "id";
                        if (attribute == "Название")
                            ExtraAttribute = "name";
                        if (attribute == "Цена")
                            ExtraAttribute = "price";
                        if (attribute == "Описание")
                            ExtraAttribute = "description";
                        if (attribute == "Дата проведения")
                            ExtraAttribute = "date";
                        if (attribute == "Код рабочего места")
                            ExtraAttribute = "workPlace_id";
                        if (attribute == "Количество в наличии")
                            ExtraAttribute = "quantity";
                    }
                    break;
            }
        }
        List<string> ReceptionWorkerItems = new List<string>() { "Заказы", "Забронированные билеты", "Продукты", "Мероприятия" };
        public string Table { get; set; }
        public string Attribute { get; set; }
        public string ExtraAttribute { get; set; }
        private void FillAttributes()
        {
            comboBoxAttribute.Items.Clear();
            string selectedItem = comboBoxObj.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Работники":
                    comboBoxAttribute.Items.AddRange(new string[] { "Логин", "Пароль", "Код профессии", "Имя", "Фамилия", "Отчество", "Дата рождения", "Код рабочего места", "Телеф. номер", "Не заполнять" });
                    break;
                case "Рабочие места":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код рабочего места", "Код места в здании", "Код здания", "Не заполнять" });
                    break;
                case "Профессии":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код профессии", "Название", "Не заполнять" });
                    break;
                case "Оборудование":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код оборудования", "Название", "Количество в наличии", "Код профессии", "Не заполнять" });
                    break;
                case "Рабочие дни":
                    comboBoxAttribute.Items.AddRange(new string[] { "Логин рабочего", "Рабочие дни", "Не заполнять" });
                    break;
                case "Здания на территории":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код здания", "Количество комнат", "Не заполнять" });
                    break;
                case "Комнаты":
                    comboBoxAttribute.Items.AddRange(new string[] { "Номер комнаты", "Цена", "Количество кроватей", "Занят?", "Код здания", "Не заполнять" });
                    break;
                case "Права пользователей":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код профессии", "Ограниченные права?", "Не заполнять" });
                    break;
                case "Жильцы":
                    comboBoxAttribute.Items.AddRange(new string[] { "Логин", "Пароль", "Эл. почта", "Имя", "Фамилия", "Отчество", "Дата рождения", "Дата приезда", "Дата отъезда",
                        "Страна", "Номер комнаты","Не заполнять"});
                    break;
                case "Заказы":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код заказа", "Код продукта", "Количество", "Стоимость", "Логин заказчика", "Дата оформления", "Оплачен?", "Не заполнять" });
                    break;
                case "Забронированные билеты":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код заказа", "Код мероприятия", "Количество", "Стоимость", "Логин заказчика", "Оплачен?", "Не заполнять" });
                    break;
                case "Продукты":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код продукта", "Название", "Цена", "Описание", "Тип", "Количество в наличии", "Не заполнять" });
                    break;
                case "Мероприятия":
                    comboBoxAttribute.Items.AddRange(new string[] { "Код мероприятия", "Название", "Цена", "Описание", "Дата проведения", "Код рабочего места", "Количество в наличии", "Не заполнять" });
                    break;
            }
            comboBoxAttribute.Text = comboBoxAttribute.Items[comboBoxAttribute.Items.Count - 1].ToString();
        }

        private void FillExtraAttributes()
        {
            cmbBoxExtraAttribute.Items.Clear();
            string selectedItem = comboBoxObj.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Работники":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Логин", "Пароль", "Код профессии", "Имя", "Фамилия", "Отчество", "Дата рождения", "Код рабочего места", "Телеф. номер" });
                    break;
                case "Рабочие места":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код рабочего места", "Код места в здании", "Код здания" });
                    break;
                case "Профессии":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код профессии", "Название" });
                    break;
                case "Оборудование":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код оборудования", "Название", "Количество в наличии", "Код профессии" });
                    break;
                case "Рабочие дни":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Логин рабочего", "Рабочие дни" });
                    break;
                case "Здания на территории":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код здания", "Количество комнат" });
                    break;
                case "Комнаты":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Номер комнаты", "Цена", "Количество кроватей", "Занят?", "Код здания" });
                    break;
                case "Права пользователей":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код профессии", "Ограниченные права?" });
                    break;
                case "Жильцы":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Логин", "Пароль", "Эл. почта", "Имя", "Фамилия", "Отчество", "Дата рождения", "Дата приезда", "Дата отъезда",
                        "Страна", "Номер комнаты"});
                    break;
                case "Заказы":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код заказа", "Код продукта", "Количество", "Стоимость", "Логин заказчика", "Дата оформления", "Оплачен?" });
                    break;
                case "Забронированные билеты":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код заказа", "Код мероприятия", "Количество", "Стоимость", "Логин заказчика", "Оплачен?" });
                    break;
                case "Продукты":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код продукта", "Название", "Цена", "Описание", "Тип", "Количество в наличии" });
                    break;
                case "Мероприятия":
                    cmbBoxExtraAttribute.Items.AddRange(new string[] { "Код мероприятия", "Название", "Цена", "Описание", "Дата проведения", "Код рабочего места", "Количество в наличии" });
                    break;
            }

            cmbBoxExtraAttribute.Text = cmbBoxExtraAttribute.Items[0].ToString();
        }
        private void конструкторЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxObj.Items.Clear();
            dataGridView1.Visible = false;
            panel1.Visible = true;
            foreach (var item in ReceptionWorkerItems)
            {
                comboBoxObj.Items.Add(item);
            }
            comboBoxObj.Text = comboBoxObj.Items[0].ToString();
        }

        private void comboBoxObj_SelectedValueChanged(object sender, EventArgs e)
        {
            FindTable(comboBoxObj.SelectedItem.ToString());
            FillAttributes();
            if (checkBox1.Checked)
                FillExtraAttributes();
        }

        private void txtBxSomeText_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBxSomeText.Text == "Введите значение...")
                txtBxSomeText.Text = string.Empty;
        }
        private string safeString = " 0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";

        private void txtBxSomeText_TextChanged(object sender, EventArgs e)
        {
            int counter = 0;
            for (int i = 0; i < txtBxSomeText.Text.Length; i++)
            {
                if (safeString.Contains(txtBxSomeText.Text[i]))
                    counter++;
            }
            if (counter != txtBxSomeText.Text.Length)
            {
                txtBxSomeText.ForeColor = Color.Red;
            }
            else
            {
                txtBxSomeText.ForeColor = Color.Black;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                FillExtraAttributes();
                cmbBoxAndOr.Enabled = true;
                cmbBoxAndOr.Items.AddRange(new string[] { "И", "ИЛИ" });
                cmbBoxAndOr.Text = cmbBoxAndOr.Items[0].ToString();
                cmbBoxExtraAttribute.Enabled = true;
                FillExtraAttributes();
                cmbBxExtraSign.Enabled = true;
                cmbBxExtraSign.Items.AddRange(new string[] { "=", "!=" });
                cmbBxExtraSign.Text = cmbBxExtraSign.Items[0].ToString();
                txtbxExtraSomeText.Enabled = true;
                txtbxExtraSomeText.Text = "Введите значение...";
            }
            else
            {
                cmbBoxAndOr.Items.Clear();
                cmbBoxAndOr.Enabled = false;
                cmbBoxAndOr.Enabled = false;
                cmbBoxExtraAttribute.Enabled = false;
                cmbBoxExtraAttribute.Items.Clear();
                cmbBxExtraSign.Enabled = false;
                cmbBxExtraSign.Items.Clear();
                txtbxExtraSomeText.Text = "";
                txtbxExtraSomeText.Enabled = false;
            }
        }

        private void txtbxExtraSomeText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxExtraSomeText_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtbxExtraSomeText.Text == "Введите значение...")
                txtbxExtraSomeText.Text = string.Empty;
        }

        private void comboBoxAttribute_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxAttribute.SelectedItem.ToString() != "Не заполнять")
            {
                FindAttribute(comboBoxObj.SelectedItem.ToString(), comboBoxAttribute.SelectedItem.ToString());

                txtBxSomeText.Text = "Введите значение...";
                txtBxSomeText.Enabled = true;
                comboBoxSign.Enabled = true;
                comboBoxSign.Items.Clear();
                comboBoxSign.Items.AddRange(new string[] { "=", "!=" });
                comboBoxSign.Text = comboBoxSign.Items[0].ToString();
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                comboBoxSign.Items.Clear();
                comboBoxSign.Enabled = false;
                txtBxSomeText.Text = "";
                txtBxSomeText.Enabled = false;
            }
        }

        private void cmbBoxExtraAttribute_SelectedValueChanged(object sender, EventArgs e)
        {
            FindExtraAttribute(comboBoxObj.SelectedItem.ToString(), cmbBoxExtraAttribute.SelectedItem.ToString());
        }
        private void ConvertToAttributeDataType(string tableCMB, string attribute, string inputText, ref dynamic outPut)
        {
            switch (tableCMB)
            {
                case "Работники":
                    {
                        if (attribute == "Дата рождения" || attribute == "Логин" || attribute == "Пароль" || attribute == "Имя" || attribute == "Фамилия" || attribute == "Отчество" || attribute == "Телеф. номер")
                            outPut = inputText;

                        if (attribute == "Код профессии" || attribute == "Код рабочего места")
                            outPut = int.Parse(outPut);
                    }
                    break;
                case "Рабочие места":
                    {
                        if (attribute == "Код места в здании" || attribute == "Код здания")
                            outPut = inputText;
                        if (attribute == "Код рабочего места")
                            outPut = int.Parse(inputText);
                    }
                    break;
                case "Профессии":
                    {
                        if (attribute == "Код профессии")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Название")
                        {
                            outPut = inputText;
                        }
                    }
                    break;
                case "Оборудование":
                    {
                        if (attribute == "Код оборудования" || attribute == "Количество в наличии" || attribute == "Код профессии")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Название")
                        {
                            outPut = inputText;
                        }
                    }
                    break;
                case "Рабочие дни":
                    {
                        if (attribute == "Логин рабочего" || attribute == "Рабочие дни")
                        {
                            outPut = inputText;
                        }
                    }
                    break;
                case "Здания на территории":
                    {
                        if (attribute == "Код здания")
                        {
                            outPut = inputText;
                        }
                        if (attribute == "Количество комнат")
                        {
                            outPut = int.Parse(inputText);
                        }
                    }
                    break;
                case "Комнаты":
                    {
                        if (attribute == "Номер комнаты" || attribute == "Количество кроватей")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Цена")
                        {
                            outPut = decimal.Parse(inputText);
                        }
                        if (attribute == "Занят?")
                        {
                            outPut = bool.Parse(inputText);
                        }
                        if (attribute == "Код здания")
                        {
                            outPut = inputText;
                        }
                    }
                    break;
                case "Права пользователей":
                    {
                        if (attribute == "Код профессии")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Ограниченные права?")
                        {
                            outPut = bool.Parse(inputText);
                        }
                    }
                    break;
                case "Жильцы":
                    {

                        if (attribute == "Дата рождения" || attribute == "Логин" || attribute == "Пароль" || attribute == "Имя"
                    || attribute == "Фамилия" || attribute == "Отчество" || attribute == "Эл. почта" || attribute == "Дата приезда"
                    || attribute == "Дата отъезда" || attribute == "Страна")
                        {
                            outPut = inputText;
                        }
                        if (attribute == "Номер комнаты")
                        {
                            outPut = int.Parse(inputText);
                        }
                    }
                    break;
                case "Заказы":
                    {
                        if (attribute == "Код заказа" || attribute == "Код продукта" || attribute == "Количество")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Стоимость")
                        {
                            outPut = decimal.Parse(inputText);
                        }
                        if (attribute == "Логин заказчика" || attribute == "Дата оформления")
                        {
                            outPut = inputText;
                        }
                        if (attribute == "Оплачен ?")
                        {
                            outPut = bool.Parse(inputText);
                        }
                    }
                    break;
                case "Забронированные билеты":
                    {
                        if (attribute == "Код заказа" || attribute == "Код мероприятия" || attribute == "Количество")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Стоимость")
                        {
                            outPut = decimal.Parse(inputText);
                        }
                        if (attribute == "Логин заказчика")
                        {
                            outPut = inputText;
                        }
                        if (attribute == "Оплачен?")
                        {
                            outPut = bool.Parse(inputText);
                        }
                    }
                    break;
                case "Продукты":
                    {
                        if (attribute == "Код продукта" || attribute == "Количество в наличии")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Название" || attribute == "Описание" || attribute == "Тип")
                        {
                            outPut = inputText;
                        }
                        if (attribute == "Цена")
                        {
                            outPut = decimal.Parse(inputText);
                        }
                    }
                    break;
                case "Мероприятия":
                    {
                        if (attribute == "Код мероприятия" || attribute == "Количество в наличии" || attribute == "Код рабочего места")
                        {
                            outPut = int.Parse(inputText);
                        }
                        if (attribute == "Название" || attribute == "Описание" || attribute == "Дата проведения")
                        {
                            outPut = inputText;
                        }
                        if (attribute == "Цена")
                        {
                            outPut = decimal.Parse(inputText);
                        }
                    }
                    break;
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dynamic input1 = 0;
            dynamic input2 = 0;

            dgwSearchResults.Rows.Clear();
            dgwSearchResults.Columns.Clear();
            string request = string.Empty;

            if (comboBoxAttribute.SelectedItem.ToString() != "Не заполнять" && checkBox1.Checked == false)
            {
                string text = txtBxSomeText.Text.Trim(' ');
                if (text == string.Empty)
                    MessageBox.Show("Заполните данные");
                else
                {
                    request = $"Select * from {Table} where {Attribute}{comboBoxSign.SelectedItem.ToString()}@{Attribute}";
                }
            }
            if (comboBoxAttribute.SelectedItem.ToString() == "Не заполнять" && checkBox1.Checked == false)
            {
                request = $"Select * from {Table}";
            }
            if (comboBoxAttribute.SelectedItem.ToString() != "Не заполнять" && checkBox1.Checked == true)
            {
                string orAnd = string.Empty;
                if (cmbBoxAndOr.SelectedItem.ToString() == "И")
                    orAnd = "AND";
                else
                    orAnd = "OR";

                string text2 = txtbxExtraSomeText.Text.Trim(' ');
                string text = txtBxSomeText.Text.Trim(' ');
                if (text == string.Empty || text2 == string.Empty)
                    MessageBox.Show("Заполните данные");
                else
                {
                    request = $"Select * from {Table} where {Attribute}{comboBoxSign.SelectedItem.ToString()}@{Attribute} {orAnd} " +
                        $"{ExtraAttribute} {cmbBxExtraSign.SelectedItem.ToString()}@{ExtraAttribute}1";
                }
            }

            try
            {
                ConvertToAttributeDataType(comboBoxObj.SelectedItem.ToString(), comboBoxAttribute.SelectedItem.ToString(), txtBxSomeText.Text, ref input1);
                if (txtbxExtraSomeText.Enabled)
                    ConvertToAttributeDataType(comboBoxObj.SelectedItem.ToString(), cmbBoxExtraAttribute.SelectedItem.ToString(), txtbxExtraSomeText.Text, ref input2);

                switch (Table)
                {
                    case "Workers":
                        {
                            dgwSearchResults.Columns.Add("", "Логин");
                            dgwSearchResults.Columns.Add("", "Пароль");
                            dgwSearchResults.Columns.Add("", "Код профессии");
                            dgwSearchResults.Columns.Add("", "Имя");
                            dgwSearchResults.Columns.Add("", "Фамилия");
                            dgwSearchResults.Columns.Add("", "Отчество");
                            dgwSearchResults.Columns.Add("", "Дата рождения");
                            dgwSearchResults.Columns.Add("", "Код рабочего места");
                            dgwSearchResults.Columns.Add("", "Телеф. номер");
                        }
                        break;
                    case "Workdays":
                        {
                            dgwSearchResults.Columns.Add("", "Логин рабочего");
                            dgwSearchResults.Columns.Add("", "Рабочие дни");
                        }
                        break;
                    case "Professions":
                        {
                            dgwSearchResults.Columns.Add("", "Код профессии");
                            dgwSearchResults.Columns.Add("", "Название");
                        }
                        break;
                    case "Equipment":
                        {
                            dgwSearchResults.Columns.Add("", "Код оборудования");
                            dgwSearchResults.Columns.Add("", "Название");
                            dgwSearchResults.Columns.Add("", "Кол-во в наличии");
                            dgwSearchResults.Columns.Add("", "Код профессии");
                        }
                        break;
                    case "UsersPower":
                        {
                            dgwSearchResults.Columns.Add("", "Код профессии");
                            dgwSearchResults.Columns.Add("", "Ограниченные права?");
                        }
                        break;
                    case "WorkPlaces":
                        {
                            dgwSearchResults.Columns.Add("", "Код рабочего места");
                            dgwSearchResults.Columns.Add("", "Код места в здании");
                            dgwSearchResults.Columns.Add("", "Код здания");
                        }
                        break;
                    case "Buildings":
                        {
                            dgwSearchResults.Columns.Add("", "Код здания");
                            dgwSearchResults.Columns.Add("", "Кол-во комнат");
                        }
                        break;
                    case "Rooms":
                        {
                            dgwSearchResults.Columns.Add("", "Номер комнаты");
                            dgwSearchResults.Columns.Add("", "Цена");
                            dgwSearchResults.Columns.Add("", "Кол-во в кроватей");
                            dgwSearchResults.Columns.Add("", "Свободен?");
                            dgwSearchResults.Columns.Add("", "Код здания");
                        }
                        break;
                    case "Events":
                        {
                            dgwSearchResults.Columns.Add("", "Код мероприятия");
                            dgwSearchResults.Columns.Add("", "Название");
                            dgwSearchResults.Columns.Add("", "Цена");
                            dgwSearchResults.Columns.Add("", "Описание");
                            dgwSearchResults.Columns.Add("", "Дата проведения");
                            dgwSearchResults.Columns.Add("", "Код рабочего места");
                            dgwSearchResults.Columns.Add("", "Кол-во билетов в наличии");
                        }
                        break;
                    case "Tourists":
                        {
                            dgwSearchResults.Columns.Add("", "Логин");
                            dgwSearchResults.Columns.Add("", "Пароль");
                            dgwSearchResults.Columns.Add("", "Эл. почта");
                            dgwSearchResults.Columns.Add("", "Имя");
                            dgwSearchResults.Columns.Add("", "Фамилия");
                            dgwSearchResults.Columns.Add("", "Отчество");
                            dgwSearchResults.Columns.Add("", "Дата рождения");
                            dgwSearchResults.Columns.Add("", "Дата приезда");
                            dgwSearchResults.Columns.Add("", "Дата отъезда");
                            dgwSearchResults.Columns.Add("", "Страна");
                            dgwSearchResults.Columns.Add("", "Номер комнаты");
                        }
                        break;
                    case "BookedTickets":
                        {
                            dgwSearchResults.Columns.Add("", "Код заказа");
                            dgwSearchResults.Columns.Add("", "Код мероприятия");
                            dgwSearchResults.Columns.Add("", "Кол-во");
                            dgwSearchResults.Columns.Add("", "Стоимость");
                            dgwSearchResults.Columns.Add("", "Логин заказчика");
                            dgwSearchResults.Columns.Add("", "Оплачен?");
                        }
                        break;
                    case "Orders":
                        {
                            dgwSearchResults.Columns.Add("", "Код заказа");
                            dgwSearchResults.Columns.Add("", "Код товара");
                            dgwSearchResults.Columns.Add("", "Кол-во");
                            dgwSearchResults.Columns.Add("", "Стоимость");
                            dgwSearchResults.Columns.Add("", "Логин заказчика");
                            dgwSearchResults.Columns.Add("", "Дата оформления заказа");
                            dgwSearchResults.Columns.Add("", "Оплачен?");
                        }
                        break;
                    case "Products":
                        {
                            dgwSearchResults.Columns.Add("", "Код товара");
                            dgwSearchResults.Columns.Add("", "Название");
                            dgwSearchResults.Columns.Add("", "Цена");
                            dgwSearchResults.Columns.Add("", "Описание");
                            dgwSearchResults.Columns.Add("", "Вид");
                            dgwSearchResults.Columns.Add("", "Кол-во в наличии");
                        }
                        break;
                }
                var cmd = new SqlCommand(request, sqlcon);
                cmd.Parameters.AddWithValue($"@{Attribute}", input1);
                cmd.Parameters.AddWithValue($"@{ExtraAttribute}1", input2);
                using (var dr = cmd.ExecuteReader())
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        counter++;
                        switch (Table)
                        {
                            case "Events":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["name"].ToString(), dr["price"].ToString(),
                                        dr["description"].ToString(), dr["date"].ToString(), dr["workPlace_id"].ToString(), dr["quantity"].ToString() });
                                break;

                            case "BookedTickets":
                                if (dr["login"].ToString() == PersonalInfo.Login)
                                {
                                    dgwSearchResults.Rows.Add(new string[] { dr["item_id"].ToString(), dr["event_id"].ToString(), dr["quantity"].ToString(),
                                        dr["cost"].ToString(), dr["login"].ToString(), dr["isPaid"].ToString() });
                                }
                                break;
                            case "Orders":
                                if (dr["login"].ToString() == PersonalInfo.Login)
                                {
                                    dgwSearchResults.Rows.Add(new string[] { dr["order_id"].ToString(), dr["product_id"].ToString(), dr["quantity"].ToString(),
                                        dr["cost"].ToString(), dr["login"].ToString(), dr["dateOrder"].ToString(), dr["isDone"].ToString() });
                                }
                                break;
                            case "Products":
                                dgwSearchResults.Rows.Add(new string[] { dr["product_id"].ToString(), dr["name"].ToString(), dr["price"].ToString(),
                                        dr["description"].ToString(), dr["type"].ToString(), dr["quantity"].ToString()});
                                break;
                        }
                    }
                    if (counter == 0)
                    {
                        dgwSearchResults.Rows.Clear();
                        dgwSearchResults.Columns.Clear();
                        MessageBox.Show("Такие записи отсутствуют в базе данных");
                    }
                }
            }
            catch (Exception)
            {
                dgwSearchResults.Rows.Clear();
                dgwSearchResults.Columns.Clear();
                MessageBox.Show("Ошибка в формировании запроса");
            }

        }
    }
}

