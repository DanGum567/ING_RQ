using ChillDeCojones.Properties;
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
        private grupo02DBEntities1 db = new grupo02DBEntities1();
        public event EventHandler Modificar;
        private static Products instance;
        public Products()
        {
            instance = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrearColumnasAtributosUsuario();
            MostrarListaProductos();
            cargarAccion();
            ActualizarNumeroProductos(); //Carga el numero de productos actual en la BBDD
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
        private void CrearColumnasAtributosUsuario()
        {
            foreach (AtributoUsuario atributoUsuario in db.AtributoUsuario.Take(3))
            {
                string tipo = atributoUsuario.TYPE; // El tipo del atributo actual
                DataGridViewColumn nuevaColumna = null;

                switch (tipo)
                {
                    case "Image":
                        nuevaColumna = new DataGridViewImageColumn
                        {
                            HeaderText = atributoUsuario.NAME,
                            Name = atributoUsuario.NAME
                        };
                        break;

                    default:
                        nuevaColumna = new DataGridViewTextBoxColumn
                        {
                            HeaderText = atributoUsuario.NAME,
                            Name = atributoUsuario.NAME
                        };
                        break;
                }

                listaProductosDataGridView.Columns.Add(nuevaColumna);

            }
        }

        private void MostrarListaProductos()
        {
            ActualizarNumeroProductos();
            listaProductosDataGridView.Rows.Clear();
            listaProductosDataGridView.SuspendLayout();


            List<Producto> productos = db.Producto.ToList();
            int fila = 0;
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
                //Producto precargadoEnMemoria = Precargador.GetProductoEnMemoria(idProducto);

                delQueCargarVariables = cargadoJustoAhora;


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

                byte[] skuBytes = null;
                byte[] gtinBytes = null;
                byte[] thumbailBytes = null;

                //Comprobamos si ya se han cargado las variables de Producto anteriormente
                //skuBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.SKU, idProducto);
                //gtinBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.GTIN, idProducto);
                //thumbailBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.thumbnail, idProducto);


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
                    fila,
                    thumbail,
                    idProducto,
                    sku,
                    label
                );

                listaProductosDataGridView.Columns["Fila"].Visible = false;
                listaProductosDataGridView.Columns["ID"].Visible = false;
                List<AtributoUsuario> tresPrimeros = db.AtributoUsuario.Take(3).ToList();
                foreach (AtributoUsuario atributoUsuario in tresPrimeros)
                {

                    var valor = db.ValorAtributoUsuario.Find(atributoUsuario.ID, cargadoJustoAhora.ID);

                    if (valor != null)
                    {
                        string tipo = atributoUsuario.TYPE;
                        object valorConvertido = null;
                        switch (tipo)
                        {
                            case "Date":
                                valorConvertido = Convertidor.BytesADateTime(valor.VALOR).ToString();
                                break;
                            case "Number":
                                valorConvertido = Convertidor.BytesAFloat(valor.VALOR).ToString();
                                break;
                            case "Text":
                                valorConvertido = Convertidor.BytesAString(valor.VALOR);
                                break;

                            case "Image":
                                valorConvertido = Convertidor.BytesAImage(valor.VALOR);
                                break;

                            default:
                                Console.WriteLine($"UNKNOWN TYPE: {tipo}");
                                break;
                        }
                        if (valorConvertido != null)
                        {
                            //MessageBox.Show("fila: " + fila.ToString());
                            listaProductosDataGridView.Rows[fila].Cells[atributoUsuario.NAME].Value = valorConvertido;
                        }

                    }
                    else
                    {
                        /*string tipo = atributoUsuario.TYPE;
                        switch (tipo)
                        {
                            case "Date":
                            case "Number":
                            case "Text":
                                listaProductosDataGridView.Rows.Add(" ");
                                break;

                            case "Image":
                                listaProductosDataGridView.Rows.Add(Resources.imagenPredeterminadaProducto);
                                break;

                            default:
                                Console.WriteLine($"UNKNOWN TYPE: {tipo}");
                                break;
                        }*/

                    }

                }
                fila++;
            }

            listaProductosDataGridView.ResumeLayout();
            listaProductosDataGridView.ClearSelection();// Se deselecciona el primer elemento
        }

        private void newProductButton_Click(object sender, EventArgs e)
        {

            if (db.Producto.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.Nombre.Equals("Free")).Productos)
            {

                Common.ShowSubForm(new ProductDetailsForm(null, true, db));
            }
            else
            {
                MessageBox.Show("You have reached the maximum number of attributes allowed");
            }
        }

        public static void EliminarProducto(Producto productoAEliminar)
        {
            try
            {
                // Busca el atributo en la base de datos
                if (productoAEliminar != null)
                {
                    // Se pregunta al usuario si está seguro de que quiere eliminar el atributo
                    DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Llamamos al método Borrar del objeto Producto para eliminarlo de la base de datos
                        instance.db.Producto.Remove(productoAEliminar);
                        instance.db.SaveChanges(); // Guarda los cambios en la base de datos
                        MessageBox.Show("Product successfully deleted", "Successful Deletion");

                        instance.MostrarListaProductos(); // Se recarga la lista de productos
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



        private void listaProductosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtén el ID del atributo desde la fila seleccionada
                int idProducto = Convert.ToInt32(listaProductosDataGridView.Rows[e.RowIndex].Cells["ID"].Value);
                // Verifica si la celda pertenece a la columna "Eliminar"
                Producto producto = db.Producto.Find(idProducto);
                if (e.ColumnIndex == listaProductosDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    EliminarProducto(producto);
                }
                // Si se hizo clic en el botón "Editar"
                else if (e.ColumnIndex == listaProductosDataGridView.Columns["Edit"].Index)
                {
                    Common.ShowSubForm(new ProductDetailsForm(producto, true, db));
                }
                else //MostrarDetallesProducto
                {
                    Common.ShowSubForm(new ProductDetailsForm(producto, false, db));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void ActualizarNumeroProductos()
        {
            // Cuenta los productos en la base de datos
            int numeroProductos = db.Producto.Count();
            // Actualiza el texto del Label
            NumeroProductosLabel.Text = "Products (" + numeroProductos.ToString() + "/" + db.PlanSuscripcion.Select(p => p.Productos).FirstOrDefault().ToString() + ")";
        }
    }
}
