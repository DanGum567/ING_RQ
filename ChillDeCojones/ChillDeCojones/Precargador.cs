using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ChillDeCojones
{
    internal class Precargador
    {
        private static Precargador instance;
        private ConcurrentDictionary<int, Producto> productosEnMemoria;
        ///(int,int) => (id_atributo, id_producto)
        private ConcurrentDictionary<(int, int), byte[]> atributosEnMemoria;

        public Precargador()
        {
            instance = this;
            productosEnMemoria = new ConcurrentDictionary<int, Producto>();
            atributosEnMemoria = new ConcurrentDictionary<(int, int), byte[]>();

            var contextoTemporal = new grupo02DBEntities();
            foreach (Producto producto in contextoTemporal.Producto.ToList())
            {
                new Thread(() =>
                {
                    int idProducto = producto.ID;
                    var contextoHilo = new grupo02DBEntities();
                    contextoHilo.Configuration.LazyLoadingEnabled = false;
                    Producto productoPrecargado = contextoHilo.Producto.Find(idProducto);
                    if (productoPrecargado != null)
                    {
                        productosEnMemoria.TryAdd(idProducto, productoPrecargado);
                        //MessageBox.Show("Se ha precargado correctamente el producto con ID " + idProducto);
                    }
                    contextoHilo.Dispose();

                }).Start();
            }

            foreach (ValorAtributoSistema atributo in contextoTemporal.ValorAtributoSistema.ToList())
            {
                new Thread(() =>
                {
                    int idAtributoSistema = atributo.ID_ATRIBUTOSISTEMA;
                    int idProducto = atributo.ID_PRODUCTO;
                    var contextoHilo = new grupo02DBEntities();
                    contextoHilo.Configuration.LazyLoadingEnabled = false;
                    ValorAtributoSistema atributoPrecargado = contextoHilo.ValorAtributoSistema.Find(idAtributoSistema, idProducto);
                    if (atributoPrecargado != null)
                    {
                        (int, int) tuplaClave = (idAtributoSistema, idProducto);
                        atributosEnMemoria.TryAdd(tuplaClave, atributoPrecargado.VALOR);
                        //MessageBox.Show("Se ha precargado correctamente el valor de atributo con ID de atributo " + idAtributoSistema + " y ID de producto " + idProducto);
                    }
                    contextoHilo.Dispose();

                }).Start();
            }
        }

        public static Producto GetProductoEnMemoria(int idProducto)
        {
            instance.productosEnMemoria.TryGetValue(idProducto, out Producto producto);
            return producto;
        }

        public static byte[] GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema tipoAtributo, int idProducto)
        {
            (int, int) tuplaClave = (AtributoManager.ObtenerAtributoSistema(tipoAtributo, new grupo02DBEntities()).ID, idProducto);
            instance.atributosEnMemoria.TryGetValue(tuplaClave, out byte[] bytesAtributo);
            return bytesAtributo;
        }
    }
}
