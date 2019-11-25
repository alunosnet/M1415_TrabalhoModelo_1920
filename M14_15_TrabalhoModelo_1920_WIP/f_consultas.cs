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
    public partial class f_consultas : Form
    {
        BaseDados bd;
        public f_consultas(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void listarOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = @"select Nome,datediff(year,data_nasc,getdate()) as Idade
                        from leitores
                        where datediff(year,data_nasc,getdate())>=(
                        select avg(datediff(year,data_nasc,getdate()))
                        from leitores)";
            dataGridView1.DataSource = bd.devolveSQL(sql);

        }

        private void listarONúmeroDeEmpréstimosPorLeitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //listar o número de emprestimos por leitor
            string sql = @"select nome,count(*) as [Nr Empréstimos]
                        from emprestimos
                        inner join leitores
                        on emprestimos.nleitor=leitores.nleitor
                        group by emprestimos.nleitor,nome
                        order by [Nr Empréstimos]";
            dataGridView1.DataSource = bd.devolveSQL(sql);
        }
    }
}
