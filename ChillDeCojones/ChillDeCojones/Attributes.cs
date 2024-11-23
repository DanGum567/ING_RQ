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

    public enum TipoAtributoSistema
    {
        SKU,
        GTIN,
        thumbnail
    }

    public partial class Attributes : Form
    {
        public Attributes()
        {
            InitializeComponent();
        }

        private void Attributes_Load(object sender, EventArgs e)
        {

        }

        public static int ObtenerIdAtributoSistema(TipoAtributoSistema tipoAtributo)
        {
            int id;
            grupo02DBEntities db = new grupo02DBEntities();
            string nombreTipoAtributo = Enum.GetName(typeof(TipoAtributoSistema), tipoAtributo);
            var comando = from atributo in db.AtributoSistema where atributo.NAME.Equals(nombreTipoAtributo) select atributo.ID;
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

        public static void AñadirValorAtributoDelSistemaAProducto(
            TipoAtributoSistema atributoAAÑadir,
            Producto producto,
            object atributo,
            grupo02DBEntities contexto)
        {
            if (producto == null || atributo == null)
            {
                throw new ArgumentNullException("El producto o atributo no pueden ser nulos.");
            }

            int idAtributoAAñadir = ObtenerIdAtributoSistema(atributoAAÑadir);
            var atributoSistema = contexto.AtributoSistema.Find(idAtributoAAñadir);
            if (atributoSistema == null)
            {
                throw new InvalidOperationException($"No se encontró el atributo con ID {idAtributoAAñadir}");
            }

            if (contexto.Entry(producto).State == EntityState.Detached)
            {
                contexto.Producto.Attach(producto);
            }

            ValorAtributoSistema valorAtributoSistema = new ValorAtributoSistema
            {
                AtributoSistema = atributoSistema,
                Producto = producto,
                VALOR = ConvertirAtributo(atributoAAÑadir, atributo)
            };

            contexto.ValorAtributoSistema.Add(valorAtributoSistema);
            // No llamamos SaveChanges aquí; lo dejamos al nivel superior.
        }

        public static byte[] ObtenerValorAtributoSistema(Producto producto, TipoAtributoSistema tipoAtributo, grupo02DBEntities contexto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException("El producto no puede ser nulo.");
            }
            int idAtributo = ObtenerIdAtributoSistema(tipoAtributo);
            var valorAtributo = from valor in contexto.ValorAtributoSistema
                                where valor.ID_ATRIBUTOSISTEMA == idAtributo && valor.ID_PRODUCTO == producto.ID
                                select valor.VALOR;

            if (valorAtributo.Count() == 0)
            {
                return null;
            }
            return valorAtributo.FirstOrDefault();
        }


        private static byte[] ConvertirAtributo(TipoAtributoSistema tipo, object atributo)
        {
            switch (tipo)
            {
                case TipoAtributoSistema.SKU:
                    return Convertidor.StringToBytes((string)atributo);
                case TipoAtributoSistema.GTIN:
                    return Convertidor.StringToBytes((string)atributo);
                case TipoAtributoSistema.thumbnail:
                    return Convertidor.ImageToBytes((Image)atributo, System.Drawing.Imaging.ImageFormat.Png);
                default:
                    throw new NotSupportedException($"El tipo de atributo {tipo} no está soportado.");
            }
        }

    }
}
