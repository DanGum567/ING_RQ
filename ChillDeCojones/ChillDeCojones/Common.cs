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
    public partial class Common : Form
    {
        // Usar una propiedad auto-implementada para garantizar un único punto de acceso
        private static Common instance;
        public static Common Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Common();
                }
                return instance;
            }
        }


        private string fraseSecreta = "ilovepalomo"; // Define tu frase secreta
        private StringBuilder buffer = new StringBuilder(); // Para almacenar las teclas presionadas

        public Common()
        {
            InitializeComponent();
            this.KeyPreview = true; // Asegura que el formulario capture las teclas
            this.KeyPress += Form1_KeyPress; // Maneja el evento KeyPress
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Agregar la tecla presionada al buffer
            buffer.Append(e.KeyChar);

            // Limitar el tamaño del buffer para que no crezca innecesariamente
            if (buffer.Length > fraseSecreta.Length)
            {
                buffer.Remove(0, buffer.Length - fraseSecreta.Length);
            }

            // Comprobar si el buffer contiene la frase secreta
            if (buffer.ToString().Contains(fraseSecreta))
            {
                ShowSubForm(new Help(true));
                buffer.Clear(); // Reiniciar el buffer si se detecta la frase
            }
        }

        private void toolStripProductsButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Products());
        }

        public static void ClearSubForm()
        {
            instance.buffer.Clear(); // Reiniciar el buffer si se detecta la frase

            if (instance != null)
            {
                instance.panel1.Controls.Clear();
            }
        }

        public static void ShowSubForm(Form subForm)
        {

            try
            {
                ClearSubForm();
                subForm.TopLevel = false;
                subForm.AutoScroll = true;
                subForm.FormBorderStyle = FormBorderStyle.None; // Opcional, elimina bordes del formulario
                subForm.Dock = DockStyle.Fill;
                instance.panel1.Controls.Add(subForm);
                if (!subForm.GetType().Name.Equals("Dashboard"))
                {
                    string label = "Dashboard > " + subForm.GetType().Name;
                    instance.labelRuta.Text = label;
                }
                else
                {
                    instance.labelRuta.Text = "Dashboard";
                }

                subForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripDashboardButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Dashboard());
        }

        private void toolStripAttributesButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Attributes());
        }

        private void Common_Load(object sender, EventArgs e)
        {
            instance = this;
            ShowSubForm(new Dashboard());
        }


        private void toolStripCategoriesButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Categorias());
        }

        private void toolStripRelationshipsButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Relaciones());

        }

        private void toolStripHelpButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Help(false));
        }

        private void toolStripIntegrationsButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Integracion());
        }
    }
}
