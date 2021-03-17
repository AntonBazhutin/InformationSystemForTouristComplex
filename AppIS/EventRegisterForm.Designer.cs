
namespace AppIS
{
    partial class EventRegisterForm
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
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxEventId = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownCountOfTickets = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.comboBoxWorkPlace_id = new System.Windows.Forms.ComboBox();
            this.labelWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(18, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "Код рабочего места";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(110, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 18);
            this.label11.TabIndex = 79;
            this.label11.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(81, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 77;
            this.label4.Text = "Описание";
            // 
            // txtBxDescription
            // 
            this.txtBxDescription.Location = new System.Drawing.Point(161, 88);
            this.txtBxDescription.Name = "txtBxDescription";
            this.txtBxDescription.Size = new System.Drawing.Size(100, 20);
            this.txtBxDescription.TabIndex = 76;
            this.txtBxDescription.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(110, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "Цена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(82, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "Название";
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(161, 36);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(100, 20);
            this.txtBxName.TabIndex = 72;
            this.txtBxName.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Код мероприятия";
            // 
            // txtBxEventId
            // 
            this.txtBxEventId.Location = new System.Drawing.Point(161, 10);
            this.txtBxEventId.Name = "txtBxEventId";
            this.txtBxEventId.Size = new System.Drawing.Size(100, 20);
            this.txtBxEventId.TabIndex = 70;
            this.txtBxEventId.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(98, 222);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 82;
            this.btnSubmit.Text = "Добавить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(43, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 85;
            this.label6.Text = "Кол-во билетов";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 114);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 86;
            // 
            // numericUpDownCountOfTickets
            // 
            this.numericUpDownCountOfTickets.Location = new System.Drawing.Point(160, 172);
            this.numericUpDownCountOfTickets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountOfTickets.Name = "numericUpDownCountOfTickets";
            this.numericUpDownCountOfTickets.Size = new System.Drawing.Size(101, 20);
            this.numericUpDownCountOfTickets.TabIndex = 87;
            this.numericUpDownCountOfTickets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPrice.Location = new System.Drawing.Point(161, 62);
            this.numericUpDownPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(101, 20);
            this.numericUpDownPrice.TabIndex = 88;
            this.numericUpDownPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxWorkPlace_id
            // 
            this.comboBoxWorkPlace_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkPlace_id.FormattingEnabled = true;
            this.comboBoxWorkPlace_id.Location = new System.Drawing.Point(161, 146);
            this.comboBoxWorkPlace_id.Name = "comboBoxWorkPlace_id";
            this.comboBoxWorkPlace_id.Size = new System.Drawing.Size(100, 21);
            this.comboBoxWorkPlace_id.TabIndex = 89;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(70, 206);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(158, 13);
            this.labelWarning.TabIndex = 90;
            this.labelWarning.Text = "Проверьте вводимые данные";
            // 
            // EventRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 286);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.comboBoxWorkPlace_id);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.numericUpDownCountOfTickets);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxEventId);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 325);
            this.MinimumSize = new System.Drawing.Size(320, 325);
            this.Name = "EventRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EventRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxEventId;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown numericUpDownCountOfTickets;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.ComboBox comboBoxWorkPlace_id;
        private System.Windows.Forms.Label labelWarning;
    }
}