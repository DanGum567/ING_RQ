using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Runtime.Remoting.Messaging;

namespace ChillDeCojones
{
    public class UnSoloProductoNoTieneAtributoNumericoException : Exception
    {
    }

    public class NoExisteAtributoNumericoParaPrecioException : Exception
    {
    }

    public partial class Integracion : Form
    {
        private grupo02DBEntities1 db = new grupo02DBEntities1();
        private List<Producto> productosFiltrados;
        public Integracion()
        {
            InitializeComponent();

            //Cargamos combobox
            cbCategory.DataSource = db.CategoriaProducto.ToList();

            //Agregamos columnas al dataGridView:

            //Thumbnail:
            DataGridViewImageColumn columna1 = new DataGridViewImageColumn();
            columna1.HeaderText = "thumbnail";
            columna1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centramos el texto
            columna1.Name = "thumbnail";
            columna1.Width = 200;
            columna1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
            //ID:
            DataGridViewTextBoxColumn columna2 = new DataGridViewTextBoxColumn();
            columna2.HeaderText = "ID";
            columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centramos el texto
            columna2.Name = "id";
            columna2.Width = 200;

            //SKU:
            DataGridViewTextBoxColumn columna3 = new DataGridViewTextBoxColumn();
            columna3.HeaderText = "SKU";
            columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centramos el texto
            columna3.Name = "sku";
            columna2.Width = 200;

            //Label:
            DataGridViewTextBoxColumn columna4 = new DataGridViewTextBoxColumn();
            columna4.HeaderText = "Label";
            columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centramos el texto
            columna4.Name = "label";
            columna4.Width = 200;


            // Añadir la columna al DataGridView
            dataGridView1.Columns.Add(columna1);
            dataGridView1.Columns.Add(columna2);
            dataGridView1.Columns.Add(columna3);
            dataGridView1.Columns.Add(columna4);

            // Aumentamos la altura de las filas, para que se muestren bien las imagenes:

            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.ReadOnly = true; // No podemos modificar dataGridView
        }

        private void cargarProductos()
        {
            if (cbCategory.SelectedItem != null)
            {
                //Categoria seleccionada
                CategoriaProducto categoriaSeleccionada = (CategoriaProducto)cbCategory.SelectedItem;

                productosFiltrados = categoriaSeleccionada.Producto.ToList();
                dataGridView1.Rows.Clear();
                dataGridView1.SuspendLayout();


                foreach (Producto cargadoJustoAhora in productosFiltrados)
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


                    dataGridView1.Rows.Add(
                        thumbail,
                        ID,
                        sku,
                        label
                    );

                    dataGridView1.Columns["ID"].Visible = false;


                    dataGridView1.ResumeLayout();
                    dataGridView1.ClearSelection();// Se deselecciona el primer elemento

                    List<AtributoUsuario> tresPrimeros = db.AtributoUsuario.Take(3).ToList();
                    
                    int fila = 0;
                    int columnIndex = 3; // Los atributos de usuario empiezan desde el índice 3
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
                                //Comprobamos si la columna ya existe
                                if (!dataGridView1.Columns.Contains(atributoUsuario.NAME))
                                {
                                    //Si no existe, la añadimos
                                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn { HeaderText = atributoUsuario.NAME, Name = atributoUsuario.NAME.ToLower() };
                                    dataGridView1.Columns.Add(column);
                                }
                                dataGridView1.Rows[fila].Cells[atributoUsuario.NAME].Value = valorConvertido;
                            }
                        }
                    }
                    ++fila;
                }
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
           
        }
        private void bClearCategory_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void bClearDate_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cbCategory_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void bExport_Click(object sender, EventArgs e)
        {

            //Comprobamos que hay almenos 1 producto en la cuenta.
            int num_products = db.Producto.Count();
            if (num_products == 0)
            {
                MessageBox.Show("There is no product associated to the account !!!");
                return;
            }else if(dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("There are no filtered products");
                return;
            }
           
            ConfiguracionExportacion configuracionExport = new ConfiguracionExportacion(productosFiltrados);
            configuracionExport.ShowDialog();
            try
            {
                Exportar(configuracionExport);
            }
            catch (UnSoloProductoNoTieneAtributoNumericoException)
            {
                // MessageBox.Show("ERROR: " + ex.Message);
            }

        }


        private void Exportar(ConfiguracionExportacion configuracionExportacion)
        {
            // Datos de ejemplo
            string[] headers = { "SKU", "Title", "Fulfilled by", "Amazon SKU", "Price", "Offer Prime" };
            string[][] data = {
            new string[] { "Ana", "25", "Madrid" },
            new string[] { "Luis", "30", "Barcelona" },
            new string[] { "María", "28", "Valencia" }
            };

            //obtenemos los productos
            List<Producto> listaProductos = db.Producto.ToList();
            foreach (Producto producto in listaProductos)
            {
                //Sku = sku
                //title = label
                //fulfilled by = account name
                //amazon sku = gtin
                //offer prime = false
                //price = primer atributo float o integer

                byte[] skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, producto, db);
                string SKU = Convertidor.BytesAString(skuBytes);

                byte[] gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, producto, db);
                string GTIN = Convertidor.BytesAString(gtinBytes);

                List<AtributoUsuario> listaAtributos = db.AtributoUsuario.ToList();
                AtributoUsuario primerAtributoNumerico = null;
                foreach (AtributoUsuario atributo in listaAtributos)
                {
                    if (atributo.TYPE == TipoAtributoUsuario.Number.ToString())
                    {
                        primerAtributoNumerico = atributo;
                        break;
                    }
                }

                ValorAtributoUsuario valor = db.ValorAtributoUsuario.Find(primerAtributoNumerico.ID, producto.ID);

                string sku = SKU;
                string title = producto.LABEL;
                //string fulfilledBy = Dashboard.InformeDeLaCuenta.account_name;
                string amazonSku = GTIN;
                string offerPrime = "False";
                string price;
                List<string> fila = new List<string>();

            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save Export",
                Filter = "CSV Files (*.csv)|*.csv", // Filtrar por archivos .csv
                DefaultExt = "csv", // Extensión predeterminada
                FileName = "Amazon Export.csv" // Nombre sugerido
            };

            // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó una ruta
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Escribir la cabecera
                    writer.WriteLine(string.Join(",", headers));

                    // Escribir los datos
                    foreach (var row in data)
                    {
                        writer.WriteLine(string.Join(",", row));
                    }
                }
                MessageBox.Show("El archivo se guardó correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }
    }
}
