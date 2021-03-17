
namespace AppIS
{
    partial class WorkPlaceRegisterForm
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
            this.txtBxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.comboBxBuilding_id = new System.Windows.Forms.ComboBox();
            this.txtBxPlace_id = new System.Windows.Forms.TextBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBxId
            // 
            this.txtBxId.Location = new System.Drawing.Point(132, 26);
            this.txtBxId.Name = "txtBxId";
            this.txtBxId.Size = new System.Drawing.Size(100, 20);
            this.txtBxId.TabIndex = 1;
            this.txtBxId.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Код записи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(38, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Код места";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(31, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Код здания";
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(86, 166);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 45;
            this.btnSubmit.Text = "Добавить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // comboBxBuilding_id
            // 
            this.comboBxBuilding_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBxBuilding_id.FormattingEnabled = true;
            this.comboBxBuilding_id.Location = new System.Drawing.Point(132, 103);
            this.comboBxBuilding_id.Name = "comboBxBuilding_id";
            this.comboBxBuilding_id.Size = new System.Drawing.Size(100, 21);
            this.comboBxBuilding_id.TabIndex = 50;
            // 
            // txtBxPlace_id
            // 
            this.txtBxPlace_id.Location = new System.Drawing.Point(132, 63);
            this.txtBxPlace_id.Name = "txtBxPlace_id";
            this.txtBxPlace_id.Size = new System.Drawing.Size(100, 20);
            this.txtBxPlace_id.TabIndex = 51;
            this.txtBxPlace_id.TextChanged += new System.EventHandler(this.txtBxId_TextChanged);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(62, 150);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(158, 13);
            this.labelWarning.TabIndex = 52;
            this.labelWarning.Text = "Проверьте вводимые данные";
            // 
            // WorkPlaceRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 229);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.txtBxPlace_id);
            this.Controls.Add(this.comboBxBuilding_id);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxId);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 268);
            this.MinimumSize = new System.Drawing.Size(296, 268);
            this.Name = "WorkPlaceRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление рабочего места";
            this.Load += new System.EventHandler(this.WorkPlaceRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox comboBxBuilding_id;
        private System.Windows.Forms.TextBox txtBxPlace_id;
        private System.Windows.Forms.Label labelWarning;
    }
}