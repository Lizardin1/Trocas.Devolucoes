using Dapper;
using System.Data;
using System.Data.SqlClient;
using TrocasDevolucoes.Decorecasa;
using TrocasDevolucoes.Decorecasa.Model.Modelo;

namespace GunaUITestes.Controller.ListaReposicoes
{
    public class ListarReposicoes
    {
        public static List<repoModel> ListTodasReposicoes = new List<repoModel>();
        public static List<repoModel> listReposicoes(string where)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
                {

                    ListTodasReposicoes = connection.Query<repoModel>($@"SELECT TOP (50)    CANAL, ID, NF_E, 
                                                                                        NOME_CLIENTE, 
                                                                                        PRODUTO, QTD,
                                                                                        DATA_REGISTRO,
                                                                                        DATA_LIMITE_ENVIO,
                                                                                        STATUS, SOB_ENCOMENDA,
                                                                                        PEDIDO_FEITO,
                                                                                        IMAGE_BYTE1,
                                                                                        IMAGE_BYTE2
                                                                                        FROM [dbo].[Tabela_Suporte] WITH (INDEX(PK_TABELA_SUPORTE_1)){where} Order By [dbo].[Tabela_Suporte].id Desc", commandType: CommandType.Text).AsList();
                }
                return ListTodasReposicoes;
            }
            catch (Exception ex)
            {
                return ListTodasReposicoes;
            }
        }
    }
}
