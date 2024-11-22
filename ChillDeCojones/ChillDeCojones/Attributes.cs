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
    public enum TipoAtributo
    {
        Text,
        Number,
        Date,
        Image
    }

    public partial class Attributes : Form
    {
        public Attributes()
        {
            InitializeComponent();
        }

        private void Attributes_Load(object sender, EventArgs e)
        {
            label1.Text = ObtenerIdAtributoSistema(TipoAtributo.Image).ToString();
        }

        public int ObtenerIdAtributoSistema(TipoAtributo tipoAtributo)
        {
            int id;
            grupo02DBEntities db = new grupo02DBEntities();
            string nombreTipoAtributo = Enum.GetName(typeof(TipoAtributo), tipoAtributo);
            var comando = from atributo in db.AtributoSistema where atributo.TYPE.Equals(nombreTipoAtributo) select atributo.ID;
            if (comando.ToList().Count() > 0)
            {
                id = comando.First();
            }
            else
            {
                id = -1;
            }
            return id;
        }
    }
}
