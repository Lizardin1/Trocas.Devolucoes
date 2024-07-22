using System.ComponentModel.DataAnnotations.Schema;

namespace TrocasDevolucoes.Decorecasa.Model.Modelo
{
    [Table("Tabela_Suporte")]
    public class repoModel
    {
        public int id { get; set; }
        public DateTime data_registro { get; set; }
        public string canal { get; set; }
        public int nf_e { get; set; }
        public string nome_cliente { get; set; }
        public string produto { get; set; }
        public string sku_produto { get; set; }
        public int qtd { get; set; }
        public string problema { get; set; }
        public string obs_problema { get; set; }
        public string resolucao { get; set; }
        public DateTime data_limite_envio { get; set; }
        public int nf_de_reposicao { get; set; }
        public string status { get; set; }
        public DateTime data_envio { get; set; }
        public int data_envio_verificado { get; set; }
        public DateTime data_faturado { get; set; }
        public int data_faturado_verificado { get; set; }
        public string transportadora { get; set; }
        public string link_rastreio { get; set; }
        public string sob_encomenda { get; set; }
        public string pedido_feito { get; set; }
        public DateTime data_pedido_feito { get; set; }
        public int data_pedido_feito_verificado { get; set; }
        public string obs_adicional_suporte { get; set; }
        public DateTime obs_adicional_suporte_data { get; set; }
        public int anotacao_suporte_verificado { get; set; }
        public string obs_adicional_logistica { get; set; }
        public DateTime obs_adicional_logistica_data { get; set; }
        public int anotacao_logistica_verificado { get; set; }
        public string obs_adicional_compras { get; set; }
        public DateTime obs_adicional_compras_data { get; set; }
        public int anotacao_compras_verificado { get; set; }
        public string cpf { get; set; }
        public string anexo1 { get; set; }
        public string anexo2 { get; set; }
        public decimal custo_reversa { get; set; }
        public decimal custo_envio { get; set; }
        public decimal preco_custo_produto { get; set; }
        public string nome_usuario { get; set; }
        public string pedido_excluido { get; set; }
        public string anexo3 { get; set; }
        public int notificacao_vizu_suporte { get; set; }
        public int notificacao_vizu_compras { get; set; }
        public int notificacao_vizu_logistica { get; set; }
        public byte[] image_byte1 { get; set; }
        public byte[] image_byte2 { get; set; }
    }
}
