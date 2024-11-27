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
        public Common()
        {
            InitializeComponent();
        }

        private void toolStripProductsButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Products());
        }

        public static void ClearSubForm()
        {
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
                string label = "Dashboard > " + subForm.GetType().Name;
                instance.labelRuta.Text = label;
                subForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripDashboardButton_Click(object sender, EventArgs e)
        {
            ClearSubForm();
            string label = "Dashboard";
            instance.labelRuta.Text = label;
        }

        private void toolStripAttributesButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Attributes());
        }

        private void Common_Load(object sender, EventArgs e)
        {
            instance = this;
        }


        private void toolStripCategoriesButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Categorias());
        }

        private void toolStripRelationshipsButton_Click(object sender, EventArgs e)
        {
            //ShowSubForm(new Relaciones());
        }
    }
}
