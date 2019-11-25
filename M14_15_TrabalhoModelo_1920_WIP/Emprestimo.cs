using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M14_15_TrabalhoModelo_1920_WIP
{
    class Emprestimo
    {
        public int nemprestimo;
        public int nleitor;
        public int nlivro;
        public DateTime data_emprestimo;
        public DateTime data_devolve;
        public bool estado;

        public Emprestimo(int nleitor, int nlivro, DateTime data_devolve)
        {
            this.nleitor = nleitor;
            this.nlivro = nlivro;
            this.data_devolve = data_devolve;
        }
        public void Adicionar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"insert into emprestimos(nlivro,nleitor,
                            data_emprestimo,data_devolve,estado) values 
                            (@nlivro,@nleitor,getdate(),
                                @data_devolve,1)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nlivro",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nlivro
                },
                new SqlParameter()
                {
                    ParameterName="@nleitor",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nleitor
                },
                new SqlParameter()
                {
                    ParameterName="@data_devolve",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_devolve
                },
            };
            //executar
            bd.executaSQL(sql, parametros);
            //alterar o estado do livro emprestado para 0
            sql = "UPDATE livros SET estado=0 WHERE nlivro=" + nlivro;
            bd.executaSQL(sql);
        }

        internal static void Devolver(BaseDados bd, int nlivro)
        {
            //alterar o estado do emprestimo
            string sql = @"update emprestimos set estado=0 
                            where estado=1 and nlivro=" + nlivro;
            bd.executaSQL(sql);
            //alterar o estado do livro
            sql = "update livros set estado=1 where nlivro=" + nlivro;
            bd.executaSQL(sql);
        }
    }
}
