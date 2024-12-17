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
        private grupo02DBEntities1 db = new grupo02DBEntities1();
        public InformeDeLaCuenta informeDeLaCuenta;
        public static Dashboard instance;

        public Dashboard()
        {
            instance = this;
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            informeDeLaCuenta = new InformeDeLaCuenta
            {
                account_name = "ChillDeCojones",
                creation_date = DateTime.Now,
                num_products = db.Producto.Count(),
                num_categories = db.CategoriaProducto.Count(),
                num_attributes = db.AtributoUsuario.Count(),
                num_relationships = db.RelacionProducto.Count()
            };
            var planSuscripcion = db.PlanSuscripcion.FirstOrDefault(x => x.Nombre.Equals("Free"));
            numeroProductos.Text = "Products: " + informeDeLaCuenta.num_products.ToString() + "/" + planSuscripcion.Productos;
            numeroCategorias.Text = "Categories: " + informeDeLaCuenta.num_categories.ToString() + "/" + planSuscripcion.CategoriasProducto;
            numeroAtributos.Text = "Attributes: " + informeDeLaCuenta.num_attributes.ToString() + "/" + planSuscripcion.Atributos;
            numeroRelaciones.Text = "Relationships: " + informeDeLaCuenta.num_relationships.ToString() + "/" + planSuscripcion.Relaciones;
            createdDateLabel.Text = "Creation Date: " + informeDeLaCuenta.creation_date.ToShortDateString();
            accountNameLabel.Text = "Account Name: " + informeDeLaCuenta.account_name;
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
