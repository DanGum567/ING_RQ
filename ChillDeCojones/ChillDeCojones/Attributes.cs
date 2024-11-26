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
                dataGridViewAtributos.ClearSelection();
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

        public static void AñadirValorAtributoDelSistemaAProducto(TipoAtributoSistema atributoAAÑadir, Producto producto, object atributo, grupo02DBEntities contexto)
        {

            if (!(atributoAAÑadir == TipoAtributoSistema.thumbnail) && ( producto == null || atributo == null))
            {
                MessageBox.Show("El producto o atributo no pueden ser nulos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(atributoAAÑadir == TipoAtributoSistema.GTIN)
            {
                if (ValidarGTIN(atributo.ToString()) == false)
                {   
                    return;
                }
            }

            int idAtributoAAñadir = ObtenerIdAtributoSistema(atributoAAÑadir);
            var atributoSistema = contexto.AtributoSistema.Find(idAtributoAAñadir);
            if (atributoSistema == null)
            {
                MessageBox.Show($"No se encontró el atributo con ID {idAtributoAAñadir}", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            };


            // Mostrar el formulario como modal
            InsertarAtributo.ShowDialog();

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

                    // Crear los TextBox para las columnas "NAME" y "TYPE"
                    TextBox txtName = new TextBox();
                    TextBox txtType = new TextBox();

                    // Coloca los TextBox en las celdas correspondientes
                    txtName.Text = dataGridViewAtributos.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    txtType.Text = dataGridViewAtributos.Rows[e.RowIndex].Cells["Type"].Value.ToString();

                    // Establece el tamaño y la posición de los TextBox en las celdas
                    txtName.Size = new Size(dataGridViewAtributos.Columns["Name"].Width, dataGridViewAtributos.Rows[e.RowIndex].Height);
                    txtType.Size = new Size(dataGridViewAtributos.Columns["Type"].Width, dataGridViewAtributos.Rows[e.RowIndex].Height);

                    // Añadir los TextBox al DataGridView
                    dataGridViewAtributos.Controls.Add(txtName);
                    dataGridViewAtributos.Controls.Add(txtType);

                    // Establece la posición de los TextBox
                    txtName.Location = dataGridViewAtributos.GetCellDisplayRectangle(e.RowIndex, dataGridViewAtributos.Columns["Name"].Index, true).Location;
                    txtType.Location = dataGridViewAtributos.GetCellDisplayRectangle(e.RowIndex, dataGridViewAtributos.Columns["Type"].Index, true).Location;
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
                    //atributo.NAME = dataGridViewAtributos.Rows[rowIndex].Cells["Name"].Value.ToString();
                    //atributo.TYPE = dataGridViewAtributos.Rows[rowIndex].Cells["Type"].Value.ToString();
                    //atributo.NAME = txtName.Text;
                    //atributo.TYPE = txtType.Text;
       
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
                MessageBox.Show("ERROR: " + ex.Message);
                return false;
            }
        }


    }
}
