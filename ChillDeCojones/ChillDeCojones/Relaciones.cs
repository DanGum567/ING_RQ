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
    public partial class Relaciones : Form
    {
        grupo02DBEntities1 db = new grupo02DBEntities1();

        public Relaciones()
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
            labelNumeroRelaciones.Text += "(" + db.RelacionProducto.Count().ToString() + ")";
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
                dataGridViewRelaciones.ClearSelection();
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

        private void EliminarRelacion()
        {
            /*if (relacion != null)
            {
                // Se pregunta al usuario si está seguro de que quiere eliminar el atributo
                DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Llamamos al método Borrar del objeto Producto para eliminarlo de la base de datos
                    db.RelacionProducto.Remove(relacion);
                    db.SaveChanges(); // Guarda los cambios en la base de datos
                }
            }
            else
            {
                MessageBox.Show("Attribute not found.", "Error");
            }*/
        }

        private void dataGridViewRelaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
