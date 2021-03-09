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
        List<string> Buildings = new List<string>();
        public List<Room> Rooms = new List<Room>();
        public Room AddingRoom { get; set; }
        public bool IsFilled { get; set; }
        public RoomRegisterForm(Room addingRoom, List<string> Buildings)
        {
            this.Buildings = Buildings;
            IsFilled = true;
            AddingRoom = addingRoom;
            InitializeComponent();
        }
        public RoomRegisterForm(int id, List<string> Buildings)
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
                comboBoxBuilding_id.Items.Add(item);
            }

            comboBoxBuilding_id.Text = Buildings[0];

            if (IsFilled)
            {
                comboBoxBuilding_id.Enabled = false;
                txtBxRoom_id.ReadOnly = true;
                txtBxRoom_id.Text = AddingRoom.Id.ToString();
                numericUpDownCountofBeds.Value = AddingRoom.Beds;
                numericUpDownPrice.Value = AddingRoom.Price;
                if (AddingRoom.IsAvailable)
                    comboBoxIsAvailable.Text = "Да";
                else
                    comboBoxIsAvailable.Text = "Нет";
                comboBoxBuilding_id.Text = AddingRoom.Building_id;
                label6.Visible = false;
                numericUpDownCountOfRooms.Visible = false;
                numericUpDownCountOfRooms.Enabled = false;
            }
            else
            {
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
    }
}
