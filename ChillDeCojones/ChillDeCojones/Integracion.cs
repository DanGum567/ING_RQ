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
    public partial class Integracion : Form
    {
        public Integracion()
        {
            InitializeComponent();
        }

        private void cargarProductos()
        {

        }
        private void bClearCategory_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void bClearDate_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cbCategory_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            ConfiguracionExportacion configuracionExport = new ConfiguracionExportacion();
            configuracionExport.ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }
    }
}
