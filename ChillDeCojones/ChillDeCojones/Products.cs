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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MostrarListaProductosV2Optimizada();
            MostrarListaProductos();
        }

        private void MostrarListaProductos()
        {
            listaProductosDataGridView.SuspendLayout();
            using (grupo02DBEntities db = new grupo02DBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false; // Desactiva Lazy Loading
                List<Producto> productos = new List<Producto>();
                productos = db.Producto.ToList();

                foreach (Producto producto in productos)
                {
                    byte[] thumbailBytes = Attributes.ObtenerValorAtributoSistema(producto, TipoAtributoSistema.thumbnail, db);
                    Image thumbail = null;
                    if (thumbailBytes != null)
                    {
                        thumbail = Convertidor.BytesToImage(thumbailBytes);
                    }

                    byte[] skuBytes = Attributes.ObtenerValorAtributoSistema(producto, TipoAtributoSistema.SKU, db);
                    string sku = "(Sin SKU)";
                    if (skuBytes != null)
                    {
                        sku = Convertidor.BytesToString(skuBytes);
                    }

                    byte[] gtinBytes = Attributes.ObtenerValorAtributoSistema(producto, TipoAtributoSistema.GTIN, db);
                    string gtin = "(Sin GTIN)";
                    if (gtinBytes != null)
                    {
                        gtin = Convertidor.BytesToString(gtinBytes);
                    }

                    listaProductosDataGridView.Rows.Add(
                        thumbail,
                        sku,
                        gtin,
                        producto.LABEL,
                        producto.FECHAMODIFICACION,
                        producto.FECHACREACION
                    );
                }
            }
            listaProductosDataGridView.ResumeLayout();
        }

        private void MostrarListaProductosV2Optimizada()
        {
            using (grupo02DBEntities db = new grupo02DBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Optimización de la consulta
                var productos = db.Producto
                    .Select(p => new
                    {
                        Producto = p,
                        Thumbnail = p.ValorAtributoSistema.FirstOrDefault(v => v.ID_ATRIBUTOSISTEMA == (int)TipoAtributoSistema.thumbnail),
                        SKU = p.ValorAtributoSistema.FirstOrDefault(v => v.ID_ATRIBUTOSISTEMA == (int)TipoAtributoSistema.SKU),
                        GTIN = p.ValorAtributoSistema.FirstOrDefault(v => v.ID_ATRIBUTOSISTEMA == (int)TipoAtributoSistema.GTIN)
                    })
                    .ToList();

                // Suspender el renderizado para mejorar el rendimiento
                listaProductosDataGridView.SuspendLayout();

                foreach (var item in productos)
                {
                    Producto producto = item.Producto;

                    // Convertir atributos con las optimizaciones necesarias
                    byte[] thumbnailBytes = item.Thumbnail?.VALOR;
                    Image thumbnail = thumbnailBytes != null ? Convertidor.BytesToImage(thumbnailBytes) : null;

                    byte[] skuBytes = item.SKU?.VALOR;
                    string sku = skuBytes != null ? Convertidor.BytesToString(skuBytes) : "(Sin SKU)";

                    byte[] gtinBytes = item.GTIN?.VALOR;
                    string gtin = gtinBytes != null ? Convertidor.BytesToString(gtinBytes) : "(Sin GTIN)";

                    // Añadir fila a la vista
                    listaProductosDataGridView.Rows.Add(
                        thumbnail,
                        sku,
                        gtin,
                        producto.LABEL,
                        producto.FECHAMODIFICACION,
                        producto.FECHACREACION
                    );
                }

                // Reanudar el renderizado
                listaProductosDataGridView.ResumeLayout();
            }
        }


        private void newProductButton_Click(object sender, EventArgs e)
        {
            Common.ShowSubForm(new ProductDetails());
        }
    }
}
