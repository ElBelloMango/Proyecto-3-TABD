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
            Cargar_Visualizacion();
        }

        private void Cargar_Visualizacion()
        {
            dataGridView1.DataSource = AccesoDatos.GetConsumos();
            dataGridView2.DataSource = AccesoDatos.GetValoracionReq01();
            dataGridView3.DataSource = AccesoDatos.GetValoracionReq02();
        }

        private void ClearCampos()
        {
            //Pagina Edit
            txtboxIdConsumo.Text = "";
            datepickEdit.Value = DateTime.Now;
            comboServicioEdit.SelectedItem = comboServicioAdd.Items[0];
            txtBoxConsumoEdit.Text = "";
            txtBoxValorTEdit.Text = "";

            //Pagina Delete
            txtboxIdConsumoDel.Text = "";
            datepickerDel.Value = DateTime.Now;
            comboServicioDel.SelectedItem = comboServicioAdd.Items[0];
            txtboxConsumoDel.Text = "";
            txtBoxValorTDel.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtboxConsumoAdd.Text != "" && txtboxValorTAdd.Text !="")
            {
                try
                {
                    int año;
                    int mes;
                    int id_servicio;
                    double consumo;
                    double valorT;
                    año = Int32.Parse(datepickAdd.Value.ToString("yyyy"));
                    mes = Int32.Parse(datepickAdd.Value.ToString("MM"));
                    id_servicio = comboServicioAdd.SelectedIndex+1;
                    consumo = Double.Parse(txtboxConsumoAdd.Text);
                    valorT = Double.Parse(txtboxValorTAdd.Text);
                    
                    Consumo Consumo = new Consumo(año, mes, id_servicio, consumo, valorT);
                    AccesoDatos.guardarConsumo(Consumo);
                    MessageBox.Show("Servicio actualizado exitosamente.",
                        "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Visualizacion();
                }
                catch (FormatException error)
                {
                    MessageBox.Show("Los campos deben estar llenos y numéricos\n" +
                        error.Message,
                        "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Los campos deben estar llenos y numéricos\n"
                        ,"Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String mes = dataGridView1.SelectedCells[2].Value.ToString();

                if (Int32.Parse(dataGridView1.SelectedCells[2].Value.ToString()) < 10)
                {
                    mes = "0" + dataGridView1.SelectedCells[2].Value.ToString();
                }
                //Pagina Edit
                txtboxIdConsumo.Text = dataGridView1.SelectedCells[0].Value.ToString();
                datepickEdit.Value = DateTime.ParseExact((dataGridView1.SelectedCells[1].Value + "-" + mes), "yyyy-MM", null);
                comboServicioEdit.SelectedItem = comboServicioEdit.Items[Int32.Parse(dataGridView1.SelectedCells[3].Value.ToString()) - 1];
                txtBoxConsumoEdit.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtBoxValorTEdit.Text = dataGridView1.SelectedCells[5].Value.ToString();

                //Pagina Delete
                txtboxIdConsumoDel.Text = dataGridView1.SelectedCells[0].Value.ToString();
                datepickerDel.Value = DateTime.ParseExact((dataGridView1.SelectedCells[1].Value + "-" + mes), "yyyy-MM", null);
                comboServicioDel.SelectedItem = comboServicioEdit.Items[Int32.Parse(dataGridView1.SelectedCells[3].Value.ToString()) - 1];
                txtboxConsumoDel.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtBoxValorTDel.Text = dataGridView1.SelectedCells[5].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtBoxConsumoEdit.Text != "" && txtBoxValorTEdit.Text != "")
            {
                try
                {
                    int id_consumo;
                    int año;
                    int mes;
                    int id_servicio;
                    double consumo;
                    double valorT;
                    id_consumo = Int32.Parse(txtboxIdConsumo.Text);
                    año = Int32.Parse(datepickEdit.Value.ToString("yyyy"));
                    mes = Int32.Parse(datepickEdit.Value.ToString("MM"));
                    id_servicio = comboServicioEdit.SelectedIndex + 1;
                    consumo = Double.Parse(txtBoxConsumoEdit.Text);
                    valorT = Double.Parse(txtBoxValorTEdit.Text);

                    Consumo Consumo = new Consumo(id_consumo, año, mes, id_servicio, consumo, valorT);
                    AccesoDatos.EditConsumo(Consumo);
                    MessageBox.Show("Servicio actualizado exitosamente.",
                            "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Visualizacion();
                }
                catch (FormatException error)
                {
                    MessageBox.Show("Los campos deben estar llenos y numéricos\n" +
                        error.Message,
                        "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxConsumoEdit.Text != "" && txtBoxValorTEdit.Text != "")
            {
                try
                {
                    int id_consumo;
                    int año;
                    int mes;
                    int id_servicio;
                    double consumo;
                    double valorT;
                    id_consumo = Int32.Parse(txtboxIdConsumoDel.Text);
                    año = Int32.Parse(datepickerDel.Value.ToString("yyyy"));
                    mes = Int32.Parse(datepickerDel.Value.ToString("MM"));
                    id_servicio = comboServicioDel.SelectedIndex + 1;
                    consumo = Double.Parse(txtboxConsumoDel.Text);
                    valorT = Double.Parse(txtBoxValorTDel.Text);

                    Consumo Consumo = new Consumo(id_consumo, año, mes, id_servicio, consumo, valorT);
                    AccesoDatos.DeleteConsumo(Consumo);
                    MessageBox.Show("Servicio eliminado exitosamente.",
                            "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cargar_Visualizacion();
                    ClearCampos();
                }
                catch (FormatException error)
                {
                    MessageBox.Show("Los campos deben estar llenos y numéricos\n" +
                        error.Message,
                        "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
