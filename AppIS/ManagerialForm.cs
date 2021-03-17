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
using System.Windows.Controls;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace AppIS
{
    public partial class ManagerialForm : Form
    {
        public object CurrentObject { get; set; }
        public Worker PersonalInfo { get; set; }
        public ManagerialForm(Worker personalInfo)
        {
            PersonalInfo = personalInfo;

            InitializeComponent();

            Connect();

            DefinePower();
        }

        private SqlConnection sqlcon;

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
        private void списокВсехЖильцовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip2.Visible = false;
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(добавитьToolStripMenuItem);
            contextMenuStrip1.Items.Add(редактироватьToolStripMenuItem1);
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);
            CreateTreeViewOfTourists();
        }

        private void ManagerialForm_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = PersonalInfo.Surname + " " + PersonalInfo.Name + " " + PersonalInfo.Thirdname;
            if (Text == "Форма администратора")
                списокСотрудниковToolStripMenuItem_Click(this, e);
            if (Text == "Форма работника на ресепшене")
                списокВсехЖильцовToolStripMenuItem_Click(this, e);
            if (Text == "Форма сотрудника комплекса")
                рабочиеМестаToolStripMenuItem_Click(this, e);
        }

        private void DefinePower()
        {
            Worker worker = PersonalInfo;

            bool limitPower = false;
            string isEmpty = string.Empty;
            var cmd = new SqlCommand("Select * from UsersPower where profession_id=@profession_id", sqlcon);
            cmd.Parameters.AddWithValue("@profession_id", worker.Profession_id);
            cmd.ExecuteNonQuery();

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    isEmpty = dr["limitPower"].ToString();
                }
            }

            if (isEmpty == string.Empty)
            {
                Text = "Форма сотрудника комплекса";
                туристыToolStripMenuItem.Enabled = false;
                туристыToolStripMenuItem.Visible = false;
                магазинToolStripMenuItem.Enabled = false;
                магазинToolStripMenuItem.Visible = false;
                dataGridView1.ContextMenuStrip.Enabled = false;
                списокСотрудниковToolStripMenuItem.Visible = false;
                списокСотрудниковToolStripMenuItem.Enabled = false;
                оборудованиеToolStripMenuItem.Visible = false;
                оборудованиеToolStripMenuItem.Enabled = false;
                профессииToolStripMenuItem.Visible = false;
                профессииToolStripMenuItem.Enabled = false;
                зданияНаТерриторииToolStripMenuItem.Enabled = false;
                комнатыToolStripMenuItem.Enabled = false;
                зданияНаТерриторииToolStripMenuItem.Visible = false;
                комнатыToolStripMenuItem.Visible = false;
                contextMenuStrip2.Items.Clear();
            }
            else
            {
                limitPower = bool.Parse(isEmpty);

                if (limitPower)
                {
                    Text = "Форма работника на ресепшене";

                    работникиToolStripMenuItem.Visible = false;
                }
                else
                    Text = "Форма администратора";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            CurrentObject = new Order();
            CreateTreeViewOfOrders();
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);
            contextMenuStrip1.Items.Add(редактироватьToolStripMenuItem1);
        }

        private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            CurrentObject = new Product();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
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
                    dataGridView1.Rows.Add(new object[] { dr["product_id"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["description"].ToString(), dr["type"].ToString(), dr["quantity"].ToString() });
                    dataGridView1.Rows[i].Tag = new Product(int.Parse(dr["product_id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["type"].ToString(), int.Parse(dr["quantity"].ToString()));
                    i++;
                }
            }
        }

        private void мероприятияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            CurrentObject = new Event();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

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

        private void списокСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(добавитьToolStripMenuItem);
            contextMenuStrip1.Items.Add(редактироватьToolStripMenuItem1);
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);
            CreateTreeViewOfWorkers();
        }

        private void профессииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;

            CurrentObject = new Profession();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Professions", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Название");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["name"].ToString() });
                    dataGridView1.Rows[i].Tag = new Profession(int.Parse(dr["id"].ToString()), dr["name"].ToString());
                    i++;
                }
            }
        }

        private void рабочиеМестаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;
            CurrentObject = new WorkPlace();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from WorkPlaces", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Код здания");
            dataGridView1.Columns.Add("", "Код места");

            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["building_id"].ToString(), dr["place_id"].ToString() });
                    dataGridView1.Rows[i].Tag = new WorkPlace(int.Parse(dr["id"].ToString()), dr["building_id"].ToString(), dr["place_id"].ToString());
                    i++;
                }
            }
        }

        private void оборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;
            CurrentObject = new Equipment();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Equipment", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Кол-во");
            dataGridView1.Columns.Add("", "Принадлежит профессии");

            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["name"].ToString(), dr["quantity"].ToString(), dr["profession_id"].ToString() });
                    dataGridView1.Rows[i].Tag = new Equipment(int.Parse(dr["id"].ToString()), dr["name"].ToString(), int.Parse(dr["quantity"].ToString()), int.Parse(dr["profession_id"].ToString()));
                    i++;
                }
            }
        }

        private void рабочиеДниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;
            CurrentObject = new WorkDay();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Workdays", sqlcon);
            dataGridView1.Columns.Add("", "Код рабочего");
            dataGridView1.Columns.Add("", "Рабочие дни");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["worker_login"].ToString(), dr["workDays"].ToString() });
                    dataGridView1.Rows[i].Tag = new WorkDay(dr["worker_login"].ToString(), dr["workDays"].ToString());
                    i++;
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                object obj = treeView1.SelectedNode.Tag;

                if (obj is Room)
                {
                    Room room;

                    room = obj as Room;

                    Tourist addingTourist = null;

                    TouristRegisterForm register = new TouristRegisterForm(room.Id);

                    if (register.ShowDialog() == DialogResult.OK)
                    {
                        addingTourist = register.AddingTourist;
                    }

                    if (addingTourist != null)
                    {
                        var cmd = new SqlCommand("Select * from Tourists where login=@login AND password=@password", sqlcon);
                        cmd.Parameters.AddWithValue("@login", addingTourist.Login);
                        cmd.Parameters.AddWithValue("@password", addingTourist.Password);
                        cmd.ExecuteNonQuery();

                        Tourist temp = null;
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                temp = new Tourist(dr["login"].ToString(), dr["password"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(), dr["email"].ToString(), dr["dateOfComing"].ToString(), dr["dateOfLeaving"].ToString(), dr["country"].ToString(), int.Parse(dr["room_id"].ToString()));
                            }
                        }

                        if (temp == null)
                        {
                            cmd = new SqlCommand(
                            "Insert into Tourists(login,password,email,name,surname,thirdname,dateOfBirth,dateOfComing,dateOfLeaving,country,room_id) " +
                            "Values(@login,@password,@email,@name,@surname,@thirdname,@dateOfBirth,@dateOfComing,@dateOfLeaving,@country,@room_id)"
                            , sqlcon);

                            cmd.Parameters.AddWithValue("@login", addingTourist.Login);
                            cmd.Parameters.AddWithValue("@password", addingTourist.Password);
                            cmd.Parameters.AddWithValue("@email", addingTourist.Email);
                            cmd.Parameters.AddWithValue("@name", addingTourist.Name);
                            cmd.Parameters.AddWithValue("@surname", addingTourist.Surname);
                            cmd.Parameters.AddWithValue("@thirdname", addingTourist.Thirdname);
                            cmd.Parameters.AddWithValue("@dateOfBirth", addingTourist.DateOfBirth);
                            cmd.Parameters.AddWithValue("@dateOfComing", addingTourist.DateOfComing);
                            cmd.Parameters.AddWithValue("@dateOfLeaving", addingTourist.DateOfLeaving);
                            cmd.Parameters.AddWithValue("@country", addingTourist.Country);
                            cmd.Parameters.AddWithValue("@room_id", addingTourist.Room_id);

                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("Update Rooms SET isAvailable=@isAvailable where id=@id", sqlcon);
                            cmd.Parameters.AddWithValue("@id", addingTourist.Room_id);
                            cmd.Parameters.AddWithValue("@isAvailable", false);
                            cmd.ExecuteNonQuery();
                            CreateTreeViewOfTourists();
                        }
                        else
                            MessageBox.Show("Турист с таким логином и паролем уже зарегистрирован");
                    }
                }
                else
                if (obj is WorkPlace)
                {
                    WorkPlace workPlace = obj as WorkPlace;

                    Worker addingWorker = null;

                    List<int> Profession_ids = new List<int>();
                    List<int> WorkPlaces_ids = new List<int>();
                    var comm = new SqlCommand("select * from Professions", sqlcon);
                    using (var dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Profession_ids.Add(int.Parse(dr["id"].ToString()));
                        }
                    }
                    comm = new SqlCommand("select * from WorkPlaces", sqlcon);

                    using (var dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            WorkPlaces_ids.Add(int.Parse(dr["id"].ToString()));
                        }
                    }

                    WorkerRegisterForm register = new WorkerRegisterForm(workPlace.Id, Profession_ids, WorkPlaces_ids);

                    if (register.ShowDialog() == DialogResult.OK)
                    {
                        addingWorker = register.AddingWorker;
                    }

                    if (addingWorker != null)
                    {
                        var cmd = new SqlCommand("Select * from Workers where login=@login AND password=@password", sqlcon);
                        cmd.Parameters.AddWithValue("@login", addingWorker.Login);
                        cmd.Parameters.AddWithValue("@password", addingWorker.Password);
                        cmd.ExecuteNonQuery();

                        Worker temp = null;

                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                temp = new Worker(dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(),
                                    int.Parse(dr["profession_id"].ToString()), int.Parse(dr["workPlace_id"].ToString()), dr["phoneNumber"].ToString(), dr["login"].ToString(),
                                    dr["password"].ToString());
                            }
                        }

                        if (temp == null)
                        {
                            cmd = new SqlCommand(
                          "Insert into Workers(login,password,profession_id,name,surname,thirdname,dateOfBirth,workPlace_id,phoneNumber) " +
                          "Values(@login,@password,@profession_id,@name,@surname,@thirdname,@dateOfBirth,@workPlace_id,@phoneNumber)"
                          , sqlcon);

                            cmd.Parameters.AddWithValue("@login", addingWorker.Login);
                            cmd.Parameters.AddWithValue("@password", addingWorker.Password);
                            cmd.Parameters.AddWithValue("@profession_id", addingWorker.Profession_id);
                            cmd.Parameters.AddWithValue("@name", addingWorker.Name);
                            cmd.Parameters.AddWithValue("@surname", addingWorker.Surname);
                            cmd.Parameters.AddWithValue("@thirdname", addingWorker.Thirdname);
                            cmd.Parameters.AddWithValue("@dateOfBirth", addingWorker.DateOfBirth);
                            cmd.Parameters.AddWithValue("@workPlace_id", addingWorker.WorkPlace_id);
                            cmd.Parameters.AddWithValue("@phoneNumber", addingWorker.DateOfBirth);

                            cmd.ExecuteNonQuery();
                            CreateTreeViewOfWorkers();
                        }
                        else
                            MessageBox.Show("Работник с таким логином и паролем уже зарегистрирован");
                    }
                }
            }
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                object obj = treeView1.SelectedNode.Tag;

                if (obj is Tourist)
                {
                    Tourist addingTourist = treeView1.SelectedNode.Tag as Tourist;

                    TouristRegisterForm change = new TouristRegisterForm(addingTourist);

                    if (change.ShowDialog() == DialogResult.OK)
                    {
                        addingTourist = change.AddingTourist;
                        var cmd = new SqlCommand("delete from Tourists where login=@login", sqlcon);
                        cmd.Parameters.AddWithValue("@login", addingTourist.Login);
                        cmd.ExecuteNonQuery();
                        treeView1.SelectedNode.Remove();

                        cmd = new SqlCommand(
                                   "Insert into Tourists(login,password,email,name,surname,thirdname,dateOfBirth,dateOfComing,dateOfLeaving,country,room_id) " +
                                   "Values(@login,@password,@email,@name,@surname,@thirdname,@dateOfBirth,@dateOfComing,@dateOfLeaving,@country,@room_id)"
                                   , sqlcon);

                        cmd.Parameters.AddWithValue("@login", addingTourist.Login);
                        cmd.Parameters.AddWithValue("@password", addingTourist.Password);
                        cmd.Parameters.AddWithValue("@email", addingTourist.Email);
                        cmd.Parameters.AddWithValue("@name", addingTourist.Name);
                        cmd.Parameters.AddWithValue("@surname", addingTourist.Surname);
                        cmd.Parameters.AddWithValue("@thirdname", addingTourist.Thirdname);
                        cmd.Parameters.AddWithValue("@dateOfBirth", addingTourist.DateOfBirth);
                        cmd.Parameters.AddWithValue("@dateOfComing", addingTourist.DateOfComing);
                        cmd.Parameters.AddWithValue("@dateOfLeaving", addingTourist.DateOfLeaving);
                        cmd.Parameters.AddWithValue("@country", addingTourist.Country);
                        cmd.Parameters.AddWithValue("@room_id", addingTourist.Room_id);

                        cmd.ExecuteNonQuery();
                        CreateTreeViewOfTourists();
                    }
                }
                else
                if (obj is Worker)
                {
                    List<int> Profession_ids = new List<int>();
                    List<int> WorkPlaces_ids = new List<int>();
                    var comm = new SqlCommand("select * from Professions", sqlcon);
                    using (var dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Profession_ids.Add(int.Parse(dr["id"].ToString()));
                        }
                    }
                    comm = new SqlCommand("select * from WorkPlaces", sqlcon);

                    using (var dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            WorkPlaces_ids.Add(int.Parse(dr["id"].ToString()));
                        }
                    }
                    Worker newWorker = treeView1.SelectedNode.Tag as Worker;

                    WorkerRegisterForm change = new WorkerRegisterForm(newWorker, Profession_ids, WorkPlaces_ids);

                    if (change.ShowDialog() == DialogResult.OK)
                    {
                        newWorker = change.AddingWorker;
                        var cmd = new SqlCommand("delete from Workers where login=@login", sqlcon);
                        cmd.Parameters.AddWithValue("@login", newWorker.Login);
                        cmd.ExecuteNonQuery();
                        treeView1.SelectedNode.Remove();

                        cmd = new SqlCommand(
                                 "Insert into Workers(login,password,profession_id,name,surname,thirdname,dateOfBirth,workPlace_id,phoneNumber) " +
                                 "Values(@login,@password,@profession_id,@name,@surname,@thirdname,@dateOfBirth,@workPlace_id,@phoneNumber)"
                                 , sqlcon);

                        cmd.Parameters.AddWithValue("@login", newWorker.Login);
                        cmd.Parameters.AddWithValue("@password", newWorker.Password);
                        cmd.Parameters.AddWithValue("@profession_id", newWorker.Profession_id);
                        cmd.Parameters.AddWithValue("@name", newWorker.Name);
                        cmd.Parameters.AddWithValue("@surname", newWorker.Surname);
                        cmd.Parameters.AddWithValue("@thirdname", newWorker.Thirdname);
                        cmd.Parameters.AddWithValue("@dateOfBirth", newWorker.DateOfBirth);
                        cmd.Parameters.AddWithValue("@workPlace_id", newWorker.WorkPlace_id);
                        cmd.Parameters.AddWithValue("@phoneNumber", newWorker.PhoneNumber);

                        cmd.ExecuteNonQuery();
                        CreateTreeViewOfWorkers();
                    }
                }
                else
                if (obj is Order)
                {
                    OrderRegisterForm equipRegister = new OrderRegisterForm(treeView1.SelectedNode.Tag as Order);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        Order created = equipRegister.AddingOrder;

                        var cmd = new SqlCommand(
                            "delete from Orders where order_id=@order_id"
                            , sqlcon);

                        cmd.Parameters.AddWithValue("@order_id", created.Order_id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                                "Insert into Orders(order_id,product_id,quantity,cost,login,dateOrder,isDone) " +
                                "Values(@order_id,@product_id,@quantity,@cost,@login,@dateOrder,@isDone)"
                                , sqlcon);
                        cmd.Parameters.AddWithValue("@order_id", created.Order_id);
                        cmd.Parameters.AddWithValue("@product_id", created.Product_id);
                        cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                        cmd.Parameters.AddWithValue("@cost", created.Cost);
                        cmd.Parameters.AddWithValue("@login", created.Login);
                        cmd.Parameters.AddWithValue("@dateOrder", created.DateOrder);
                        cmd.Parameters.AddWithValue("@isDone", created.IsDone);
                        cmd.ExecuteNonQuery();

                        if (created.IsDone)
                        {
                            cmd = new SqlCommand("select * from Products where product_id=@product_id", sqlcon);
                            cmd.Parameters.AddWithValue("@product_id", created.Product_id);
                            cmd.ExecuteNonQuery();
                            Product elem = new Product();
                            using (var dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    elem = new Product(int.Parse(dr["product_id"].ToString()), dr["name"].ToString(),
                                        decimal.Parse(dr["price"].ToString()), dr["description"].ToString(),
                                        dr["type"].ToString(), int.Parse(dr["quantity"].ToString()));
                                }
                            }

                            elem.Quantity -= created.Quantity;


                            cmd = new SqlCommand("UPDATE Products SET quantity=@quantity where @product_id=product_id", sqlcon);
                            cmd.Parameters.AddWithValue("@quantity", elem.Quantity);
                            cmd.Parameters.AddWithValue("@product_id", elem.Id);
                            cmd.ExecuteNonQuery();
                            treeView1.SelectedNode.BackColor = Color.Green;
                        }

                        заказыToolStripMenuItem_Click(this, e);
                    }
                }
                else
                if (obj is BookedTicket)
                {
                    BookedTicketRegisterForm equipRegister = new BookedTicketRegisterForm(treeView1.SelectedNode.Tag as BookedTicket);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        BookedTicket created = equipRegister.AddingTicket;

                        var cmd = new SqlCommand(
                              "delete from BookedTickets where item_id=@item_id"
                              , sqlcon);

                        cmd.Parameters.AddWithValue("@item_id", created.Item_id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                            "Insert into BookedTickets(item_id,event_id,quantity,cost,login,isPaid) " +
                            "Values(@item_id,@event_id,@quantity,@cost,@login,@isPaid)"
                            , sqlcon);
                        cmd.Parameters.AddWithValue("@item_id", created.Item_id);
                        cmd.Parameters.AddWithValue("@event_id", created.Event_id);
                        cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                        cmd.Parameters.AddWithValue("@cost", created.Cost);
                        cmd.Parameters.AddWithValue("@login", created.Login);
                        cmd.Parameters.AddWithValue("@isPaid", created.isPaid);
                        cmd.ExecuteNonQuery();

                        if (created.isPaid)
                        {
                            cmd = new SqlCommand("select * from Events where id=@id", sqlcon);
                            cmd.Parameters.AddWithValue("@id", created.Event_id);
                            cmd.ExecuteNonQuery();
                            Event elem = new Event();
                            using (var dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    elem = new Event(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()),
                                        dr["description"].ToString(), dr["date"].ToString(),
                                        int.Parse(dr["workPlace_id"].ToString()), int.Parse(dr["quantity"].ToString()));
                                }
                            }

                            elem.Quantity -= created.Quantity;
                            cmd = new SqlCommand("UPDATE Events SET quantity=@quantity where @id=id", sqlcon);
                            cmd.Parameters.AddWithValue("@quantity", elem.Quantity);
                            cmd.Parameters.AddWithValue("@id", elem.Id);
                            cmd.ExecuteNonQuery();
                            treeView1.SelectedNode.BackColor = Color.Green;
                        }

                        бронированиеБилетовToolStripMenuItem_Click(this, e);
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                object tag = treeView1.SelectedNode.Tag;

                if (tag is Tourist || tag is Worker)
                {
                    object obj = new object();
                    var cmd = new SqlCommand();

                    if (treeView1.SelectedNode.Tag is Tourist)
                    {
                        Tourist tourist = treeView1.SelectedNode.Tag as Tourist;
                        obj = tourist as Tourist;
                        cmd = new SqlCommand("delete from Orders where login=@login", sqlcon);
                        cmd.Parameters.AddWithValue("@login", tourist.Login);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from BookedTickets where login=@login", sqlcon);
                        cmd.Parameters.AddWithValue("@login", tourist.Login);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("delete from Tourists where login=@login", sqlcon);
                        cmd.Parameters.AddWithValue("@login", tourist.Login);
                    }

                    if (tag is Worker)
                    {
                        Worker worker = tag as Worker;
                        obj = worker as Worker;
                        cmd = new SqlCommand("delete from Workers where login=@login", sqlcon);
                        cmd.Parameters.AddWithValue("@login", worker.Login);
                    }

                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                    if (obj is Worker)
                        CreateTreeViewOfWorkers();
                    if (obj is Tourist)
                        CreateTreeViewOfTourists();
                }
                if (tag is BookedTicket || tag is Order)
                {
                    if (tag is Order)
                    {
                        Order ev = tag as Order;

                        var cmd = new SqlCommand(
                             "delete from Orders where order_id=@order_id"
                             , sqlcon);

                        cmd.Parameters.AddWithValue("@order_id", ev.Order_id);
                        cmd.ExecuteNonQuery();
                        treeView1.SelectedNode.Remove();
                        CreateTreeViewOfOrders();
                    }
                    if (tag is BookedTicket)
                    {
                        BookedTicket ev = tag as BookedTicket;

                        var cmd = new SqlCommand(
                              "delete from BookedTickets where item_id=@item_id"
                              , sqlcon);

                        cmd.Parameters.AddWithValue("@item_id", ev.Item_id);
                        cmd.ExecuteNonQuery();
                        treeView1.SelectedNode.Remove();
                        CreateTreeOfBookedTickets();
                    }
                }
            }
        }
        private void CreateTreeViewOfOrders()
        {
            treeView1.Visible = true;
            dataGridView1.Visible = false;
            treeView1.Nodes.Clear();

            List<Order> orders = new List<Order>();
            List<Tourist> tourists = new List<Tourist>();

            var cmd = new SqlCommand("Select * from Tourists", sqlcon);

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    tourists.Add(new Tourist(dr["login"].ToString(), dr["password"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(), dr["email"].ToString(), dr["dateOfComing"].ToString(), dr["dateOfLeaving"].ToString(), dr["country"].ToString(), int.Parse(dr["room_id"].ToString())));
                }
            }

            cmd = new SqlCommand("Select * from Orders", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    orders.Add(new Order(int.Parse(dr["order_id"].ToString()), int.Parse(dr["product_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), dr["dateOrder"].ToString(), dr["login"].ToString(), bool.Parse(dr["isDone"].ToString())));
                }
            }


            for (int i = 0; i < tourists.Count; i++)
            {
                TreeNode tourist = new TreeNode();

                tourist.Tag = tourists[i].Login;
                tourist.Text = "(" + tourists[i].Login + ") " + tourists[i].Surname + " " + tourists[i].Name + " " + tourists[i].Thirdname + " [" + tourists[i].Room_id + " номер]";

                for (int j = 0; j < orders.Count; j++)
                {
                    if (orders[j].Login == tourists[i].Login)
                    {
                        TreeNode order = new TreeNode();
                        order.Tag = orders[j];
                        if (orders[j].IsDone)
                            order.BackColor = Color.Green;
                        else
                            order.BackColor = Color.Red;
                        order.Text = orders[j].ToString();
                        tourist.Nodes.Add(order);
                    }
                }

                if (tourist.Nodes.Count > 0)
                    treeView1.Nodes.Add(tourist);
            }
        }
        private void CreateTreeViewOfWorkers()
        {
            treeView1.Visible = true;
            dataGridView1.Visible = false;
            treeView1.Nodes.Clear();

            List<Worker> workers = new List<Worker>();
            List<WorkPlace> workPlaces = new List<WorkPlace>();
            List<Building> buildings = new List<Building>();
            var cmd = new SqlCommand("Select * from Workers", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    workers.Add(new Worker(dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(), int.Parse(dr["profession_id"].ToString()), int.Parse(dr["workPlace_id"].ToString()), dr["phoneNumber"].ToString(), dr["login"].ToString(), dr["password"].ToString()));
                }
            }

            cmd = new SqlCommand("Select * from WorkPlaces", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    workPlaces.Add(new WorkPlace(int.Parse(dr["id"].ToString()), dr["building_id"].ToString(), dr["place_id"].ToString()));
                }
            }

            cmd = new SqlCommand("Select * from Buildings", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    buildings.Add(new Building(dr["id"].ToString(), int.Parse(dr["rooms"].ToString())));
                }
            }

            TreeNode building = new TreeNode();
            TreeNode place = new TreeNode();
            TreeNode worker = new TreeNode();

            for (int i = 0; i < buildings.Count; i++)
            {
                building = new TreeNode();
                building.Text = buildings[i].Id;

                for (int j = 0; j < workPlaces.Count; j++)
                {
                    place = new TreeNode();

                    if (buildings[i].Id == workPlaces[j].Building_id)
                    {
                        place.Text = workPlaces[j].Place_id;
                        place.Tag = workPlaces[j];

                        for (int x = 0; x < workers.Count; x++)
                        {
                            if (workPlaces[j].Id == workers[x].WorkPlace_id)
                            {
                                worker = new TreeNode(workers[x].ToString());
                                worker.Tag = workers[x];
                                place.Nodes.Add(worker);
                            }
                        }
                        building.Text = buildings[i].Id;
                        //building.Tag = buildings[i].Id;
                        building.Nodes.Add(place);
                    }
                }


                treeView1.Nodes.Add(building);
            }
        }
        private void CreateTreeViewOfTourists()
        {
            treeView1.Visible = true;
            dataGridView1.Visible = false;
            treeView1.Nodes.Clear();

            List<Building> buildings = new List<Building>();
            List<Tourist> tourists = new List<Tourist>();
            List<Room> rooms = new List<Room>();

            var cmd = new SqlCommand("Select * from Tourists", sqlcon);

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    tourists.Add(new Tourist(dr["login"].ToString(), dr["password"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(), dr["email"].ToString(), dr["dateOfComing"].ToString(), dr["dateOfLeaving"].ToString(), dr["country"].ToString(), int.Parse(dr["room_id"].ToString())));
                }
            }

            cmd = new SqlCommand("Select * from Buildings", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    buildings.Add(new Building(dr["id"].ToString(), int.Parse(dr["rooms"].ToString())));
                }
            }

            cmd = new SqlCommand("Select * from Rooms", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    rooms.Add(new Room(int.Parse(dr["id"].ToString()), decimal.Parse(dr["price"].ToString()), int.Parse(dr["beds"].ToString()), bool.Parse(dr["isAvailable"].ToString()), dr["building_id"].ToString()));
                }
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                TreeNode building = new TreeNode();
                TreeNode room;
                uint emptyNodes = 0;

                for (int j = 0; j < rooms.Count; j++)
                {
                    if (buildings[i].Id == rooms[j].Building_id)
                    {
                        room = new TreeNode();

                        for (int x = 0; x < tourists.Count; x++)
                        {
                            if (rooms[j].Id == tourists[x].Room_id)
                            {
                                TreeNode resident = new TreeNode(tourists[x].ToString());
                                resident.Tag = tourists[x];
                                room.Nodes.Add(resident);
                            }
                        }

                        if (room.Nodes.Count == 0)
                        {
                            emptyNodes++;
                            room.BackColor = Color.ForestGreen;
                            room.Text = $"Номер ({rooms[j].Id}) Свободен, Кроватей : {rooms[j].Beds}, Цена {rooms[j].Price}p";
                        }
                        else
                        {
                            room.BackColor = Color.Red;
                            room.Text = $"Номер ({rooms[j].Id}) Занят";
                        }


                        room.Tag = rooms[j];

                        cmd = new SqlCommand("Update Rooms SET @isAvailable=isAvailable where @id=id", sqlcon);
                        cmd.Parameters.AddWithValue("@id", rooms[j].Id);

                        if (room.Nodes.Count == 0)
                        {
                            cmd.Parameters.AddWithValue("@isAvailable", true);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@isAvailable", false);
                        }
                        cmd.ExecuteNonQuery();
                        building.Nodes.Add(room);
                    }
                }

                building.Text = $"{buildings[i].Id} [{emptyNodes} / {building.Nodes.Count}]";
                treeView1.Nodes.Add(building);
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand();

            if (CurrentObject is WorkPlace)
            {
                WorkPlace wp = new WorkPlace();
                if (dataGridView1.RowCount > 0)
                    wp = dataGridView1.Rows[dataGridView1.RowCount - 1].Tag as WorkPlace;

                List<string> building_ids = new List<string>();
                cmd = new SqlCommand("Select * from Buildings", sqlcon);
                cmd.ExecuteNonQuery();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        building_ids.Add(dr["id"].ToString());
                    }
                }

                WorkPlaceRegisterForm wpRegister = new WorkPlaceRegisterForm(wp.Id + 1, building_ids);
                if (wpRegister.ShowDialog() == DialogResult.OK)
                {
                    WorkPlace created = wpRegister.AddingWorkPlace;

                    cmd = new SqlCommand(
                           "Insert into WorkPlaces(id,place_id,building_id) " +
                           "Values(@id,@place_id,@building_id)"
                           , sqlcon);

                    cmd.Parameters.AddWithValue("@id", created.Id);
                    cmd.Parameters.AddWithValue("@place_id", created.Place_id);
                    cmd.Parameters.AddWithValue("@building_id", created.Building_id);

                    cmd.ExecuteNonQuery();
                    рабочиеМестаToolStripMenuItem_Click(this, e);
                }
            }
            if (CurrentObject is Profession)
            {
                Profession prof = new Profession();
                if (dataGridView1.RowCount > 0)
                    prof = dataGridView1.Rows[dataGridView1.RowCount - 1].Tag as Profession;

                ProfessionRegisterForm profRegister = new ProfessionRegisterForm(prof.Id + 1);

                if (profRegister.ShowDialog() == DialogResult.OK)
                {
                    Profession created = profRegister.AddingProfession;

                    cmd = new SqlCommand(
                           "Insert into Professions(id,name) " +
                           "Values(@id,@name)"
                           , sqlcon);

                    cmd.Parameters.AddWithValue("@id", created.Id);
                    cmd.Parameters.AddWithValue("@name", created.Name);
                    cmd.ExecuteNonQuery();

                    string rights = profRegister.Rights;

                    if (rights == "Полные" || rights == "Ограниченные")
                    {
                        cmd = new SqlCommand(
                             "Insert into UsersPower(profession_id,limitPower) " +
                             "Values(@profession_id,@limitPower)"
                             , sqlcon);

                        bool limitPower = false;
                        if (rights == "Полные")
                            limitPower = true;
                        else
                            limitPower = false;

                        cmd.Parameters.AddWithValue("@profession_id", created.Id);
                        cmd.Parameters.AddWithValue("@limitPower", limitPower);
                        cmd.ExecuteNonQuery();
                    }

                    профессииToolStripMenuItem_Click(this, e);
                }
            }
            if (CurrentObject is Equipment)
            {
                Equipment eq = new Equipment();
                if (dataGridView1.RowCount > 0)
                    eq = dataGridView1.Rows[dataGridView1.RowCount - 1].Tag as Equipment;

                List<int> professions = new List<int>();
                cmd = new SqlCommand("select * from Professions", sqlcon);
                cmd.ExecuteNonQuery();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        professions.Add(int.Parse(dr["id"].ToString()));
                    }
                }
                EquipmentRegisterForm equipRegister = new EquipmentRegisterForm(eq.Id + 1, professions);

                if (equipRegister.ShowDialog() == DialogResult.OK)
                {
                    Equipment created = equipRegister.AddingEquipment;

                    cmd = new SqlCommand(
                           "Insert into Equipment(id,name,quantity,profession_id) " +
                           "Values(@id,@name,@quantity,@profession_id)"
                           , sqlcon);

                    cmd.Parameters.AddWithValue("@id", created.Id);
                    cmd.Parameters.AddWithValue("@name", created.Name);
                    cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                    cmd.Parameters.AddWithValue("@profession_id", created.ProfessionId);
                    cmd.ExecuteNonQuery();
                    оборудованиеToolStripMenuItem_Click(this, e);
                }
            }
            if (CurrentObject is WorkDay)
            {
                List<string> onCheck = new List<string>();
                cmd = new SqlCommand("select worker_login from Workdays", sqlcon);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        onCheck.Add(dr["worker_login"].ToString());
                    }
                }

                List<string> logins = new List<string>();
                cmd = new SqlCommand("select login from Workers", sqlcon);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!onCheck.Contains(dr["login"].ToString()))
                            logins.Add(dr["login"].ToString());
                    }
                }
                if (logins.Count > 0)
                {
                    WorkDayRegisterForm equipRegister = new WorkDayRegisterForm(logins);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        WorkDay created = equipRegister.AddingWorkDay;

                        cmd = new SqlCommand(
                               "Insert into Workdays(worker_login,workDays) " +
                               "Values(@worker_login,@workDays)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@worker_login", created.WorkerLogin);
                        cmd.Parameters.AddWithValue("@workDays", created.WorkDays);
                        cmd.ExecuteNonQuery();
                        рабочиеДниToolStripMenuItem_Click(this, e);
                    }
                }
                else
                    MessageBox.Show("У всех работников уже есть расписание рабочих дней");
            }
            if (CurrentObject is Product)
            {
                Product pr = new Product();
                if (dataGridView1.RowCount > 0)
                    pr = dataGridView1.Rows[dataGridView1.RowCount - 1].Tag as Product;

                ProductRegisterForm equipRegister = new ProductRegisterForm(pr.Id + 1);

                if (equipRegister.ShowDialog() == DialogResult.OK)
                {
                    Product created = equipRegister.AddingProduct;

                    cmd = new SqlCommand(
                           "Insert into Products(product_id,name,price,description,type,quantity) " +
                           "Values(@product_id,@name,@price,@description,@type,@quantity)"
                           , sqlcon);

                    cmd.Parameters.AddWithValue("@product_id", created.Id);
                    cmd.Parameters.AddWithValue("@name", created.Name);
                    cmd.Parameters.AddWithValue("@price", created.Price);
                    cmd.Parameters.AddWithValue("@description", created.Description);
                    cmd.Parameters.AddWithValue("@type", created.Type);
                    cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                    cmd.ExecuteNonQuery();
                    продуктыToolStripMenuItem_Click(this, e);
                }
            }
            if (CurrentObject is Event)
            {
                Event ev = new Event();
                if (dataGridView1.RowCount > 0)
                    ev = dataGridView1.Rows[dataGridView1.RowCount - 1].Tag as Event;

                List<int> workPlace_ids = new List<int>();
                cmd = new SqlCommand("Select * from Events", sqlcon);
                cmd.ExecuteNonQuery();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        workPlace_ids.Add(int.Parse(dr["id"].ToString()));
                    }
                }

                EventRegisterForm equipRegister = new EventRegisterForm(ev.Id + 1, workPlace_ids);

                if (equipRegister.ShowDialog() == DialogResult.OK)
                {
                    Event created = equipRegister.AddingEvent;

                    cmd = new SqlCommand(
                           "Insert into Events(id,name,price,description,date,workPlace_id,quantity) " +
                           "Values(@id,@name,@price,@description,@date,@workPlace_id,@quantity)"
                           , sqlcon);

                    cmd.Parameters.AddWithValue("@id", created.Id);
                    cmd.Parameters.AddWithValue("@name", created.Name);
                    cmd.Parameters.AddWithValue("@price", created.Price);
                    cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                    cmd.Parameters.AddWithValue("@description", created.Description);
                    cmd.Parameters.AddWithValue("@date", created.Date);
                    cmd.Parameters.AddWithValue("@workPlace_id", created.WorkPlace_id);
                    cmd.ExecuteNonQuery();
                    мероприятияToolStripMenuItem1_Click(this, e);
                }
            }
            if (CurrentObject is Building)
            {
                BuildingRegisterForm equipRegister = new BuildingRegisterForm();

                if (equipRegister.ShowDialog() == DialogResult.OK)
                {
                    Building created = equipRegister.AddinBuilding;

                    cmd = new SqlCommand(
                           "Insert into Buildings(id,rooms) " +
                           "Values(@id,@rooms)"
                           , sqlcon);

                    cmd.Parameters.AddWithValue("@id", created.Id);
                    cmd.Parameters.AddWithValue("@rooms", created.Rooms);
                    cmd.ExecuteNonQuery();
                    зданияНаТерриторииToolStripMenuItem_Click(this, e);
                }
            }
            if (CurrentObject is UserPower)
            {
                cmd = new SqlCommand("Select profession_id from UsersPower", sqlcon);
                cmd.ExecuteNonQuery();

                List<int> onCheck = new List<int>();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        onCheck.Add(int.Parse(dr["profession_id"].ToString()));
                    }
                }

                cmd = new SqlCommand("Select * from Professions", sqlcon);
                cmd.ExecuteNonQuery();

                List<int> professions = new List<int>();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!onCheck.Contains(int.Parse(dr["id"].ToString())))
                            professions.Add(int.Parse(dr["id"].ToString()));
                    }
                }

                if (professions.Count > 0)
                {
                    UserPowerRegisterForm userPowerR = new UserPowerRegisterForm(professions);

                    if (userPowerR.ShowDialog() == DialogResult.OK)
                    {
                        UserPower created = userPowerR.AddingPower;

                        cmd = new SqlCommand(
                               "Insert into UsersPower(profession_id,limitPower) " +
                               "Values(@profession_id,@limitPower)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@profession_id", created.Profession_id);
                        cmd.Parameters.AddWithValue("@limitPower", created.LimitPower);
                        cmd.ExecuteNonQuery();
                        праваПользователейToolStripMenuItem_Click(this, e);
                    }
                }
                else
                    MessageBox.Show("У всех существующих профессий уже есть права");
            }
            if (CurrentObject is Room)
            {
                cmd = new SqlCommand("Select * from Rooms", sqlcon);
                cmd.ExecuteNonQuery();
                int id = 0;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        id = int.Parse(dr["id"].ToString());
                    }
                }
                List<string> buildings = new List<string>();
                cmd = new SqlCommand("Select * from Buildings", sqlcon);
                cmd.ExecuteNonQuery();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        buildings.Add(dr["id"].ToString());
                    }
                }

                RoomRegisterForm equipRegister = new RoomRegisterForm(id + 1, buildings);

                if (equipRegister.ShowDialog() == DialogResult.OK)
                {
                    List<Room> created = equipRegister.Rooms;

                    int count = 0;
                    cmd = new SqlCommand("Select * from Rooms where @building_id=building_id", sqlcon);
                    cmd.Parameters.AddWithValue("@building_id", created[0].Building_id);
                    cmd.ExecuteNonQuery();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            count++;
                        }
                    }

                    int iCount = 0;
                    cmd = new SqlCommand("Select * from Buildings where @id=id", sqlcon);
                    cmd.Parameters.AddWithValue("@id", created[0].Building_id);
                    cmd.ExecuteNonQuery();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            iCount = int.Parse(dr["rooms"].ToString());
                        }
                    }

                    count = iCount - count;

                    if (count >= created.Count)
                    {
                        for (int i = 0; i < created.Count; i++)
                        {
                            cmd = new SqlCommand(
                                                      "Insert into Rooms(id,price,beds,isAvailable,building_id) " +
                                                      "Values(@id,@price,@beds,@isAvailable,@building_id)"
                                                      , sqlcon);

                            cmd.Parameters.AddWithValue("@id", created[i].Id);
                            cmd.Parameters.AddWithValue("@price", created[i].Price);
                            cmd.Parameters.AddWithValue("@beds", created[i].Beds);
                            cmd.Parameters.AddWithValue("@isAvailable", created[i].IsAvailable);
                            cmd.Parameters.AddWithValue("@building_id", created[i].Building_id);
                            cmd.ExecuteNonQuery();
                        }

                        комнатыToolStripMenuItem_Click(this, e);
                    }
                    else
                        MessageBox.Show($"Превышение максимального кол-ва создаваемых комнат в здании ({created[0].Building_id})");
                }
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand();

            if (dataGridView1.RowCount > 0)
            {
                object obj = dataGridView1.CurrentRow.Tag;

                if (obj is WorkPlace)
                {
                    List<string> building_ids = new List<string>();
                    cmd = new SqlCommand("Select * from Buildings", sqlcon);
                    cmd.ExecuteNonQuery();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            building_ids.Add(dr["id"].ToString());
                        }
                    }
                    WorkPlaceRegisterForm wpRegister = new WorkPlaceRegisterForm(obj as WorkPlace, building_ids);
                    if (wpRegister.ShowDialog() == DialogResult.OK)
                    {
                        WorkPlace created = wpRegister.AddingWorkPlace;

                        cmd = new SqlCommand(
                              "delete from WorkPlaces where id=@id", sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                               "Insert into WorkPlaces(id,place_id,building_id) " +
                               "Values(@id,@place_id,@building_id)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.Parameters.AddWithValue("@place_id", created.Place_id);
                        cmd.Parameters.AddWithValue("@building_id", created.Building_id);

                        cmd.ExecuteNonQuery();
                        рабочиеМестаToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is Profession)
                {
                    ProfessionRegisterForm profRegister = new ProfessionRegisterForm(obj as Profession);

                    if (profRegister.ShowDialog() == DialogResult.OK)
                    {
                        Profession created = profRegister.AddingProfession;

                        cmd = new SqlCommand(
                             "delete from Professions where id=@id"
                             , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                               "Insert into Professions(id,name) " +
                               "Values(@id,@name)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.Parameters.AddWithValue("@name", created.Name);
                        cmd.ExecuteNonQuery();
                        профессииToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is UserPower)
                {
                    UserPowerRegisterForm profRegister = new UserPowerRegisterForm(obj as UserPower);

                    if (profRegister.ShowDialog() == DialogResult.OK)
                    {
                        UserPower created = profRegister.AddingPower;

                        cmd = new SqlCommand(
                             "UPDATE UsersPower SET limitPower=@limitPower where profession_id=@profession_id"
                             , sqlcon);

                        if (created.LimitPower == true)
                            cmd.Parameters.AddWithValue("@limitPower", 1);
                        else
                            cmd.Parameters.AddWithValue("@limitPower", 0);
                        cmd.Parameters.AddWithValue("@profession_id", created.Profession_id);
                        cmd.ExecuteNonQuery();

                        праваПользователейToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is Equipment)
                {
                    List<int> professions = new List<int>();
                    cmd = new SqlCommand("select * from Professions", sqlcon);
                    cmd.ExecuteNonQuery();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            professions.Add(int.Parse(dr["id"].ToString()));
                        }
                    }
                    EquipmentRegisterForm equipRegister = new EquipmentRegisterForm(obj as Equipment, professions);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        Equipment created = equipRegister.AddingEquipment;
                        cmd = new SqlCommand(
                            "delete from Equipment where id=@id"
                            , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                               "Insert into Equipment(id,name,quantity,profession_id) " +
                               "Values(@id,@name,@quantity,@profession_id)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.Parameters.AddWithValue("@name", created.Name);
                        cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                        cmd.Parameters.AddWithValue("@profession_id", created.ProfessionId);
                        cmd.ExecuteNonQuery();
                        оборудованиеToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is WorkDay)
                {
                    WorkDayRegisterForm equipRegister = new WorkDayRegisterForm(obj as WorkDay);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        WorkDay created = equipRegister.AddingWorkDay;

                        cmd = new SqlCommand(
                            "UPDATE Workdays  SET workDays=@workDays where worker_login=@worker_login"
                            , sqlcon);

                        cmd.Parameters.AddWithValue("@worker_login", created.WorkerLogin);
                        cmd.Parameters.AddWithValue("@workDays", created.WorkDays);
                        cmd.ExecuteNonQuery();
                        рабочиеДниToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is Product)
                {
                    ProductRegisterForm equipRegister = new ProductRegisterForm(obj as Product);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        Product created = equipRegister.AddingProduct;

                        cmd = new SqlCommand(
                            "delete from Products where product_id=@product_id"
                            , sqlcon);

                        cmd.Parameters.AddWithValue("@product_id", created.Id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                               "Insert into Products(product_id,name,price,description,type,quantity) " +
                               "Values(@product_id,@name,@price,@description,@type,@quantity)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@product_id", created.Id);
                        cmd.Parameters.AddWithValue("@name", created.Name);
                        cmd.Parameters.AddWithValue("@price", created.Price);
                        cmd.Parameters.AddWithValue("@description", created.Description);
                        cmd.Parameters.AddWithValue("@type", created.Type);
                        cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                        cmd.ExecuteNonQuery();
                        продуктыToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is Event)
                {
                    List<int> workPlace_ids = new List<int>();
                    cmd = new SqlCommand("Select * from Events", sqlcon);
                    cmd.ExecuteNonQuery();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            workPlace_ids.Add(int.Parse(dr["id"].ToString()));
                        }
                    }

                    EventRegisterForm equipRegister = new EventRegisterForm(obj as Event, workPlace_ids);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        Event created = equipRegister.AddingEvent;

                        cmd = new SqlCommand(
                            "delete from Events where id=@id"
                            , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(
                               "Insert into Events(id,name,price,description,date,workPlace_id,quantity) " +
                               "Values(@id,@name,@price,@description,@date,@workPlace_id,@quantity)"
                               , sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.Parameters.AddWithValue("@name", created.Name);
                        cmd.Parameters.AddWithValue("@price", created.Price);
                        cmd.Parameters.AddWithValue("@quantity", created.Quantity);
                        cmd.Parameters.AddWithValue("@description", created.Description);
                        cmd.Parameters.AddWithValue("@date", created.Date);
                        cmd.Parameters.AddWithValue("@workPlace_id", created.WorkPlace_id);
                        cmd.ExecuteNonQuery();
                        мероприятияToolStripMenuItem1_Click(this, e);
                    }
                }
                if (obj is Building)
                {
                    BuildingRegisterForm equipRegister = new BuildingRegisterForm(obj as Building);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        Building created = equipRegister.AddinBuilding;

                        cmd = new SqlCommand("UPDATE Buildings SET rooms=@rooms where @id=id", sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.Parameters.AddWithValue("@rooms", created.Rooms);
                        cmd.ExecuteNonQuery();
                        зданияНаТерриторииToolStripMenuItem_Click(this, e);
                    }
                }
                if (obj is Room)
                {
                    List<string> buildings = new List<string>();
                    cmd = new SqlCommand("Select * from Buildings", sqlcon);
                    cmd.ExecuteNonQuery();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            buildings.Add(dr["id"].ToString());
                        }
                    }

                    RoomRegisterForm equipRegister = new RoomRegisterForm(obj as Room, buildings);

                    if (equipRegister.ShowDialog() == DialogResult.OK)
                    {
                        Room created = equipRegister.AddingRoom;

                        cmd = new SqlCommand("UPDATE Rooms SET price=@price,beds=@beds,isAvailable=@isAvailable where @id=id", sqlcon);

                        cmd.Parameters.AddWithValue("@id", created.Id);
                        cmd.Parameters.AddWithValue("@price", created.Price);
                        cmd.Parameters.AddWithValue("@beds", created.Beds);
                        cmd.Parameters.AddWithValue("@isAvailable", created.IsAvailable);
                        cmd.ExecuteNonQuery();
                        комнатыToolStripMenuItem_Click(this, e);
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand();


            if (dataGridView1.RowCount > 0)
            {
                object obj = dataGridView1.CurrentRow.Tag;

                if (obj is WorkPlace)
                {
                    WorkPlace wp = obj as WorkPlace;

                    cmd = new SqlCommand(
                          "delete from WorkPlaces where id=@id", sqlcon);

                    cmd.Parameters.AddWithValue("@id", wp.Id);
                    cmd.ExecuteNonQuery();
                    рабочиеМестаToolStripMenuItem_Click(this, e);
                }

                if (obj is Profession)
                {
                    Profession prof = obj as Profession;

                    cmd = new SqlCommand(
                         "delete from Professions where id=@id"
                         , sqlcon);

                    cmd.Parameters.AddWithValue("@id", prof.Id);
                    cmd.ExecuteNonQuery();
                    профессииToolStripMenuItem_Click(this, e);
                }
                if (obj is UserPower)
                {
                    UserPower prof = obj as UserPower;

                    cmd = new SqlCommand(
                         "delete from UsersPower where profession_id=@profession_id"
                         , sqlcon);
                    cmd.Parameters.AddWithValue("@profession_id", prof.Profession_id);
                    cmd.ExecuteNonQuery();
                    праваПользователейToolStripMenuItem_Click(this, e);
                }

                if (obj is Equipment)
                {
                    Equipment eq = obj as Equipment;

                    cmd = new SqlCommand(
                        "delete from Equipment where id=@id"
                        , sqlcon);

                    cmd.Parameters.AddWithValue("@id", eq.Id);
                    cmd.ExecuteNonQuery();
                    оборудованиеToolStripMenuItem_Click(this, e);
                }
                if (obj is WorkDay)
                {
                    WorkDay wd = obj as WorkDay;

                    cmd = new SqlCommand(
                        "delete from Workdays where worker_login=@worker_login"
                        , sqlcon);

                    cmd.Parameters.AddWithValue("@worker_login", wd.WorkerLogin);
                    cmd.ExecuteNonQuery();
                    рабочиеДниToolStripMenuItem_Click(this, e);
                }
                if (obj is Product)
                {
                    Product pr = obj as Product;

                    cmd = new SqlCommand(
                        "delete from Products where product_id=@product_id"
                        , sqlcon);

                    cmd.Parameters.AddWithValue("@product_id", pr.Id);
                    cmd.ExecuteNonQuery();
                    продуктыToolStripMenuItem_Click(this, e);
                }
                if (obj is Event)
                {
                    Event ev = obj as Event;

                    cmd = new SqlCommand(
                        "delete from Events where id=@id"
                        , sqlcon);

                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                    мероприятияToolStripMenuItem1_Click(this, e);
                }
                if (obj is Building)
                {
                    Building ev = obj as Building;

                    cmd = new SqlCommand(
                        "delete from Buildings where id=@id"
                        , sqlcon);

                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                    зданияНаТерриторииToolStripMenuItem_Click(this, e);
                }
                if (obj is Room)
                {
                    Room ev = obj as Room;

                    cmd = new SqlCommand(
                        "delete from Rooms where id=@id"
                        , sqlcon);

                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                    комнатыToolStripMenuItem_Click(this, e);
                }
            }
        }

        private void работникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void бронированиеБилетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            CurrentObject = new BookedTicket();
            CreateTreeOfBookedTickets();
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(удалитьToolStripMenuItem);
            contextMenuStrip1.Items.Add(редактироватьToolStripMenuItem1);
        }
        private void CreateTreeOfBookedTickets()
        {
            treeView1.Visible = true;
            dataGridView1.Visible = false;
            treeView1.Nodes.Clear();
            List<Tourist> tourists = new List<Tourist>();
            List<BookedTicket> tickets = new List<BookedTicket>();
            List<Event> events = new List<Event>();
            var cmd = new SqlCommand("select * from BookedTickets", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    tickets.Add(new BookedTicket(int.Parse(dr["item_id"].ToString()),
                        int.Parse(dr["event_id"].ToString()), int.Parse(dr["quantity"].ToString()), decimal.Parse(dr["cost"].ToString()), dr["login"].ToString(), bool.Parse(dr["isPaid"].ToString())));
                }
            }

            cmd = new SqlCommand("select * from Tourists", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    tourists.Add(new Tourist(dr["login"].ToString(), dr["password"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(), dr["email"].ToString(), dr["dateOfComing"].ToString(), dr["dateOfLeaving"].ToString(), dr["country"].ToString(), int.Parse(dr["room_id"].ToString())));
                }
            }

            cmd = new SqlCommand("select * from Events", sqlcon);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    events.Add(new Event(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["date"].ToString(), int.Parse(dr["workPlace_id"].ToString()), int.Parse(dr["quantity"].ToString())));
                }
            }

            TreeNode tourist = new TreeNode();
            TreeNode ticket = new TreeNode();

            for (int i = 0; i < tourists.Count; i++)
            {
                tourist = new TreeNode();
                tourist.Text = tourists[i].Surname + " " + tourists[i].Name + " " + tourists[i].Thirdname;

                for (int j = 0; j < tickets.Count; j++)
                {
                    if (tourists[i].Login == tickets[j].Login)
                    {
                        for (int x = 0; x < events.Count; x++)
                        {
                            if (events[x].Id == tickets[j].Event_id)
                            {
                                ticket.Text = $"({tickets[j].Event_id}) {events[x].Name} - {tickets[j].Quantity} шт. {tickets[j].Cost}р - Оплачен? {tickets[j].isPaid}";
                            }
                        }

                        if (tickets[j].isPaid)
                            ticket.BackColor = Color.Green;
                        else
                            ticket.BackColor = Color.Red;

                        ticket.Tag = tickets[j];
                        tourist.Nodes.Add(ticket);
                        treeView1.Nodes.Add(tourist);
                    }
                }
            }
        }

        private void зданияНаТерриторииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;
            CurrentObject = new Building();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Buildings", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Кол-во комнат");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["rooms"].ToString() });
                    dataGridView1.Rows[i].Tag = new Building(dr["id"].ToString(), int.Parse(dr["rooms"].ToString()));
                    i++;
                }
            }
        }

        private void комнатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;
            CurrentObject = new Room();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Rooms", sqlcon);
            dataGridView1.Columns.Add("", "Номер комнаты");
            dataGridView1.Columns.Add("", "Цена");
            dataGridView1.Columns.Add("", "Кол-во кроватей");
            dataGridView1.Columns.Add("", "Свободна?");
            dataGridView1.Columns.Add("", "Код здания");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["price"].ToString(), dr["beds"].ToString(), dr["isAvailable"].ToString(), dr["building_id"].ToString());
                    dataGridView1.Rows[i].Tag = new Room(int.Parse(dr["id"].ToString()), decimal.Parse(dr["price"].ToString()), int.Parse(dr["beds"].ToString()), bool.Parse(dr["isAvailable"].ToString()), dr["building_id"].ToString());
                    i++;
                }
            }
        }

        private void праваПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            contextMenuStrip1.Visible = false;
            CurrentObject = new UserPower();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from UsersPower", sqlcon);
            dataGridView1.Columns.Add("", "Код профессии");
            dataGridView1.Columns.Add("", "Права");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["profession_id"].ToString(), bool.Parse(dr["limitPower"].ToString()) == true ? "Ограниченные" : "Полные");
                    dataGridView1.Rows[i].Tag = new UserPower(int.Parse(dr["profession_id"].ToString()), bool.Parse(dr["limitPower"].ToString()));
                    i++;
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
        List<string> AdminItems = new List<string>() { "Работники", "Рабочие места", "Профессии", "Оборудование", "Рабочие дни", "Здания на территории",
            "Комнаты", "Права пользователей", "Жильцы", "Заказы", "Забронированные билеты", "Продукты", "Мероприятия"};
        List<string> ReceptionWorkerItems = new List<string>() { "Жильцы", "Заказы", "Забронированные билеты", "Продукты", "Мероприятия" };
        List<string> StaffMemeberItems = new List<string>() { "Рабочие места", "Рабочие дни" };
        private string safeString = " 0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю_-,.'";
        private void конструкторЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxObj.Items.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = false;
            panel1.Visible = true;

            if (Text == "Форма администратора")
            {
                foreach (var item in AdminItems)
                {
                    comboBoxObj.Items.Add(item);
                }
                comboBoxObj.Text = comboBoxObj.Items[0].ToString();
            }
            if (Text == "Форма работника на ресепшене")
            {
                foreach (var item in ReceptionWorkerItems)
                {
                    comboBoxObj.Items.Add(item);
                }
                comboBoxObj.Text = comboBoxObj.Items[0].ToString();
            }
            if (Text == "Форма сотрудника комплекса")
            {
                foreach (var item in StaffMemeberItems)
                {
                    comboBoxObj.Items.Add(item);
                }
                comboBoxObj.Text = comboBoxObj.Items[0].ToString();
            }
        }

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
        public string Table { get; set; }
        public string Attribute { get; set; }
        public string ExtraAttribute { get; set; }
        private void comboBoxObj_SelectedValueChanged(object sender, EventArgs e)
        {
            FindTable(comboBoxObj.SelectedItem.ToString());
            FillAttributes();
            if (checkBox1.Checked)
                FillExtraAttributes();
        }
        private void txtBxSomteText_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBxSomeText.Text == "Введите значение...")
                txtBxSomeText.Text = string.Empty;
        }
        private void txtBxSomteText_TextChanged(object sender, EventArgs e)
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
        private void txtbxExtraExtraSomeText_MouseClick(object sender, MouseEventArgs e)
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
                            if (inputText.ToLower() == "true")
                                outPut = true;
                            if (inputText.ToLower() == "false")
                                outPut = false;
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
                        if (attribute == "Оплачен?")
                        {
                            if (inputText.ToLower() == "true")
                                outPut = true;
                            if (inputText.ToLower() == "false")
                                outPut = false;
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
                            if (inputText.ToLower() == "true")
                                outPut = true;
                            if (inputText.ToLower() == "false")
                                outPut = false;
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
                            case "Workers":
                                dgwSearchResults.Rows.Add(new string[] { dr["login"].ToString(), dr["password"].ToString(),
                                        dr["profession_id"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(),
                                        dr["dateOfBirth"].ToString(),dr["workPlace_id"].ToString(),dr["phoneNumber"].ToString() });
                                break;
                            case "Workdays":
                                dgwSearchResults.Rows.Add(new string[] { dr["worker_login"].ToString(), dr["workDays"].ToString() });
                                break;
                            case "Professions":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["name"].ToString() });
                                break;
                            case "Equipment":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["name"].ToString(), dr["quantity"].ToString(), dr["profession_id"].ToString() });
                                break;
                            case "UsersPower":
                                dgwSearchResults.Rows.Add(new string[] { dr["profession_id"].ToString(), dr["limitPower"].ToString() });
                                break;
                            case "WorkPlaces":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["place_id"].ToString(), dr["building_id"].ToString() });
                                break;
                            case "Buildings":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["rooms"].ToString() });
                                break;
                            case "Rooms":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["price"].ToString(), dr["beds"].ToString(),
                                        dr["isAvailable"].ToString(), dr["building_id"].ToString() });
                                break;
                            case "Events":
                                dgwSearchResults.Rows.Add(new string[] { dr["id"].ToString(), dr["name"].ToString(), dr["price"].ToString(),
                                        dr["description"].ToString(), dr["date"].ToString(), dr["workPlace_id"].ToString(), dr["quantity"].ToString() });
                                break;
                            case "Tourists":
                                dgwSearchResults.Rows.Add(new string[] { dr["login"].ToString(), dr["password"].ToString(), dr["email"].ToString(),
                                        dr["name"].ToString(), dr["surname"].ToString(), dr["thirdname"].ToString(), dr["dateOfBirth"].ToString(),
                                        dr["dateOfComing"].ToString(), dr["dateOfLeaving"].ToString(), dr["country"].ToString() , dr["room_id"].ToString()  });
                                break;
                            case "BookedTickets":

                                dgwSearchResults.Rows.Add(new string[] { dr["item_id"].ToString(), dr["event_id"].ToString(), dr["quantity"].ToString(),
                                        dr["cost"].ToString(), dr["login"].ToString(), dr["isPaid"].ToString() });
                                break;
                            case "Orders":
                                dgwSearchResults.Rows.Add(new string[] { dr["order_id"].ToString(), dr["product_id"].ToString(), dr["quantity"].ToString(),
                                        dr["cost"].ToString(), dr["login"].ToString(), dr["dateOrder"].ToString(), dr["isDone"].ToString() });
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dgwSearchResults.Rows.Count > 0)
            {
                var app = new Application();
                app.Visible = true;

                var wb = app.Workbooks.Add();
                var ws = (Worksheet)wb.Worksheets[1];

                for (int i = 1; i < dgwSearchResults.Columns.Count + 1; i++)
                {
                    ws.Cells[1, i].Value = dgwSearchResults.Columns[i - 1].HeaderText;
                    ws.Cells[1, i].EntireColumn.ColumnWidth = dgwSearchResults.Columns[i - 1].Width / 5;
                    ws.Cells[1, i].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }

                for (int i = 0; i < dgwSearchResults.Rows.Count; i++)
                {
                    for (int j = 0; j < dgwSearchResults.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dgwSearchResults.Rows[i].Cells[j].Value.ToString();
                        ws.Cells[i + 2, j + 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }
            }
            else
                MessageBox.Show("Чтобы создать отчет, таблица не должна быть пустой");
        }
    }
}
