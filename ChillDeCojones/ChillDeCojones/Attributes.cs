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
            btnEliminar.HeaderText = "Delete";
            btnEliminar.Name = "Delete";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridViewAtributos.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Edit";
            btnEditar.Name = "Edit";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridViewAtributos.Columns.Add(btnEditar);

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
                //dataGridViewAtributos.Rows[e.RowIndex].ReadOnly = false;
                int idAtributo = Convert.ToInt32(dataGridViewAtributos.Rows[e.RowIndex].Cells["ID"].Value);
                ModificarAtributo ModificarAtributo = new ModificarAtributo(idAtributo);
                ModificarAtributo.AtributoModificado += (s, args) =>
                {
                    cargarAtributos(); // Recargar atributos cuando se cierre InsertarAtributo
                };


                // Mostrar el formulario como modal
                ModificarAtributo.ShowDialog();


                if (!textBoxControls.ContainsKey(e.RowIndex))
                {
                    TextBox nameTextBox = new TextBox();

                    nameTextBox.Text = dataGridViewAtributos.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    textBoxControls[e.RowIndex] = new TextBox[] { nameTextBox};

                    dataGridViewAtributos.Rows[e.RowIndex].Cells["Name"].Value = nameTextBox.Text;
                }
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
                    MessageBox.Show("Attribute successfully deleted. ", "Deletion successful.");
                }
            }
            else
            {
                MessageBox.Show("Attribute not found.", "Error");
            }
            cargarAtributos(); // Actualiza la tabla después de eliminar
        }
    }
}
