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
            grupo02DBEntities db = new grupo02DBEntities();
            if (db.CategoriaProducto.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.id == 1).CategoriasProducto)
            {
                InsertarCategoria InsertarCategoria = new InsertarCategoria();
                InsertarCategoria.CategoriaInsertada += (s, args) =>
                {
                    cargarCategorias(); 
                };

               
                InsertarCategoria.ShowDialog();
            }
            else
            {

                MessageBox.Show("You have reached the maximum number of categories allowed");
            }
            
        }

        private void dataGridViewCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewCategoria.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int idCategoria = Convert.ToInt32(dataGridViewCategoria.Rows[e.RowIndex].Cells["ID"].Value);
                if(Convert.ToInt32(dataGridViewCategoria.Rows[e.RowIndex].Cells["numProducts"].Value) > 0)
                {
                    EliminarCategoria(idCategoria);

                }
                else
                {

                    grupo02DBEntities db = new grupo02DBEntities();
                    var categoria = db.CategoriaProducto.First(x => x.ID.Equals(idCategoria));
                    db.CategoriaProducto.Remove(categoria);
                    db.SaveChanges();
                    cargarCategorias();
                }
            }

            // Modificar atributo
            if (e.RowIndex >= 0) 
            {
                if (e.ColumnIndex == dataGridViewCategoria.Columns["Editar"].Index)
                {
                    dataGridViewCategoria.Columns["Guardar"].Visible = true;
                    dataGridViewCategoria.Columns["Descartar"].Visible = true;

                    dataGridViewCategoria.Rows[e.RowIndex].ReadOnly = false;

                    // Cambia el color o diseño de la fila para indicar que está en edición (opcional)
                    dataGridViewCategoria.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Tomato;

                    // Crear los TextBox para las columnas "NAME" y "TYPE"
                    TextBox txtName = new TextBox();

                    // Coloca los TextBox en las celdas correspondientes
                    txtName.Text = dataGridViewCategoria.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    // Establece el tamaño y la posición de los TextBox en las celdas
                    txtName.Size = new Size(dataGridViewCategoria.Columns["Name"].Width, dataGridViewCategoria.Rows[e.RowIndex].Height);

                    // Añadir los TextBox al DataGridView
                    dataGridViewCategoria.Controls.Add(txtName);

                    // Establece la posición de los TextBox
                    txtName.Location = dataGridViewCategoria.GetCellDisplayRectangle(e.RowIndex, dataGridViewCategoria.Columns["Name"].Index, true).Location;
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


        private void EliminarCategoria(int idCategoria)
        {
            grupo02DBEntities db = new grupo02DBEntities();
            
            var categoria = db.CategoriaProducto.First(x => x.ID.Equals(idCategoria));
            if (categoria != null)
            {
                    DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.CategoriaProducto.Remove(categoria);
                        db.SaveChanges();
                        cargarCategorias();
                        MessageBox.Show("Category succesfully deleted.", "Deletion succesful");
                    }
            }
            else
            {
                MessageBox.Show("Category was not found.", "Error");
            }

        }

        private void GuardarCambiosFila(int rowIndex)
        {
           

        }

        private void DescartarCambiosFila(int rowIndex)
        {

        }


    }
}
