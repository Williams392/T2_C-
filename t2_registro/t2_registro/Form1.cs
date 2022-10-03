using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t2_registro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p_cod;
            string p_nombre;
            float p_precio;

            p_cod = cmbProducto.SelectedIndex;
            p_nombre = cmbProducto.SelectedItem.ToString();
            p_precio = cmbProducto.SelectedIndex;

            switch (p_cod)
            {
                case 0: IBIcodigo.Text = "0011";break;
                case 1: IBIcodigo.Text = "0022";break;
                case 2: IBIcodigo.Text = "0033";break;
                case 3: IBIcodigo.Text = "oo44";break;
                default: IBIcodigo.Text = "0055";break;
            }
            switch (p_nombre)
            {
                case "Alcohol Medicinal 70% - Frasco 120 ML": IBINombre.Text = "Alcohol Medicinal 70% - Frasco 120 ML";break;
                case "Panadol Antigripal NF Tableta": IBINombre.Text = "Panadol Antigripal NF Tableta";break;
                case "Panadol Forte Tableta": IBINombre.Text = "Panadol Forte Tableta";break;
                case "Multiflora Plus Cápsula": IBINombre.Text = "Multiflora Plus Cápsula"; break;
                default: IBINombre.Text = "Vick Vaporub Ungüento tópico";break;
            }
            switch (p_precio)
            {
                case 0: IbIPrecio.Text = "1.80"; break;
                case 1: IbIPrecio.Text = "2.20"; break;
                case 2: IbIPrecio.Text = "1.78"; break;
                case 3: IbIPrecio.Text = "133.80"; break;
                default: IbIPrecio.Text = "9.00"; break;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvLista);

            file.Cells[0].Value = IBIcodigo.Text;
            file.Cells[1].Value = IBINombre.Text;
            file.Cells[2].Value = IbIPrecio.Text;
            file.Cells[3].Value = txtCantidad.Text;
            file.Cells[4].Value = (float.Parse(IbIPrecio.Text) * float.Parse(txtCantidad.Text)).ToString();

            dgvLista.Rows.Add(file);

            DialogResult r = MessageBox.Show("Si se encontró?",
                                              "Medicamento",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Exclamation);
            

            IBIcodigo.Text = IBINombre.Text = txtCantidad.Text = "";


            obtenerTotal();

            
        }

        public void obtenerTotal()
        {
            float costot = 0;
            int contador = 0;

            contador = dgvLista.RowCount;

            for (int i = 0; i < contador; i++) // Bucle
            {
                costot += float.Parse(dgvLista.Rows[i].Cells[4].Value.ToString());
            }

            txtTotatlPagar.Text = costot.ToString();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea eliminar producto?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);
                }
            }
            catch { }
            obtenerTotal();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de Salir?", 
                                              "Registro",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
