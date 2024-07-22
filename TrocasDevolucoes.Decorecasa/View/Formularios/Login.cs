using TrocasDevolucoes.Decorecasa.Controller.Metodos;
using TrocasDevolucoes.Decorecasa.Properties;
using static TrocasDevolucoes.Decorecasa.Model.Modelo.ModelUsuario;

namespace GunaUITestes
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void tb_senha_IconRightClick(object sender, EventArgs e)
        {
            if (tb_senha.PasswordChar == default)
            {
                tb_senha.IconRight = Resources.mostrar_senha;
                tb_senha.PasswordChar = '*';
            }
            else
            {
                tb_senha.PasswordChar = default;
                tb_senha.IconRight = Resources.ocultar_senha;
            }
        }

        public List<UserLogin> entrar;
        public static string permissoes;
        public static string nome_usuario;
        private void btn_entrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_usuario.Text) && !string.IsNullOrEmpty(tb_senha.Text))
            {
                Logar();
            }
            else
            {
                MessageBox.Show("Insira um usuário e senha válidos");
            }
        }

        public void Logar()
        {
            bool log = Autenticacao.Autenticar(tb_usuario.Text, tb_senha.Text, swt_lembrar.Checked);
            if (log is true)
            {
                Loading load = new Loading();
                //DESCOMENTAR PARA AUTENTICACAO
                //permissoes = Autenticacao.entrar[0].permissoes;
                //nome_usuario = Autenticacao.entrar[0].nome;
                load.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario ou senha errados");
            }
        }

        private async void Login_Load_1(object sender, EventArgs e)
        {
            (string usuario, string senha, bool lembrar) = await Autenticacao.LoadCredentials();
            tb_usuario.Text = usuario;
            tb_senha.Text = senha;
            swt_lembrar.Checked = lembrar;
        }
    }
}
