using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MostrarListaProductosV2Optimizada();
            MostrarListaProductos();
            cargarAccion();
        }

        private void cargarAccion()
        {
            //Crear columna de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            listaProductosDataGridView.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            listaProductosDataGridView.Columns.Add(btnEditar);
        }

        private void MostrarListaProductos()
        {
            try
            {
                listaProductosDataGridView.SuspendLayout();

                grupo02DBEntities db = new grupo02DBEntities();
                List<Producto> productos = new List<Producto>();
                productos = db.Producto.ToList();

                // Limpiar las filas antes de volver a llenarlas
                listaProductosDataGridView.Rows.Clear();
                foreach (Producto producto in productos)
                {
                    byte[] thumbailBytes = Attributes.ObtenerValorAtributoSistema(producto, TipoAtributoSistema.thumbnail, db);
                    Image thumbail = null;
                    if (thumbailBytes != null)
                    {
                        thumbail = Convertidor.BytesToImage(thumbailBytes);
                    }

                    byte[] skuBytes = Attributes.ObtenerValorAtributoSistema(producto, TipoAtributoSistema.SKU, db);
                    string sku = "(Sin SKU)";
                    if (skuBytes != null)
                    {
                        sku = Convertidor.BytesToString(skuBytes);
                    }

                    byte[] gtinBytes = Attributes.ObtenerValorAtributoSistema(producto, TipoAtributoSistema.GTIN, db);
                    string gtin = "(Sin GTIN)";
                    if (gtinBytes != null)
                    {
                        gtin = Convertidor.BytesToString(gtinBytes);
                    }

                    listaProductosDataGridView.Rows.Add(
                        thumbail,
                        sku,
                        gtin,
                        producto.LABEL,
                        producto.FECHAMODIFICACION,
                        producto.FECHACREACION,
                        producto.ID
                    );

                }
                listaProductosDataGridView.Columns["ID"].Visible = false;
                listaProductosDataGridView.ResumeLayout();
                listaProductosDataGridView.ClearSelection();// Se deselecciona el primer elemento
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR PRODUCTOS: " + ex.Message);
            }
        }
        /*
        private void MostrarListaProductosV2Optimizada()
        {
            using (grupo02DBEntities db = new grupo02DBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Optimización de la consulta
                var productos = db.Producto
                    .Select(p => new
                    {
                        Producto = p,
                        Thumbnail = p.ValorAtributoSistema.FirstOrDefault(v => v.ID_ATRIBUTOSISTEMA == (int)TipoAtributoSistema.thumbnail),
                        SKU = p.ValorAtributoSistema.FirstOrDefault(v => v.ID_ATRIBUTOSISTEMA == (int)TipoAtributoSistema.SKU),
                        GTIN = p.ValorAtributoSistema.FirstOrDefault(v => v.ID_ATRIBUTOSISTEMA == (int)TipoAtributoSistema.GTIN)
                    })
                    .ToList();

                // Suspender el renderizado para mejorar el rendimiento
                listaProductosDataGridView.SuspendLayout();

                foreach (var item in productos)
                {
                    Producto producto = item.Producto;

                    // Convertir atributos con las optimizaciones necesarias
                    byte[] thumbnailBytes = item.Thumbnail?.VALOR;
                    Image thumbnail = thumbnailBytes != null ? Convertidor.BytesToImage(thumbnailBytes) : null;

                    byte[] skuBytes = item.SKU?.VALOR;
                    string sku = skuBytes != null ? Convertidor.BytesToString(skuBytes) : "(Sin SKU)";

                    byte[] gtinBytes = item.GTIN?.VALOR;
                    string gtin = gtinBytes != null ? Convertidor.BytesToString(gtinBytes) : "(Sin GTIN)";

                    // Añadir fila a la vista
                    listaProductosDataGridView.Rows.Add(
                        thumbnail,
                        sku,
                        gtin,
                        producto.LABEL,
                        producto.FECHAMODIFICACION,
                        producto.FECHACREACION
                    );
                }

                // Reanudar el renderizado
                listaProductosDataGridView.ResumeLayout();
            }
        }
        */

        private void newProductButton_Click(object sender, EventArgs e)
        {
            Common.ShowSubForm(new ProductDetails(-1));
        }

        private void EliminarProducto(int idProducto)
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                // Busca el atributo en la base de datos
                var producto = db.Producto.First(x => x.ID.Equals(idProducto));
                if (producto != null)
                {
                    // Se pregunta al usuario si está seguro de que quiere eliminar el atributo
                    DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Llamamos al método Borrar del objeto Producto para eliminarlo de la base de datos
                        db.Producto.Remove(producto);
                        db.SaveChanges(); // Guarda los cambios en la base de datos
                        MessageBox.Show("Atributo eliminado correctamente.", "Eliminación Exitosa");

                        MostrarListaProductos(); // Se recarga la lista de productos
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el atributo.", "Error");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void ModificarProducto(int idProducto)
        {
            try
            {
                Common.ShowSubForm(new ProductDetails(idProducto));


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void listaProductosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                // Obtén el ID del atributo desde la fila seleccionada
                int idProducto = Convert.ToInt32(listaProductosDataGridView.Rows[e.RowIndex].Cells["ID"].Value);
                // Verifica si la celda pertenece a la columna "Eliminar"
                if (e.ColumnIndex == listaProductosDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
                {
                    EliminarProducto(idProducto);
                }
                // Si se hizo clic en el botón "Editar"
                else if (e.ColumnIndex == listaProductosDataGridView.Columns["Editar"].Index)
                {
                    ModificarProducto(idProducto);
                }
                else
                {

                    Common.ShowSubForm(new ProductDetails(idProducto));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

        }
    }
}
