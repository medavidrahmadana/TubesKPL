namespace BarangKamuGUI
{
    partial class Form1
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
            this.inputNama = new System.Windows.Forms.TextBox();
            this.inputJumlah = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tambah = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.dataBarang = new System.Windows.Forms.DataGridView();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JumlahBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // inputNama
            // 
            this.inputNama.Location = new System.Drawing.Point(197, 173);
            this.inputNama.Name = "inputNama";
            this.inputNama.Size = new System.Drawing.Size(147, 20);
            this.inputNama.TabIndex = 0;
            this.inputNama.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // inputJumlah
            // 
            this.inputJumlah.Location = new System.Drawing.Point(197, 207);
            this.inputJumlah.Name = "inputJumlah";
            this.inputJumlah.Size = new System.Drawing.Size(146, 20);
            this.inputJumlah.TabIndex = 1;
            this.inputJumlah.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nama Barang";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jumlah Barang";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tambah
            // 
            this.tambah.Location = new System.Drawing.Point(107, 264);
            this.tambah.Name = "tambah";
            this.tambah.Size = new System.Drawing.Size(75, 23);
            this.tambah.TabIndex = 4;
            this.tambah.Text = "Tambah";
            this.tambah.UseVisualStyleBackColor = true;
            this.tambah.Click += new System.EventHandler(this.button1_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(188, 264);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 5;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.button2_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(269, 264);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 6;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataBarang
            // 
            this.dataBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBarang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaBarang,
            this.JumlahBarang});
            this.dataBarang.Location = new System.Drawing.Point(412, 155);
            this.dataBarang.Name = "dataBarang";
            this.dataBarang.Size = new System.Drawing.Size(240, 150);
            this.dataBarang.TabIndex = 7;
            this.dataBarang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NamaBarang
            // 
            this.NamaBarang.HeaderText = "Nama Barang";
            this.NamaBarang.Name = "NamaBarang";
            // 
            // JumlahBarang
            // 
            this.JumlahBarang.HeaderText = "Jumlah Barang";
            this.JumlahBarang.Name = "JumlahBarang";
            // 
            // deleteAll
            // 
            this.deleteAll.Location = new System.Drawing.Point(188, 293);
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.Size = new System.Drawing.Size(75, 23);
            this.deleteAll.TabIndex = 10;
            this.deleteAll.Text = "Delete All";
            this.deleteAll.UseVisualStyleBackColor = true;
            this.deleteAll.Click += new System.EventHandler(this.deleteAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Barang";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deleteAll);
            this.Controls.Add(this.dataBarang);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.tambah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputJumlah);
            this.Controls.Add(this.inputNama);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputNama;
        private System.Windows.Forms.TextBox inputJumlah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tambah;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DataGridView dataBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn JumlahBarang;
        private System.Windows.Forms.Button deleteAll;
        private System.Windows.Forms.Label label3;
    }
}

