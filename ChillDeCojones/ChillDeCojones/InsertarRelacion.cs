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
        grupo02DBEntities1 db = new grupo02DBEntities1();
        Producto producto;  // Producto seleccionado en la primera lista
        List<Int32> productosSeleccionadosIds; // Productos seleccionados de la segunda lista

        public InsertarRelacion()
        {
            InitializeComponent();
        }

        private void InsertarRelacion_Load(object sender, EventArgs e)
        {
            cargarProductosLista1();

        }

        private void cargarProductosLista1()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.SuspendLayout();


            List<Producto> productos = db.Producto.ToList();

            foreach (Producto cargadoJustoAhora in productos)
            {
                //Variables de Producto
                int idProducto = cargadoJustoAhora.ID;
                string label;
                DateTime fechaCreacion;
                DateTime fechaModificacion;
                int ID;

                //Comprobamos si ya se han cargado las variables de Producto anteriormente
                Producto delQueCargarVariables;
                //Producto precargadoEnMemoria = Precargador.GetProductoEnMemoria(idProducto);

                delQueCargarVariables = cargadoJustoAhora;


                //Cargamos variables del producto para mostrarlas
                label = delQueCargarVariables.LABEL;
                fechaCreacion = (DateTime)delQueCargarVariables.FECHACREACION;
                fechaModificacion = (DateTime)delQueCargarVariables.FECHAMODIFICACION;
                ID = delQueCargarVariables.ID;

                //-------------------------------------------------------------------------------------------

                //Atributos del sistema
                string sku = "(Without SKU)";
                string gtin = "(Without GTIN)";
                Image thumbail = null;

                byte[] skuBytes = null;
                byte[] gtinBytes = null;
                byte[] thumbailBytes = null;

                //Comprobamos si ya se han cargado las variables de Producto anteriormente
                //skuBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.SKU, idProducto);
                //gtinBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.GTIN, idProducto);
                //thumbailBytes = Precargador.GetBytesValorAtributoSistemaEnMemoria(TipoAtributoSistema.thumbnail, idProducto);


                if (skuBytes == null)
                {
                    skuBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.SKU, cargadoJustoAhora, db);
                }
                if (gtinBytes == null)
                {
                    gtinBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.GTIN, cargadoJustoAhora, db);
                }
                if (thumbailBytes == null)
                {
                    thumbailBytes = AtributoManager.ObtenerBytesDeValorAtributoSistemaExistente(TipoAtributoSistema.thumbnail, cargadoJustoAhora, db);
                }

                if (thumbailBytes != null)
                {
                    thumbail = Convertidor.BytesAImage(thumbailBytes);
                }
                if (skuBytes != null)
                {
                    sku = Convertidor.BytesAString(skuBytes);
                }
                if (gtinBytes != null)
                {
                    gtin = Convertidor.BytesAString(gtinBytes);
                }


                dataGridView1.Rows.Add(
                    thumbail,
                    idProducto,
                    sku,
                    label
                );

                dataGridView1.Columns["ID"].Visible = false;


                dataGridView1.ResumeLayout();
                dataGridView1.ClearSelection();// Se deselecciona el primer elemento
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    // Obtener el producto de la fila seleccionada
            //    int productoId = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

            //    // Buscar el producto en la base de datos utilizando el ID
            //    producto = db.Producto.FirstOrDefault(p => p.ID == productoId);
            //    if (producto != null)
            //    {
            //        dataGridView2.DataSource = db.Producto.Where(p => p.ID != productoId).ToList();
            //    }
            //}
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el producto de la fila seleccionada
                int productoId = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

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
                    // productosSeleccionadosIds = db.Producto.Select(p.ID)

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
            //try
            //{
            //    RelacionProducto nuevaRelacion = new RelacionProducto();
            //    if (string.IsNullOrWhiteSpace(tLabel.Text))
            //    {
            //        MessageBox.Show("ERROR: name cannot be empty");

            //    }
            //    else if (db.RelacionProducto.Any(x => x.Name.Equals(tLabel.Text)))
            //    {
            //        MessageBox.Show("ERROR: The name is already in use");
            //        tLabel.Text = "";

            //    } // Si no hay ningun producto seleccionado la relación se crea sin ninguna asociación
            //    else
            //    {
            //        nuevaRelacion.Name = tLabel.Text;
            //        db.RelacionProducto.Add(nuevaRelacion);

            //        if (producto != null)
            //        {
            //            nuevaRelacion.idRelacionProducto = producto.ID;
            //            if (productosSeleccionadosIds.Count > 0) // Devuelve null!!
            //            {
            //                foreach (int productoId in productosSeleccionadosIds)
            //                {
            //                    //Crear una nueva entrada en la tabla intermedia
            //                    ProductoRelacionIntermedia nuevaRelacionIntermedia = new ProductoRelacionIntermedia()
            //                    {
            //                        idProducto1 = productoId, // Producto seleccionado
            //                        idProducto2 = nuevaRelacion.idRelacionProducto // ID de la relación
            //                    };

            //                    //Agregar la relación intermedia a la base de datos
            //                    db.ProductoRelacionIntermedia.Add(nuevaRelacionIntermedia);
            //                }
            //            }
            //        }

            //        db.SaveChanges();

            //        // Cerrar el formulario después de agregar
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error trying to add the category: " + ex.Message);
            //}
            //RelacionInsertada?.Invoke(this, EventArgs.Empty);

            //INSERTAR CON NOMBRE BIEN
            if (!string.IsNullOrWhiteSpace(tLabel.Text))
            {
                if (db.RelacionProducto.Any(x => x.Name.Equals(tLabel.Text)))
                {
                    MessageBox.Show("ERROR: The name is already in use");

                }
                else
                {
                    RelacionProducto nuevaRelacion = new RelacionProducto();
                    nuevaRelacion.Name = tLabel.Text;
                    db.RelacionProducto.Add(nuevaRelacion);
                    db.SaveChanges();
                    this.Close();
                    RelacionInsertada?.Invoke(this, EventArgs.Empty);
                }

            }
            else
            {
                MessageBox.Show("ERROR: name cannot be empty");
            }

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
