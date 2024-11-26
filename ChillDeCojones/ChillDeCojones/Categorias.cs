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
    }
}
