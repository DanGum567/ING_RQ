using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            dataGridViewCategoria.Columns["ID"].Visible = false; // Oculta la columna

            //Crear columna de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridViewCategoria.Columns.Add(btnEliminar);

            //Columna para editar categorias
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridViewCategoria.Columns.Add(btnEditar);

            // Columna para Guardar cambios
            DataGridViewButtonColumn btnGuardar = new DataGridViewButtonColumn();
            btnGuardar.HeaderText = "Save changes";
            btnGuardar.Name = "Guardar";
            btnGuardar.Text = "💾";
            btnGuardar.UseColumnTextForButtonValue = true;
            btnGuardar.Visible = false; // Ocultamos inicialmente
            dataGridViewCategoria.Columns.Add(btnGuardar);

            // Columna para Descartar cambios
            DataGridViewButtonColumn btnDescartar = new DataGridViewButtonColumn();
            btnDescartar.HeaderText = "Discard changes";
            btnDescartar.Name = "Descartar";
            btnDescartar.Text = "❌";
            btnDescartar.UseColumnTextForButtonValue = true;
            btnDescartar.Visible = false; // Ocultamos inicialmente
            dataGridViewCategoria.Columns.Add(btnDescartar);
        }

        private void cargarCategorias()
        {
            grupo02DBEntities db = new grupo02DBEntities();
            var listaCategorias = from categorias in db.CategoriaProducto
                                  select new
                                  {
                                      ID = categorias.ID,
                                      Name = categorias.NAME,
                                      numProducts = categorias.Producto.Count()
                                  };
            dataGridViewCategoria.DataSource = listaCategorias.ToList();
            dataGridViewCategoria.ClearSelection();
        }

        private void bInsertarCategoria_Click(object sender, EventArgs e)
        {
            InsertarCategoria InsertarCategoria = new InsertarCategoria();
            InsertarCategoria.CategoriaInsertada += (s, args) =>
            {
                cargarCategorias(); // Recargar atributos cuando se cierre InsertarAtributo
                this.Enabled = true;
            };

            InsertarCategoria.CerrarPopUp += (s, args) =>
            {
                this.Enabled = true;
            };
            InsertarCategoria.ShowDialog();
            this.Enabled = false;
        }

        private void dataGridViewCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda pertenece a la columna "Eliminar"
            if (e.ColumnIndex == dataGridViewCategoria.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtén el ID del atributo desde la fila seleccionada
                int idAtributo = Convert.ToInt32(dataGridViewCategoria.Rows[e.RowIndex].Cells["ID"].Value);

                // Llama a un método para eliminar el atributo
                //EliminarCategoria(idCategoria);
            }

            // Modificar atributo
            if (e.RowIndex >= 0) // Verifica que no sea el encabezado
            {
                // Si se hizo clic en el botón "Editar"
                if (e.ColumnIndex == dataGridViewCategoria.Columns["Editar"].Index)
                {
                    // Muestra las columnas de Guardar y Descartar
                    dataGridViewCategoria.Columns["Guardar"].Visible = true;
                    dataGridViewCategoria.Columns["Descartar"].Visible = true;

                    // Establece la fila en modo de edición
                    dataGridViewCategoria.Rows[e.RowIndex].ReadOnly = false;

                    // Cambia el color o diseño de la fila para indicar que está en edición (opcional)
                    dataGridViewCategoria.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;

                    // Crear los TextBox para las columnas "NAME" y "TYPE"
                    TextBox txtName = new TextBox();
                    TextBox txtType = new TextBox();

                    // Coloca los TextBox en las celdas correspondientes
                    txtName.Text = dataGridViewCategoria.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    txtType.Text = dataGridViewCategoria.Rows[e.RowIndex].Cells["Type"].Value.ToString();

                    // Establece el tamaño y la posición de los TextBox en las celdas
                    txtName.Size = new Size(dataGridViewCategoria.Columns["Name"].Width, dataGridViewCategoria.Rows[e.RowIndex].Height);
                    txtType.Size = new Size(dataGridViewCategoria.Columns["Type"].Width, dataGridViewCategoria.Rows[e.RowIndex].Height);

                    // Añadir los TextBox al DataGridView
                    dataGridViewCategoria.Controls.Add(txtName);
                    dataGridViewCategoria.Controls.Add(txtType);

                    // Establece la posición de los TextBox
                    txtName.Location = dataGridViewCategoria.GetCellDisplayRectangle(e.RowIndex, dataGridViewCategoria.Columns["Name"].Index, true).Location;
                    txtType.Location = dataGridViewCategoria.GetCellDisplayRectangle(e.RowIndex, dataGridViewCategoria.Columns["Type"].Index, true).Location;
                }
                // Si se hizo clic en el botón "Guardar"
                else if (e.ColumnIndex == dataGridViewCategoria.Columns["Guardar"].Index)
                {
                    //GuardarCambiosFila(e.RowIndex); // Llama al método para guardar cambios
                }
                // Si se hizo clic en el botón "Descartar"
                else if (e.ColumnIndex == dataGridViewCategoria.Columns["Descartar"].Index)
                {
                    //DescartarCambiosFila(e.RowIndex); // Llama al método para descartar cambios
                }
            }
        }
    }
}
