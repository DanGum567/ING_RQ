﻿using System;
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
    public partial class Relationships : Form
    {
        grupo02DBEntities1 db = new grupo02DBEntities1();

        public Relationships()
        {
            InitializeComponent();
        }

        private void Relaciones_Load(object sender, EventArgs e)
        {
            cargarRelaciones();
            cargarAcciones();
        }

        private void ActualizarNumeroRelaciones()
        {

            labelNumeroRelaciones.Text = "Relationships (" + db.RelacionProducto.Count().ToString() + "/" + db.PlanSuscripcion.Select(p => p.Relaciones).FirstOrDefault().ToString() + ")";  // /limite de relaciones disponibles
        }

        private void cargarRelaciones()
        {
            //Seleccionar las relaciones y cargarlas en el DataGridView.
            //var listaRelaciones = from relacion in db.Relacion
            //                      select new
            //                      {
            //                          ID = relacion.idRelacion,
            //                          Name = relacion.nombre
            //                      };
            //dataGridViewRelaciones.DataSource = listaRelaciones.ToList();
            //dataGridViewRelaciones.Columns["ID"].Visible = false;

            //Añadir columnas de eliminar y editar.
            //Crear columna de eliminar
            try
            {
                ActualizarNumeroRelaciones();
                var listaRelaciones = from relacion in db.RelacionProducto
                                      select new
                                      {
                                          ID = relacion.idRelacionProducto,
                                          Name = relacion.Name
                                      };
                dataGridViewRelaciones.DataSource = listaRelaciones.ToList();
                foreach (DataGridViewColumn c in dataGridViewRelaciones.Columns)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                dataGridViewRelaciones.ClearSelection();
                dataGridViewRelaciones.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }


        }

        private void cargarAcciones()
        {
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Delete";
            btnEliminar.Name = "Delete";
            btnEliminar.Text = "🗑";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridViewRelaciones.Columns.Add(btnEliminar);

            //Columna para editar categorias
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Edit";
            btnEditar.Name = "Edit";
            btnEditar.Text = "✏";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridViewRelaciones.Columns.Add(btnEditar);
        }

        private void EliminarRelacion(int idRelacion)
        {
            var relacion = db.RelacionProducto.First(x => x.idRelacionProducto.Equals(idRelacion));
            if (relacion != null)
            {

                DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    db.RelacionProducto.Remove(relacion);

                    db.SaveChanges(); // Guarda los cambios en la base de datos

                    cargarRelaciones();

                }
            }
            else
            {
                MessageBox.Show("Relationship not found.", "Error");
            }

        }

        private void dataGridViewRelaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRelaciones.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int idAtributo = Convert.ToInt32(dataGridViewRelaciones.Rows[e.RowIndex].Cells["ID"].Value);

                EliminarRelacion(idAtributo);
            }

            if (e.ColumnIndex == dataGridViewRelaciones.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                //dataGridViewAtributos.Rows[e.RowIndex].ReadOnly = false;
                int idRelacion = Convert.ToInt32(dataGridViewRelaciones.Rows[e.RowIndex].Cells["ID"].Value);
                ModificarRelacion ModificarRelacion = new ModificarRelacion(idRelacion);
                ModificarRelacion.RelacionModificada += (s, args) =>
                {
                    cargarRelaciones(); 
                };
                //Mostrar el formulario como modal
                ModificarRelacion.ShowDialog();

            }
        }

        private void bInsertar_Click(object sender, EventArgs e)
        {
            if (db.RelacionProducto.Count() < db.PlanSuscripcion.FirstOrDefault(x => x.Nombre.Equals("Free")).Relaciones)
            {
                InsertarRelacion InsertarRelacion = new InsertarRelacion();
                InsertarRelacion.RelacionInsertada += (s, args) =>
                {
                    cargarRelaciones();
                };


                InsertarRelacion.ShowDialog();
            }
            else
            {

                MessageBox.Show("You have reached the maximum number of categories allowed");
            }
        }
    }
}
