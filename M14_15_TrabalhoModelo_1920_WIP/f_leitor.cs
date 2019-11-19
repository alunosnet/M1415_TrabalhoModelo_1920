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
        public f_leitor(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;

            AtualizaGrelha(bd);
        }

        private void AtualizaGrelha(BaseDados bd)
        {
            //preencher gridview
            dataGridView1.DataSource = Leitor.ListarTodos(bd);
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
            AtualizaGrelha(bd);
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
                AtualizaGrelha(bd);
            }
            
        }
        //atualizar o registo selecionado
        private void button3_Click(object sender, EventArgs e)
        {
            Leitor leitor = new Leitor(tbNome.Text, dtpData.Value, Utils.ImagemParaVetor(pbFoto.ImageLocation));
            //nleitor
            leitor.Atualizar(bd, nleitorEditar);
            AtualizaGrelha(bd);
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
    }
}
