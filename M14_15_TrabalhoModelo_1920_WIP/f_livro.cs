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
        int nrlinhas, nrpagina;
        public f_livro(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelhaLivros();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Livro.PesquisaPorNome(bd,textBox1.Text);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            imprimeGrelha(e, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();
            //printDialog1.ShowDialog();
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void imprimeGrelha(System.Drawing.Printing.PrintPageEventArgs e, DataGridView grelha)
        {
            Graphics impressora = e.Graphics;
            Font tipoLetra = new Font("Arial", 10);
            Font tipoLetraMaior = new Font("Arial", 12, FontStyle.Bold);
            Brush cor = Brushes.Black;
            float mesquerda, mdireita, msuperior, minferior, linha, largura;
            Pen caneta = new Pen(cor, 2);

            //margens
            mesquerda = printDocument1.DefaultPageSettings.Margins.Left;
            mdireita = printDocument1.DefaultPageSettings.Bounds.Right - mesquerda;
            msuperior = printDocument1.DefaultPageSettings.Margins.Top;
            minferior = printDocument1.DefaultPageSettings.Bounds.Height - msuperior;
            largura = mdireita - mesquerda;
            //calcular as colunas da grelha
            float[] colunas = new float[grelha.Columns.Count];
            float lgrelha = 0;
            for (int i = 0; i < grelha.Columns.Count; i++)
                lgrelha += grelha.Columns[i].Width;
            colunas[0] = mesquerda;
            float total = mesquerda, larguraColuna;
            for (int i = 0; i < grelha.Columns.Count - 1; i++)
            {
                larguraColuna = grelha.Columns[i].Width / lgrelha;
                colunas[i + 1] = larguraColuna * largura + total;
                total = colunas[i + 1];
            }
            //cabeçalhos
            for (int i = 0; i < grelha.Columns.Count; i++)
            {
                impressora.DrawString(grelha.Columns[i].HeaderText, tipoLetraMaior, cor, colunas[i], msuperior);
            }
            linha = msuperior + tipoLetraMaior.Height;
            //ciclo para percorrer a grelha
            int l;
            for (l = nrlinhas; l < grelha.Rows.Count; l++)
            {
                //desenhar linha
                impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
                //escrever uma linha
                for (int c = 0; c < grelha.Columns.Count; c++)
                {
                    impressora.DrawString(grelha.Rows[l].Cells[c].Value.ToString(),
                        tipoLetra, cor, colunas[c], linha);
                }
                //avançar para linha seguinte
                linha = linha + tipoLetra.Height;
                //verificar se o papel acabou
                if (linha + tipoLetra.Height > minferior)
                    break;
            }
            //tem mais páginas?
            if (l < grelha.Rows.Count)
            {
                nrlinhas = l + 1;
                e.HasMorePages = true;
            }
            //rodapé
            impressora.DrawString("12ºH - Página " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
            //nr página
            nrpagina++;
            //linhas
            //linha superior
            impressora.DrawLine(caneta, mesquerda, msuperior, mdireita, msuperior);
            //linha inferior
            impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
            //colunas
            for (int c = 0; c < colunas.Length; c++)
            {
                impressora.DrawLine(caneta, colunas[c], msuperior, colunas[c], linha);
            }
            //linha lado direito
            impressora.DrawLine(caneta, mdireita, msuperior, mdireita, linha);
        }

    }
}
