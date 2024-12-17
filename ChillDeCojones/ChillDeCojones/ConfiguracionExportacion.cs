using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
                amazonSKU.Value = amazonSKU.Items[0].ToString(); // el valor por defecto es False
                elecciones.amazonSKU = db.AtributoSistema.First(atr => atr.NAME.Equals(amazonSKU.Value));

                //Añadimos un combobox para el atributo Price:

                DataGridViewComboBoxCell price = new DataGridViewComboBoxCell();
                price.DataSource = db.AtributoUsuario.Where(atr => atr.TYPE.Equals("Number")).ToList();
                price.DisplayMember = "NAME";
                //Añadimos combobox al dataGridView:
                dataGridView1.Rows[4].Cells["YourAttribute"] = price;
                price.Value = price.Items[0].ToString(); // Seleccionamos el primer atributo del tipo Number
                elecciones.price = (AtributoUsuario)price.Value;


                //Añadimos combobox para el atributo OfferPrime:
                DataGridViewComboBoxCell offerprime = new DataGridViewComboBoxCell();
                offerprime.DataSource = new List<string> { "false", "true" };

                //Añadimos comboboc al datagridview:
                dataGridView1.Rows[5].Cells["YourAttribute"] = offerprime;
                offerprime.Value = offerprime.Items[0].ToString(); // el valor por defecto es False
                elecciones.offerPrime = Convert.ToBoolean(offerprime.Value);

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
                if (description.Value != null && description.Value.ToString() != "None")
                {
                    elecciones.description = db.AtributoUsuario.First(atr => atr.NAME.Equals(description.Value));
                }

                DataGridViewComboBoxCell variationOption = new DataGridViewComboBoxCell();

                variationOption.DataSource = atributosUsuario;
                //variationOption.DisplayMember = "NAME";
                dataGridView2.Rows[1].Cells["YourAttribute2"] = variationOption;
                dataGridView2.Rows[1].Cells["YourAttribute2"].Value = "None";

                if (variationOption.Value != null && variationOption.Value.ToString() != "None")
                {
                    elecciones.variationOption = db.AtributoUsuario.First(atr => atr.NAME.Equals(variationOption.Value));
                }

                DataGridViewComboBoxCell imageURL = new DataGridViewComboBoxCell();
                imageURL.DataSource = atributosUsuario;
                //imageURL.DisplayMember = "NAME";
                dataGridView2.Rows[2].Cells["YourAttribute2"] = imageURL;
                dataGridView2.Rows[2].Cells["YourAttribute2"].Value = "None";
                if (imageURL.Value != null && imageURL.Value.ToString() != "None")
                {
                    elecciones.imageURL = db.AtributoUsuario.First(atr => atr.NAME.Equals(imageURL.Value));
                }


                DataGridViewComboBoxCell altImageText = new DataGridViewComboBoxCell();
                altImageText.DataSource = atributosUsuario;
                //altImageText.DisplayMember = "NAME";
                dataGridView2.Rows[3].Cells["YourAttribute2"] = altImageText;
                dataGridView2.Rows[3].Cells["YourAttribute2"].Value = "None";
                if (altImageText.Value != null && altImageText.Value.ToString() != "None")
                {
                    elecciones.altImageText = db.AtributoUsuario.First(atr => atr.NAME.Equals(altImageText.Value));
                }


                DataGridViewComboBoxCell pdpURL = new DataGridViewComboBoxCell();
                pdpURL.DataSource = atributosUsuario;
                //pdpURL.DisplayMember = "NAME";
                dataGridView2.Rows[4].Cells["YourAttribute2"] = pdpURL;
                dataGridView2.Rows[4].Cells["YourAttribute2"].Value = "None";
                if (pdpURL.Value != null && pdpURL.Value.ToString() != "None")
                {
                    elecciones.pdpURL = db.AtributoUsuario.First(atr => atr.NAME.Equals(pdpURL.Value));
                }

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
            // Datos de ejemplo
            string[] headers = { "SKU", "Title", "Fulfilled by", "Amazon SKU", "Price", "OfferPrime", "Description", "Variation Option", "Image URL", "Alt Image Text", "PDP URL" };

            // Matriz de producto - cabeceras
            string[,] datosObligatorios = new string[productosAExportar.Count, headers.Length];

            for (int i = 0; i < productosAExportar.Count; ++i)
            {
                //Variables de Producto

                int idProducto = productosAExportar[i].ID;
                string label;
                string accountName = Dashboard.instance.informeDeLaCuenta.account_name;
                DateTime fechaCreacion;
                DateTime fechaModificacion;
                int ID;

                //Comprobamos si ya se han cargado las variables de Producto anteriormente
                Producto delQueCargarVariables;
                //Producto precargadoEnMemoria = Precargador.GetProductoEnMemoria(idProducto);

                delQueCargarVariables = productosAExportar[i];


                //Cargamos variables del producto para mostrarlas
                label = delQueCargarVariables.LABEL;
                fechaCreacion = (DateTime)delQueCargarVariables.FECHACREACION;
                fechaModificacion = (DateTime)delQueCargarVariables.FECHAMODIFICACION;
                ID = delQueCargarVariables.ID;

                //-------------------------------------------------------------------------------------------

                byte[] skuBytes = null;
                byte[] gtinBytes = null;

                skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, productosAExportar[i], db);
                gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, productosAExportar[i], db);

                if (skuBytes != null)
                {
                    datosObligatorios[i, 0] = Convertidor.BytesAString(skuBytes);
                }
                if (gtinBytes != null)
                {
                    datosObligatorios[i, 3] = Convertidor.BytesAString(gtinBytes);
                }

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
                    int fila = 1; // Queremos acceder a la segunda fila (índice 1).
                    string[] filaCompleta = new string[headers.Length];

                    for (int i = 0; i < productosAExportar.Count; ++i)
                    {
                        //Copiamos la fila completa:

                        for (int columna = 0; columna < headers.Length; columna++)
                        {
                            filaCompleta[columna] = datosObligatorios[i, columna];
                        }
                        writer.WriteLine(string.Join(",", filaCompleta));
                    }
                }
                Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });

            }



            //foreach (Producto producto in productosAExportar)
            //{
            //    //Sku = sku
            //    //title = label
            //    //fulfilled by = account name
            //    //amazon sku = gtin
            //    //offer prime = false
            //    //price = primer atributo float o integer

            //    byte[] skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, producto, db);
            //    string SKU = Convertidor.BytesAString(skuBytes);

            //    byte[] gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, producto, db);
            //    string GTIN = Convertidor.BytesAString(gtinBytes);

            //    List<AtributoUsuario> listaAtributos = db.AtributoUsuario.ToList();
            //    AtributoUsuario primerAtributoNumerico = null;
            //    foreach (AtributoUsuario atributo in listaAtributos)
            //    {
            //        if (atributo.TYPE == TipoAtributoUsuario.Number.ToString())
            //        {
            //            primerAtributoNumerico = atributo;
            //            break;
            //        }
            //    }

            //    ValorAtributoUsuario valor = db.ValorAtributoUsuario.Find(primerAtributoNumerico.ID, producto.ID);

            //    string sku = SKU;
            //    string title = producto.LABEL;
            //    //string fulfilledBy = Dashboard.InformeDeLaCuenta.account_name;
            //    string amazonSku = GTIN;
            //    string offerPrime = "False";
            //    string price;
            //    List<string> fila = new List<string>();

            //}

            //SaveFileDialog saveFileDialog = new SaveFileDialog
            //{
            //    Title = "Save Export",
            //    Filter = "CSV Files (*.csv)|*.csv", // Filtrar por archivos .csv
            //    DefaultExt = "csv", // Extensión predeterminada
            //    FileName = "Amazon Export.csv" // Nombre sugerido
            //};

            //// Mostrar el cuadro de diálogo y verificar si el usuario seleccionó una ruta
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
            //    {
            //        // Escribir la cabecera
            //        writer.WriteLine(string.Join(",", headers));

            //        // Escribir los datos
            //        foreach (var row in data)
            //        {
            //            writer.WriteLine(string.Join(",", row));
            //        }
            //    }
            //    MessageBox.Show("El archivo se guardó correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
    }
}
