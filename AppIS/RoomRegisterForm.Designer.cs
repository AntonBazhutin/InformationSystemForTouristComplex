
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
            this.labelWarning = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountofBeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(137, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 103;
            this.label5.Text = "Код здания";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(139, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 101;
            this.label4.Text = "Свободна?";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(135, 230);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(168, 20);
            this.labelWarning.TabIndex = 100;
            this.labelWarning.Text = "Заполните все поля!";
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(172, 253);
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
            this.label3.Location = new System.Drawing.Point(101, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 97;
            this.label3.Text = "Кол-во кроватей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(181, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 96;
            this.label2.Text = "Цена";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(106, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 95;
            this.label1.Text = "Номер комнаты";
            // 
            // txtBxRoom_id
            // 
            this.txtBxRoom_id.Location = new System.Drawing.Point(239, 27);
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
            this.comboBoxIsAvailable.Location = new System.Drawing.Point(239, 107);
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
            this.numericUpDownPrice.Location = new System.Drawing.Point(239, 55);
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
            this.numericUpDownCountofBeds.Location = new System.Drawing.Point(239, 81);
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
            this.comboBoxBuilding_id.Location = new System.Drawing.Point(239, 134);
            this.comboBoxBuilding_id.Name = "comboBoxBuilding_id";
            this.comboBoxBuilding_id.Size = new System.Drawing.Size(100, 21);
            this.comboBoxBuilding_id.TabIndex = 108;
            // 
            // numericUpDownCountOfRooms
            // 
            this.numericUpDownCountOfRooms.Location = new System.Drawing.Point(239, 159);
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
            this.label6.Location = new System.Drawing.Point(21, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 18);
            this.label6.TabIndex = 110;
            this.label6.Text = "Кол-во создаваемых комнат";
            // 
            // RoomRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 321);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownCountOfRooms);
            this.Controls.Add(this.comboBoxBuilding_id);
            this.Controls.Add(this.numericUpDownCountofBeds);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.comboBoxIsAvailable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxRoom_id);
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
        private System.Windows.Forms.Label labelWarning;
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
    }
}