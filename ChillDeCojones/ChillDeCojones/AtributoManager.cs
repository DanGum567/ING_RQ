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

        /// <summary>
        /// Esta función no llama a SaveChanges, lo debe hacer el que llama a esta función
        /// </summary>
        /// <param name="tipoAtributo"></param>
        /// <returns></returns>
        public static bool AñadirOActualizarValorAtributoSistema(TipoAtributoSistema tipoAtributo, Producto dueñoAtributoSistema, grupo02DBEntities contextoBaseDatos, object valorAtributo)
        {

            if (!(tipoAtributo == TipoAtributoSistema.thumbnail) && (dueñoAtributoSistema == null || valorAtributo == null))
            {
                MessageBox.Show("El producto o atributo no pueden ser nulos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (tipoAtributo == TipoAtributoSistema.GTIN)
            {
                if (ValidarGTIN(valorAtributo.ToString()) == false)
                {
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
                MessageBox.Show($"No se encontró el tipo de atributo de sistema con ID {atributoSistema.ID}", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"No se encontró el tipo de atributo de sistema con ID {atributoUsuario.ID}", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ValorAtributoUsuario valorAtributoUsuario = contextoBaseDatos.ValorAtributoUsuario.Find(atributoUsuario.ID, dueñoAtributoUsuario.ID);

            TipoAtributoUsuario tipoAtributo = (TipoAtributoUsuario)Enum.Parse(typeof(TipoAtributoUsuario), atributoUsuario.TYPE);
            if (valorAtributoUsuario == null)
            {
                //Estamos insertando, el valor no existía antes
                valorAtributoUsuario = new ValorAtributoUsuario
                {
                    AtributoUsuario = atributoUsuario,
                    Producto = dueñoAtributoUsuario,
                    VALOR = ConvertirAtributoABytes(tipoAtributo, valorAtributo)
                };

                contextoBaseDatos.ValorAtributoUsuario.Add(valorAtributoUsuario);
            }
            else
            {
                //Estamos actualizando, el valor si existía antes
                valorAtributoUsuario.VALOR = ConvertirAtributoABytes(tipoAtributo, valorAtributo);

            }

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
                throw new ArgumentNullException("El producto no puede ser nulo.");
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
                    throw new NotSupportedException($"El tipo de atributo {tipo} no está soportado.");
            }
        }

        private static bool ValidarGTIN(string GTIN)
        {
            try
            {
                // Validar que no sea nulo o vacío
                if (string.IsNullOrEmpty(GTIN))
                {
                    MessageBox.Show("El GTIN no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Validar que tenga exactamente 14 caracteres
                if (GTIN.Length != 14)
                {
                    MessageBox.Show("El GTIN debe tener exactamente 14 dígitos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Validar que todos los caracteres sean numéricos
                if (!GTIN.All(char.IsDigit))
                {
                    MessageBox.Show("El GTIN solo debe contener números.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("El GTIN no es válido (dígito de control incorrecto).", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Si todo es válido
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL VALIDAR EL GTIN: " + ex.Message);
                return false;
            }
        }
    }
}
