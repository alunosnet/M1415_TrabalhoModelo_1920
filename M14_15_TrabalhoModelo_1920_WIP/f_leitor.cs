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
    public partial class f_leitor : Form
    {
        BaseDados bd;
        int nleitorEditar;
        const int registosPorPagina = 5;
        public f_leitor(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;

            atualizaNrPaginas();
            AtualizaGrelha();
        }
        private void atualizaNrPaginas()
        {
            cbPagina.Items.Clear();
            int nrLeitores = Leitor.NrDeLeitores(bd);
            int nrPaginas = (int)Math.Ceiling(nrLeitores / (float)registosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                cbPagina.Items.Add(i);
            //para evitar erros qd não há leitores
            if (cbPagina.Items.Count == 0)
                cbPagina.Items.Add("1");
            cbPagina.SelectedIndex = 0;
        }
        private void AtualizaGrelha()
        {
            //consulta à bd
            if (cbPagina.SelectedIndex == -1)
                dataGridView1.DataSource = Leitor.ListarTodos(bd);
            else
            {
                int nrpagina = cbPagina.SelectedIndex + 1;
                int primeiroregisto = (nrpagina - 1) * registosPorPagina + 1;
                int ultimoregisto = primeiroregisto + registosPorPagina - 1;
                dataGridView1.DataSource = Leitor.listaTodosLeitores(bd,
                    primeiroregisto, ultimoregisto);

            }
        }

        //pesquisar foto
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != string.Empty)
                    pbFoto.ImageLocation = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbNome.Text == String.Empty)
            {
                MessageBox.Show("Tem de indicar o nome!");
                return;
            }
            if(pbFoto.ImageLocation==string.Empty)
            {
                MessageBox.Show("Tem de escolher uma foto!");
                return;
            }
            //converter imagem para vector
            var fotografia = Utils.ImagemParaVetor(pbFoto.ImageLocation);
            Leitor leitor = new Leitor(tbNome.Text, dtpData.Value, fotografia);
           
            leitor.Adicionar(bd);
            atualizaNrPaginas();
            AtualizaGrelha();
            LimparForm();

        }
        //editar leitor
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nleitor
            nleitorEditar = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            Leitor leitor = new Leitor(null, DateTime.Now, null);
            leitor.PesquisaPorNLeitor(bd, nleitorEditar);

            tbNome.Text = leitor.nome;
            dtpData.Value = leitor.data_nascimento;
            string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
            Utils.VetorParaImagem(leitor.fotografia, ficheiro);
            pbFoto.ImageLocation = ficheiro;
            //esconder o botão adicionar
            button2.Visible = false;
            //mostrar o botão atualizar
            button3.Visible = true;
            //mostrar o botão cancelar
            button4.Visible = true;
        }
        //remover leitor
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nleitor
            int nleitor = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            string nome = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            string mensagem = $"Tem a certeza que pretende remover o leitor {nome}";
            if (MessageBox.Show(mensagem, "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Leitor.Remover(bd,nleitor);
                atualizaNrPaginas();
                AtualizaGrelha();
            }
            
        }
        //atualizar o registo selecionado
        private void button3_Click(object sender, EventArgs e)
        {
            Leitor leitor = new Leitor(tbNome.Text, dtpData.Value, Utils.ImagemParaVetor(pbFoto.ImageLocation));
            //nleitor
            leitor.Atualizar(bd, nleitorEditar);
            AtualizaGrelha();
            //esconder
            button3.Visible = false;
            button4.Visible = false;
            button2.Visible = true;
            LimparForm();
        }

        private void LimparForm()
        {
            //limpar form
            tbNome.Clear();
            pbFoto.ImageLocation = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = true;
            LimparForm();
        }

        private void cbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelha();
        }
    }
}
