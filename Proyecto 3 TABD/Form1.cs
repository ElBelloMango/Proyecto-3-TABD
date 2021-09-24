using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_3_TABD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtboxConsumo.Text != "" && txtboxValorT.Text !=""&& txtboxValorU.Text!="")
            {
                try
                {
                    int año;
                    int mes;
                    int id_servicio;
                    double consumo;
                    double valorT;
                    double valorU;
                    año = Int32.Parse(datepickFecha.Value.ToString("yyyy"));
                    mes = Int32.Parse(datepickFecha.Value.ToString("MM"));
                    id_servicio = comboServicio.SelectedIndex+1;
                    consumo = Double.Parse(txtboxConsumo.Text);
                    valorT = Double.Parse(txtboxValorT.Text);
                    valorU = Double.Parse(txtboxValorU.Text);
                    Consumo Consumo = new Consumo(año, mes, id_servicio, consumo, valorT, valorU);
                    MessageBox.Show(AccesoDatos.test());
                    AccesoDatos.guardarConsumo(Consumo);
                    MessageBox.Show("Servicio actualizado exitosamente.",
                        "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException error)
                {
                    MessageBox.Show("Los campos deben estar llenos y numéricos\n" +
                        error.Message,
                        "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Los campos deben estar llenos y numéricos\n"
                        ,"Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
