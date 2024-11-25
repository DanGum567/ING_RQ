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
    public partial class InsertarCategoria : Form
    {
        public event EventHandler CategoriaInsertada;
        public event EventHandler CerrarPopUp;

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
                nuevaCategoria.NAME = tName.Text;

                db.CategoriaProducto.Add(nuevaCategoria);
                db.SaveChanges();

                MessageBox.Show("Category added correctly");

                // Cerrar el formulario después de agregar
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to add the category: " + ex.Message);
            }

            CategoriaInsertada?.Invoke(this, EventArgs.Empty);
            this.Close(); // El formulario se cierra despues de aceptar
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            CerrarPopUp?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void InsertarCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarPopUp?.Invoke(this, EventArgs.Empty);
        }
    }
}
