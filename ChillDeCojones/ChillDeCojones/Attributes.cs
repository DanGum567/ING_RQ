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
        public void cargarAtributos()
        {
            try
            {
                grupo02DBEntities db = new grupo02DBEntities();
                var listaAtributos = from atributos in db.AtributoUsuario
                                     select new
                                     {
                                         ID = atributos.ID,
                                         Type = atributos.TYPE,
                                         Name = atributos.NAME
                                     };
                dataGridViewAtributos.DataSource = listaAtributos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            

        }
        private void Attributes_Load(object sender, EventArgs e)
        {
            cargarAtributos();
            dataGridViewAtributos.Columns["ID"].Visible = false; // Oculta la columna ID

            //Crear columna de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridViewAtributos.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridViewAtributos.Columns.Add(btnEditar);

            // Columna para Guardar cambios
            DataGridViewButtonColumn btnGuardar = new DataGridViewButtonColumn();
            btnGuardar.HeaderText = "Save changes";
            btnGuardar.Name = "Guardar";
            btnGuardar.Text = "💾";
            btnGuardar.UseColumnTextForButtonValue = true;
            btnGuardar.Visible = false; // Ocultamos inicialmente
            dataGridViewAtributos.Columns.Add(btnGuardar);

            // Columna para Descartar cambios
            DataGridViewButtonColumn btnDescartar = new DataGridViewButtonColumn();
            btnDescartar.HeaderText = "Discard changes";
            btnDescartar.Name = "Descartar";
            btnDescartar.Text = "❌";
            btnDescartar.UseColumnTextForButtonValue = true;
            btnDescartar.Visible = false; // Ocultamos inicialmente
            dataGridViewAtributos.Columns.Add(btnDescartar);
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

        private void bInsertar_Click(object sender, EventArgs e)
        {

            InsertarAtributo InsertarAtributo = new InsertarAtributo();
            InsertarAtributo.AtributoInsertado += (s, args) =>
            {
                cargarAtributos(); // Recargar atributos cuando se cierre InsertarAtributo
                this.Enabled = true;
            };

            InsertarAtributo.CerrarPopUp += (s, args) =>
            {
                this.Enabled = true;
            };

            // Mostrar el formulario como modal
            InsertarAtributo.ShowDialog();
            this.Enabled = false;

        }
        
        private void dataGridViewAtributos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda pertenece a la columna "Eliminar"
            if (e.ColumnIndex == dataGridViewAtributos.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtén el ID del atributo desde la fila seleccionada
                int idAtributo = Convert.ToInt32(dataGridViewAtributos.Rows[e.RowIndex].Cells["ID"].Value);

                // Llama a un método para eliminar el atributo
                EliminarAtributo(idAtributo);
            }

            // Modificar atributo
            if (e.RowIndex >= 0) // Verifica que no sea el encabezado
            {
                // Si se hizo clic en el botón "Editar"
                if (e.ColumnIndex == dataGridViewAtributos.Columns["Editar"].Index)
                {
                    // Muestra las columnas de Guardar y Descartar
                    dataGridViewAtributos.Columns["Guardar"].Visible = true;
                    dataGridViewAtributos.Columns["Descartar"].Visible = true;

                    // Establece la fila en modo de edición
                    dataGridViewAtributos.Rows[e.RowIndex].ReadOnly = false;

                    // Cambia el color o diseño de la fila para indicar que está en edición (opcional)
                    dataGridViewAtributos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                // Si se hizo clic en el botón "Guardar"
                else if (e.ColumnIndex == dataGridViewAtributos.Columns["Guardar"].Index)
                {
                    GuardarCambiosFila(e.RowIndex); // Llama al método para guardar cambios
                }
                // Si se hizo clic en el botón "Descartar"
                else if (e.ColumnIndex == dataGridViewAtributos.Columns["Descartar"].Index)
                {
                    DescartarCambiosFila(e.RowIndex); // Llama al método para descartar cambios
                }
            }


        }

        private void EliminarAtributo(int idAtributo)
        {
            grupo02DBEntities db = new grupo02DBEntities();
            // Busca el atributo en la base de datos
            var atributo = db.AtributoUsuario.First(x => x.ID.Equals(idAtributo));
            if (atributo != null)
            {
                // Se pregunta al usuario si está seguro de que quiere eliminar el atributo
                DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                        // Llamamos al método Borrar del objeto Producto para eliminarlo de la base de datos
                        db.AtributoUsuario.Remove(atributo);
                        db.SaveChanges(); // Guarda los cambios en la base de datos
                        MessageBox.Show("Atributo eliminado correctamente.", "Eliminación Exitosa");
                }
            }
            else
            {
                MessageBox.Show("No se encontró el atributo.", "Error");
            }
            

            // Actualiza la tabla después de eliminar
            cargarAtributos();
        }

        private void DescartarCambiosFila(int rowIndex)
        {
            // Actualiza la tabla después de eliminar
            cargarAtributos();

            // Oculta las columnas de Guardar y Descartar
            dataGridViewAtributos.Columns["Guardar"].Visible = false;
            dataGridViewAtributos.Columns["Descartar"].Visible = false;

            // Establece la fila como solo lectura nuevamente
            dataGridViewAtributos.Rows[rowIndex].ReadOnly = true;

            MessageBox.Show("Los cambios han sido descartados.");
        }


        private void GuardarCambiosFila(int rowIndex)
        {
            grupo02DBEntities db = new grupo02DBEntities();
            // Obtén el ID de la fila
            int idAtributo = Convert.ToInt32(dataGridViewAtributos.Rows[rowIndex].Cells["ID"].Value);

                // Busca el atributo en la base de datos
                var atributo = db.AtributoUsuario.First(y => y.ID.Equals(idAtributo));
                if (atributo != null)
                {
                    // Actualiza los valores según las celdas
                    atributo.NAME = dataGridViewAtributos.Rows[rowIndex].Cells["Name"].Value.ToString();
                    atributo.TYPE = dataGridViewAtributos.Rows[rowIndex].Cells["Type"].Value.ToString();

                    db.SaveChanges(); // Guarda los cambios
                    MessageBox.Show("Cambios guardados correctamente.");
                }
            

            // Oculta las columnas de Guardar y Descartar
            dataGridViewAtributos.Columns["Guardar"].Visible = false;
            dataGridViewAtributos.Columns["Descartar"].Visible = false;

            // Establece la fila como solo lectura nuevamente
            dataGridViewAtributos.Rows[rowIndex].ReadOnly = true;

            // Opcional: Cambia el color de la fila de nuevo a su estado original
            dataGridViewAtributos.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;

            // Actualiza la tabla después de eliminar
            cargarAtributos();
        }

    }
}
