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
    public partial class f_livro : Form
    {
        BaseDados bd;
        public f_livro(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != string.Empty)
                    pbCapa.ImageLocation = openFileDialog.FileName;
            }
        }
        //adicionar livro
        private void button2_Click(object sender, EventArgs e)
        {
            //validar o form
            if (tbNome.Text.Trim() == String.Empty)
            {
                MessageBox.Show("O nome é obrigatório");
                return;
            }
            int ano = 0;
            if (int.TryParse(tbAno.Text, out ano) == false)
            {
                MessageBox.Show("O ano indicado não é válido");
                return;
            }
            if (dtpData.Value > DateTime.Now)
            {
                MessageBox.Show("A data não pode ser posterior à data atual");
                return;
            }
            decimal preco = 0;
            if (decimal.TryParse(tbPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço não é válido");
                return;
            }
            //criar o objeto livro
            Guid guid = Guid.NewGuid();
            string ficheiro = Utils.pastaDoPrograma() + @"\" + guid.ToString();
            Livro livro = new Livro(tbNome.Text,
                        ano, dtpData.Value, preco, ficheiro);
            //adicionar a bd
            livro.Adicionar(bd);
            //copiar a capa
            if (pbCapa.ImageLocation != string.Empty)
            {
                if (System.IO.File.Exists(pbCapa.ImageLocation))
                    System.IO.File.Copy(pbCapa.ImageLocation, ficheiro);
            }
            //limpar o form
            LimparForm();

            //atualizar a grid
            AtualizarGrelhaLivros();
        }

        private void AtualizarGrelhaLivros()
        {
            dataGridView1.DataSource = Livro.ListarTodos(bd);
        }

        private void LimparForm()
        {
            tbAno.Clear();
            tbNome.Clear();
            tbPreco.Clear();
            pbCapa.ImageLocation = "";
        }
    }
}
