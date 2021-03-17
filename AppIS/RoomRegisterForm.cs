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
    public partial class RoomRegisterForm : Form
    {
        List<Building> Buildings = new List<Building>();
        public List<Room> Rooms = new List<Room>();
        public Room AddingRoom { get; set; }
        public bool IsFilled { get; set; }
        public RoomRegisterForm(Room addingRoom)
        {
            IsFilled = true;
            AddingRoom = addingRoom;
            InitializeComponent();
        }
        public RoomRegisterForm(int id, List<Building> Buildings)
        {
            this.Buildings = Buildings;
            IsFilled = false;
            AddingRoom = new Room(id);
            InitializeComponent();
        }

        private void RoomRegisterForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Buildings)
            {
                comboBoxBuilding_id.Items.Add(item.Id);
            }


            if (IsFilled)
            {
                label7.Visible = false;
                txtBxRooms.Visible = false;
                comboBoxBuilding_id.Enabled = false;
                txtBxRoom_id.ReadOnly = true;
                txtBxRoom_id.Text = AddingRoom.Id.ToString();
                numericUpDownCountofBeds.Value = AddingRoom.Beds;
                numericUpDownPrice.Value = AddingRoom.Price;
                if (AddingRoom.IsAvailable)
                    comboBoxIsAvailable.Text = "Да";
                else
                    comboBoxIsAvailable.Text = "Нет";
                comboBoxBuilding_id.Items.Add(AddingRoom.Building_id);
                comboBoxBuilding_id.SelectedItem = comboBoxBuilding_id.Items[0].ToString();
                label6.Visible = false;

                numericUpDownCountOfRooms.Visible = false;
                numericUpDownCountOfRooms.Enabled = false;
            }
            else
            {
                comboBoxBuilding_id.Text = Buildings[0].Id;

                comboBoxBuilding_id.SelectedItem = comboBoxBuilding_id.Items[0].ToString();
                txtBxRooms.Text = Buildings[0].Rooms.ToString();
                label6.Visible = true;
                numericUpDownCountOfRooms.Visible = true;
                numericUpDownCountOfRooms.Enabled = true;
                txtBxRoom_id.ReadOnly = true;
                txtBxRoom_id.Text = AddingRoom.Id.ToString();
                comboBoxIsAvailable.Text = "Да";
                comboBoxIsAvailable.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (numericUpDownCountOfRooms.Enabled == false)
            {
                bool res = false;

                if (comboBoxIsAvailable.SelectedItem.ToString() == "Да")
                    res = true;
                else
                    res = false;

                AddingRoom = new Room(int.Parse(txtBxRoom_id.Text), decimal.Parse(numericUpDownPrice.Value.ToString()),
                    int.Parse(numericUpDownCountofBeds.Value.ToString()), res, comboBoxBuilding_id.SelectedItem.ToString());

            }
            else
            {
                int inc = 0;
                numericUpDownCountOfRooms.Enabled = false;
                for (int i = 0; i < numericUpDownCountOfRooms.Value; i++)
                {
                    Rooms.Add(new Room(int.Parse(txtBxRoom_id.Text) + inc, decimal.Parse(numericUpDownPrice.Value.ToString()),
                        int.Parse(numericUpDownCountofBeds.Value.ToString()), true, comboBoxBuilding_id.SelectedItem.ToString()));
                    inc++;
                }
            }
        }

        private void comboBoxBuilding_id_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!IsFilled)
            {
                txtBxRooms.Text = Buildings[comboBoxBuilding_id.SelectedIndex].Rooms.ToString();
                numericUpDownCountOfRooms.Maximum = int.Parse(txtBxRooms.Text);
            }
        }
    }
}
