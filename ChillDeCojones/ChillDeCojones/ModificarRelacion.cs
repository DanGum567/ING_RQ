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
    public partial class ModificarRelacion : Form
    {
        public event EventHandler RelacionModificada;
        grupo02DBEntities1 db = new grupo02DBEntities1();
        RelacionProducto relacion;
        List<Int32> productosRelacionados = new List<Int32>();
        int idProducto1;
 

        public ModificarRelacion(int idRelacion)
        {
            InitializeComponent();
            relacion = db.RelacionProducto.FirstOrDefault(x => x.idRelacionProducto == idRelacion);

        }


        private void ModificarRelacion_Load(object sender, EventArgs e)
        {
            try
            {
                tLabel.Text = relacion.Name;
                idProducto1 = relacion.ProductoRelacionIntermedia.First().idProducto1; // Si no tiene una relación creada da excepción
                cargarProductosLista1();
                cargarProductosLista2(db.Producto.Find(idProducto1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existe la relación" + ex.Message);
            }
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            var relacionExistente = db.RelacionProducto
                                    .FirstOrDefault(x => x.Name == tLabel.Text);
            db.RelacionProducto.Remove(relacionExistente);
            if (!string.IsNullOrWhiteSpace(tLabel.Text))
            {
                    RelacionProducto nuevaRelacion = new RelacionProducto();
                    nuevaRelacion.Name = tLabel.Text;
                    db.RelacionProducto.Add(nuevaRelacion);

                    if (dataGridView1.SelectedRows.Count > 0 && dataGridView2.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in dataGridView2.SelectedRows)
                        {
                            var id1 = dataGridView1.SelectedRows[0].Cells["ID"].Value;
                            var id2 = fila.Cells["ID2"].Value;
                            ProductoRelacionIntermedia productosEnRelacion = new ProductoRelacionIntermedia();
                            productosEnRelacion.idProducto1 = (int)id1;
                            productosEnRelacion.idProducto2 = (int)id2;
                            productosEnRelacion.idRelacionProducto = nuevaRelacion.idRelacionProducto;
                            db.ProductoRelacionIntermedia.Add(productosEnRelacion);
                             
                        }

                    }
                    db.SaveChanges();
                    this.Close();
                    RelacionModificada?.Invoke(this, EventArgs.Empty);
                

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



        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                int idProducto = (int)row.Cells["ID2"].Value;

                // Si el producto ya está seleccionado, lo deseleccionamos y lo eliminamos de la lista
                if (row.Selected)
                {
                    if (!productosRelacionados.Contains(idProducto))
                    {
                        productosRelacionados.Add(idProducto);
                    }
                }
                else
                {
                    if (productosRelacionados.Contains(idProducto))
                    {
                        productosRelacionados.Remove(idProducto);
                    }
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // NO SE PUEDE
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


            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if ((int)fila.Cells["ID"].Value == idProducto1)
                {
                    fila.Selected = true;
                    break;
                }

            }


            //dataGridView1.Rows.SelectedItem = db.Producto.FirstOrDefault(idProducto1);
        }

        private void buscarProductosRelacionados()
        {

            foreach (ProductoRelacionIntermedia relaciones in relacion.ProductoRelacionIntermedia)
            {
                //productosRelacionados es null
                productosRelacionados.Add(relaciones.Producto1.ID);
            }
        }


        private void cargarProductosLista2(Producto productoLista1)
        {
            dataGridView2.MultiSelect = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            buscarProductosRelacionados();
            dataGridView2.Rows.Clear();
            dataGridView2.SuspendLayout();
            dataGridView2.ClearSelection();
            int indice = 0;

            List<Producto> productos = db.Producto.ToList();

            foreach (Producto cargadoJustoAhora in productos)
            {
                if (cargadoJustoAhora.ID == productoLista1.ID)
                {
                    continue;
                }
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


                dataGridView2.Rows.Add(
                    thumbail,
                    idProducto,
                    sku,
                    label
                );

                if (productosRelacionados.Contains(idProducto))
                {
                    dataGridView2.Rows[indice].Selected = true;
                }

                dataGridView2.Columns["ID2"].Visible = false;


                dataGridView2.ResumeLayout();
                indice++;

            }
        }
    }
}
