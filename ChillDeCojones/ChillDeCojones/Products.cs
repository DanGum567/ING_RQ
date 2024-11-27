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

        public event EventHandler Modificar;
        public Products()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarListaProductos();
            cargarAccion();
        }

        private void cargarAccion()
        {
            //Crear columna de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Delete";
            btnEliminar.Name = "Delete";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            listaProductosDataGridView.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Edit";
            btnEditar.Name = "Edit";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            listaProductosDataGridView.Columns.Add(btnEditar);
        }

        private void MostrarListaProductos()
        {
            listaProductosDataGridView.Rows.Clear();
            listaProductosDataGridView.SuspendLayout();

            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                List<Producto> productos = db.Producto.ToList();

                foreach (Producto cargadoJustoAhora in productos)
                {
                    //Variables de Producto
                    int idProducto = cargadoJustoAhora.ID;
                    string label;
                    DateTime fechaCreacion;
                    DateTime fechaModificacion;
                    int ID;

                    //Comprobamos si ya se han cargado las variables de Producto anteriormente
                    Producto delQueCargarVariables;
                    Producto precargadoEnMemoria = Precargador.GetProductoEnMemoria(idProducto);
                    if (precargadoEnMemoria != null)
                    {
                        delQueCargarVariables = precargadoEnMemoria;
                    }
                    else
                    {
                        delQueCargarVariables = cargadoJustoAhora;
                    }

                    //Cargamos variables del producto para mostrarlas
                    label = delQueCargarVariables.LABEL;
                    fechaCreacion = (DateTime)delQueCargarVariables.FECHACREACION;
                    fechaModificacion = (DateTime)delQueCargarVariables.FECHAMODIFICACION;
                    ID = delQueCargarVariables.ID;

                    //-------------------------------------------------------------------------------------------

                    //Atributos del sistema
                    string sku = "(Without SKU)";
                    string gtin = "(Without GTIN)";
                    Image thumbail = null;

                    byte[] skuBytes;
                    byte[] gtinBytes;
                    byte[] thumbailBytes;

                    //Comprobamos si ya se han cargado las variables de Producto anteriormente
                    skuBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.SKU, idProducto);
                    gtinBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.GTIN, idProducto);
                    thumbailBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.thumbnail, idProducto);

                    if (skuBytes == null)
                    {
                        skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, cargadoJustoAhora, db);
                    }
                    if (gtinBytes == null)
                    {
                        gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, cargadoJustoAhora, db);
                    }
                    if (thumbailBytes == null)
                    {
                        MessageBox.Show("The thumbail of the product with id " + idProducto + " is not preloaded in memory");
                        thumbailBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.thumbnail, cargadoJustoAhora, db);
                    }

                    if (thumbailBytes != null)
                    {
                        thumbail = Convertidor.BytesAImage(thumbailBytes);
                    }
                    if (skuBytes != null)
                    {
                        sku = Convertidor.BytesAString(skuBytes);
                    }
                    if (gtinBytes != null)
                    {
                        gtin = Convertidor.BytesAString(gtinBytes);
                    }

                    listaProductosDataGridView.Rows.Add(
                        thumbail,
                        sku,
                        gtin,
                        label,
                        fechaModificacion,
                        fechaCreacion,
                        ID //ESTO NO QUITARLO QUE SI NO SE ROMPE TODO
                    );

                    listaProductosDataGridView.Columns["ID"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing products: " + ex.Message);
            }
            listaProductosDataGridView.ResumeLayout();
            listaProductosDataGridView.ClearSelection();// Se deselecciona el primer elemento
        }

        private void newProductButton_Click(object sender, EventArgs e)
        {

            grupo02DBEntities db = new grupo02DBEntities();
            if (db.Producto.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.id == 1).Productos)
            {

                Common.ShowSubForm(new ProductDetails(-1, this));
            }
            else
            {
                MessageBox.Show("You have reached the maximum number of attributes allowed");
            }
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
                        MessageBox.Show("Product successfully deleted", "Successful Deletion");

                        MostrarListaProductos(); // Se recarga la lista de productos
                    }
                }
                else
                {
                    MessageBox.Show("Attribute wasn't found", "Error");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to delete the attribute: " + ex.Message);
            }
        }

        private void ModificarProducto(int idProducto)
        {
            try
            {

                Modificar?.Invoke(this, EventArgs.Empty);
                Common.ShowSubForm(new ProductDetails(idProducto, this));


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
                if (e.ColumnIndex == listaProductosDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    EliminarProducto(idProducto);
                }
                // Si se hizo clic en el botón "Editar"
                else if (e.ColumnIndex == listaProductosDataGridView.Columns["Edit"].Index)
                {
                    ModificarProducto(idProducto);
                }
                else
                {

                    Common.ShowSubForm(new ProductDetails(idProducto, this));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

        }

        private void listaProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
