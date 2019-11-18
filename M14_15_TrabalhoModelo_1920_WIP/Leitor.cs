using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M14_15_TrabalhoModelo_1920_WIP
{
    class Leitor
    {
        int nleitor;
        string nome;
        DateTime data_nascimento;
        byte[] fotografia;
        bool estado; //1-ativo 0-inativo

        public Leitor(string nome,DateTime data_nascimento,
            byte[] fotografia)
        {
            this.estado = true;
            this.nome = nome;
            this.data_nascimento = data_nascimento;
            this.fotografia = fotografia;
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
