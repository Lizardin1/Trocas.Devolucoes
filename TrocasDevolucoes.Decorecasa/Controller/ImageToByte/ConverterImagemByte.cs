using System.Drawing.Imaging;

namespace TrocasDevolucoes.Decorecasa.Controller.ImageToByte
{
    public class ConverterImagemByte
    {
        public static byte[] ImageToByteArray(Image image)
        {
            using (var originalImage = image)
            {
                var resizedImage = new Bitmap(500, 500);
                using (var graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.DrawImage(originalImage, 0, 0, 500, 500);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    resizedImage.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }

           
        }
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null; 
            }

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

    }
}
