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
    public partial class ModificarValorAtributoUsuario : Form
    {

        public event EventHandler AtributoModificado;
        AtributoUsuario atributoUsuario;
        Producto producto;
        grupo02DBEntities db;
        public ModificarValorAtributoUsuario(AtributoUsuario atributoUsuario, Producto producto, grupo02DBEntities contexto)
        {
            InitializeComponent();
            this.producto = producto;
            this.atributoUsuario = atributoUsuario;
            this.db = contexto;
        }

        private void ModificarValorAtributoUsuario_Load(object sender, EventArgs e)
        {
            var valor = db.ValorAtributoUsuario.Find(atributoUsuario.ID, producto.ID);
            if (valor != null)
            {
                var tipoValor = (TipoAtributoUsuario)Enum.Parse(typeof(TipoAtributoUsuario), atributoUsuario.TYPE);
                TextBoxValue.Text = AtributoManager.ConvertirBytesAAtributo(tipoValor, valor.VALOR).ToString();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            TipoAtributoUsuario tipoAtributoUsuario = (TipoAtributoUsuario)Enum.Parse(typeof(TipoAtributoUsuario), atributoUsuario.TYPE);
            object valor = null;
            try
            {
                switch (tipoAtributoUsuario)
                {
                    case TipoAtributoUsuario.Number:
                        valor = float.Parse(TextBoxValue.Text);
                        break;
                    case TipoAtributoUsuario.Text:
                        valor = TextBoxValue.Text;
                        break;
                    case TipoAtributoUsuario.Date:
                        valor = DateTime.Parse(TextBoxValue.Text);
                        break;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Attribute format is not correct", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AtributoManager.AñadirOActualizarValorAtributoUsuario(atributoUsuario.NAME, producto, db, valor);

            AtributoModificado?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void ButtonDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
