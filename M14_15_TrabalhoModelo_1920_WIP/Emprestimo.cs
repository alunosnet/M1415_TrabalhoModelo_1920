using System;
using System.Collections.Generic;
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
            string sql = $@"insert into Leitores(nome,data_nasc,
                            fotografia,estado) values 
                            (@nome,@data_nasc,@fotografia,@estado)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_nascimento
                },
                new SqlParameter()
                {
                    ParameterName="@fotografia",
                    SqlDbType=System.Data.SqlDbType.VarBinary,
                    Value=this.fotografia
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.estado
                },

            };
            //executar
            bd.executaSQL(sql, parametros);
        }
    }
}
