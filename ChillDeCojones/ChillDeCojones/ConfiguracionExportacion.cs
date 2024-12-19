
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ChillDeCojones
{
    public partial class ConfiguracionExportacion : Form
    {
        List<Producto> productosAExportar;
        grupo02DBEntities1 db;
        private EleccionesConfiguracionExportacion elecciones = new EleccionesConfiguracionExportacion();

        public ConfiguracionExportacion(List<Producto> productos)
        {
            InitializeComponent();
            // Inicializamos el contenedor de entidades:
            db = new grupo02DBEntities1();
            //Obtenemos los productos que queremos exportar
            productosAExportar = productos;
        }

        private void ConfiguracionExportacion_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuramos el dataGridView1:

                dataGridView1.Rows.Add("SKU", "SKU");
                dataGridView1.Rows.Add("Title", "Label");
                dataGridView1.Rows.Add("Fullfield by", "ChillDeCojones");
                dataGridView1.Rows.Add("Amazon SKU");
                dataGridView1.Rows.Add("Price");
                dataGridView1.Rows.Add("OfferPrime");

                //Añadimos un combobox para el atributo AMazon SKU:

                DataGridViewComboBoxCell amazonSKU = new DataGridViewComboBoxCell();
                amazonSKU.DataSource = new List<string> { "SKU", "GTIN" };

                //Añadimos comboboc al datagridview:
                dataGridView1.Rows[3].Cells["YourAttribute"] = amazonSKU;
                amazonSKU.Value = amazonSKU.Items[1].ToString(); // el valor por defecto es False
                string nombreAmazonSKU = amazonSKU.Value.ToString();
                elecciones.amazonSKU = db.AtributoSistema.First(atr => atr.NAME.Equals(nombreAmazonSKU));

                //Añadimos un combobox para el atributo Price:

                DataGridViewComboBoxCell price = new DataGridViewComboBoxCell();
                price.DataSource = db.AtributoUsuario.Where(atr => atr.TYPE.Equals("Number")).ToList();
                price.DisplayMember = "NAME";
                //Añadimos combobox al dataGridView:
                dataGridView1.Rows[4].Cells["YourAttribute"] = price;
                price.Value = price.Items[0].ToString(); // Seleccionamos el primer atributo del tipo Number
                string nombrePrice = price.Value.ToString();
                elecciones.price = db.AtributoUsuario.First(atr => atr.NAME.Equals(nombrePrice));

                //Añadimos combobox para el atributo OfferPrime:
                DataGridViewComboBoxCell offerprime = new DataGridViewComboBoxCell();
                offerprime.DataSource = new List<string> { "false", "true" };

                //Añadimos comboboc al datagridview:
                dataGridView1.Rows[5].Cells["YourAttribute"] = offerprime;
                offerprime.Value = offerprime.Items[0].ToString(); // el valor por defecto es False
                elecciones.offerPrime = bool.Parse(offerprime.Value.ToString());

                // Configuramos el dataGridView2:

                // Añadimos los atributos opcionales:
                dataGridView2.Rows.Add("Description");
                dataGridView2.Rows.Add("Variation Option");
                dataGridView2.Rows.Add("Image URL");
                dataGridView2.Rows.Add("Alt Image Text");
                dataGridView2.Rows.Add("PDP URL");

                //Añadimos los ComboBoxes:

                List<string> atributosUsuario = new List<string>();

                foreach (AtributoUsuario a in db.AtributoUsuario)
                {
                    atributosUsuario.Add(a.ToString());
                }

                atributosUsuario.Add("None");

                DataGridViewComboBoxCell description = new DataGridViewComboBoxCell();
                description.DataSource = atributosUsuario;
                // description.DisplayMember = "NAME";
                dataGridView2.Rows[0].Cells["YourAttribute2"] = description;
                dataGridView2.Rows[0].Cells["YourAttribute2"].Value = "None";


                DataGridViewComboBoxCell variationOption = new DataGridViewComboBoxCell();

                variationOption.DataSource = atributosUsuario;
                //variationOption.DisplayMember = "NAME";
                dataGridView2.Rows[1].Cells["YourAttribute2"] = variationOption;
                dataGridView2.Rows[1].Cells["YourAttribute2"].Value = "None";



                DataGridViewComboBoxCell imageURL = new DataGridViewComboBoxCell();
                imageURL.DataSource = atributosUsuario;
                //imageURL.DisplayMember = "NAME";
                dataGridView2.Rows[2].Cells["YourAttribute2"] = imageURL;
                dataGridView2.Rows[2].Cells["YourAttribute2"].Value = "None";



                DataGridViewComboBoxCell altImageText = new DataGridViewComboBoxCell();
                altImageText.DataSource = atributosUsuario;
                //altImageText.DisplayMember = "NAME";
                dataGridView2.Rows[3].Cells["YourAttribute2"] = altImageText;
                dataGridView2.Rows[3].Cells["YourAttribute2"].Value = "None";



                DataGridViewComboBoxCell pdpURL = new DataGridViewComboBoxCell();
                pdpURL.DataSource = atributosUsuario;
                //pdpURL.DisplayMember = "NAME";
                dataGridView2.Rows[4].Cells["YourAttribute2"] = pdpURL;
                dataGridView2.Rows[4].Cells["YourAttribute2"].Value = "None";


            }
            catch (ArgumentException error)
            {
                MessageBox.Show(error.Message);
            }
        }
        // Para que todas las celdas excepto ComboBoxes sean ReadOnly
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Verificar si la celda es un ComboBox
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
            {
                // Permitir la edición solo si la celda es un ComboBox
                dataGridView1.ReadOnly = false;
            }
            else
            {
                // Evitar la edición en otras celdas
                e.Cancel = true;
            }
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Verificar si la celda es un ComboBox
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
            {
                // Permitir la edición solo si la celda es un ComboBox
                dataGridView2.ReadOnly = false;
            }
            else
            {
                // Evitar la edición en otras celdas
                e.Cancel = true;
            }
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            bool respuestaError = false;
            //FALSE = NO PREGUNTADO, TRUE = CONTINUAR EXPORTANDO LOS QUE TIENEN PRECIO, YA PREGUNTADO

            // Datos de ejemplo
            string[] headers = { "SKU", "Title", "Fulfilled by", "Amazon SKU", "Price", "OfferPrime"}; // , "Description", "Variation Option", "Image URL", "Alt Image Text", "PDP URL" 

            // Matriz de producto - cabeceras
            string[,] datosObligatorios = new string[productosAExportar.Count, headers.Length];

            // Lista para almacenar solo los productos válidos (sin precio -1)
            List<string[]> productosFiltrados = new List<string[]>();

            for (int i = 0; i < productosAExportar.Count; ++i)
            {
                // Variables de Producto
                DateTime fechaCreacion;
                DateTime fechaModificacion;
                int ID;

                // Cargamos variables del producto para mostrarlas
                fechaCreacion = (DateTime)productosAExportar[i].FECHACREACION;
                fechaModificacion = (DateTime)productosAExportar[i].FECHAMODIFICACION;
                ID = productosAExportar[i].ID;

                // SKU = SKU (0)
                byte[] skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, productosAExportar[i], db);
                string SKU = null;
                if (skuBytes != null)
                {
                    SKU = Convertidor.BytesAString(skuBytes);
                }
                datosObligatorios[i, 0] = SKU;

                // TITLE = LABEL (1)
                string label = productosAExportar[i].LABEL;
                if (label.Contains(","))
                {
                    label = "'" + label + "'";
                }
                datosObligatorios[i, 1] = label;

                // FULFILLED BY = ACCOUNT NAME (2)
                string accountName = Dashboard.instance.informeDeLaCuenta.account_name;
                if (accountName.Contains(","))
                {
                    accountName = "'" + accountName + "'";
                }
                datosObligatorios[i, 2] = accountName;

                // AMAZON SKU = SKU/GTIN (3)
                string amazonSKU = null;
                if (elecciones.amazonSKU.NAME == TipoAtributoSistema.GTIN.ToString())
                {
                    byte[] gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, productosAExportar[i], db);
                    if (gtinBytes != null)
                    {
                        amazonSKU = Convertidor.BytesAString(gtinBytes);
                    }
                }
                else
                {
                    amazonSKU = Convertidor.BytesAString(skuBytes);
                }
                datosObligatorios[i, 3] = amazonSKU;

                // PRICE = PRICE (4)
                float price = 0f;

                var query = db.ValorAtributoUsuario.Find(elecciones.price.ID, productosAExportar[i].ID);
                if (query == null)
                {
                    if (respuestaError == false)
                    {
                        DialogResult result = MessageBox.Show($"Some products do not have a {elecciones.price.NAME} attribute, do you want to export the ones that do?", "Missing attribute", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            respuestaError = true;
                        }
                        else
                        {
                            return;
                        }
                    }

                    price = -1f; // Asignamos -1 si no se encuentra el precio
                }
                else
                {
                    price = Convertidor.BytesAFloat(query.VALOR);
                }
                datosObligatorios[i, 4] = price.ToString().Replace(",", ".");



                //OfferPrime

                datosObligatorios[i, 5] = elecciones.offerPrime ? "true" : "false";



                // Si el precio es -1, omitimos este producto de la lista
                if (price != -1f)
                {
                    // Solo agregar productos cuyo precio no sea -1
                    string[] filaCompleta = new string[headers.Length];
                    for (int columna = 0; columna < headers.Length; columna++)
                    {
                        filaCompleta[columna] = datosObligatorios[i, columna];
                    }
                    productosFiltrados.Add(filaCompleta);
                }




            }

            // Crear el archivo CSV
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

                    // Escribir los datos de los productos filtrados
                    foreach (var fila in productosFiltrados)
                    {
                        writer.WriteLine(string.Join(",", fila));
                    }
                }

                // Abrir el archivo CSV después de exportarlo
                Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
            }
        }




        //atributos obligatorios datagridview
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreAmazonSKU = dataGridView1.Rows[3].Cells["YourAttribute"].Value.ToString();
            elecciones.amazonSKU = db.AtributoSistema.First(atr => atr.NAME.Equals(nombreAmazonSKU));

            string nombrePrice = dataGridView1.Rows[4].Cells["YourAttribute"].Value.ToString();
            elecciones.price = db.AtributoUsuario.First(atr => atr.NAME.Equals(nombrePrice));

            DataGridViewComboBoxCell offerprime = (DataGridViewComboBoxCell)dataGridView1.Rows[5].Cells["YourAttribute"];
            elecciones.offerPrime = Convert.ToBoolean(offerprime.Value);
        }


        //Atributos opcionales datagridview
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == 0 && e.ColumnIndex == 1)
            {
                //Description
                if (dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value != null && dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value.ToString() != "None")
                {
                    elecciones.description = db.AtributoUsuario.First(atr => atr.NAME.Equals(dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value));
                }
            }
            else if (e.RowIndex == 1 && e.ColumnIndex == 1)
            {
                //Description
                if (dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value != null && dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value.ToString() != "None")
                {
                    elecciones.variationOption = db.AtributoUsuario.First(atr => atr.NAME.Equals(dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value));
                }
            }
            else if (e.RowIndex == 2 && e.ColumnIndex == 1)
            {
                //Description
                if (dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value != null && dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value.ToString() != "None")
                {
                    elecciones.imageURL = db.AtributoUsuario.First(atr => atr.NAME.Equals(dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value));
                }
            }
            else if (e.RowIndex == 3 && e.ColumnIndex == 1)
            {
                //Description
                if (dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value != null && dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value.ToString() != "None")
                {
                    elecciones.altImageText = db.AtributoUsuario.First(atr => atr.NAME.Equals(dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value));
                }
            }
            else if (e.RowIndex == 4 && e.ColumnIndex == 1)
            {
                //Description
                if (dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value != null && dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value.ToString() != "None")
                {
                    elecciones.pdpURL = db.AtributoUsuario.First(atr => atr.NAME.Equals(dataGridView1.SelectedRows[0].Cells["YourAttribute2"].Value));
                }
            }
        }
    }
}
