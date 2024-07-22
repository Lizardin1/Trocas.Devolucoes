using Guna.UI2.WinForms;
using GunaUITestes.Controller;
using GunaUITestes.Controller.ListaReposicoes;
using System.Diagnostics;
using TrocasDevolucoes.Decorecasa.Controller.ImageToByte;
using TrocasDevolucoes.Decorecasa.Controller.Metodos;
using TrocasDevolucoes.Decorecasa.Controller.Metodos.RegistrarReposicao;
using TrocasDevolucoes.Decorecasa.Controller.VerificacaoExtensao;
using TrocasDevolucoes.Decorecasa.Model.Modelo;
using TrocasDevolucoes.Decorecasa.Properties;
using TrocasDevolucoes.Decorecasa.View.Formularios;

namespace GunaUITestes
{
    public partial class FormPrincipal : Form
    {
        public static string permissoes = Login.permissoes;
        public static string nome_usuario = Login.nome_usuario;
        public FormPrincipal()
        {
            InitializeComponent();
            PesquisarReposicoes(string.Empty);
            DefinirLbBemVindo();
            BloquearRegistroDeReposicoes();
        }
        public void DefinirLbBemVindo()
        {
            DateTime DataAtual = DateTime.Now;
            int Hora = DataAtual.Hour;

            if (Hora < 12)
            {
                lb_welcome.Text = $"Bom dia, {nome_usuario}";
            }
            else if (Hora > 18)
            {
                lb_welcome.Text = $"Boa noite, {nome_usuario}";
            }
            else
            {
                lb_welcome.Text = $"Boa tarde, {nome_usuario}";
            }
        }
        public void PesquisarReposicoes(string ParamPesquisa)
        {
            DataGridCarregarDados(ListarReposicoes.listReposicoes($" WHERE PEDIDO_EXCLUIDO IS NULL AND STATUS IS NOT NULL  {ParamPesquisa}"), grd_reposicoes_todas, tab_page_todos);
            DataGridCarregarDados(ListarReposicoes.listReposicoes($" WHERE PEDIDO_EXCLUIDO IS NULL AND STATUS = 'PENDENTE' {ParamPesquisa}"), grid_reposicoes_pendentes, tab_page_pendentes);
            DataGridCarregarDados(ListarReposicoes.listReposicoes($" WHERE PEDIDO_EXCLUIDO IS NULL AND STATUS = 'FATURADO' {ParamPesquisa}"), grid_reposicoes_faturadas, tab_page_faturados);
            DataGridCarregarDados(ListarReposicoes.listReposicoes($" WHERE PEDIDO_EXCLUIDO IS NULL AND STATUS = 'ENVIADO'  {ParamPesquisa}"), grid_reposicoes_enviadas, tab_page_enviados);
            DataGridCarregarDados(ListarReposicoes.listReposicoes($" WHERE PEDIDO_EXCLUIDO IS NULL AND STATUS <> 'ENVIADO' AND CONVERT(date, data_limite_envio, 103) < '{DateTime.Now.ToString("yyyy-MM-dd")}' {ParamPesquisa}"), grid_reposicoes_no_prazo, tab_page_no_prazo);

        }
        public void DataGridCarregarDados(List<repoModel> listReposicao, Guna2DataGridView DataGridListReposicoes, TabPage tabPage)
        {
            tabPage.Text = tabPage.Tag + " " + listReposicao.Count;
            DataGridListReposicoes.Rows.Clear();
            if (listReposicao.Count <= 0) return;
            if (listReposicao.Count == 1)
            {
                DataGridListReposicoes.Rows.Add(1);
            }
            else
            {
                DataGridListReposicoes.Rows.Add(listReposicao.Count - 1);
            }
            for (int i = 0; i < 50; i++)
            {
                string[] data_1 = listReposicao[i].data_registro.ToString().Split(' ');
                string[] data_2 = listReposicao[i].data_limite_envio.ToString().Split(' ');

                if (canalParaImagem.ContainsKey(listReposicao[i].canal))
                {
                    DataGridListReposicoes.Rows[i].Cells[0].Value = canalParaImagem[listReposicao[i].canal];
                }
                DataGridListReposicoes.Rows[i].Cells[1].Value = data_1[0];
                DataGridListReposicoes.Rows[i].Cells[2].Value = data_2[0];
                DataGridListReposicoes.Rows[i].Cells[3].Value = listReposicao[1].nf_e;
                DataGridListReposicoes.Rows[i].Cells[4].Value = "Gustavo Lizardo";
                DataGridListReposicoes.Rows[i].Cells[5].Value = listReposicao[1].produto;
                DataGridListReposicoes.Rows[i].Cells[6].Value = listReposicao[1].qtd;
                DataGridListReposicoes.Rows[i].Cells[7].Value = listReposicao[1].status;
                DataGridListReposicoes.Rows[i].Cells[8].Value = listReposicao[1].sob_encomenda;
                DataGridListReposicoes.Rows[i].Cells[9].Value = listReposicao[1].pedido_feito;
                DataGridListReposicoes.Rows[i].Tag = listReposicao[i].id + "-" + listReposicao[i].nome_cliente;
            }
        }
        Dictionary<string, Image> canalParaImagem = new Dictionary<string, Image>
        {
            { "MERCADO LIVRE", Resources.meli },
            { "SITE", Resources.decore },
            { "CAMICADO", Resources.camicado },
            { "OLIST", Resources.olist },
            { "MADEIRA", Resources.madeira},
            { "MAGAZINE LUIZA", Resources.magalu },
            { "AMAZON", Resources.amazon },
            { "SHEIN", Resources.icone_shein },
            { "SHOPEE", Resources.shopee }
        };
        int MaxTabPages = 14;
        private void grd_reposicoes_todas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] Tag = grd_reposicoes_todas.Rows[e.RowIndex].Tag.ToString().Split("-");
                CriarTabPageDetalhesCliente(Tag);
            }
            catch (Exception ex)
            {

            }
        }
        private void grid_reposicoes_pendentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] Tag = grid_reposicoes_pendentes.Rows[e.RowIndex].Tag.ToString().Split("-");
                CriarTabPageDetalhesCliente(Tag);
            }
            catch (Exception ex)
            {

            }
        }
        private void grid_reposicoes_faturadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] Tag = grid_reposicoes_faturadas.Rows[e.RowIndex].Tag.ToString().Split("-");
                CriarTabPageDetalhesCliente(Tag);
            }
            catch (Exception ex)
            {

            }
        }
        private void grid_reposicoes_enviadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] Tag = grid_reposicoes_enviadas.Rows[e.RowIndex].Tag.ToString().Split("-");
                CriarTabPageDetalhesCliente(Tag);
            }
            catch (Exception ex)
            {

            }
        }
        private void grid_reposicoes_no_prazo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] Tag = grid_reposicoes_no_prazo.Rows[e.RowIndex].Tag.ToString().Split("-");
                CriarTabPageDetalhesCliente(Tag);
            }
            catch (Exception ex)
            {

            }
        }
        private void tb_cpf_cnpj_TextChanged(object sender, EventArgs e)
        {
            tb_cpf_cnpj.TextChanged -= tb_cpf_cnpj_TextChanged;

            string text = FormatarCpfCpnj.CpfCpnjFormat(tb_cpf_cnpj.Text);

            tb_cpf_cnpj.Text = text;
            tb_cpf_cnpj.SelectionStart = tb_cpf_cnpj.Text.Length;
            tb_cpf_cnpj.SelectionLength = 0;
            tb_cpf_cnpj.TextChanged += tb_cpf_cnpj_TextChanged;
        }
        private void BloquearRegistroDeReposicoes()
        {
            label_permissao.Text = "Registrar uma nova reposição";
            label_permissao.Visible = true;
            if (permissoes == "suporte" || permissoes == "visitante") return;
            label_permissao.Text = "Você não permissão para utilizar está página, caso precise realizar um registro entre em contato com o suporte.";

            btn_cadastrar_reposicao.Enabled = false;
            label_permissao.Visible = true;
            foreach (Control control in panel_registrar.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Enabled = false;
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.Enabled = false;
                }
                if (control is Guna2ToggleSwitch swt)
                {
                    swt.Enabled = false;
                }
            }
            foreach (Control control in gpbox_anexos.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Enabled = false;
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.Enabled = false;
                }
            }
            foreach (Control control in gpbox_anotacao.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Enabled = false;
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.Enabled = false;
                }
            }
            foreach (Control control in gpbox_cliente.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Enabled = false;
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.Enabled = false;
                }
            }
            foreach (Control control in gpbox_descricao.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Enabled = false;
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.Enabled = false;
                }
            }
            foreach (Control control in gpbox_produto.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Enabled = false;
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.Enabled = false;
                }
                if (control is Guna2ToggleSwitch swt)
                {
                    swt.Enabled = false;
                }
            }
        }
        public bool iconLimparBuscar = false;
        private void tb_pesquisar_IconRightClick(object sender, EventArgs e)
        {
            if (!iconLimparBuscar)
            {
                tb_pesquisar.IconRight = Resources.x;
                iconLimparBuscar = true;
                string TbPesquisarConsulta = $"AND (NOME_CLIENTE LIKE '%{tb_pesquisar.Text}%' OR NF_E LIKE '%{tb_pesquisar.Text}%' OR CPF LIKE '%{tb_pesquisar.Text}%')";
                PesquisarReposicoes(TbPesquisarConsulta);
            }
            else
            {
                tb_pesquisar.Clear();
                tb_pesquisar.IconRight = Resources.loupe__1_;
                iconLimparBuscar = false;
                PesquisarReposicoes(string.Empty);
            }
        }
        private void tb_pesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string TbPesquisarConsulta = $"AND (NOME_CLIENTE LIKE '%{tb_pesquisar.Text}%' OR NF_E LIKE '%{tb_pesquisar.Text}%' OR CPF LIKE '%{tb_pesquisar.Text}%')";

                if (!iconLimparBuscar)
                {
                    tb_pesquisar.IconRight = Resources.x;
                    iconLimparBuscar = true;
                    PesquisarReposicoes(TbPesquisarConsulta);
                }
                else if (iconLimparBuscar && !string.IsNullOrEmpty(tb_pesquisar.Text))
                {
                    iconLimparBuscar = true;
                    PesquisarReposicoes(TbPesquisarConsulta);
                }
                else
                {
                    tb_pesquisar.Clear();
                    tb_pesquisar.IconRight = Resources.loupe__1_;
                    iconLimparBuscar = false;
                    PesquisarReposicoes(string.Empty);
                }
            }
        }
        private void btn_cadastrar_reposicao_Click(object sender, EventArgs e)
        {
            int dias = cb_urgencia.Text == "1" ? 2 : cb_urgencia.Text == "2" ? 3 : cb_urgencia.Text == "3" ? 4 : 2;
            DateTime data_limite_envio = DateTime.Now.AddDays(dias);


            if (string.IsNullOrEmpty(tb_nome.Text))
            {
                tb_nome.PlaceholderText = "Campo obrigatório";
                tb_nome.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_cpf_cnpj.Text))
            {
                tb_cpf_cnpj.Focus();
                return;
            }
            string canal = cb_canal_venda.Text;
            string nf = tb_nf_e.Text;
            string urgencia = cb_urgencia.Text; //tratar
            decimal custo_reversa = !string.IsNullOrEmpty(tb_custo_reversa.Text) ? decimal.Parse(tb_custo_reversa.Text) : 0;
            string nome_cliente = tb_nome.Text;
            string cpf = tb_cpf_cnpj.Text;
            string nome_produto = tb_nome_produto.Text;
            string sku = tb_produto_sku.Text;
            int qtd = !string.IsNullOrEmpty(tb_produto_qtd.Text) ? int.Parse(tb_produto_qtd.Text) : 0;
            bool sob_encomenda = swt_sob_encomenda.Checked;
            bool reenvio = swt_reenvio.Checked;
            string anexo1 = tb_anexo1.Text;
            string anexo2 = tb_anexo2.Text;
            string anotacao = tb_anotacoes.Text;
            string problema = cb_problema.Text;
            string resolucao = tb_resolucao.Text;
            string obs_problema = tb_obs_problema.Text;
            byte[] image1 = pb_anexo1.Image != null ? ConverterImagemByte.ImageToByteArray(pb_anexo1.Image) : new byte[0];
            byte[] image2 = pb_anexo2.Image != null ? ConverterImagemByte.ImageToByteArray(pb_anexo2.Image) : new byte[0];



            int cliente_registrado = Registrar.RegistrarRepocicao(canal,
                                                                 nf,
                                                                 urgencia,
                                                                 custo_reversa,
                                                                 nome_cliente,
                                                                 cpf,
                                                                 nome_produto,
                                                                 sku,
                                                                 qtd,
                                                                 sob_encomenda,
                                                                 reenvio,
                                                                 anexo1,
                                                                 anexo2,
                                                                 anotacao,
                                                                 problema,
                                                                 resolucao,
                                                                 obs_problema,
                                                                 nome_usuario,
                                                                 data_limite_envio,
                                                                 image1,
                                                                 image2);

            if (cliente_registrado > 0)
            {
                notifyIcon1.ShowBalloonTip(1, "Sucesso!", $"Reposição de {nome_cliente} registrado com sucesso", ToolTipIcon.Info);
                TextBoxClear();
            }
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            PesquisarReposicoes(string.Empty);
            tb_pesquisar.Clear();
            tb_pesquisar.IconRight = Resources.loupe__2_;
        }
        private void tab_control_principal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = tab_control_principal.SelectedIndex;
            if (selectedIndex != 0 && selectedIndex != 1 && selectedIndex != 2)
            {
                TabPage selectedTab = tab_control_principal.TabPages[selectedIndex];
                tab_control_principal.TabPages.Remove(selectedTab);
                tab_control_principal.SelectedTab = tabPage1;
            }
        }
        private void CriarTabPageDetalhesCliente(string[] Tag)
        {
            if (tab_control_principal.TabPages.Count < MaxTabPages)
            {
                try
                {
                    DetalhesRepo.id_cliente = Tag[0];
                    DetalhesRepo userControlDetalhesRepo = new DetalhesRepo();
                    TabPage TabPageDetalhesReposicao = new TabPage();
                    TabPageDetalhesReposicao.Controls.Add(userControlDetalhesRepo);
                    TabPageDetalhesReposicao.Text = Tag[1].ToUpper();
                    TabPageDetalhesReposicao.BackColor = Color.FromArgb(33, 33, 33);
                    tab_control_principal.Controls.Add(TabPageDetalhesReposicao);
                    tab_control_principal.SelectedTab = TabPageDetalhesReposicao;
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1, "Limite atingido", "Feche algumas abas antes de abrir outras", ToolTipIcon.Info);
            }
        }
        private void TextBoxClear()
        {
            foreach (Control control in panel_registrar.Controls)
            {
                if(control is Guna2PictureBox pbbox)
                {
                    pbbox.Image = null;
                }
                if (control is Guna2TextBox tbox)
                {
                    tbox.Clear();
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.SelectedIndex = 0;
                }
            }
            foreach (Control control in gpbox_anexos.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Clear();
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.SelectedIndex = 0;
                }
            }
            foreach (Control control in gpbox_anotacao.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Clear();
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.SelectedIndex = 0;
                }
            }
            foreach (Control control in gpbox_cliente.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Clear();
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.SelectedIndex = 0;
                }
            }
            foreach (Control control in gpbox_descricao.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Clear();
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.SelectedIndex = 0;
                }
            }
            foreach (Control control in gpbox_produto.Controls)
            {
                if (control is Guna2TextBox tbox)
                {
                    tbox.Clear();
                }
                if (control is Guna2ComboBox cbox)
                {
                    cbox.SelectedIndex = 0;
                }
            }
        }
        private void tb_produto_qtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }
        private void tb_nf_e_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }
        private void tb_custo_reversa_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatDecimal.DecNumber(sender, e);
        }
        private void link_patch_notes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = @"https://decorecasa499-my.sharepoint.com/:w:/g/personal/gustavolizard_lojadecorecasa_com_br/EfOzfpjC3L5DmiEzZeyt_WYB_YgclAhvzgDxrZl3H1yFXA?e=EmuRjM";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        private void link_ajuda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = @"https://wa.me/5532999138505?text=Preciso+de+ajuda+com+o+app+do+suporte!";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        private void tb_anexo1_IconRightClick(object sender, EventArgs e)
        {
            if (abrir_pasta.ShowDialog() == DialogResult.OK)
            {
                string file_path = abrir_pasta.FileName;

                if (VerificarVideoImagem.IsImageFile(file_path))
                {
                    pb_anexo1.Image = Image.FromFile(file_path);
                    tb_anexo1.Text = Path.GetFileName(file_path);
                }
                else
                {
                    MessageBox.Show("Tipo de arquivo não suportado.");
                }
            }
        }
        private void tb_anexo2_IconRightClick(object sender, EventArgs e)
        {
            if (abrir_pasta.ShowDialog() == DialogResult.OK)
            {
                string file_path = abrir_pasta.FileName;

                if (VerificarVideoImagem.IsImageFile(file_path))
                {
                    pb_anexo2.Image = Image.FromFile(file_path);
                    tb_anexo2.Text = Path.GetFileName(file_path);
                }
                else
                {
                    MessageBox.Show("Tipo de arquivo não suportado.");
                }
            }
        }
    }
}
