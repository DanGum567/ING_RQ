using ChillDeCojones.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public enum TipoAtributoUsuario
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

    internal class AtributoManager
    {
        /// <summary>
        /// tipoAtributo debe ser <see cref="TipoAtributoSistema"/> o <see cref="TipoAtributoUsuario"/>
        /// </summary>
        /// <param name="tipoAtributo"></param>
        /// <returns></returns>
        public static AtributoSistema ObtenerAtributoSistema(TipoAtributoSistema tipoAtributo, grupo02DBEntities contexto)
        {
            string nombreTipoAtributo = Enum.GetName(tipoAtributo.GetType(), tipoAtributo);
            return contexto.AtributoSistema.First(a => a.NAME == nombreTipoAtributo);
        }

        public static AtributoUsuario ObtenerIdDeAtributoUsuario(string nombreAtributo, grupo02DBEntities contexto)
        {
            return contexto.AtributoUsuario.First(a => a.NAME.Equals(nombreAtributo));
        }

        //public LinkedList<ValorAtributoUsuario>

        /// <summary>
        /// Esta función no llama a SaveChanges, lo debe hacer el que llama a esta función
        /// </summary>
        /// <param name="tipoAtributo"></param>
        /// <returns></returns>
        public static bool AñadirOActualizarValorAtributoSistema(TipoAtributoSistema tipoAtributo, Producto dueñoAtributoSistema, grupo02DBEntities contextoBaseDatos, object valorAtributo)
        {

            if (!(tipoAtributo == TipoAtributoSistema.thumbnail) && (dueñoAtributoSistema == null || valorAtributo == null))
            {//metete a discord que te enseñamos

                MessageBox.Show("Product and attribute must be not null.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tipoAtributo == TipoAtributoSistema.SKU)
            {

                if (valorAtributo == null || string.IsNullOrEmpty((string)valorAtributo))
                {
                    MessageBox.Show("The SKU cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (ObtenerTrueSiSKUEstaRepetido((string)valorAtributo, ObtenerListaBytesValoresAtributosSistemaExistentes(tipoAtributo, contextoBaseDatos)))
                {
                    MessageBox.Show("The SKU is duplicated.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (tipoAtributo == TipoAtributoSistema.GTIN)
            {
                if (ValidarGTIN(valorAtributo.ToString()) == false)
                {
                    return false;
                }
                if (ObtenerTrueSiGTINEstaRepetido((string)valorAtributo, ObtenerListaBytesValoresAtributosSistemaExistentes(tipoAtributo, contextoBaseDatos)))
                {
                    MessageBox.Show("The GTIN is duplicated.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (tipoAtributo == TipoAtributoSistema.thumbnail && valorAtributo == null)
            {
                valorAtributo = Resources.imagenPredeterminadaProducto;
            }

            var atributoSistema = ObtenerAtributoSistema(tipoAtributo, contextoBaseDatos);
            if (atributoSistema == null)
            {
                MessageBox.Show($"No attribute type with ID {atributoSistema.ID} was found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ValorAtributoSistema valorAtributoSistema = contextoBaseDatos.ValorAtributoSistema.Find(atributoSistema.ID, dueñoAtributoSistema.ID);


            if (valorAtributoSistema != null)
            {
                contextoBaseDatos.ValorAtributoSistema.Remove(valorAtributoSistema);
                contextoBaseDatos.SaveChanges();
            }

            ValorAtributoSistema nuevo = new ValorAtributoSistema();
            nuevo.AtributoSistema = atributoSistema;
            nuevo.Producto = dueñoAtributoSistema;
            nuevo.VALOR = ConvertirAtributoABytes(tipoAtributo, valorAtributo);
            contextoBaseDatos.ValorAtributoSistema.Add(nuevo);

            return true;

            // No llamamos SaveChanges aquí; lo dejamos al nivel superior.
        }

        /// <summary>
        /// Esta función no llama a SaveChanges, lo debe hacer el que llama a esta función
        /// </summary>
        /// <param name="tipoAtributo"></param>
        /// <returns></returns>
        public static void AñadirOActualizarValorAtributoUsuario(string nombreAtributo, Producto dueñoAtributoUsuario, grupo02DBEntities contextoBaseDatos, object valorAtributo)
        {

            var atributoUsuario = ObtenerIdDeAtributoUsuario(nombreAtributo, contextoBaseDatos);
            if (atributoUsuario == null)
            {
                MessageBox.Show($"No attribute type with given ID {atributoUsuario.ID} was found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ValorAtributoUsuario valorAtributoUsuario = contextoBaseDatos.ValorAtributoUsuario.Find(atributoUsuario.ID, dueñoAtributoUsuario.ID);

            TipoAtributoUsuario tipoAtributo = (TipoAtributoUsuario)Enum.Parse(typeof(TipoAtributoUsuario), atributoUsuario.TYPE);
            if (valorAtributoUsuario != null)
            {
                contextoBaseDatos.ValorAtributoUsuario.Remove(valorAtributoUsuario);
                contextoBaseDatos.SaveChanges();
            }
            //Estamos insertando, el valor no existía antes
            ValorAtributoUsuario nuevo = new ValorAtributoUsuario
            {
                AtributoUsuario = atributoUsuario,
                Producto = dueñoAtributoUsuario,
                VALOR = ConvertirAtributoABytes(tipoAtributo, valorAtributo)
            };
            contextoBaseDatos.ValorAtributoUsuario.Add(nuevo);

            // No llamamos SaveChanges aquí; lo dejamos al nivel superior.
        }

        /// <summary>
        /// tipoAtributo debe ser <see cref="TipoAtributoSistema"/> o <see cref="TipoAtributoUsuario"/>
        /// <para>Devuelve null si no se ha encontrado el atributo sistema en la base de datos (Por ejemplo, cuando un producto no tiene thumbail)</para>
        /// </summary>
        /// <param name="tipoAtributo"></param>
        /// <returns></returns>
        public static byte[] ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema tipoAtributo, Producto dueñoAtributoSistema, grupo02DBEntities contextoBaseDatos)
        {
            if (dueñoAtributoSistema == null)
            {
                throw new ArgumentNullException("The product cannot be null.");
            }

            int idAtributo = ObtenerAtributoSistema(tipoAtributo, contextoBaseDatos).ID;
            ValorAtributoSistema comando = contextoBaseDatos.ValorAtributoSistema.Find(idAtributo, dueñoAtributoSistema.ID);
            if (comando == null)
            {
                return null;
            }
            else
            {
                return comando.VALOR;
            }
        }

        public static LinkedList<byte[]> ObtenerListaBytesValoresAtributosSistemaExistentes(TipoAtributoSistema tipoAtributo, grupo02DBEntities contextoBaseDatos)
        {
            LinkedList<byte[]> resultado = new LinkedList<byte[]>();
            foreach (Producto producto in contextoBaseDatos.Producto.ToList())
            {
                resultado.AddLast(ObtenerBytesDeValorAtributoSistemaExistente(tipoAtributo, producto, contextoBaseDatos));
            }
            return resultado;
        }

        public static bool ObtenerTrueSiSKUEstaRepetido(String valorSKU, LinkedList<byte[]> listaSKU)
        {
            return ObtenerTrueSiUnAtributoEstaRepetidoEnLaBaseDeDatos(valorSKU, listaSKU);
        }

        public static bool ObtenerTrueSiGTINEstaRepetido(String valorGTIN, LinkedList<byte[]> listaGTIN)
        {
            return ObtenerTrueSiUnAtributoEstaRepetidoEnLaBaseDeDatos(valorGTIN, listaGTIN);
        }

        public static bool ObtenerTrueSiUnAtributoEstaRepetidoEnLaBaseDeDatos(string valorAributoAComprobar, LinkedList<byte[]> listaBytesAtributo)
        {
            // Usaremos un HashSet para rastrear valores únicos y detectar duplicados.
            int contadorVeces = 0;
            foreach (var item in listaBytesAtributo)
            {
                // Convertir los bytes a string (asumiendo que los datos son cadenas).
                if (item == null)
                {
                    continue;
                }
                string valor = Convertidor.BytesAString(item);
                if (valor.Equals(valorAributoAComprobar, StringComparison.OrdinalIgnoreCase))
                {
                    contadorVeces++;
                    if (contadorVeces >= 2)
                    {
                        return true;
                    }
                }
            }

            // Si terminamos el recorrido sin encontrar duplicados, devolvemos false.
            return false;
        }

        /// <summary>
        /// tipoAtributo debe ser <see cref="TipoAtributoSistema"/> o <see cref="TipoAtributoUsuario"/>
        /// </summary>
        /// <param name="tipoAtributo"></param>
        /// <returns></returns>
        public static byte[] ConvertirAtributoABytes(Enum tipo, object atributo)
        {
            switch (tipo)
            {
                //Atributos de sistema
                case TipoAtributoSistema.SKU:
                    return Convertidor.StringABytes((string)atributo);
                case TipoAtributoSistema.GTIN:
                    return Convertidor.StringABytes((string)atributo);
                case TipoAtributoSistema.thumbnail:
                    return Convertidor.ImageABytes((Image)atributo, ImageFormat.Png);

                //Atributos de usuario
                case TipoAtributoUsuario.Text:
                    return Convertidor.StringABytes((string)atributo);
                case TipoAtributoUsuario.Number:
                    return Convertidor.FloatABytes((float)atributo);
                case TipoAtributoUsuario.Date:
                    return Convertidor.DateTimeABytes((DateTime)atributo);
                case TipoAtributoUsuario.Image:
                    return Convertidor.ImageABytes((Image)atributo, ImageFormat.Png);
                default:
                    throw new NotSupportedException($"The attriute type {tipo} is not supported.");
            }
        }

        /// <summary>
        /// Convierte un arreglo de bytes en un atributo específico, según el tipo de atributo.
        /// </summary>
        /// <param name="tipo">Tipo de atributo (debe ser <see cref="TipoAtributoSistema"/> o <see cref="TipoAtributoUsuario"/>)</param>
        /// <param name="bytes">Arreglo de bytes que representa el atributo</param>
        /// <returns>El atributo convertido al tipo correspondiente</returns>
        public static object ConvertirBytesAAtributo(Enum tipo, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                throw new ArgumentNullException(nameof(bytes), "El arreglo de bytes no puede ser nulo o vacío.");

            switch (tipo)
            {
                // Atributos de sistema
                case TipoAtributoSistema.SKU:
                case TipoAtributoSistema.GTIN:
                    return Convertidor.BytesAString(bytes);
                case TipoAtributoSistema.thumbnail:
                    return Convertidor.BytesAImage(bytes);

                // Atributos de usuario
                case TipoAtributoUsuario.Text:
                    return Convertidor.BytesAString(bytes);
                case TipoAtributoUsuario.Number:
                    return Convertidor.BytesAFloat(bytes);
                case TipoAtributoUsuario.Date:
                    return Convertidor.BytesADateTime(bytes);
                case TipoAtributoUsuario.Image:
                    return Convertidor.BytesAImage(bytes);

                default:
                    throw new NotSupportedException($"El tipo de atributo {tipo} no es compatible.");
            }
        }


        private static bool ValidarGTIN(string GTIN)
        {
            try
            {
                // Validar que no sea nulo o vacío
                if (string.IsNullOrEmpty(GTIN))
                {
                    MessageBox.Show("The GTIN cannot be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Validar que tenga exactamente 14 caracteres
                if (GTIN.Length != 14)
                {
                    MessageBox.Show("The GTIN must have 14 digits.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Validar que todos los caracteres sean numéricos
                if (!GTIN.All(char.IsDigit))
                {
                    MessageBox.Show("The GTIN only can contains numbers.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Calcular el dígito de control (algoritmo módulo 10)
                int suma = 0;
                for (int i = 0; i < 13; i++) // Iterar sobre los primeros 13 dígitos
                {
                    int digito = int.Parse(GTIN[i].ToString());
                    suma += (i % 2 == 0) ? digito * 3 : digito; // Alternar multiplicación por 3 y 1
                }

                int digitoControlCalculado = (10 - (suma % 10)) % 10; // Calcular el dígito de control
                int digitoControlReal = int.Parse(GTIN[13].ToString()); // Último dígito del GTIN

                // Verificar si el dígito de control coincide
                if (digitoControlCalculado != digitoControlReal)
                {
                    MessageBox.Show("The GTIN was invalid (incorrect control digit).", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Si todo es válido
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR VALIDATING GTIN: " + ex.Message);
                return false;
            }
        }
    }
}
