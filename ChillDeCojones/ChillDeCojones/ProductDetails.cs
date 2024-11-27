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
    public partial class ProductDetails : Form
    {
        grupo02DBEntities db;
        Producto producto;
        bool creandoProducto = false;
        //bool modificar = false;
        Products generalProducts;

        public ProductDetails(Producto producto, Products formGeneral, grupo02DBEntities contexto)
        {
            InitializeComponent();
            generalProducts = formGeneral;
            this.db = contexto;
            if (producto == null)//Crear producto
            {
                Producto productoNuevo = new Producto();
                productoNuevo.FECHACREACION = DateTime.Now;
                productoNuevo.FECHAMODIFICACION = DateTime.Now;
                productoNuevo.LABEL = "";
                this.producto = db.Producto.Add(productoNuevo);
                db.SaveChanges();
                creandoProducto = true;
                //db.SaveChanges();
            }
            else//Modificar o mostrar producto
            {
                
                this.producto = producto;
                creandoProducto = false;
            }
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!creandoProducto)
            {
                MostrarDetallesProducto();
                
                bCategoria.Visible = true;
                cbCategoria.Visible = false;
                cargarCategorias();
                cargarEliminarCategorias();
                

            }
            else //Cuando se inserta
            {
                bCategoria.Visible = true;
                cbCategoria.Visible = false;
                cargarCategorias();
                cargarEliminarCategorias();
            }
            //siempre
            DeleteProductButton.Visible = !creandoProducto;
            CargarListaAtributos(false);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ERROR CARGANDO PRODUCTOS: " + ex.Message);
            //}


        }

        private void CargarListaAtributos(bool modificar)
        {
            for (int i = 0; i < 5; i++)
            {
                // Crear un Panel

                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown; // Vertical
                flowLayoutPanel1.WrapContents = false;                 // Evita que se reorganicen horizontalmente
                flowLayoutPanel1.AutoScroll = true;                    // Permite desplazamiento

                Form formulario = new ImageAttributePanel();
                formulario.TopLevel = false; // Necesario para incrustar el Form
                formulario.Dock = DockStyle.Fill; // Ajustar al tamaño del Panel
                formulario.FormBorderStyle = FormBorderStyle.None;

                //panel.Controls.Add(formulario);
                //panel1.Controls.Add(panel);

                formulario.Show();
                //MessageBox.Show(panel.Parent.Name);
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

            var categorias = (from categoria in producto.CategoriaProducto
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
                    cargarCategorias();
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

            AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.SKU, producto, db, skuTextBox.Text);
            AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.GTIN, producto, db, gtinTextBox.Text);
            AtributoManager.AñadirOActualizarValorAtributoSistema(TipoAtributoSistema.thumbnail, producto, db, thumbnailPictureBox.Image);

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
            Common.ShowSubForm(new Products());
        }

        private void dCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dCategoria.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int idCategoria = (int)dCategoria.Rows[e.RowIndex].Cells["ID"].Value;
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
                //string nombreCategoria = cbCategoria.Items[cbCategoria.SelectedIndex].ToString();
                //CategoriaProducto categoria = db.CategoriaProducto.First(cat => cat.NAME.Equals(nombreCategoria));
                CategoriaProducto categoria = (CategoriaProducto)cbCategoria.Items[cbCategoria.SelectedIndex];

                // Si el producto se encuentra, añades la categoría

                // Añadir la categoría seleccionada al producto
                if (!producto.CategoriaProducto.Contains(categoria))
                {
                    producto.CategoriaProducto.Add(categoria);
                    categoria.Producto.Add(producto); // Asegúrate de que la relación se añade en ambos sentidos
                    dCategoria.DataSource = producto.CategoriaProducto.ToList();

                }


                //if (modificar)
                //{
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
                //}

            }
        }


        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            Products.EliminarProducto(producto);
            Common.ShowSubForm(new Products());
        }
    }
}
