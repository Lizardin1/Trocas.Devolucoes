using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TrocasDevolucoes.Decorecasa.Controller.Metodos.RegistrarReposicao
{
    public class Registrar
    {
        public static int registrado;
        public static int RegistrarRepocicao(   string canal,
                                                string nf,
                                                string urgencia,
                                                decimal custo_reversa,
                                                string nome_cliente,
                                                string cpf,
                                                string nome_produto,
                                                string sku,
                                                int qtd,
                                                bool sob_encomenda,
                                                bool reenvio,
                                                string anexo1,
                                                string anexo2,
                                                string anotacao,
                                                string problema,
                                                string resolucao,
                                                string obs_problema,
                                                string nome_usuario,
                                                DateTime data_limite_envio,
                                                byte[] image1,
                                                byte[] image2)
        {
            string query = (@"Insert into Tabela_suporte (  data_registro, 
                                                            canal, 
                                                            nf_e, 
                                                            nome_cliente,
                                                            cpf,
                                                            produto, 
                                                            qtd, 
                                                            problema,
                                                            obs_problema, 
                                                            resolucao,
                                                            sob_encomenda,
                                                            data_limite_envio,
                                                            status,
                                                            obs_adicional_suporte_data, 
                                                            obs_adicional_logistica_data, 
                                                            obs_adicional_compras_data,
                                                            sku_produto,
                                                            nome_usuario,
                                                            data_envio,
                                                            data_faturado,
                                                            data_pedido_feito,
                                                            custo_reversa,
                                                            anexo1,
                                                            anexo2,
                                                            obs_adicional_suporte,
                                                            image_byte1,
                                                            image_byte2
                                                            ) 
                                                            values 
                                                            (@date_registro,
                                                            @canal, 
                                                            @nf_e, 
                                                            @nome_cliente,
                                                            @cpf,
                                                            @produto, 
                                                            @qtd,
                                                            @problema, 
                                                            @obs_problema, 
                                                            @resolucao,
                                                            @sob_encomenda,
                                                            @data_limite_envio,
                                                            @status,
                                                            @obs_adicional_suporte_data, 
                                                            @obs_adicional_logistica_data,
                                                            @obs_adicional_compras_data,
                                                            @sku,
                                                            @nome_usuario,
                                                            @data_envio,
                                                            @data_faturado,
                                                            @data_pedido_feito,
                                                            @custo_reversa,
                                                            @anexo1,
                                                            @anexo2,
                                                            @obs_adicional_suporte,
                                                            @image_byte1,
                                                            @image_byte2)");

            DateTime dataPadrao = new DateTime(1753, 1, 1, 12, 0, 0);
   

            DynamicParameters param = new DynamicParameters();
            param.Add("@date_registro", DateTime.Now);
            param.Add("@canal", canal);
            param.Add("@nf_e", nf);
            param.Add("@nome_cliente", nome_cliente);
            param.Add("@produto", nome_produto);
            param.Add("@cpf", cpf);
            param.Add("@sku", sku);
            param.Add("@qtd", qtd);
            param.Add("@problema", problema);
            param.Add("@obs_problema", obs_problema);
            param.Add("@resolucao", resolucao);
            param.Add("@sob_encomenda", sob_encomenda == true ? "Sim" : "Não");
            param.Add("@data_limite_envio", data_limite_envio);
            param.Add("@status", reenvio == true ? "Pendente" : "Sem reenvio");
            param.Add("@obs_adicional_compras_data", dataPadrao);
            param.Add("@obs_adicional_logistica_data", dataPadrao);
            param.Add("@obs_adicional_suporte_data", !string.IsNullOrEmpty(anotacao) ? DateTime.Now : dataPadrao);
            param.Add("@nome_usuario", nome_usuario);
            param.Add("@data_envio", dataPadrao);
            param.Add("@data_faturado", dataPadrao);
            param.Add("@data_pedido_feito", dataPadrao);
            param.Add("@custo_reversa", custo_reversa);
            param.Add("@obs_adicional_suporte", anotacao);
            param.Add("@anexo1", anexo1);
            param.Add("@anexo2", anexo2);
            param.Add("@image_byte1", image1);
            param.Add("@image_byte2", image2);

            using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
            {
                registrado = connection.Execute(query, param, commandType: CommandType.Text);
            }
            return registrado;
        }
    }
}
