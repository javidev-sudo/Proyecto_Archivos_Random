using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto_ArchR_javi
{
    public partial class Form1 : Form
    {
        ArchProd a1;
        int codigo;
        int nr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a1 = new ArchProd();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            a1.Abrir_Grabar(saveFileDialog1.FileName);
            bool b = true;

            do
            {
                if (b)
                {
                    codigo = int.Parse(Interaction.InputBox("ingrese el codigo inicial"));
                    b = !b;
                }
                else
                {
                    Interaction.MsgBox("el codigo inicial debe de ser multiplo de 1000, intente nuevamente");
                    codigo = int.Parse(Interaction.InputBox("ingrese el codigo inicial"));
                }

            } while (codigo % 1000 != 0);

            nr = 1;
            dataGridView1.Rows[0].Cells[0].Value = string.Concat(codigo + nr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a1.Grabar(
                     Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value),
                     Convert.ToString(dataGridView1.Rows[0].Cells[1].Value),
                     Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value),
                     Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value),
                     true
                     );

            dataGridView1.Rows.Clear();
            nr++;
            dataGridView1.Rows[0].Cells[0].Value = string.Concat(codigo + nr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nr > 0)
            {

                a1.Cerrar_Grabar();
                Interaction.MsgBox("los datos han sido grabados correctamente");
            }
            else
            {
                Interaction.MsgBox("acceda almenos un registro inicial");
            }
        }
    }
}
