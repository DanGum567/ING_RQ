using ChillDeCojones.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public partial class ProductDetailsForm : Form
    {
        grupo02DBEntities1 db;
        Producto producto;
        bool creandoProducto = false;
        bool modificandoProducto = false;

        public ProductDetailsForm(Producto producto, bool modificarProducto, grupo02DBEntities1 contexto)
        {
            InitializeComponent();
            this.db = contexto;
            modificandoProducto = modificarProducto;
            if (producto == null)//Crear producto
            {
                Producto productoNuevo = new Producto();
                productoNuevo.FECHACREACION = DateTime.Now;
                productoNuevo.FECHAMODIFICACION = DateTime.Now;
                productoNuevo.LABEL = "";
                this.producto = db.Producto.Add(productoNuevo);
                db.SaveChanges();
                creandoProducto = true;
            }
            else//Modificar o mostrar producto
            {

                this.producto = producto;
                creandoProducto = false;
            }
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            if (!creandoProducto)
            {
                MostrarDetallesProducto();
            }

            bCategoria.Visible = modificandoProducto;
            skuTextBox.Enabled = modificandoProducto;
            gtinTextBox.Enabled = modificandoProducto;
            productLabelTextBox.Enabled = modificandoProducto;

            uploadThumbnailButton.Visible = modificandoProducto;
            discardThumbailButton.Visible = modificandoProducto;
            saveChangesButton.Visible = modificandoProducto;
            discardChangesButton.Visible = modificandoProducto;

            DeleteProductButton.Visible = !creandoProducto;
            EditProductButton.Visible = !modificandoProducto;

            cbCategoria.Visible = false;

            CargarCategorias();

            CargarListaAtributos(false);
            if (modificandoProducto)
            {
                CargarBotonDeEliminarCategorias();
                CargarLasVariasColumnasParaLosAtributosDeUsuarioQueSeHanHechoEnElProgramaYSeHanGuardadoEnLaBaseDeDatosCorrectamente();

            }
            if (creandoProducto)
            {
                labelCreated.Text += "   " + DateTime.Now.ToString();
                labelModified.Text += " " + DateTime.Now.ToString();
            }

        }

        private void CargarListaAtributos(bool modificar)
        {
            dataGridView1.Rows.Clear(); // Borra las columnas para que no se vuelvan a crear otra vez
            dataGridView1.Columns["ID"].Visible = false;


            foreach (AtributoUsuario atributoUsuario in db.AtributoUsuario.ToList())
            {
                var valor = db.ValorAtributoUsuario.Find(atributoUsuario.ID, producto.ID); //tiene valor ya?

                if (valor != null)
                {
                    string tipo = atributoUsuario.TYPE;
                    TipoAtributoUsuario tipoValor = (TipoAtributoUsuario)Enum.Parse(typeof(TipoAtributoUsuario), tipo);
                    object valorConvertido = AtributoManager.ConvertirBytesAAtributo(tipoValor, valor.VALOR);

                    object valorColumna = null;
                    switch (tipoValor)
                    {
                        case TipoAtributoUsuario.Text:
                            valorColumna = (string)valorConvertido;
                            break;
                        case TipoAtributoUsuario.Number:
                            valorColumna = ((float)valorConvertido).ToString();
                            break;
                        case TipoAtributoUsuario.Date:
                            valorColumna = ((DateTime)valorConvertido).ToShortDateString();
                            break;
                        case TipoAtributoUsuario.Image:
                            valorColumna = (Image)valorConvertido;
                            break;
                    }

                    if (valorColumna is Image imagenValor)
                    {
                        dataGridView1.Rows.Add(atributoUsuario.ID, atributoUsuario.NAME, "", imagenValor);
                    }
                    else if (valorColumna is string textoValor)
                    {
                        dataGridView1.Rows.Add(atributoUsuario.ID, atributoUsuario.NAME, textoValor, Resources.pixelpngblancomiau);
                    }

                }
                else
                {
                    dataGridView1.Rows.Add(atributoUsuario.ID, atributoUsuario.NAME, "(No attribute)", Resources.pixelpngblancomiau);
                }
            }

            dataGridView1.Height = dataGridView1.Columns.Count * dataGridView1.Rows[0].Height;
        }

        private void CargarLasVariasColumnasParaLosAtributosDeUsuarioQueSeHanHechoEnElProgramaYSeHanGuardadoEnLaBaseDeDatosCorrectamente()
        {
            DataGridViewButtonColumn btnUpload = new DataGridViewButtonColumn();
            btnUpload.HeaderText = "Upload attribute";
            btnUpload.Name = "Upload";
            btnUpload.Text = "Upload attribute";
            btnUpload.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnUpload);

            DataGridViewButtonColumn btnDiscard = new DataGridViewButtonColumn();
            btnDiscard.HeaderText = "Discard attribute";
            btnDiscard.Name = "Discard";
            btnDiscard.Text = "Discard attribute";
            btnDiscard.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnDiscard);
        }

        private void CargarBotonDeEliminarCategorias()
        {
            //Si hay alguna categoria se crea, si no no se crea el boton

            var categorias = (from categoria in producto.CategoriaProducto
                              select new
                              {
                                  ID = categoria.ID,
                                  Name = categoria.NAME
                              }).ToList();


            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Delete";
            btnEliminar.Name = "Delete";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dCategoria.Columns.Add(btnEliminar);
            //dCategoria.Columns["Delete"].Visible = false;


        }

        private void CargarCategorias()
        {

            //Poner las categorias en el desplegable
            //dCategoria.Rows.Clear();
            cbCategoria.DataSource = db.CategoriaProducto.ToList();

            //Poner las que tiene ese producto en el dataGridView con un boton eliminar
            var prod = db.Producto.Find(producto.ID);
            var categorias = from categoria in producto.CategoriaProducto
                             select new
                             {
                                 ID = categoria.ID,
                                 Name = categoria.NAME
                             };

            dCategoria.DataSource = categorias.ToList();
            dCategoria.Columns["ID"].Visible = false;
            dCategoria.ClearSelection();
        }



        private void uploadThumbnailButton_Click(object sender, EventArgs e)
        {
            Image thumbnail = AbrirPestañaSeleccionarImagen();
            if (thumbnail != null)
            {
                thumbnailPictureBox.Image = thumbnail;
            }
        }

        private Image AbrirPestañaSeleccionarImagen()
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
                MessageBox.Show("ERROR RESIZE IMAGE: " + ex.Message);
                return null;
            }

        }

        private void MostrarDetallesProducto()
        {
            try
            {
                if (producto != null)
                {
                    // Obtener el valor del SKU y GTIN como byte[]
                    byte[] skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, producto, db);
                    byte[] gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, producto, db);

                    // Convertir los valores de byte[] a string 
                    skuTextBox.Text = Encoding.UTF8.GetString(skuBytes);
                    gtinTextBox.Text = Encoding.UTF8.GetString(gtinBytes);

                    productLabelTextBox.Text = producto.LABEL;
                    labelCreated.Text += "   " + producto.FECHACREACION.ToString();
                    labelModified.Text += " " + producto.FECHAMODIFICACION.ToString();


                    // Cargar la imagen del thumbnail
                    byte[] thumbnailBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.thumbnail, producto, db);
                    if (thumbnailBytes != null)
                    {
                        thumbnailPictureBox.Image = Convertidor.BytesAImage(thumbnailBytes);
                    }

                    cbCategoria.Visible = false;
                    bCategoria.Visible = true;

                    // Cargar los atributos de usuario relacionados con este producto
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show("The product was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void ModificarProducto()
        {

            producto.FECHAMODIFICACION = DateTime.Now;
            producto.LABEL = productLabelTextBox.Text;

            bool correcto = true;
            //if (!skuTextBox.Text.Equals(producto.AtributoUsuario))
            //{
            correcto &= AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.SKU, producto, db, skuTextBox.Text);
            //}
            //if (!gtinTextBox.Text.Equals(producto.))
            //{
            correcto &= AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.GTIN, producto, db, gtinTextBox.Text);
            //}


            correcto &= AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.thumbnail, producto, db, thumbnailPictureBox.Image);

            if (!correcto)
            {
                //MessageBox.Show("Some values were incorrect, please check the values you have submitted", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine($"Entidad: {eve.Entry.Entity.GetType().Name}");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($" - Propiedad: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                    }
                }
            }

            Common.ShowSubForm(new Products());
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            ModificarProducto();
        }

        private void discardChangesButton_Click(object sender, EventArgs e)
        {
            if (creandoProducto)
            {
                db.Producto.Remove(producto);
                db.SaveChanges();
            }
            Common.ShowSubForm(new Products());
        }

        private void dCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!modificandoProducto)
            {
                return;
            }
            if (e.ColumnIndex == dCategoria.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int idCategoria = (int)dCategoria.Rows[e.RowIndex].Cells["ID"].Value;
                var categoriaEliminar = db.CategoriaProducto.Find(idCategoria);
                producto.CategoriaProducto.Remove(categoriaEliminar);
                categoriaEliminar.Producto.Remove(producto);
                dCategoria.DataSource = producto.CategoriaProducto.ToList();
                //db.SaveChanges();
                CargarCategorias();
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
                CategoriaProducto categoria = (CategoriaProducto)cbCategoria.SelectedItem;

                if (!producto.CategoriaProducto.Contains(categoria))
                {
                    producto.CategoriaProducto.Add(categoria);
                    categoria.Producto.Add(producto); // Asegurar bidireccionalidad

                    try
                    {
                        db.SaveChanges(); // Guardar los cambios
                        CargarCategorias(); // Refrescar las categorías
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar cambios: " + ex.Message);
                    }
                }
            }
        }


        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            Products.EliminarProducto(producto);
            Common.ShowSubForm(new Products());
        }

        private void EditProductButton_Click(object sender, EventArgs e)
        {
            Common.ShowSubForm(new ProductDetailsForm(producto, true, db));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!modificandoProducto)
            {
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Upload"].Index && e.RowIndex >= 0)
            {
                int idAtributo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                var atributoUsuario = db.AtributoUsuario.Find(idAtributo);
                if (atributoUsuario.TYPE == "Image") //es imagen
                {
                    Image thumbnail = AbrirPestañaSeleccionarImagen();
                    if (thumbnail != null)
                    {
                        AtributoManager.AñadirOActualizarValorAtributoUsuario(atributoUsuario.NAME, producto, db, thumbnail);
                        ((DataGridViewImageCell)dataGridView1.Rows[e.RowIndex].Cells["Image1"]).Value = thumbnail;
                        dataGridView1.Rows[e.RowIndex].Cells["Text"].Value = "";

                    }
                }
                else //se puede escribir en un nuevo form
                {
                    //CUANDO EL TIPO NO ES UNA IMAGEN

                    ModificarValorAtributoUsuario ModificarValorAtributoUsuario = new ModificarValorAtributoUsuario(atributoUsuario, producto, db);
                    ModificarValorAtributoUsuario.AtributoModificado += (s, args) =>
                    {
                        CargarListaAtributos(modificandoProducto);
                    };


                    // Mostrar el formulario como modal
                    ModificarValorAtributoUsuario.ShowDialog();
                }

            }

            if (e.ColumnIndex == dataGridView1.Columns["Discard"].Index && e.RowIndex >= 0)
            {
                int idAtributo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                var atributoUsuario = db.AtributoUsuario.Find(idAtributo);
                if (atributoUsuario.TYPE == "Image") //es imagen
                {
                    // Asigna la imagen directamente a la celda personalizada
                    ((DataGridViewImageCell)dataGridView1.Rows[e.RowIndex].Cells["Image1"]).Value = Resources.pixelpngblancomiau;
                    dataGridView1.Rows[e.RowIndex].Cells["Text"].Value = "(No attribute)";
                }
                else//no es imagen
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Text"].Value = "(No attribute)";
                }
                var valor = db.ValorAtributoUsuario.Find(atributoUsuario.ID, producto.ID);
                db.ValorAtributoUsuario.Remove(valor);
            }
        }
    }
}
