namespace M14_15_TrabalhoModelo_1920_WIP
{
    partial class f_consultas
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 1;
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem,
            this.listarOToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem
            // 
            this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem.Name = "listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem";
            this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem.Text = "Listar o número de empréstimos por leitor";
            this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem.Click += new System.EventHandler(this.listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem_Click);
            // 
            // listarOToolStripMenuItem
            // 
            this.listarOToolStripMenuItem.Name = "listarOToolStripMenuItem";
            this.listarOToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.listarOToolStripMenuItem.Text = "Listar os leitores com idade superior à média";
            this.listarOToolStripMenuItem.Click += new System.EventHandler(this.listarOToolStripMenuItem_Click);
            // 
            // f_consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "f_consultas";
            this.Text = "f_consultas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarOToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}