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
        public Integracion()
        {
            InitializeComponent();
        }

        private void cargarProductos()
        {

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
            ConfiguracionExportacion configuracionExport = new ConfiguracionExportacion();
            configuracionExport.ShowDialog();

            //Comprobamos que hay almenos 1 producto en la cuenta.
            int num_products = db.Producto.Count();
            if (num_products == 0)
            {
            }
            else
            {
                MessageBox.Show("Error: The account does not have products.");
            }


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
