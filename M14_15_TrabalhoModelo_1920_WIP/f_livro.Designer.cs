namespace M14_15_TrabalhoModelo_1920_WIP
{
    partial class f_livro
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbAno = new System.Windows.Forms.TextBox();
            this.tbPreco = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.pbCapa = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ano";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Preço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Capa";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(94, 27);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(227, 20);
            this.tbNome.TabIndex = 1;
            // 
            // tbAno
            // 
            this.tbAno.Location = new System.Drawing.Point(94, 60);
            this.tbAno.Name = "tbAno";
            this.tbAno.Size = new System.Drawing.Size(227, 20);
            this.tbAno.TabIndex = 1;
            // 
            // tbPreco
            // 
            this.tbPreco.Location = new System.Drawing.Point(94, 126);
            this.tbPreco.Name = "tbPreco";
            this.tbPreco.Size = new System.Drawing.Size(227, 20);
            this.tbPreco.TabIndex = 1;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(94, 93);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(227, 20);
            this.dtpData.TabIndex = 2;
            // 
            // pbCapa
            // 
            this.pbCapa.Location = new System.Drawing.Point(94, 163);
            this.pbCapa.Name = "pbCapa";
            this.pbCapa.Size = new System.Drawing.Size(224, 148);
            this.pbCapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCapa.TabIndex = 3;
            this.pbCapa.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 54);
            this.button2.TabIndex = 5;
            this.button2.Text = "Adicionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(352, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(356, 314);
            this.dataGridView1.TabIndex = 6;
            // 
            // f_livro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbCapa);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.tbPreco);
            this.Controls.Add(this.tbAno);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_livro";
            this.Text = "f_livro";
            ((System.ComponentModel.ISupportInitialize)(this.pbCapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbAno;
        private System.Windows.Forms.TextBox tbPreco;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.PictureBox pbCapa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}