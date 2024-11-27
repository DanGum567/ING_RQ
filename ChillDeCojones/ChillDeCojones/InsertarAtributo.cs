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
        grupo02DBEntities db = new grupo02DBEntities();
        public event EventHandler AtributoInsertado;
        public InsertarAtributo()
        {
            InitializeComponent();
        }

        private void InsertarAtributo_Load(object sender, EventArgs e)
        {
            try
            {
                cbType.DataSource = Enum.GetValues(typeof(TipoAtributoUsuario)); // Se crea el desplegable del Type de atributo
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }


        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                // Crear una nueva instancia de AtributoUsuario
                AtributoUsuario nuevoAtributo = new AtributoUsuario();
                nuevoAtributo.TYPE = cbType.SelectedItem.ToString();
                nuevoAtributo.NAME = tName.Text;
                bool atributoRepetido = db.AtributoUsuario.Any(a => a.NAME == nuevoAtributo.NAME);

                if (atributoRepetido)
                {
                    MessageBox.Show("ERROR: An attribute with that name already exists.");
                    return; // No continuar con la inserción si el atributo está repetido
                }
                db.AtributoUsuario.Add(nuevoAtributo);
                db.SaveChanges();

                MessageBox.Show("Added attribute succesfully");

                // Cerrar el formulario después de agregar
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR adding this attribute: " + ex.Message);
            }

            AtributoInsertado?.Invoke(this, EventArgs.Empty);
            this.Close(); // El formulario se cierra despues de aceptar
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
