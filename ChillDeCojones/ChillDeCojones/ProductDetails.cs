using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public partial class ProductDetails : Form
    {
        int idProducto;
        public ProductDetails(int idProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;   
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarDetallesProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }


        }

        private void LoadAtributosUsuario()
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                // Limpiar el ListView antes de llenarlo
                lAtributosUsuario.Items.Clear();

                // Consultar los AtributosUsuario relacionados con el producto actual
                var atributosUsuario = from atributo in db.AtributoUsuario
                                       where atributo.ID == idProducto
                                       select atributo;

                // Recorrer los resultados y agregar cada atributo al ListView
                foreach (var atributo in atributosUsuario)
                {
                    ListViewItem item = new ListViewItem(atributo.NAME);
                    item.SubItems.Add(atributo.TYPE.ToString());
                    lAtributosUsuario.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
          
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
                    // Cargar la imagen seleccionada
                    Image originalImage = Image.FromFile(openFileDialog.FileName);

                    // Verificar si la imagen tiene el tamaño correcto
                    if (originalImage.Width != 200 || originalImage.Height != 200)
                    {
                        // Redimensionar la imagen a 200x200
                        Image resizedImage = ResizeImage(originalImage, 200, 200);
                        return resizedImage;
                    }
                    else
                    {
                        return originalImage;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            try
            {
                // Crear una nueva imagen con las dimensiones deseadas
                Bitmap resizedBitmap = new Bitmap(width, height);

                // Usar un objeto Graphics para realizar el redimensionado
                using (Graphics g = Graphics.FromImage(resizedBitmap))
                {
                    g.DrawImage(img, 0, 0, width, height);
                }

                return resizedBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return null;
            }

        }

        private void MostrarDetallesProducto()
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                var productoSeleccionado = from producto in db.Producto where producto.ID == idProducto select producto;
                skuTextBox.Text = 
                gtinTextBox.Text = 

                labelModified.Text += productoSeleccionado.FECHAMODIFICACION.FirstOrDefault().ToString();
                labelCreated.Text += Created.FirstOrDefault().ToString();

                productLabelTextBox.Text = 
                thumbnailPictureBox
                LoadAtributosUsuario();

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);    
            }
        }

        private void AñadirProducto()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void ModificarProducto()
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                Producto productoModificado = db.Producto.FirstOrDefault(x=> x.ID==idProducto);
                productoModificado.FECHAMODIFICACION = DateTime.Now;
                productoModificado.LABEL = productLabelTextBox.Text;

                Attributes.AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema.SKU, productoModificado, skuTextBox.Text, db);
                Attributes.AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema.GTIN, productoModificado, gtinTextBox.Text, db);
                Attributes.AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema.thumbnail, productoModificado, thumbnailPictureBox.Image, db);
                db.SaveChanges();

                Common.ShowSubForm(new Products());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if(idProducto == -1)
            {
                AñadirProducto();
            }
            else
            {
                ModificarProducto();
            }

        }

        private void discardChangesButton_Click(object sender, EventArgs e)
        {
            Common.ShowSubForm(new Products());
        }
    }
}
