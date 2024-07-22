using Guna.UI2.WinForms;

namespace TrocasDevolucoes.Decorecasa.Controller.Metodos
{
    public class FormatDecimal
    {
        public static void DecNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true;
            else if (e.KeyChar == 44)
            {
                Guna2TextBox txt = (Guna2TextBox)sender;
                if (txt.Text.Contains(","))
                    e.Handled = true;
            }
        }
    }
}
