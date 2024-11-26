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

                    //-------------------------------------------------------------------------------------------

                    //Atributos del sistema
                    string sku = "(Sin SKU)";
                    string gtin = "(Sin GTIN)";
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
                        skuBytes = Attributes.ObtenerValorAtributoSistema(cargadoJustoAhora, TipoAtributoSistema.SKU, db);
                    }
                    if (gtinBytes == null)
                    {
                        gtinBytes = Attributes.ObtenerValorAtributoSistema(cargadoJustoAhora, TipoAtributoSistema.GTIN, db);
                    }
                    if (thumbailBytes == null)
                    {
                        thumbailBytes = Attributes.ObtenerValorAtributoSistema(cargadoJustoAhora, TipoAtributoSistema.thumbnail, db);
                    }

                    thumbailBytes = Attributes.ObtenerValorAtributoSistema(cargadoJustoAhora, TipoAtributoSistema.thumbnail, db);
                    skuBytes = Attributes.ObtenerValorAtributoSistema(cargadoJustoAhora, TipoAtributoSistema.SKU, db);
                    gtinBytes = Attributes.ObtenerValorAtributoSistema(cargadoJustoAhora, TipoAtributoSistema.GTIN, db);


                    if (thumbailBytes != null)
                    {
                        thumbail = Convertidor.BytesToImage(thumbailBytes);
                    }
                    if (skuBytes != null)
                    {
                        sku = Convertidor.BytesToString(skuBytes);
                    }
                    if (gtinBytes != null)
                    {
                        gtin = Convertidor.BytesToString(gtinBytes);
                    }
                    /*
                    string atributo1 = db.AtributoUsuario.Count() > 0 ? db.AtributoUsuario..NAME : "(Sin Atributo 1)";
                    string atributo2 = db.AtributoUsuario.Count() > 1 ? db.AtributoUsuario[1].NAME : "(Sin Atributo 2)";
                    string atributo3 = db.AtributoUsuario.Count() > 2 ? atributosUsuario[2].NAME : "(Sin Atributo 3)";
                    */
                    listaProductosDataGridView.Rows.Add(
                        thumbail,
                        sku,
                        gtin,
                        label,
                        //atributo1, // Atributo 1 personalizado
                        //atributo2, // Atributo 2 personalizado
                        //atributo3, // Atributo 3 personalizado
                        fechaModificacion,
                        fechaCreacion
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR PRODUCTOS: " + ex.Message);
            }
            listaProductosDataGridView.ResumeLayout();
            listaProductosDataGridView.ClearSelection();// Se deselecciona el primer elemento
        }
 
        private void newProductButton_Click(object sender, EventArgs e)
        {

            grupo02DBEntities db = new grupo02DBEntities();
            if (db.Producto.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.id == 1).Productos)
            {

                Common.ShowSubForm(new ProductDetails(-1));
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
                MessageBox.Show("ERROR AL ELIMINAR PRODUCTO: " + ex.Message);
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
