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
        public static Common instance;
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
            instance.panel1.Controls.Clear();
        }

        public static void ShowSubForm(Form subForm)
        {
            ClearSubForm();
            subForm.TopLevel = false;
            subForm.AutoScroll = true;
            subForm.FormBorderStyle = FormBorderStyle.None; // Opcional, elimina bordes del formulario
            subForm.Dock = DockStyle.Fill;
            instance.panel1.Controls.Add(subForm);
            subForm.Show();
        }

        private void toolStripDashboardButton_Click(object sender, EventArgs e)
        {
            ClearSubForm();
        }

        private void toolStripAttributesButton_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Attributes());
        }

        private void Common_Load(object sender, EventArgs e)
        {
            instance = this;
        }
    }
}
