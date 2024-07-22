using Dapper;
using Guna.UI2.WinForms;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using TrocasDevolucoes.Decorecasa.Model.Modelo;

namespace TrocasDevolucoes.Decorecasa.Controller.Metodos
{
    public  class Autenticacao
    {
        public static void SaveCredentials(string usuario, string senha, bool lembrar)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (lembrar)
            {
                config.AppSettings.Settings["Username"].Value = usuario;
                config.AppSettings.Settings["Password"].Value = senha;
                config.AppSettings.Settings["RememberMe"].Value = "true";
            }
            else
            {
                config.AppSettings.Settings["Username"].Value = string.Empty;
                config.AppSettings.Settings["Password"].Value = string.Empty;
                config.AppSettings.Settings["RememberMe"].Value = "false";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        public static List<ModelUsuario.UserLogin> entrar;
        public static bool Autenticar(string usuario, string senha, bool lembrar)
        {
            try
            {
                var query = $"SELECT * FROM TB_LOGIN_REPOSICOES_APP WHERE USUARIO = @usuario AND SENHA = @senha";
                var param = new DynamicParameters();
                param.Add("@usuario", usuario);
                param.Add("@senha", senha);

                //using (SqlConnection connection = new SqlConnection(Variaveis.ConnectionString))
                //{
                //    entrar = connection.Query<ModelUsuario.UserLogin>(query, param).AsList();
                //}

                //PASSAR USARIO E SENHAS QUE O METODO RECEBE
                //if (entrar[0].usuario == "admin" && entrar[0].senha == "admin")
                //{
                //    SaveCredentials(usuario, senha, lembrar);
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                //RETIRAR PARA AUTENCICACAO
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async static Task<(string, string, bool)> LoadCredentials()
        {
            if (bool.TryParse(ConfigurationManager.AppSettings["RememberMe"], out bool rememberMe) && rememberMe)
            {
                string usuario = ConfigurationManager.AppSettings["Username"];
                string senha = ConfigurationManager.AppSettings["Password"];
                bool lembrar = true;

                return (usuario, senha, lembrar);
            }
            return (string.Empty, string.Empty, false);
        }
    }
}
