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
        public f_leitor(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
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
        }
    }
}
