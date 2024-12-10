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
    public partial class InsertarRelacion : Form
    {
        public event EventHandler RelacionInsertada;
        grupo02DBEntities1 bd = new grupo02DBEntities1();
        Producto producto;  // Producto seleccionado en la primera lista
        List<Int32> productosSeleccionadosIds; // Productos seleccionados de la segunda lista

        public InsertarRelacion()
        {
            InitializeComponent();
        }

        private void InsertarRelacion_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bd.Producto.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el producto de la fila seleccionada
                int productoId = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

                // Buscar el producto en la base de datos utilizando el ID
                producto = bd.Producto.FirstOrDefault(p => p.ID == productoId);
                if (producto != null)
                {
                    dataGridView2.DataSource = bd.Producto.Where(p => p.ID != productoId).ToList();
                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    // Obtener el ID del producto seleccionado
                    int productoId = (int)row.Cells["ID"].Value;
                    // productosSeleccionadosIds = bd.Producto.Select(p.ID)

                    //Asegurarse de que el ID no se repita en la lista
                    if (!productosSeleccionadosIds.Contains(productoId))
                    {
                        productosSeleccionadosIds.Add(productoId);
                    }
                }
            }
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            try
            {
                RelacionProducto nuevaRelacion = new RelacionProducto();
                if (string.IsNullOrWhiteSpace(tLabel.Text))
                {
                    MessageBox.Show("ERROR: name cannot be empty");

                }
                else if (bd.RelacionProducto.Any(x => x.Name.Equals(tLabel.Text)))
                {
                    MessageBox.Show("ERROR: The name is already in use");
                    tLabel.Text = "";

                } // Si no hay ningun producto seleccionado la categoria se crea sin ninguna asociación
                else
                {
                    nuevaRelacion.Name = tLabel.Text;
                    bd.RelacionProducto.Add(nuevaRelacion);

                    if (producto != null)
                    {
                        nuevaRelacion.idRelacionProducto = producto.ID;
                        if (productosSeleccionadosIds.Count > 0)
                        {
                            foreach (int productoId in productosSeleccionadosIds)
                            {
                                // Crear una nueva entrada en la tabla intermedia
                                //Producto_RelacionProductoIntermedia nuevaRelacionIntermedia = new Producto_RelacionProductoIntermedia()
                                {
                                    //idProducto1 = productoId, // Producto seleccionado
                                    //idProducto2 = nuevaRelacion.idRelacionProducto // ID de la relación
                                };

                                // Agregar la relación intermedia a la base de datos
                                //bd.Producto_RelacionIntermedia.Add(nuevaRelacionIntermedia);
                            }
                        }
                    }

                    bd.SaveChanges();

                    // Cerrar el formulario después de agregar
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to add the category: " + ex.Message);
            }
            RelacionInsertada?.Invoke(this, EventArgs.Empty);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
