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
        grupo02DBEntities1 db = new grupo02DBEntities1();

        public Categorias()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            cargarAcciones();
            ActualizarNumeroCategorias();
        }
        private void cargarAcciones()
        {
            dataGridViewCategoria.Columns["ID"].Visible = false;

            //Crear columna de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Delete";
            btnEliminar.Name = "Delete";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridViewCategoria.Columns.Add(btnEliminar);

            //Columna para editar categorias
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Edit";
            btnEditar.Name = "Edit";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridViewCategoria.Columns.Add(btnEditar);
        }
        private void cargarCategorias()
        {
            ActualizarNumeroCategorias();
            var listaCategorias = from categorias in db.CategoriaProducto
                                  select new
                                  {
                                      ID = categorias.ID,
                                      Name = categorias.NAME,
                                      numProducts = categorias.Producto.Count()
                                  };


            dataGridViewCategoria.DataSource = listaCategorias.ToList();



        }

        private void bInsertarCategoria_Click(object sender, EventArgs e)
        {

            if (db.CategoriaProducto.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.Nombre.Equals("Free")).CategoriasProducto)
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

            if (e.ColumnIndex == dataGridViewCategoria.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int idCategoria = Convert.ToInt32(dataGridViewCategoria.Rows[e.RowIndex].Cells["ID"].Value);
                if (Convert.ToInt32(dataGridViewCategoria.Rows[e.RowIndex].Cells["numProducts"].Value) > 0)
                {
                    EliminarCategoria(idCategoria);

                }
                else
                {
                    var categoria = db.CategoriaProducto.First(x => x.ID.Equals(idCategoria));
                    db.CategoriaProducto.Remove(categoria);
                    db.SaveChanges();
                    cargarCategorias();
                }
            }

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridViewCategoria.Columns["Edit"].Index)
                {

                    //dataGridViewAtributos.Rows[e.RowIndex].ReadOnly = false;
                    int idCategoria = Convert.ToInt32(dataGridViewCategoria.Rows[e.RowIndex].Cells["ID"].Value);
                    ModificarCategoria ModificarCategoria = new ModificarCategoria(idCategoria);
                    ModificarCategoria.CategoriaModificada += (s, args) =>
                    {
                        cargarCategorias();
                    };

                    ModificarCategoria.ShowDialog();
                }

            }
        }



        private void EliminarCategoria(int idCategoria)
        {
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

        private void ActualizarNumeroCategorias()
        {
            int numeroCategorias = db.CategoriaProducto.Count();
            categoriesLabel.Text = "Categories (" + numeroCategorias.ToString() + ")";

        }
    }
}
