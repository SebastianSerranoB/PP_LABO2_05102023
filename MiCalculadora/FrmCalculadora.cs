using Entidades;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
       

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento disparado al cerrar el formulario, pregunta si es la decision final.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la calculadora?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtPrimerOperador.Clear();
            this.txtSegundoOperador.Clear();
            this.lblResultado.Text = "Resultado:";
           // this.resultado = null;
        }

        /// <summary>
        /// Evento disparado al construir el form, settea por defecto el resultado a decimal, y la operacion seleccionada como vacio(suma por defecto)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.rdbDecimal.Checked = true;
            this.cmbOperacion.SelectedItem = "";
        }





















        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
           /* 
                if (this.rdbDecimal.Checked == true)
                {
                    this.sistema = Esistema.Decimal;
                    this.SetResultado();
                }
           */
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            /*
                if (this.rdbBinario.Checked == true)
                {
                    this.sistema = Esistema.Binario;
                    this.SetResultado();
                }

            */
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            
        }

        //private void SetResultado() { }
        
           
            
        


        //ss
        /// <summary>
        /// Valida el input de los textbox, si ok realiza la operacion correspondiente y muestra el resultado, de lo contrario genera una ventana emergente indicando error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
           
        } 

      

    }
}