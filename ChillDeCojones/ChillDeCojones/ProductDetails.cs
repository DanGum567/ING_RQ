using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public partial class ProductDetails : Form
    {
        public ProductDetails()
        {
            InitializeComponent();
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {

        }

        private void uploadThumbnailButton_Click(object sender, EventArgs e)
        {
            Image thumbnail = UploadImageFileDialog();
            if (thumbnail != null)
            {
                thumbnailPictureBox.Image = thumbnail;
            }
        }

        private Image UploadImageFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Selecciona una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cargar la imagen seleccionada en el PictureBox
                    return Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    return null;
                }
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            grupo02DBEntities db = new grupo02DBEntities();
            Producto nuevoProducto = new Producto();
            nuevoProducto.FECHACREACION = DateTime.Now;
            nuevoProducto.FECHAMODIFICACION = DateTime.Now;
            nuevoProducto.LABEL = productLabelTextBox.Text;

            Attributes.AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema.SKU, nuevoProducto, skuTextBox.Text, db);
            Attributes.AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema.GTIN, nuevoProducto, gtinTextBox.Text, db);
            Attributes.AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema.thumbnail, nuevoProducto, thumbnailPictureBox.Image, db);

            db.Producto.Add(nuevoProducto);
            db.SaveChanges();

            Common.ShowSubForm(new Products());
        }

        private void discardChangesButton_Click(object sender, EventArgs e)
        {
            Common.ShowSubForm(new Products());
        }
    }
}
