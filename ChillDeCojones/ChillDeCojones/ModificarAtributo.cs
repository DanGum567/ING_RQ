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
    public partial class ModificarAtributo : Form
    {
        grupo02DBEntities db = new grupo02DBEntities();
        AtributoUsuario atributo;
        public event EventHandler AtributoModificado;
        public ModificarAtributo(int idAtributo)
        {
            InitializeComponent();
            atributo = db.AtributoUsuario.Find(idAtributo);
        }

        private void ModificarAtributo_Load(object sender, EventArgs e)
        {

            tName.Text = atributo.NAME;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tName.Text))
            {
                MessageBox.Show("ERROR: The name cannot be empty.");
            }
            else if (db.AtributoUsuario.Any(a => a.NAME.Equals(tName.Text)) ||
                 Enum.GetNames(typeof(TipoAtributoSistema)).Any(nombre => nombre.Equals(tName.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("ERROR: The name is already in use");
                tName.Text = "";
            }
            else
            {
                atributo.NAME = tName.Text;
                db.SaveChanges();
                this.Close();
            }
            AtributoModificado?.Invoke(this, EventArgs.Empty);

        }

        private void ButtonDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
