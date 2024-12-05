using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public partial class Dashboard : Form
    {
        private grupo02DBEntities db = new grupo02DBEntities();
        private InformeDeLaCuenta informeDeLaCuenta;

        public Dashboard()
        {
            InitializeComponent();

            informeDeLaCuenta = new InformeDeLaCuenta
            {
                Nombre = "ChillDeCojones",
                FechaCreacion = DateTime.Now,
                NumeroProductos = db.Producto.Count(),
                NumeroCategorias = db.CategoriaProducto.Count(),
                NumeroAtributos = db.AtributoUsuario.Count(),
                NumeroRelaciones = db.Relacion.Count()
            };

            numeroProductos.Text = informeDeLaCuenta.NumeroProductos.ToString();
            numeroCategorias.Text = informeDeLaCuenta.NumeroCategorias.ToString();
            numeroAtributos.Text = informeDeLaCuenta.NumeroAtributos.ToString();
            numeroRelaciones.Text = informeDeLaCuenta.NumeroRelaciones.ToString();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            // Convertir el objeto a una cadena JSON
            string json = JsonSerializer.Serialize(informeDeLaCuenta, new JsonSerializerOptions
            {
                WriteIndented = true // Formatear el JSON para que sea legible
            });

            // Crear un cuadro de diálogo para guardar el archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save Account Data",
                Filter = "JSON Files (*.json)|*.json", // Filtrar por archivos .json
                DefaultExt = "json", // Extensión predeterminada
                FileName = "Account Data.json" // Nombre sugerido
            };

            // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó una ruta
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("El archivo se guardó correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
