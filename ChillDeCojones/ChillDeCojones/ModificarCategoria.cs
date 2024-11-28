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
    public partial class ModificarCategoria : Form
    {
        grupo02DBEntities db = new grupo02DBEntities();
        CategoriaProducto categoria;
        public event EventHandler CategoriaModificada;

        public ModificarCategoria(int idCategoria)
        {
            InitializeComponent();
            categoria = db.CategoriaProducto.Find(idCategoria);
        }

        private void ModificarCategoria_Load(object sender, EventArgs e)
        {
            tName.Text = categoria.NAME;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tName.Text))
            {
                MessageBox.Show("ERROR: name cannot be empty");

            }
            else if (db.CategoriaProducto.Any(c => c.NAME.Equals(tName.Text))
                || Enum.GetNames(typeof(TipoAtributoSistema)).Any(nombre => nombre.Equals(tName.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("ERROR: The name is already in use");
                tName.Text = "";
            }
            else
            {
                categoria.NAME = tName.Text;
                db.SaveChanges();                
                this.Close();
            }
            CategoriaModificada?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
