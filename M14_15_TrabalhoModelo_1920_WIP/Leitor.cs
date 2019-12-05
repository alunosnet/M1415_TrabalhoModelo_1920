using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M14_15_TrabalhoModelo_1920_WIP
{
    class Leitor
    {
        public int nleitor;
        public string nome;
        public DateTime data_nascimento;
        public byte[] fotografia;
        public bool estado; //1-ativo 0-inativo

        public Leitor(int nleitor,string nome)
        {
            this.nleitor = nleitor;
            this.nome = nome;
        }
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

        internal static DataTable ListaLeitoresDisponiveis(BaseDados bd)
        {
            string sql = "select * from leitores where estado=1";
            return bd.devolveSQL(sql);
        }

        //remover
        public static void Remover(BaseDados bd,int id)
        {
            string sql = "delete from leitores where nleitor=" + id;
            bd.executaSQL(sql);
        }
        //atualizar
        public void Atualizar(BaseDados bd,int id)
        {
            //sql com insert
            string sql = $@"update leitores set nome=@nome,data_nasc=@data_nasc,
                        fotografia=@fotografia WHERE nleitor=@nleitor";
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
                    ParameterName="@nleitor",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=id
                },

            };
            //executar
            bd.executaSQL(sql, parametros);
        }
        //listar todos
        public static DataTable ListarTodos(BaseDados bd)
        {
            return bd.devolveSQL("Select * from leitores");
        }
        //pesquisar
        public DataTable PesquisaPorNome(BaseDados bd,string nome)
        {
            string sql = "select * from leitores where nome like @nome";
            string filtro = "%" + nome + "%";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=filtro
                }
            };
            return bd.devolveSQL(sql, parametros);
        }
        //pesquisar por nleitor
        public void PesquisaPorNLeitor(BaseDados bd,int id)
        {
            string sql = "select * from leitores where nleitor=" + id;
            DataTable dados = bd.devolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.nleitor = int.Parse(dados.Rows[0]["nleitor"].ToString());
                this.nome = dados.Rows[0]["nome"].ToString();
                this.data_nascimento = DateTime.Parse(dados.Rows[0]["data_nasc"].ToString());
                this.fotografia = (byte[])dados.Rows[0]["fotografia"];
                this.estado = bool.Parse(dados.Rows[0]["estado"].ToString());
            }
        }
        static public int NrDeLeitores(BaseDados bd)
        {
            string sql = "Select count(*) as nr from leitores";
            DataTable dados = bd.devolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }
        public static DataTable listaTodosLeitores(BaseDados bd,
           int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT nleitor,nome,estado from 
                    (select row_number() over (order by nleitor) as num,
                        nleitor,nome,estado from leitores) as p
                        WHERE num>={primeiroregisto} and
                        num<={ultimoregisto}";
            return bd.devolveSQL(sql);
        }
        public override string ToString()
        {
            return this.nome;
        }
    }
}
