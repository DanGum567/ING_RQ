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
    public partial class Help : Form
    {
        public Help(bool mostrarAMiAmorchi)
        {
            InitializeComponent();
            if (mostrarAMiAmorchi)
            {
                MostrarAMiQueridoPalomino();
            }
            else
            {
                label1.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }

        public void MostrarAMiQueridoPalomino()
        {
            label1.Visible = true;
            pictureBox1.Visible = true;
        }
    }
}
