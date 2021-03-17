
namespace AppIS
{
    partial class ProductRegisterForm
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
            this.txtBxQuantity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBxType = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxProductId = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(14, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 69;
            this.label5.Text = "Кол-во в наличии";
            // 
            // txtBxQuantity
            // 
            this.txtBxQuantity.Location = new System.Drawing.Point(149, 146);
            this.txtBxQuantity.Name = "txtBxQuantity";
            this.txtBxQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtBxQuantity.TabIndex = 68;
            this.txtBxQuantity.TextChanged += new System.EventHandler(this.txtBxProductId_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(106, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 66;
            this.label11.Text = "Вид";
            // 
            // txtBxType
            // 
            this.txtBxType.Location = new System.Drawing.Point(149, 119);
            this.txtBxType.Name = "txtBxType";
            this.txtBxType.Size = new System.Drawing.Size(100, 20);
            this.txtBxType.TabIndex = 65;
            this.txtBxType.TextChanged += new System.EventHandler(this.txtBxProductId_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(97, 224);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 41);
            this.btnSubmit.TabIndex = 64;
            this.btnSubmit.Text = "Добавить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(69, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 57;
            this.label4.Text = "Описание";
            // 
            // txtBxDescription
            // 
            this.txtBxDescription.Location = new System.Drawing.Point(149, 92);
            this.txtBxDescription.Name = "txtBxDescription";
            this.txtBxDescription.Size = new System.Drawing.Size(100, 20);
            this.txtBxDescription.TabIndex = 56;
            this.txtBxDescription.TextChanged += new System.EventHandler(this.txtBxProductId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(98, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 55;
            this.label3.Text = "Цена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(70, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Название";
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(149, 40);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(100, 20);
            this.txtBxName.TabIndex = 52;
            this.txtBxName.TextChanged += new System.EventHandler(this.txtBxProductId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(41, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "Код продукта";
            // 
            // txtBxProductId
            // 
            this.txtBxProductId.Location = new System.Drawing.Point(149, 14);
            this.txtBxProductId.Name = "txtBxProductId";
            this.txtBxProductId.Size = new System.Drawing.Size(100, 20);
            this.txtBxProductId.TabIndex = 50;
            this.txtBxProductId.TextChanged += new System.EventHandler(this.txtBxProductId_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(148, 65);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown1.TabIndex = 70;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(70, 208);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(158, 13);
            this.labelWarning.TabIndex = 71;
            this.labelWarning.Text = "Проверьте вводимые данные";
            // 
            // ProductRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 277);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBxQuantity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBxType);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxProductId);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 316);
            this.MinimumSize = new System.Drawing.Size(310, 316);
            this.Name = "ProductRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ProductRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBxQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBxType;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxProductId;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelWarning;
    }
}