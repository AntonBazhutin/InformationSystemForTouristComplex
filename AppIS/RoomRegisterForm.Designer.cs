
namespace AppIS
{
    partial class RoomRegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxRoom_id = new System.Windows.Forms.TextBox();
            this.comboBoxIsAvailable = new System.Windows.Forms.ComboBox();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCountofBeds = new System.Windows.Forms.NumericUpDown();
            this.comboBoxBuilding_id = new System.Windows.Forms.ComboBox();
            this.numericUpDownCountOfRooms = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxRooms = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountofBeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 103;
            this.label5.Text = "Код здания";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(151, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 101;
            this.label4.Text = "Свободна?";
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(196, 225);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 99;
            this.btnSubmit.Text = "ОК";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(113, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 97;
            this.label3.Text = "Кол-во кроватей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(193, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 96;
            this.label2.Text = "Цена";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(118, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 95;
            this.label1.Text = "Номер комнаты";
            // 
            // txtBxRoom_id
            // 
            this.txtBxRoom_id.Location = new System.Drawing.Point(251, 12);
            this.txtBxRoom_id.Name = "txtBxRoom_id";
            this.txtBxRoom_id.ReadOnly = true;
            this.txtBxRoom_id.Size = new System.Drawing.Size(100, 20);
            this.txtBxRoom_id.TabIndex = 93;
            // 
            // comboBoxIsAvailable
            // 
            this.comboBoxIsAvailable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIsAvailable.FormattingEnabled = true;
            this.comboBoxIsAvailable.Items.AddRange(new object[] {
            "Да",
            "Нет"});
            this.comboBoxIsAvailable.Location = new System.Drawing.Point(251, 92);
            this.comboBoxIsAvailable.Name = "comboBoxIsAvailable";
            this.comboBoxIsAvailable.Size = new System.Drawing.Size(100, 21);
            this.comboBoxIsAvailable.TabIndex = 105;
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPrice.Location = new System.Drawing.Point(251, 40);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownPrice.TabIndex = 106;
            this.numericUpDownPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCountofBeds
            // 
            this.numericUpDownCountofBeds.Location = new System.Drawing.Point(251, 66);
            this.numericUpDownCountofBeds.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCountofBeds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountofBeds.Name = "numericUpDownCountofBeds";
            this.numericUpDownCountofBeds.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownCountofBeds.TabIndex = 107;
            this.numericUpDownCountofBeds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxBuilding_id
            // 
            this.comboBoxBuilding_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBuilding_id.FormattingEnabled = true;
            this.comboBoxBuilding_id.Location = new System.Drawing.Point(117, 128);
            this.comboBoxBuilding_id.Name = "comboBoxBuilding_id";
            this.comboBoxBuilding_id.Size = new System.Drawing.Size(100, 21);
            this.comboBoxBuilding_id.TabIndex = 108;
            this.comboBoxBuilding_id.SelectedValueChanged += new System.EventHandler(this.comboBoxBuilding_id_SelectedValueChanged);
            // 
            // numericUpDownCountOfRooms
            // 
            this.numericUpDownCountOfRooms.Location = new System.Drawing.Point(251, 172);
            this.numericUpDownCountOfRooms.Name = "numericUpDownCountOfRooms";
            this.numericUpDownCountOfRooms.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownCountOfRooms.TabIndex = 109;
            this.numericUpDownCountOfRooms.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(33, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 18);
            this.label6.TabIndex = 110;
            this.label6.Text = "Кол-во создаваемых комнат";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(224, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 16);
            this.label7.TabIndex = 111;
            this.label7.Text = "Доступно для создания комнат:";
            // 
            // txtBxRooms
            // 
            this.txtBxRooms.Location = new System.Drawing.Point(445, 129);
            this.txtBxRooms.Name = "txtBxRooms";
            this.txtBxRooms.ReadOnly = true;
            this.txtBxRooms.Size = new System.Drawing.Size(70, 20);
            this.txtBxRooms.TabIndex = 112;
            // 
            // RoomRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 270);
            this.Controls.Add(this.txtBxRooms);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownCountOfRooms);
            this.Controls.Add(this.comboBoxBuilding_id);
            this.Controls.Add(this.numericUpDownCountofBeds);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.comboBoxIsAvailable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxRoom_id);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(543, 309);
            this.MinimumSize = new System.Drawing.Size(543, 309);
            this.Name = "RoomRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.RoomRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountofBeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxRoom_id;
        private System.Windows.Forms.ComboBox comboBoxIsAvailable;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownCountofBeds;
        private System.Windows.Forms.ComboBox comboBoxBuilding_id;
        private System.Windows.Forms.NumericUpDown numericUpDownCountOfRooms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBxRooms;
    }
}