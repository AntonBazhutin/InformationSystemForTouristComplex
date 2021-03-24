
namespace AppIS
{
    partial class TouristRegisterForm
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
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxThirdname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxLogin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBxEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBxCountry = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimeComing = new System.Windows.Forms.DateTimePicker();
            this.dateTimeLeaving = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(144, 24);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(100, 20);
            this.txtBxName.TabIndex = 0;
            this.txtBxName.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(91, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(56, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фамилия";
            // 
            // txtBxSurname
            // 
            this.txtBxSurname.Location = new System.Drawing.Point(144, 50);
            this.txtBxSurname.Name = "txtBxSurname";
            this.txtBxSurname.Size = new System.Drawing.Size(100, 20);
            this.txtBxSurname.TabIndex = 2;
            this.txtBxSurname.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(54, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отчество";
            // 
            // txtBxThirdname
            // 
            this.txtBxThirdname.Location = new System.Drawing.Point(144, 76);
            this.txtBxThirdname.Name = "txtBxThirdname";
            this.txtBxThirdname.Size = new System.Drawing.Size(100, 20);
            this.txtBxThirdname.TabIndex = 4;
            this.txtBxThirdname.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Дата рождения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(34, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дата приезда";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(33, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Дата отъезда";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(302, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Логин";
            // 
            // txtBxLogin
            // 
            this.txtBxLogin.Location = new System.Drawing.Point(367, 24);
            this.txtBxLogin.Name = "txtBxLogin";
            this.txtBxLogin.Size = new System.Drawing.Size(100, 20);
            this.txtBxLogin.TabIndex = 12;
            this.txtBxLogin.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(291, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Пароль";
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(367, 50);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBxPassword.TabIndex = 14;
            this.txtBxPassword.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(276, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "Эл. почта";
            // 
            // txtBxEmail
            // 
            this.txtBxEmail.Location = new System.Drawing.Point(367, 76);
            this.txtBxEmail.Name = "txtBxEmail";
            this.txtBxEmail.Size = new System.Drawing.Size(100, 20);
            this.txtBxEmail.TabIndex = 16;
            this.txtBxEmail.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(71, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Страна";
            // 
            // txtBxCountry
            // 
            this.txtBxCountry.Location = new System.Drawing.Point(144, 128);
            this.txtBxCountry.Name = "txtBxCountry";
            this.txtBxCountry.Size = new System.Drawing.Size(100, 20);
            this.txtBxCountry.TabIndex = 19;
            this.txtBxCountry.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(336, 191);
            this.btnSubmit.MaximumSize = new System.Drawing.Size(105, 41);
            this.btnSubmit.MinimumSize = new System.Drawing.Size(105, 41);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Заселить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(17, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "Номер комнаты";
            // 
            // dateTimeComing
            // 
            this.dateTimeComing.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeComing.Location = new System.Drawing.Point(144, 202);
            this.dateTimeComing.Name = "dateTimeComing";
            this.dateTimeComing.Size = new System.Drawing.Size(100, 20);
            this.dateTimeComing.TabIndex = 25;
            // 
            // dateTimeLeaving
            // 
            this.dateTimeLeaving.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLeaving.Location = new System.Drawing.Point(144, 228);
            this.dateTimeLeaving.Name = "dateTimeLeaving";
            this.dateTimeLeaving.Size = new System.Drawing.Size(100, 20);
            this.dateTimeLeaving.TabIndex = 26;
            // 
            // dateTimeDateOfBirth
            // 
            this.dateTimeDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDateOfBirth.Location = new System.Drawing.Point(144, 102);
            this.dateTimeDateOfBirth.Name = "dateTimeDateOfBirth";
            this.dateTimeDateOfBirth.Size = new System.Drawing.Size(100, 20);
            this.dateTimeDateOfBirth.TabIndex = 27;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(145, 178);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 21);
            this.comboBox1.TabIndex = 28;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(309, 165);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(158, 13);
            this.labelWarning.TabIndex = 29;
            this.labelWarning.Text = "Проверьте вводимые данные";
            // 
            // TouristRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 277);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimeDateOfBirth);
            this.Controls.Add(this.dateTimeLeaving);
            this.Controls.Add(this.dateTimeComing);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBxCountry);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBxEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBxPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBxLogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxThirdname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxSurname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 316);
            this.MinimumSize = new System.Drawing.Size(515, 316);
            this.Name = "TouristRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заселение туриста";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TouristRegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.TouristRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxThirdname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBxLogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBxEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBxCountry;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimeComing;
        private System.Windows.Forms.DateTimePicker dateTimeLeaving;
        private System.Windows.Forms.DateTimePicker dateTimeDateOfBirth;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelWarning;
    }
}