using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EnviosForms
{
    public partial class FormSeleccionPlantillas : Form
    {
        ComunidadesForms.EnviosForms.CompletarEnvioForm form_anterior;

        public FormSeleccionPlantillas(ComunidadesForms.EnviosForms.CompletarEnvioForm form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        private void FormSeleccionPlantillas_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Circular", @"\\Urenux\urendes\PLANTILLAS\PlantillasEnviosApp\Circular.txt");
            dataGridView1.Rows.Add("Acta", @"\\Urenux\urendes\PLANTILLAS\PlantillasEnviosApp\Acta.txt");
            dataGridView1.Rows.Add("Convocatoria", @"\\Urenux\urendes\PLANTILLAS\PlantillasEnviosApp\Convocatoria.txt");
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                String total = "";
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(dataGridView1.SelectedCells[1].Value.ToString());
                while ((line = file.ReadLine()) != null)
                {
                    total += line + "\r\n";
                }
                file.Close();
                form_anterior.recogerText(total);
                this.Close();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String total = "";
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(dataGridView1.SelectedCells[1].Value.ToString());
            while ((line = file.ReadLine()) != null)
            {
                total += line + "\r\n";
            }
            file.Close();
            form_anterior.recogerText(total);
            this.Close();
        }
    }
}
