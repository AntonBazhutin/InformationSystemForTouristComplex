
namespace AppIS
{
    partial class WorkerRegisterForm
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
            this.label11 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxThirdname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBxWorkPlace_id = new System.Windows.Forms.ComboBox();
            this.comboBxProfession_id = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(4, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 18);
            this.label11.TabIndex = 46;
            this.label11.Text = "Код места работы";
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(340, 194);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 44;
            this.btnSubmit.Text = "Добавить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(273, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 18);
            this.label9.TabIndex = 41;
            this.label9.Text = "Моб. телеф";
            // 
            // txtBxPhoneNumber
            // 
            this.txtBxPhoneNumber.Location = new System.Drawing.Point(371, 79);
            this.txtBxPhoneNumber.Name = "txtBxPhoneNumber";
            this.txtBxPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBxPhoneNumber.TabIndex = 40;
            this.txtBxPhoneNumber.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(304, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 18);
            this.label8.TabIndex = 39;
            this.label8.Text = "Пароль";
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(371, 54);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBxPassword.TabIndex = 38;
            this.txtBxPassword.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(315, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "Логин";
            // 
            // txtBxLogin
            // 
            this.txtBxLogin.Location = new System.Drawing.Point(371, 27);
            this.txtBxLogin.Name = "txtBxLogin";
            this.txtBxLogin.Size = new System.Drawing.Size(100, 20);
            this.txtBxLogin.TabIndex = 36;
            this.txtBxLogin.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(26, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Дата рождения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(67, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Отчество";
            // 
            // txtBxThirdname
            // 
            this.txtBxThirdname.Location = new System.Drawing.Point(148, 79);
            this.txtBxThirdname.Name = "txtBxThirdname";
            this.txtBxThirdname.Size = new System.Drawing.Size(100, 20);
            this.txtBxThirdname.TabIndex = 28;
            this.txtBxThirdname.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(69, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Фамилия";
            // 
            // txtBxSurname
            // 
            this.txtBxSurname.Location = new System.Drawing.Point(148, 53);
            this.txtBxSurname.Name = "txtBxSurname";
            this.txtBxSurname.Size = new System.Drawing.Size(100, 20);
            this.txtBxSurname.TabIndex = 26;
            this.txtBxSurname.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(104, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Имя";
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(148, 27);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(100, 20);
            this.txtBxName.TabIndex = 24;
            this.txtBxName.TextChanged += new System.EventHandler(this.txtBxName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(24, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 18);
            this.label5.TabIndex = 49;
            this.label5.Text = "Код профессии";
            // 
            // comboBxWorkPlace_id
            // 
            this.comboBxWorkPlace_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBxWorkPlace_id.FormattingEnabled = true;
            this.comboBxWorkPlace_id.Location = new System.Drawing.Point(148, 176);
            this.comboBxWorkPlace_id.Name = "comboBxWorkPlace_id";
            this.comboBxWorkPlace_id.Size = new System.Drawing.Size(121, 21);
            this.comboBxWorkPlace_id.TabIndex = 50;
            // 
            // comboBxProfession_id
            // 
            this.comboBxProfession_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBxProfession_id.FormattingEnabled = true;
            this.comboBxProfession_id.Location = new System.Drawing.Point(148, 206);
            this.comboBxProfession_id.Name = "comboBxProfession_id";
            this.comboBxProfession_id.Size = new System.Drawing.Size(121, 21);
            this.comboBxProfession_id.TabIndex = 51;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(148, 106);
            this.dateTimePicker1.MaxDate = new System.DateTime(2003, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 52;
            this.dateTimePicker1.Value = new System.DateTime(2003, 1, 1, 0, 0, 0, 0);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(313, 176);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(158, 13);
            this.labelWarning.TabIndex = 53;
            this.labelWarning.Text = "Проверьте вводимые данные";
            // 
            // WorkerRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 277);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBxProfession_id);
            this.Controls.Add(this.comboBxWorkPlace_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBxPhoneNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBxPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBxLogin);
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
            this.Name = "WorkerRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление работника";
            this.Load += new System.EventHandler(this.WorkerRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBxPhoneNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBxLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxThirdname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBxWorkPlace_id;
        private System.Windows.Forms.ComboBox comboBxProfession_id;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelWarning;
    }
}