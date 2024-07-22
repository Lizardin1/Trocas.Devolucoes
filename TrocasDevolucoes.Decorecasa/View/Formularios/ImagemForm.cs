using TrocasDevolucoes.Decorecasa.Controller.ImageToByte;

namespace TrocasDevolucoes.Decorecasa.View.Formularios
{
    public partial class ImagemForm : Form
    {
        public byte[] img1 = DetalhesRepo.repoModel[0].image_byte1 == null ? new byte[0] : DetalhesRepo.repoModel[0].image_byte1;
        public byte[] img2 = DetalhesRepo.repoModel[0].image_byte2 == null ? new byte[0] : DetalhesRepo.repoModel[0].image_byte2;
        public ImagemForm()
        {
            InitializeComponent();
            CarregarConteudos();
        }
        public void CarregarConteudos()
        {
            pb_img1.Image = ConverterImagemByte.ByteArrayToImage(img1);
            pb_img2.Image = ConverterImagemByte.ByteArrayToImage(img2);
        }
    }
}
