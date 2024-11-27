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
        grupo02DBEntities db = new grupo02DBEntities();
        int idProducto;
        bool modificar = false;
        Products generalProducts;
        List<CategoriaProducto> cacheCategorias;

        public ProductDetails(int idProducto, Products general)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            generalProducts = general;
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (idProducto > 0)
                {
                    generalProducts.Modificar += (s, args) =>
                    {
                        modificar = true;
                    };
                    MostrarDetallesProducto();
                    if (modificar) //cuando se va a modificar
                    {
                        bCategoria.Visible = true;
                        cbCategoria.Visible = false;
                        cargarCategorias();
                        cargarEliminarCategorias();
                    }
                    else //solo cuando se va a ver
                    {
                    }

                }
                else //Cuando se inserta
                {
                    bCategoria.Visible = true;
                    cbCategoria.Visible = false;
                    cargarCategorias(); //<- esto da excepcion
                    cargarEliminarCategorias();
                }
                CargarListaAtributos(modificar);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }


        }

        private void CargarListaAtributos(bool modificar)
        {
            for (int i = 0; i < 5; i++)
            {
                // Crear un Panel

                Panel panel = new Panel();
                panel.Size = new Size(400, 200);
                panel.BorderStyle = BorderStyle.None;

                Form formulario = new ImageAttributePanel();
                formulario.TopLevel = false; // Necesario para incrustar el Form
                formulario.Dock = DockStyle.Fill; // Ajustar al tamaño del Panel
                formulario.FormBorderStyle = FormBorderStyle.None;

                panel.Controls.Add(formulario);
                groupBox1.Controls.Add(panel);

                formulario.Show();
                MessageBox.Show(panel.Parent.Name);
                // Agregar el Panel al FlowLayoutPanel
            }

            List<AtributoUsuario> atributoUsuarios = db.AtributoUsuario.ToList();
            // Limpia los elementos actuales del ListView para evitar duplicados
            foreach (AtributoUsuario val in atributoUsuarios)
            {
            }
        }

        private void cargarEliminarCategorias()
        {
            //Si hay alguna categoria se crea, si no no se crea el boton
            if (idProducto < 0)
            {
                return;
            }
            Producto p = db.Producto.Find(idProducto); //<- excepcion dice q esto es null. Nuh uh
            var categorias = (from categoria in p.CategoriaProducto
                              select new
                              {
                                  ID = categoria.ID,
                                  Name = categoria.NAME
                              }).ToList();

            if ((categorias.Count > 0))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Delete";
                btnEliminar.Name = "Delete";
                btnEliminar.Text = "🗑";
                btnEliminar.UseColumnTextForButtonValue = true;
                dCategoria.Columns.Add(btnEliminar);
                //dCategoria.Columns["Delete"].Visible = false;
            }

        }

        private void cargarCategorias()
        {
            //Poner las categorias en el desplegable
            if (idProducto < 0)
            {
                return;
            }
            cbCategoria.DataSource = db.CategoriaProducto.ToList();
            Producto p = db.Producto.Find(idProducto); //<- excepcion dice q esto es null. Nuh uh

            //Poner las que tiene ese producto en el dataGridView con un boton eliminar
            var categorias = from categoria in p.CategoriaProducto
                             select new
                             {
                                 ID = categoria.ID,
                                 Name = categoria.NAME

                             };

            dCategoria.DataSource = categorias.ToList();
        }

        private void cargarAtributosUsuario()
        {
            try
            {
                // Limpiar el ListView antes de llenarlo
                //lAtributosUsuario.Items.Clear();

                // Consultar los AtributosUsuario relacionados con el producto actual
                var atributosUsuario = from atributo in db.AtributoUsuario
                                       where atributo.ID == idProducto
                                       select atributo;

                // Recorrer los resultados y agregar cada atributo al ListView
                foreach (var atributo in atributosUsuario)
                {
                    ListViewItem item = new ListViewItem(atributo.NAME);
                    item.SubItems.Add(atributo.TYPE.ToString());
                    //lAtributosUsuario.Items.Add(item);
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
                openFileDialog.Filter = "Image file|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an image";

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
                var ListaProductoSeleccionado = from producto in db.Producto where producto.ID == idProducto select producto;
                var productoSelecionado = ListaProductoSeleccionado.FirstOrDefault(); // Se coge el objeto producto de la query

                if (productoSelecionado != null)
                {
                    // Obtener el valor del SKU y GTIN como byte[]
                    byte[] skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, productoSelecionado, db);
                    byte[] gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, productoSelecionado, db);

                    // Convertir los valores de byte[] a string 
                    skuTextBox.Text = Encoding.UTF8.GetString(skuBytes);
                    gtinTextBox.Text = Encoding.UTF8.GetString(gtinBytes);

                    productLabelTextBox.Text = productoSelecionado.LABEL;
                    labelCreated.Text += "   " + productoSelecionado.FECHACREACION.ToString();
                    labelModified.Text += " " + productoSelecionado.FECHAMODIFICACION.ToString();


                    // Cargar la imagen del thumbnail
                    byte[] thumbnailBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.thumbnail, productoSelecionado, db);
                    if (thumbnailBytes != null)
                    {
                        thumbnailPictureBox.Image = Convertidor.BytesAImage(thumbnailBytes);
                    }

                    cbCategoria.Visible = false;
                    bCategoria.Visible = true;

                    // Cargar los atributos de usuario relacionados con este producto
                    cargarAtributosUsuario();
                    cargarCategorias();
                }
                else
                {
                    MessageBox.Show("The product was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void AñadirProducto()
        {
            try
            {
                Producto nuevoProducto = new Producto();
                nuevoProducto.FECHACREACION = DateTime.Now;
                nuevoProducto.FECHAMODIFICACION = DateTime.Now;
                nuevoProducto.LABEL = productLabelTextBox.Text;

                AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.SKU, nuevoProducto, db, skuTextBox.Text);
                AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.GTIN, nuevoProducto, db, gtinTextBox.Text);
                AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.thumbnail, nuevoProducto, db, thumbnailPictureBox.Image);

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
                Producto productoModificado = db.Producto.Find(idProducto);
                productoModificado.FECHAMODIFICACION = DateTime.Now;
                productoModificado.LABEL = productLabelTextBox.Text;

                AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.SKU, productoModificado, db, skuTextBox.Text);
                AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.GTIN, productoModificado, db, gtinTextBox.Text);
                AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.thumbnail, productoModificado, db, thumbnailPictureBox.Image);
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
            if (idProducto == -1)
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
            if (e.ColumnIndex == dCategoria.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int idCategoria = (int)dCategoria.Rows[e.RowIndex].Cells["ID"].Value;
                var producto = db.Producto.Find(idProducto);
                var categoriaEliminar = db.CategoriaProducto.Find(idCategoria);
                producto.CategoriaProducto.Remove(categoriaEliminar);
                categoriaEliminar.Producto.Remove(producto);
                db.SaveChanges();
            }
        }

        private void bCategoria_Click(object sender, EventArgs e)
        {
            cbCategoria.Visible = true;
        }





        private void discardThumbailButton_Click(object sender, EventArgs e)
        {
            thumbnailPictureBox.Image = null;
            ModificarProducto();
        }



        private void cbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedItem != null)
            {
                CategoriaProducto categoria = (CategoriaProducto)cbCategoria.Items[cbCategoria.SelectedIndex];

                if (idProducto < -1{
                }
                var producto = db.Producto.Find(idProducto);
                //ARREGLAR ESTO
                producto.CategoriaProducto.Add(categoria);
                categoria.Producto.Add(producto);
                db.SaveChanges();
                cbCategoria.Visible = false;
                cargarCategorias();

                if (modificar)
                {
                    /*MessageBox.Show("Modify");
                    grupo02DBEntities db = new grupo02DBEntities();
                    categoria = (CategoriaProducto)cbCategoria.SelectedItem;
                    if (categoria != null)
                    {
                        var producto = db.Producto.Find(idProducto);
                        //ARREGLAR ESTO
                        producto.CategoriaProducto.Add(categoria);
                        categoria.Producto.Add(producto);
                        db.SaveChanges();
                        cbCategoria.Visible = false;
                        cargarCategorias();
                    }*/
                }
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {

        }
    }
}
