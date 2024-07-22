using System.ComponentModel.DataAnnotations.Schema;

namespace TrocasDevolucoes.Decorecasa.Model.Modelo
{
    public class ModelUsuario
    {
        [Table("TB_LOGIN_REPOSICOES_APP")]
        public class UserLogin
        {
            public int id { get; }
            public string usuario { get; set; }
            public string senha { get; set; }
            public char lembrar { get; set; }
            public string permissoes { get; }
            public string nome { get;}
        }
    }
}
