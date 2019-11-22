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
    public partial class f_emprestimos : Form
    {
        BaseDados bd;
        public f_emprestimos(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            //preencher a cb livros
            preencheCBLivros();
            //preenche a cb leitores
            preencheCBLeitores();
        }

        private void preencheCBLivros()
        {
            DataTable dados = Livro.ListaLivrosDisponiveis(bd);
            cbLivros.Items.Clear();
            foreach(DataRow linha in dados.Rows)
            {
                Livro livro = new Livro(
                    int.Parse(linha["nlivro"].ToString()),
                    linha["nome"].ToString()
                    );
                cbLivros.Items.Add(livro);
            }
        }

        private void preencheCBLeitores()
        {
            DataTable dados = Leitor.ListaLeitoresDisponiveis(bd);
            cbLeitores.Items.Clear();
            foreach (DataRow linha in dados.Rows)
            {
                Leitor leitor = new Leitor(
                    int.Parse(linha["nleitor"].ToString()),
                    linha["nome"].ToString()
                    );
                cbLeitores.Items.Add(leitor);
            }
        }
    }
}
