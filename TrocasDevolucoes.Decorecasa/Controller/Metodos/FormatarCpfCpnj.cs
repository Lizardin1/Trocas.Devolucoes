namespace GunaUITestes.Controller
{
    public class FormatarCpfCpnj
    {
        public static string CpfCpnjFormat(string cpfCpnjText)
        {
            string text = cpfCpnjText.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);

            // Formatar como CPF
            if (text.Length <= 11)
            {
                // Formatar como CPF
                if (text.Length > 2)
                    text = text.Insert(3, ".");
                if (text.Length > 6)                                                                                                 
                    text = text.Insert(7, ".");
                if (text.Length > 10)
                    text = text.Insert(11, "-");
            }
            else
            {
                // Formatar como CNPJ
                if (text.Length > 2)
                    text = text.Insert(2, ".");
                if (text.Length > 5)
                    text = text.Insert(6, ".");
                if (text.Length > 8)
                    text = text.Insert(10, "/");
                if (text.Length > 12)
                    text = text.Insert(15, "-");
            }

            return text;
        }
    }
}
