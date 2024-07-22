using Dapper;
using GunaUITestes;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrocasDevolucoes.Decorecasa.Controller.Metodos.EditarReposicao
{
    public class UpdateReposicao
    {
        public static int AtualizarPedido(  string id_cliente,
                                            int data_pedido_feito_verificado,
                                            int anotacao_suporte_verificado,
                                            int anotacao_expedicao_verificado,
                                            int anotacao_compras_verificado,
                                            int status_enviado_verificado,
                                            int status_faturado_verificado,
                                            DateTime data_pedido_feito,
                                            DateTime data_anotacao_suporte,
                                            DateTime data_anotacao_expedicao,
                                            DateTime data_anotacao_compras,
                                            DateTime data_enviado,
                                            DateTime data_faturado,
                                            string canal,
                                            string nome_cliente,
                                            string cpf,
                                            string nf,
                                            string custo_reversa,
                                            string nome_produto,
                                            string sob_encomenda,
                                            string sku,
                                            string produto_preco_custo,
                                            int qtd,
                                            string anexo1,
                                            string anexo2,
                                            string pedido_feito,
                                            string problema,
                                            string resolucao,
                                            string obs_problema,
                                            string anotacao_suporte,
                                            string anotacao_expedicao,
                                            string anotacao_compras,
                                            string status,
                                            string custo_envio,
                                            string nf_reposicao,
                                            string transportadora,
                                            string link_rastreio)
        {
            string query = $@"UPDATE TABELA_SUPORTE
                                        SET 
                                            canal = @canal,
                                            nf_e = @nf_e,
                                            nome_cliente = @nome_cliente,
                                            produto = @produto,
                                            sku_produto = @sku_produto,
                                            qtd = @qtd,
                                            problema = @problema,
                                            obs_problema = @obs_problema,
                                            resolucao = @resolucao,
                                            nf_de_reposicao = @nf_de_reposicao,
                                            status = @status,
                                            data_envio = @data_envio,
                                            data_envio_verificado = @data_envio_verificado,
                                            transportadora = @transportadora,
                                            link_rastreio = @link_rastreio,
                                            sob_encomenda = @sob_encomenda,
                                            pedido_feito = @pedido_feito,
                                            data_pedido_feito = @data_pedido_feito,
                                            data_pedido_feito_verificado = @data_pedido_feito_verificado,
                                            obs_adicional_suporte = @obs_adicional_suporte,
                                            obs_adicional_suporte_data = @obs_adicional_suporte_data,
                                            anotacao_suporte_verificado = @anotacao_suporte_verificado,
                                            obs_adicional_logistica = @obs_adicional_logistica,
                                            obs_adicional_logistica_data = @obs_adicional_logistica_data,
                                            anotacao_logistica_verificado = @anotacao_expedicao_verificado,
                                            obs_adicional_compras = @obs_adicional_compras,
                                            obs_adicional_compras_data = @obs_adicional_compras_data,
                                            anotacao_compras_verificado = @anotacao_compras_verificado,
                                            cpf = @cpf,
                                            anexo1 = @anexo1,
                                            anexo2 = @anexo2,
                                            custo_reversa = @custo_reversa,
                                            custo_envio = @custo_envio,
                                            preco_custo_produto = @preco_custo_produto,
                                            nome_usuario = @nome_usuario,
                                            data_faturado = @data_faturado,
                                            data_faturado_verificado = @data_faturado_verificado WHERE id = @id";

            DynamicParameters param = new DynamicParameters();

            param.Add("@id", id_cliente);
            param.Add("@canal", canal);
            param.Add("@nf_e", int.Parse(nf));
            param.Add("@nome_cliente", nome_cliente);
            param.Add("@produto", nome_produto);
            param.Add("@sku_produto", sku);
            param.Add("@qtd", qtd);
            param.Add("@problema", problema);
            param.Add("@obs_problema", obs_problema);
            param.Add("@resolucao", resolucao);
            param.Add("@nf_de_reposicao", nf_reposicao);
            param.Add("@status", status);
            param.Add("@data_envio", data_enviado);
            param.Add("@data_envio_verificado" , status_enviado_verificado);
            param.Add("@transportadora", transportadora);
            param.Add("@link_rastreio", link_rastreio);
            param.Add("@sob_encomenda", sob_encomenda);
            param.Add("@pedido_feito", pedido_feito);
            param.Add("@data_pedido_feito", data_pedido_feito);
            param.Add("@data_pedido_feito_verificado", data_pedido_feito_verificado);
            param.Add("@obs_adicional_suporte", anotacao_suporte);
            param.Add("@obs_adicional_suporte_data", data_anotacao_suporte);
            param.Add("@anotacao_suporte_verificado", anotacao_suporte_verificado);
            param.Add("@obs_adicional_logistica", anotacao_expedicao);
            param.Add("@obs_adicional_logistica_data", data_anotacao_expedicao);
            param.Add("@anotacao_expedicao_verificado", anotacao_expedicao_verificado);
            param.Add("@obs_adicional_compras", anotacao_compras);
            param.Add("@obs_adicional_compras_data", data_anotacao_compras);
            param.Add("@anotacao_compras_verificado", anotacao_compras_verificado);
            param.Add("@cpf", cpf);
            param.Add("@anexo1", anexo1);
            param.Add("@anexo2", anexo2);
            param.Add("@custo_reversa", decimal.Parse(custo_reversa));
            param.Add("@custo_envio", decimal.Parse(custo_envio));
            param.Add("@preco_custo_produto", decimal.Parse(produto_preco_custo));
            param.Add("@nome_usuario", Login.nome_usuario);
            param.Add("@data_faturado", data_faturado);
            param.Add("@data_faturado_verificado", status_faturado_verificado);

            using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
            {
                int alterado = connection.Execute(query, param);
                return alterado;
            }
        }


        public static int AtualizarDadosDoSuporte(string id_cliente,
                                                    decimal custo_reversa,
                                                    string canal,
                                                    int nf,
                                                    string nome_cliente,
                                                    string cpf,
                                                    string nome_produto,
                                                    string sku,
                                                    int qtd,
                                                    string sob_encomenda,
                                                    string anexo1,
                                                    string anexo2,
                                                    string problema,
                                                    string obs_problema,
                                                    string resolucao,
                                                    string anotacao_suporte,
                                                    DateTime data_anotacao_suporte,
                                                    int anotacao_verificado)
        {
            var QueryAtualizarDadosSuporte = @" UPDATE TABELA_SUPORTE SET 
                                                canal = @canal,
                                                nf_e = @nf_e,
                                                nome_cliente = @nome_cliente,
                                                cpf = @cpf,
                                                produto = @produto,
                                                sku_produto = @sku_produto,
                                                qtd = @qtd,
                                                sob_encomenda = @sob_encomenda,
                                                anexo1 = @anexo1,
                                                anexo2 = @anexo2,
                                                problema = @problema,
                                                obs_problema = @obs_problema,
                                                resolucao = @resolucao,                                      
                                                custo_reversa = @custo_reversa,
                                                obs_adicional_suporte = @obs_adicional_suporte,
                                                obs_adicional_suporte_data = @obs_adicional_suporte_data,
                                                anotacao_suporte_verificado = @anotacao_suporte_verificado WHERE id = @id";

            var param = new DynamicParameters();

            param.Add("@id", id_cliente);
            param.Add("@canal", canal);
            param.Add("@nf_e", nf);
            param.Add("@nome_cliente", nome_cliente);
            param.Add("@produto", nome_produto);
            param.Add("@sku_produto", sku);
            param.Add("@qtd", qtd);
            param.Add("@problema", problema);
            param.Add("@obs_problema", obs_problema);
            param.Add("@resolucao", resolucao);
            param.Add("@sob_encomenda", sob_encomenda);
            param.Add("@obs_adicional_suporte", anotacao_suporte);
            param.Add("@obs_adicional_suporte_data", data_anotacao_suporte);
            param.Add("@anotacao_suporte_verificado", anotacao_verificado);
            param.Add("@cpf", cpf);
            param.Add("@anexo1", anexo1);
            param.Add("@anexo2", anexo2);
            param.Add("@custo_reversa", custo_reversa);

            using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
            {
                int atualizado = connection.Execute(QueryAtualizarDadosSuporte, param, commandType: CommandType.Text);
                return atualizado;
            }
        }

        public static int AtualizarDadosDeCompras(  string id_cliente,
                                                    string anotacao,
                                                    string pedido_feito,
                                                    DateTime data_pedido_feito,
                                                    int anotacao_verificado)
        {
            string QueryAtualizarDadosCompras = @"UPDATE TABELA_SUPORTE SET obs_adicional_compras = @anotacao_compras, 
                                                                            pedido_feito = @pedido_feito,
                                                                            data_pedido_feito = @data_pedido_feito,
                                                                            anotacao_compras_verificado = @anotacao_verificado WHERE id = @id";

            var param = new DynamicParameters();
            param.Add("@id", id_cliente);
            param.Add("@anotacao_compras", anotacao);
            param.Add("@pedido_feito", pedido_feito);
            param.Add("@data_pedido_feito", data_pedido_feito);
            param.Add("@anotacao_verificado", anotacao_verificado);

            using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
            {
                int atualizado = connection.Execute(QueryAtualizarDadosCompras, param, commandType: CommandType.Text);
                return atualizado;
            }
        }

        public static int AtualizarDadosDaLogistica(string id_cliente,
                                                    string status,
                                                    int nf_reposicao,
                                                    decimal custo_envio,
                                                    string transportadora,
                                                    DateTime data_envio,
                                                    int data_envio_verificado,
                                                    DateTime data_faturado,
                                                    int data_faturado_verificado,
                                                    string link_rastreio)
        {

            string QueryAtualizarDadosLogistica = @"UPDATE TABELA_SUPORTE SET status = @status, 
                                                                        nf_de_reposicao = @nf_de_reposicao,
                                                                        custo_envio = @custo_envio,
                                                                        transportadora = @transportadora,
                                                                        data_envio = @data_envio,
                                                                        data_envio_verificado = @data_envio_verificado,
                                                                        data_faturado = @data_faturado,
                                                                        data_faturado_verificado = @data_faturado_verificado, link_rastreio = @link_rastreio WHERE id = @id_cliente";

            var param = new DynamicParameters();
            param.Add("@id_cliente", id_cliente );
            param.Add("@status", status);
            param.Add("@nf_de_reposicao" , nf_reposicao);
            param.Add("@custo_envio", custo_envio);
            param.Add("@transportadora", transportadora);
            param.Add("@data_envio", data_envio);
            param.Add("@data_envio_verificado", data_envio_verificado );
            param.Add("@data_faturado", data_faturado);
            param.Add("@data_faturado_verificado", data_faturado_verificado);
            param.Add("@link_rastreio", link_rastreio);

            using(SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
            {
                int atualizado = connection.Execute(QueryAtualizarDadosLogistica, param, commandType: CommandType.Text);
                return atualizado;
            }
        }
    }
}
