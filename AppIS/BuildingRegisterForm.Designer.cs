
namespace AppIS
{
    partial class BuildingRegisterForm
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxId = new System.Windows.Forms.TextBox();
            this.numericUpDownCountOfRooms = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(73, 156);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 61;
            this.btnSubmit.Text = "Добавить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 60;
            this.label2.Text = "Кол-во номеров";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 59;
            this.label1.Text = "Код здания";
            // 
            // txtBxId
            // 
            this.txtBxId.Location = new System.Drawing.Point(104, 12);
            this.txtBxId.Name = "txtBxId";
            this.txtBxId.Size = new System.Drawing.Size(100, 20);
            this.txtBxId.TabIndex = 57;
            this.txtBxId.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // numericUpDownCountOfRooms
            // 
            this.numericUpDownCountOfRooms.Location = new System.Drawing.Point(135, 84);
            this.numericUpDownCountOfRooms.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownCountOfRooms.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountOfRooms.Name = "numericUpDownCountOfRooms";
            this.numericUpDownCountOfRooms.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownCountOfRooms.TabIndex = 63;
            this.numericUpDownCountOfRooms.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(99, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 64;
            this.checkBox1.Text = "Жилой корпус?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(46, 140);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(158, 13);
            this.labelWarning.TabIndex = 65;
            this.labelWarning.Text = "Проверьте вводимые данные";
            // 
            // BuildingRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 209);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDownCountOfRooms);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxId);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(274, 248);
            this.MinimumSize = new System.Drawing.Size(274, 248);
            this.Name = "BuildingRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BuildingRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOfRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxId;
        private System.Windows.Forms.NumericUpDown numericUpDownCountOfRooms;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label labelWarning;
    }
}