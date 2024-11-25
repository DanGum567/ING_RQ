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
    public partial class InsertarAtributo : Form
    {
        
        public event EventHandler AtributoInsertado;
        public event EventHandler CerrarPopUp;
        public InsertarAtributo()
        {
            InitializeComponent();
        }

        private void InsertarAtributo_Load(object sender, EventArgs e)
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                cbType.DataSource = Enum.GetValues(typeof(TipoAtributo)); // Se crea el desplegable del Type de atributo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                // Crear una nueva instancia de AtributoUsuario
                AtributoUsuario nuevoAtributo = new AtributoUsuario();
                nuevoAtributo.TYPE = cbType.SelectedItem.ToString();
                nuevoAtributo.NAME = tName.Text;

                db.AtributoUsuario.Add(nuevoAtributo);
                db.SaveChanges();

                MessageBox.Show("Atributo agregado correctamente.");

                // Cerrar el formulario después de agregar
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el atributo: " + ex.Message);
            }

            AtributoInsertado?.Invoke(this, EventArgs.Empty);
            this.Close(); // El formulario se cierra despues de aceptar
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            CerrarPopUp?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void InsertarAtributo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarPopUp?.Invoke(this, EventArgs.Empty);
        }
    }
}
