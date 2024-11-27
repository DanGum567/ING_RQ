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
                if (idProducto > 0)
                {

                    MostrarDetallesProducto();
                }
                else
                {
                    bCategoria.Visible = true;
                    cbCategoria.Visible = false;
                    cargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }


        }

        private void cargarCategorias()
        {
            grupo02DBEntities db = new grupo02DBEntities();
            var categorias = from producto in db.Producto select producto.CategoriaProducto;

            dCategoria.DataSource = categorias.ToList();

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dCategoria.Columns.Add(btnEliminar);

            cbCategoria.DataSource = db.CategoriaProducto.ToList();

        }

        private void cargarAtributosUsuario()
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
                var ListaProductoSeleccionado = from producto in db.Producto where producto.ID == idProducto select producto;
                var productoSelecionado = ListaProductoSeleccionado.FirstOrDefault(); // Se coge el objeto producto de la query

                if (productoSelecionado != null)
                {
                    // Obtener el valor del SKU y GTIN como byte[]
                    byte[] skuBytes = Attributes.ObtenerValorAtributoSistema(productoSelecionado, TipoAtributoSistema.SKU, db);
                    byte[] gtinBytes = Attributes.ObtenerValorAtributoSistema(productoSelecionado, TipoAtributoSistema.GTIN, db);

                    // Convertir los valores de byte[] a string 
                    skuTextBox.Text = Encoding.UTF8.GetString(skuBytes);
                    gtinTextBox.Text = Encoding.UTF8.GetString(gtinBytes);

                    productLabelTextBox.Text = productoSelecionado.LABEL;
                    labelCreated.Text += "   " + productoSelecionado.FECHACREACION.ToString();
                    labelModified.Text += " " + productoSelecionado.FECHAMODIFICACION.ToString();


                    // Cargar la imagen del thumbnail
                    byte[] thumbnailBytes = Attributes.ObtenerValorAtributoSistema(productoSelecionado, TipoAtributoSistema.thumbnail, db);
                    if (thumbnailBytes != null)
                    {
                        thumbnailPictureBox.Image = Convertidor.BytesToImage(thumbnailBytes);
                    }

                    cbCategoria.Visible = false;
                    bCategoria.Visible = true;

                    // Cargar los atributos de usuario relacionados con este producto
                    cargarAtributosUsuario();
                    cargarCategorias();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        private void dCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dCategoria.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                grupo02DBEntities db = new grupo02DBEntities();
                CategoriaProducto categoriaEliminar = (CategoriaProducto) dCategoria.Rows[e.RowIndex].Cells[0].Value;
                var producto = db.Producto.Find(idProducto);
                producto.CategoriaProducto.Remove(categoriaEliminar);
                db.SaveChanges();
            }
        }

        private void bCategoria_Click(object sender, EventArgs e)
        {
            cbCategoria.Visible = true;
        }

        private void cbCategoria_Click(object sender, EventArgs e)
        {
            grupo02DBEntities db = new grupo02DBEntities();
            CategoriaProducto categoria = (CategoriaProducto)cbCategoria.SelectedItem;
            if (categoria != null)
            {

                var producto = db.Producto.Find(idProducto);
                producto.CategoriaProducto.Add(categoria);
                db.SaveChanges();
                cbCategoria.Visible = false;
                cargarCategorias();
            }
        }
    }
}
