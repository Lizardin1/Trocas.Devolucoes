namespace TrocasDevolucoes.Decorecasa.Controller.VerificacaoExtensao
{
    public class VerificarVideoImagem
    {
        public static bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension == ".bmp" || extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        }

        public static bool IsVideoFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension == ".mp4" || extension == ".avi" || extension == ".mpeg" || extension == ".wmv" || extension == ".mov";
        }
    }
}
