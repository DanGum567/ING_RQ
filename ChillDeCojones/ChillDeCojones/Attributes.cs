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




    public partial class Attributes : Form
    {
        grupo02DBEntities db = new grupo02DBEntities();
        private Dictionary<int, TextBox[]> textBoxControls = new Dictionary<int, TextBox[]>();
        public Attributes()
        {
            InitializeComponent();
        }
        public void cargarAtributos()
        {
            try
            {
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





        private void bInsertar_Click(object sender, EventArgs e)
        {
            if (db.AtributoUsuario.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.id == 1).Atributos)
            {
                InsertarAtributo InsertarAtributo = new InsertarAtributo();
                InsertarAtributo.AtributoInsertado += (s, args) =>
                {
                    cargarAtributos(); // Recargar atributos cuando se cierre InsertarAtributo
                };


                // Mostrar el formulario como modal
                InsertarAtributo.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have reached the maximum number of attributes allowed");
            }


        }

        private void dataGridViewAtributos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewAtributos.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int idAtributo = Convert.ToInt32(dataGridViewAtributos.Rows[e.RowIndex].Cells["ID"].Value);

                EliminarAtributo(idAtributo);
            }

            if (e.ColumnIndex == dataGridViewAtributos.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                dataGridViewAtributos.Rows[e.RowIndex].ReadOnly = false;

                dataGridViewAtributos.Columns["Guardar"].Visible = true;
                dataGridViewAtributos.Columns["Descartar"].Visible = true;

                dataGridViewAtributos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Tomato;

                if (!textBoxControls.ContainsKey(e.RowIndex))
                {
                    TextBox nameTextBox = new TextBox();

                    nameTextBox.Text = dataGridViewAtributos.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    textBoxControls[e.RowIndex] = new TextBox[] { nameTextBox};

                    dataGridViewAtributos.Rows[e.RowIndex].Cells["Name"].Value = nameTextBox.Text;
                }
            }
            if (e.ColumnIndex == dataGridViewAtributos.Columns["Guardar"].Index && e.RowIndex >= 0)
            {
                GuardarCambiosFila(e.RowIndex);
            }

            if (e.ColumnIndex == dataGridViewAtributos.Columns["Descartar"].Index && e.RowIndex >= 0)
            {
                DescartarCambiosFila(e.RowIndex);
            }

        }
        private void dataGridViewAtributos_CurrentCellChanged(object sender, EventArgs e)
        {
            // Verificar si la fila actual es editable
            if (dataGridViewAtributos.CurrentRow != null && !dataGridViewAtributos.CurrentRow.ReadOnly)
            {
                // Asegurarse de que la celda en la fila actual se pueda editar
                dataGridViewAtributos.BeginEdit(true);
            }
        }
        private void EliminarAtributo(int idAtributo)
        {
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
            // Vuelve a cargar los datos para descartar los cambios
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
            

            // Obtén el ID de la fila
            int idAtributo = Convert.ToInt32(dataGridViewAtributos.Rows[rowIndex].Cells["ID"].Value);

            // Busca el atributo en la base de datos
            var atributo = db.AtributoUsuario.First(y => y.ID.Equals(idAtributo));
            if (atributo != null)
            {
                // Actualiza los valores según las celdas
                // Asignamos los valores de los TextBox a las propiedades del atributo
                TextBox[] textBoxes = textBoxControls[rowIndex];
                atributo.NAME = textBoxes[0].Text;
                atributo.TYPE = textBoxes[1].Text;

                db.SaveChanges(); // Guarda los cambios
                MessageBox.Show("Cambios guardados correctamente.");
            }

            // Oculta las columnas de Guardar y Descartar
            dataGridViewAtributos.Columns["Guardar"].Visible = false;
            dataGridViewAtributos.Columns["Descartar"].Visible = false;

            // Establece la fila como solo lectura nuevamente
            dataGridViewAtributos.Rows[rowIndex].ReadOnly = true;

            // Cambia el color de la fila de nuevo a su estado original
            dataGridViewAtributos.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;

            // Actualiza la tabla después de guardar
            cargarAtributos();
        }




    }
}
