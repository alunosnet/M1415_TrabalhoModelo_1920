using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M14_15_TrabalhoModelo_1920_WIP
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados();
        public Form1()
        {
            InitializeComponent();
        }

       
        //editar-leitores
        private void leitorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f_leitor f = new f_leitor(bd);
            f.Show();
        }
        //editar-livros
        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_livro f = new f_livro(bd);
            f.Show();
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_emprestimos f = new f_emprestimos(bd);
            f.Show();
        }

        private void devolverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_devolve f = new f_devolve(bd);
            f.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_consultas f = new f_consultas(bd);
            f.Show();
        }
    }
}
