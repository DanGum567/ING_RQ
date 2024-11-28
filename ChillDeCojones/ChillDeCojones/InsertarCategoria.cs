using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChillDeCojones
{
    public partial class InsertarCategoria : Form
    {
        public event EventHandler CategoriaInsertada;

        public InsertarCategoria()
        {
            InitializeComponent();
           
        }


        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                // Crear una nueva instancia de CateogiraProducto
                CategoriaProducto nuevaCategoria = new CategoriaProducto();
                if (string.IsNullOrWhiteSpace(tName.Text))
                {
                    MessageBox.Show("ERROR: name cannot be empty");
                    
                }
                else if (db.CategoriaProducto.Any(x => x.NAME.Equals(tName.Text))
                    || Enum.GetNames(typeof(TipoAtributoSistema)).Any(nombre => nombre.Equals(tName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("ERROR: The name is already in use");
                    tName.Text = "";
                   
                }
                else
                {
                    nuevaCategoria.NAME = tName.Text;
                    db.CategoriaProducto.Add(nuevaCategoria);
                    db.SaveChanges();

                    // Cerrar el formulario después de agregar
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to add the category: " + ex.Message);
            }

            CategoriaInsertada?.Invoke(this, EventArgs.Empty);
           // El formulario se cierra despues de aceptar
        }
        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
