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
    public partial class f_devolve : Form
    {
        BaseDados bd;
        public f_devolve(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            preencheLBLivros();

        }

        private void preencheLBLivros()
        {
            DataTable dados = Livro.ListaLivrosEmprestados(bd);
            listBox1.Items.Clear();
            foreach (DataRow linha in dados.Rows)
            {
                Livro livro = new Livro(
                    int.Parse(linha["nlivro"].ToString()),
                    linha["nome"].ToString()
                    );
                listBox1.Items.Add(livro);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Tem de selecionar um livro.");
                return;
            }
            Livro livro = listBox1.SelectedItem as Livro;

            //alterar o estado do empréstimo e do livro
            Emprestimo.Devolver(bd,livro.nlivro);

            preencheLBLivros();
        }
    }
}
