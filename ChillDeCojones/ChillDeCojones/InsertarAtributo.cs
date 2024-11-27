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
                MessageBox.Show("ERROR: " + ex.Message);
            }



        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una nueva instancia de AtributoUsuario  


                if (string.IsNullOrWhiteSpace(tName.Text))
                {
                    MessageBox.Show("ERROR: The name cannot be empty.");
                }
                else if (db.AtributoUsuario.Any(a => a.NAME.Equals(tName.Text, StringComparison.OrdinalIgnoreCase))
                    || Enum.GetNames(typeof(TipoAtributoSistema)).Any(nombre => nombre.Equals(tName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("ERROR: The name is already in use");
                    tName.Text = "";
                }
                else
                {
                    AtributoUsuario nuevoAtributo = new AtributoUsuario();
                    nuevoAtributo.TYPE = cbType.SelectedItem.ToString();
                    nuevoAtributo.NAME = tName.Text;
                    db.AtributoUsuario.Add(nuevoAtributo);
                    db.SaveChanges();
                    MessageBox.Show("Attribute added succesfully");

                    // Cerrar el formulario después de agregar
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR trying to add the attribute: " + ex.Message);
            }

            AtributoInsertado?.Invoke(this, EventArgs.Empty);

        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Impide que el carácter se muestre en el TextBox
            }
        }
    }
}
