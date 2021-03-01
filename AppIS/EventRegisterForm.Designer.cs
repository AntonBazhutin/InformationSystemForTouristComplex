
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
            this.txtBxWorkPlaceId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBxDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxEventId = new System.Windows.Forms.TextBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "Код рабочего места";
            // 
            // txtBxWorkPlaceId
            // 
            this.txtBxWorkPlaceId.Location = new System.Drawing.Point(158, 150);
            this.txtBxWorkPlaceId.Name = "txtBxWorkPlaceId";
            this.txtBxWorkPlaceId.Size = new System.Drawing.Size(100, 20);
            this.txtBxWorkPlaceId.TabIndex = 80;
            this.txtBxWorkPlaceId.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(107, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 18);
            this.label11.TabIndex = 79;
            this.label11.Text = "Дата";
            // 
            // txtBxDate
            // 
            this.txtBxDate.Location = new System.Drawing.Point(158, 123);
            this.txtBxDate.Name = "txtBxDate";
            this.txtBxDate.Size = new System.Drawing.Size(100, 20);
            this.txtBxDate.TabIndex = 78;
            this.txtBxDate.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(78, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 77;
            this.label4.Text = "Описание";
            // 
            // txtBxDescription
            // 
            this.txtBxDescription.Location = new System.Drawing.Point(158, 96);
            this.txtBxDescription.Name = "txtBxDescription";
            this.txtBxDescription.Size = new System.Drawing.Size(100, 20);
            this.txtBxDescription.TabIndex = 76;
            this.txtBxDescription.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(107, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "Цена";
            // 
            // txtBxPrice
            // 
            this.txtBxPrice.Location = new System.Drawing.Point(158, 70);
            this.txtBxPrice.Name = "txtBxPrice";
            this.txtBxPrice.Size = new System.Drawing.Size(100, 20);
            this.txtBxPrice.TabIndex = 74;
            this.txtBxPrice.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(79, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "Название";
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(158, 44);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(100, 20);
            this.txtBxName.TabIndex = 72;
            this.txtBxName.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(114, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Код";
            // 
            // txtBxEventId
            // 
            this.txtBxEventId.Location = new System.Drawing.Point(158, 18);
            this.txtBxEventId.Name = "txtBxEventId";
            this.txtBxEventId.Size = new System.Drawing.Size(100, 20);
            this.txtBxEventId.TabIndex = 70;
            this.txtBxEventId.TextChanged += new System.EventHandler(this.txtBxEventId_TextChanged);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(61, 199);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(168, 20);
            this.labelWarning.TabIndex = 83;
            this.labelWarning.Text = "Заполните все поля!";
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
            // EventRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 286);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBxWorkPlaceId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBxDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxPrice);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBxWorkPlaceId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBxDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxEventId;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Button btnSubmit;
    }
}