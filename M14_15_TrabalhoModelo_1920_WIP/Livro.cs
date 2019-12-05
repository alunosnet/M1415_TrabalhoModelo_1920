using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M14_15_TrabalhoModelo_1920_WIP
{
    class Livro
    {
        public int nlivro;
        public string nome;
        public int ano;
        public DateTime data_aquisicao;
        public decimal preco;
        public string capa;
        public bool estado;
        public Livro(int nlivro,string nome)
        {
            this.nlivro = nlivro;
            this.nome = nome;
        }
        public Livro(string nome, int ano, DateTime data_aquisicao, decimal preco, string capa)
        {
            this.nome = nome;
            this.ano = ano;
            this.data_aquisicao = data_aquisicao;
            this.preco = preco;
            this.capa = capa;
        }

        internal static DataTable ListaLivrosDisponiveis(BaseDados bd)
        {
            string sql = "select * from livros where estado=1";
            return bd.devolveSQL(sql);
        }
        internal static DataTable ListaLivrosEmprestados(BaseDados bd)
        {
            string sql = "select * from livros where estado=0";
            return bd.devolveSQL(sql);
        }
        public void Adicionar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"insert into Livros(nome,ano,data_aquisicao,
                            preco,capa,estado) values 
                            (@nome,@ano,@data_aquisicao,@preco,@capa,@estado)";
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
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@capa",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.capa
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=true
                },
            };
            //executar
            bd.executaSQL(sql, parametros);
        }
        //remover
        public static void Remover(BaseDados bd, int id)
        {
            string sql = "delete from livros where nlivro=" + id;
            bd.executaSQL(sql);
        }
        //atualizar
        public void Atualizar(BaseDados bd, int id)
        {
            string sql = $@"update livros set nome=@nome,ano=@ano,data_aquisicao=@data_aquisicao,
                        preco=@preco,capa=@capa WHERE nlivro=@nlivro";
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
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@capa",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.capa
                },
                new SqlParameter()
                {
                    ParameterName="@nlivro",
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
            return bd.devolveSQL("Select * from livros");
        }
        //pesquisar
        public static DataTable PesquisaPorNome(BaseDados bd, string nome)
        {
            string sql = "select * from livros where nome like @nome";
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
        public void PesquisaPorNLivro(BaseDados bd, int id)
        {
            string sql = "select * from livros where nlivro=" + id;
            DataTable dados = bd.devolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.nlivro = int.Parse(dados.Rows[0]["nlivro"].ToString());
                this.nome = dados.Rows[0]["nome"].ToString();
                this.ano = int.Parse(dados.Rows[0]["ano"].ToString());
                this.data_aquisicao = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString());
                this.preco = decimal.Parse(dados.Rows[0]["preco"].ToString());
                this.capa = dados.Rows[0]["capa"].ToString();
                this.estado = bool.Parse(dados.Rows[0]["estado"].ToString());
            }
        }
        
        public override string ToString()
        {
            return this.nome;
        }
    }
}
