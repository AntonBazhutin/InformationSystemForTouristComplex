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

namespace AppIS
{
    public partial class ManagerialForm : Form
    {
        public object CurrentObject { get; set; }
        List<Profession> profession = new List<Profession>();
        List<WorkDay> workDays = new List<WorkDay>();
        List<WorkPlace> workPlaces = new List<WorkPlace>();
        List<Equipment> equipment = new List<Equipment>();
        List<Product> products = new List<Product>();
        List<Event> events = new List<Event>();

        public Worker PersonalInfo { get; set; }
        public ManagerialForm(Worker personalInfo)
        {
            PersonalInfo = personalInfo;

            InitializeComponent();

            Connect();
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
            CreateTreeViewOfTourists();
        }

        private void ManagerialForm_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = PersonalInfo.Surname + " " + PersonalInfo.Name + " " + PersonalInfo.Thirdname;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTreeViewOfOrders();
        }

        private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                    dataGridView1.Rows.Add(new object[] { (int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["type"].ToString(), int.Parse(dr["quantity"].ToString())) });
                    dataGridView1.Rows[i].Tag = new Product(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["type"].ToString(), int.Parse(dr["quantity"].ToString()));
                    i++;
                }
            }
        }

        private void мероприятияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentObject = new Event();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
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
                    dataGridView1.Rows.Add(new object[] { (int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["date"].ToString(), int.Parse(dr["workPlace_id"].ToString())) });
                    dataGridView1.Rows[i].Tag = new Event(int.Parse(dr["id"].ToString()), dr["name"].ToString(), decimal.Parse(dr["price"].ToString()), dr["description"].ToString(), dr["date"].ToString(), int.Parse(dr["workPlace_id"].ToString()));
                    i++;
                }
            }
        }

        private void списокСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTreeViewOfWorkers();
        }

        private void профессииToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            CurrentObject = new Equipment();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Equipment", sqlcon);
            dataGridView1.Columns.Add("", "Код");
            dataGridView1.Columns.Add("", "Название");
            dataGridView1.Columns.Add("", "Кол-во");
            dataGridView1.Columns.Add("", "Серийный номер");
            dataGridView1.Columns.Add("", "Принадлежит профессии");

            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new object[] { dr["id"].ToString(), dr["name"].ToString(), int.Parse(dr["quantity"].ToString()), dr["serialNumber"].ToString(), int.Parse(dr["profession_id"].ToString()) });
                    dataGridView1.Rows[i].Tag = new Equipment(int.Parse(dr["id"].ToString()), dr["name"].ToString(), int.Parse(dr["quantity"].ToString()), dr["serialNumber"].ToString(), int.Parse(dr["profession_id"].ToString()));
                    i++;
                }
            }
        }

        private void рабочиеДниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentObject = new WorkDay();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            treeView1.Visible = false;
            dataGridView1.Visible = true;

            var cmd = new SqlCommand("Select * from Workdays", sqlcon);
            dataGridView1.Columns.Add("", "Код рабочего");
            dataGridView1.Columns.Add("", "День недели");
            int i = 0;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(new WorkDay(int.Parse(dr["worker_login"].ToString()), dr["day"].ToString()));
                    dataGridView1.Rows[i].Tag = new WorkDay(int.Parse(dr["worker_login"].ToString()), dr["day"].ToString());
                    i++;
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Room || treeView1.SelectedNode.Tag is WorkPlace)
            {
                if (treeView1.SelectedNode.Tag is Room)
                {
                    Room room;

                    room = treeView1.SelectedNode.Tag as Room;

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
                            CreateTreeViewOfTourists();
                        }
                        else
                            MessageBox.Show("Турист с таким логином и паролем уже зарегистрирован");
                    }
                }

                if (treeView1.SelectedNode.Tag is WorkPlace)
                {
                    WorkPlace workPlace = treeView1.SelectedNode.Tag as WorkPlace;

                    Worker addingWorker = null;

                    WorkerRegisterForm register = new WorkerRegisterForm(workPlace.Id);

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
            if (treeView1.SelectedNode.Tag is Tourist)
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
            if (treeView1.SelectedNode.Tag is Worker)
            {
                Worker newWorker = treeView1.SelectedNode.Tag as Worker;

                WorkerRegisterForm change = new WorkerRegisterForm(newWorker);

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
                    cmd.Parameters.AddWithValue("@phoneNumber", newWorker.DateOfBirth);

                    cmd.ExecuteNonQuery();
                    CreateTreeViewOfWorkers();
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Tourist || treeView1.SelectedNode.Tag is Worker)
            {
                object obj = new object();
                var cmd = new SqlCommand();

                if (treeView1.SelectedNode.Tag is Tourist)
                {
                    Tourist tourist = treeView1.SelectedNode.Tag as Tourist;
                    obj = tourist as Tourist;
                    cmd = new SqlCommand("delete from Tourists where login=@login", sqlcon);
                    cmd.Parameters.AddWithValue("@login", tourist.Login);
                }

                if (treeView1.SelectedNode.Tag is Worker)
                {
                    Worker worker = treeView1.SelectedNode.Tag as Worker;
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
                    orders.Add(new Order(int.Parse(dr["id"].ToString()), dr["dateOrder"].ToString(), dr["login"].ToString(), bool.Parse(dr["isDone"].ToString())));
                }
            }


            for (int i = 0; i < tourists.Count; i++)
            {
                TreeNode tourist = new TreeNode();

                tourist.Tag = tourists[i].Login;

                for (int j = 0; j < orders.Count; j++)
                {
                    if (orders[j].Login == tourists[i].Login)
                    {
                        TreeNode order = new TreeNode();
                        order.Tag = orders[j].Login;
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
                    buildings.Add(new Building(dr["id"].ToString(), uint.Parse(dr["rooms"].ToString())));
                }
            }

            TreeNode building = new TreeNode();
            TreeNode place = new TreeNode();
            TreeNode worker = new TreeNode();

            for (int i = 0; i < buildings.Count; i++)
            {
                building = new TreeNode();

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
                    buildings.Add(new Building(dr["id"].ToString(), uint.Parse(dr["rooms"].ToString())));
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
                        building.Nodes.Add(room);
                    }
                }

                building.Text = $"{buildings[i].Id}  [{building.Nodes.Count - emptyNodes} / {buildings[i].Rooms}]";
                treeView1.Nodes.Add(building);
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CurrentObject is WorkPlace)
            {

            }
            if (CurrentObject is Profession)
            {

            }
            if (CurrentObject is Equipment)
            {

            }
            if (CurrentObject is WorkDay)
            { 
            
            }
            if (CurrentObject is Product)
            { 
            
            }
            if (CurrentObject is Event)
            { 
            
            }
        }
    }
}
