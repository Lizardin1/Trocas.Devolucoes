using Dapper;
using Guna.UI2.WinForms;
using GunaUITestes;
using System.Data;
using System.Data.SqlClient;
using TrocasDevolucoes.Decorecasa.Controller.Metodos;
using TrocasDevolucoes.Decorecasa.Controller.Metodos.EditarReposicao;
using TrocasDevolucoes.Decorecasa.Controller.VerificacaoExtensao;
using TrocasDevolucoes.Decorecasa.Model.Modelo;

namespace TrocasDevolucoes.Decorecasa.View.Formularios
{
    public partial class DetalhesRepo : UserControl
    {
        public static string id_cliente { get; set; }
        public static string permissoes = Login.permissoes;
        public static List<repoModel> repoModel = new List<repoModel>();
        public DetalhesRepo()
        {
            InitializeComponent();
            BucarCliente();
            ExibirDados();
        }
        private void BucarCliente()
        {
            if (permissoes == "visitante")
            {
                btn_editar.Visible = false;
            }
            using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("@ID", id_cliente);
                repoModel = connection.Query<repoModel>("SELECT * FROM TABELA_SUPORTE WITH (INDEX(PK_TABELA_SUPORTE_1)) WHERE ID = @ID", param, commandType: CommandType.Text).AsList();
            }
        }
        private void ExibirDados()
        {
            tb_data_registrado.Text = repoModel[0].data_registro.ToString("dd/MM/yyyy HH:mm");
            cb_canal_venda.Text = repoModel[0].canal;
            tb_nf.Text = repoModel[0].nf_e.ToString();
            tb_custo_reversa.Text = repoModel[0].custo_reversa.ToString();
            tb_nome.Text = repoModel[0].nome_cliente;
            tb_cpf_cnpj.Text = repoModel[0].cpf;
            tb_nome_produto.Text = repoModel[0].produto;
            tb_sob_encomenda.Text = repoModel[0].sob_encomenda;
            swt_pedido_feito.Checked = repoModel[0].pedido_feito == "Sim" ? true : false;
            tb_produto_sku.Text = repoModel[0].sku_produto;
            tb_preco_custo.Text = repoModel[0].preco_custo_produto.ToString();
            tb_data_pedido_feito.Text = repoModel[0].data_pedido_feito.ToString("dd/MM/yyyy HH:mm");
            tb_produto_qtd.Text = repoModel[0].qtd.ToString();
            tb_anexo1.Text = repoModel[0].anexo1;
            tb_anexo2.Text = repoModel[0].anexo2;
            cb_problema.Text = repoModel[0].problema;
            tb_resolucao.Text = repoModel[0].resolucao;
            tb_obs_problema.Text = repoModel[0].obs_problema;
            tb_anotacao_suporte.Text = repoModel[0].obs_adicional_suporte;
            tb_data_anotacao_suporte.Text = repoModel[0].obs_adicional_suporte_data.ToString("dd/MM/yyyy HH:mm");
            tb_anotacao_expedicao.Text = repoModel[0].obs_adicional_logistica;
            tb_data_anotacao_expedicao.Text = repoModel[0].obs_adicional_logistica_data.ToString("dd/MM/yyyy HH:mm");
            tb_anotacao_compras.Text = repoModel[0].obs_adicional_compras;
            tb_data_anotacao_compras.Text = repoModel[0].obs_adicional_compras_data.ToString("dd/MM/yyyy HH:mm");
            cb_status_envio.Text = repoModel[0].status;
            tb_data_faturado.Text = repoModel[0].data_faturado.ToString("dd/MM/yyyy HH:mm");
            tb_data_envio.Text = repoModel[0].data_envio.ToString("dd/MM/yyyy HH:mm");
            tb_nf_reposicao.Text = repoModel[0].nf_de_reposicao.ToString();
            tb_custo_envio.Text = repoModel[0].custo_envio.ToString();
            cb_transportadora.Text = repoModel[0].transportadora;
            tb_link_rastreio.Text = repoModel[0].link_rastreio;
            lb_detalhes_repo.Text = "Detalhes da reposição de " + repoModel[0].nome_cliente;
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (repoModel[0].status == "Sem reenvio") return;
            HabilitarEdicao();
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DesabilitarEdicao();
        }
        private void HabilitarEdicao()
        {
            btn_editar.Visible = false;
            btn_confirmar.Location = btn_editar.Location;
            btn_cancelar.Location = new Point(946, 700);
            btn_cancelar.Visible = true;
            btn_confirmar.Visible = true;
            if (permissoes == "suporte")
            {
                Guna2TextBox[] tboxList = { tb_nf, tb_custo_reversa, tb_nome, tb_cpf_cnpj, tb_nome_produto, tb_produto_sku, tb_produto_qtd, tb_anexo1, tb_anexo2, tb_resolucao, tb_obs_problema, tb_anotacao_suporte };
                Guna2ComboBox[] cboxList = { cb_canal_venda, cb_problema };
                foreach (Guna2TextBox tbox in tboxList)
                {
                    tbox.ReadOnly = false;
                }
                foreach (Guna2ComboBox cbox in cboxList)
                {
                    cbox.Enabled = true;
                    cbox.BorderColor = Color.FromArgb(99, 99, 99);
                }
            }
            if (permissoes == "compras")
            {
                if (repoModel[0].pedido_feito != "Sim")
                {
                    swt_pedido_feito.Enabled = true;
                }
                tb_anotacao_compras.Enabled = true;
                tb_anotacao_compras.BorderColor = Color.FromArgb(99, 99, 99);
            }
            if (permissoes == "logistica")
            {
                Guna2TextBox[] tboxList = { tb_nf_reposicao, tb_custo_envio, tb_anotacao_expedicao };
                Guna2ComboBox[] cboxList = { cb_transportadora, cb_status_envio };

                if (repoModel[0].status != "Enviado")
                {
                    foreach (Guna2TextBox tbox in tboxList)
                    {
                        tbox.ReadOnly = false;
                        tbox.BorderColor = Color.FromArgb(99, 99, 99);
                    }
                    foreach (Guna2ComboBox cbox in cboxList)
                    {
                        cbox.Enabled = true;
                        cbox.BorderColor = Color.FromArgb(99, 99, 99);
                    }
                }
            }
        }
        private void DesabilitarEdicao()
        {
            btn_editar.Visible = true;
            btn_cancelar.Visible = false;
            btn_confirmar.Visible = false;
            if (permissoes == "suporte")
            {
                Guna2TextBox[] tboxList = { tb_nf, tb_custo_reversa, tb_nome, tb_cpf_cnpj, tb_nome_produto, tb_produto_sku, tb_produto_qtd, tb_anexo1, tb_anexo2, tb_resolucao, tb_obs_problema, tb_anotacao_suporte };
                Guna2ComboBox[] cboxList = { cb_canal_venda, cb_problema };
                foreach (Guna2TextBox tbox in tboxList)
                {
                    tb_cpf_cnpj.ReadOnly = true;
                    tbox.Enabled = false;
                }
                foreach (Guna2ComboBox cbox in cboxList)
                {
                    cbox.Enabled = false;
                    cbox.BorderColor = Color.FromArgb(55, 55, 55);
                }
            }
            if (permissoes == "compras")
            {
                swt_pedido_feito.Enabled = false;
                tb_anotacao_compras.Enabled = false;
            }
            if (permissoes == "logistica")
            {
                Guna2TextBox[] tboxList = { tb_nf_reposicao, tb_custo_envio, tb_anotacao_expedicao };
                Guna2ComboBox[] cboxList = { cb_transportadora, cb_status_envio };
                foreach (Guna2TextBox tbox in tboxList)
                {
                    tbox.Enabled = false;
                }
                foreach (Guna2ComboBox cbox in cboxList)
                {
                    cbox.Enabled = false;
                    cbox.BorderColor = Color.FromArgb(55, 55, 55);
                }
            }
        }
        private void tb_produto_qtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            if (permissoes == "suporte")
            {
                ValoresParaAtualizarSuporte();
                return;
            }
            if (permissoes == "compras")
            {
                ValoresParaAtualizarCompras();
                return;
            }
            if (permissoes == "logistica")
            {
                ValoresParaAtualizarExpedicao();
                return;
            }
        }
        private void ValoresParaAtualizarSuporte()
        {
            decimal custo_reversa = !string.IsNullOrEmpty(tb_custo_reversa.Text) ? decimal.Parse(tb_custo_reversa.Text) : 0;
            string canal = cb_canal_venda.Text;
            int nf = !string.IsNullOrEmpty(tb_nf.Text) ? int.Parse(tb_nf.Text) : 0;
            string nome_cliente = tb_nome.Text;
            string cpf = tb_cpf_cnpj.Text;
            string nome_produto = tb_nome_produto.Text;
            string sku = tb_produto_sku.Text;
            int qtd = !string.IsNullOrEmpty(tb_produto_qtd.Text) ? int.Parse(tb_produto_qtd.Text) : 0;
            string sob_encomenda = tb_sob_encomenda.Text;
            string anexo1 = tb_anexo1.Text;
            string anexo2 = tb_anexo2.Text;
            string problema = cb_problema.Text;
            string obs_problema = tb_obs_problema.Text;
            string resolucao = tb_resolucao.Text;
            string anotacao_suporte = tb_anotacao_suporte.Text;
            DateTime data_anotacao_suporte;
            int anotacao_verificado = 0;

            if (!string.IsNullOrEmpty(tb_anotacao_suporte.Text) && repoModel[0].anotacao_suporte_verificado != 1)
            {
                data_anotacao_suporte = DateTime.Now;
                anotacao_verificado = 1;
            }
            else
            {
                data_anotacao_suporte = DateTime.Parse(tb_data_anotacao_suporte.Text);
            }

            int atualizado = UpdateReposicao.AtualizarDadosDoSuporte(id_cliente,
                                                                        custo_reversa,
                                                                        canal,
                                                                        nf,
                                                                        nome_cliente,
                                                                        cpf,
                                                                        nome_produto,
                                                                        sku,
                                                                        qtd,
                                                                        sob_encomenda,
                                                                        anexo1,
                                                                        anexo2,
                                                                        problema,
                                                                        obs_problema,
                                                                        resolucao,
                                                                        anotacao_suporte,
                                                                        data_anotacao_suporte,
                                                                        anotacao_verificado);

            if (atualizado > 0)
            {
                notifyIcon1.ShowBalloonTip(1, "Sucesso", $"Reposicao de {nome_cliente} Atualizada com sucesso", ToolTipIcon.Info);
                DesabilitarEdicao();
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1, "Erro", $"Erro ao atualizar reposicao de {nome_cliente} ", ToolTipIcon.Error);
            }

        }
        private void ValoresParaAtualizarCompras()
        {
            string anotacao_compras = tb_anotacao_compras.Text;
            string pedido_feito = swt_pedido_feito.Checked ? "Sim" : "Não";
            DateTime data_anotacao_compras;
            int anotacao_verificado = 0;

            if (!string.IsNullOrEmpty(tb_anotacao_compras.Text) && repoModel[0].anotacao_compras_verificado != 1)
            {
                data_anotacao_compras = DateTime.Now;
                anotacao_verificado = 1;
            }
            else
            {
                data_anotacao_compras = DateTime.Parse(tb_data_anotacao_compras.Text);
            }

            int atualizado = UpdateReposicao.AtualizarDadosDeCompras(id_cliente,
                                                                    anotacao_compras,
                                                                    pedido_feito,
                                                                    data_anotacao_compras,
                                                                    anotacao_verificado);


            if (atualizado > 0)
            {
                notifyIcon1.ShowBalloonTip(1, "Sucesso", $"Reposicao de {repoModel[0].nome_cliente} Atualizada com sucesso", ToolTipIcon.Info);
                DesabilitarEdicao();
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1, "Erro", $"Erro ao atualizar reposicao de {repoModel[0].nome_cliente} ", ToolTipIcon.Error);
            }
        }
        private void ValoresParaAtualizarExpedicao()
        {
            string status = cb_status_envio.Text;
            int nf_reposicao = int.Parse(tb_nf_reposicao.Text);
            decimal custo_envio = string.IsNullOrEmpty(tb_custo_envio.Text) ? 0 : decimal.Parse(tb_custo_envio.Text);
            string transporadora = cb_transportadora.Text;
            int data_envio_verificado = 0;
            int data_faturado_verificado = 0;
            string link_rastreio = tb_link_rastreio.Text;
            DateTime data_envio;
            DateTime data_faturado;

            if (cb_status_envio.Text == "Faturado" && repoModel[0].data_faturado_verificado != 1)
            {
                data_faturado = DateTime.Now;
                data_faturado_verificado = 1;
            }
            else
            {
                data_faturado = DateTime.Parse(tb_data_faturado.Text);
            }

            if (cb_status_envio.Text == "Enviado" && repoModel[0].data_envio_verificado != 1)
            {
                data_envio = DateTime.Now;
                data_envio_verificado = 1;
            }
            else
            {
                data_envio = DateTime.Parse(tb_data_envio.Text);
            }

            int atualizado = UpdateReposicao.AtualizarDadosDaLogistica(id_cliente,
                                                                        status,
                                                                        nf_reposicao,
                                                                        custo_envio,
                                                                        transporadora,
                                                                        data_envio,
                                                                        data_envio_verificado,
                                                                        data_faturado,
                                                                        data_faturado_verificado,
                                                                        link_rastreio);

            if (atualizado > 0)
            {
                notifyIcon1.ShowBalloonTip(1, "Sucesso", $"Reposicao de {repoModel[0].nome_cliente} Atualizada com sucesso", ToolTipIcon.Info);
                DesabilitarEdicao();
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1, "Erro", $"Erro ao atualizar reposicao de {repoModel[0].nome_cliente} ", ToolTipIcon.Error);
            }
        }
        private void cb_transportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> Transportadoras = new Dictionary<string, string>()
            {
                { "Total Express","https://tracking.totalexpress.com.br/buscar-pedido?_gl=1*y3tg0t*_ga*MzQzNjgyNzI4LjE3MTM5ODAwMzY.*_ga_8TZL3TR04J*MTcxMzk4MDA0MC4xLjEuMTcxMzk4MDA0MC42MC4wLjA." },
                { "JadLog", "https://www.jadlog.com.br/tracking"},
                { "J&T Express",$"https://www.jtexpress.com.br/trajectoryQuery?waybillNo=NUMERO_PEDIDO&type=0&cpf=CPF_CLIENTE" },
                { "VHZ",  "http://www.vhztransporte.com.br/rastreamento.php"},
                { "Correios", "https://rastreamento.correios.com.br/app/index.php" },
                { "JAMEF",  "https://www.jamef.com.br/#acompanhamento-da-carga"}
            };

            if (Transportadoras.ContainsKey(cb_transportadora.Text))
            {
                tb_link_rastreio.Text = Transportadoras[cb_transportadora.Text];
            }
        }
        private void tb_nf_reposicao_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }

        private void tb_custo_envio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }

        private void tb_custo_reversa_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }

        private void btn_anexos_Click(object sender, EventArgs e)
        {            
            ImagemForm img_form = new ImagemForm();
            img_form.ShowDialog();
        }
    }
}
