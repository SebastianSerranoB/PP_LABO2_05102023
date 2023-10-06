using Entidades;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        private Calculadora calculadora;

        public FrmCalculadora()
        {
            InitializeComponent();
            this.calculadora = new Calculadora("Sebastian Serrano");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la calculadora?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }

        }


        private void MostrarHistorial()
        {
            this.lstHistorial.DataSource = null;
            this.lstHistorial.DataSource = this.calculadora.Operaciones;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.calculadora.EliminarHistorialDeOperaciones();
            this.txtPrimerOperando.Text = string.Empty;
            this.txtSegundoOperando.Text = string.Empty;
            this.lblResultado.Text = $"Resultado:";
            this.MostrarHistorial();
        }


        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperacion.DataSource = new char[] { '+', '-', '*',
                                                                    '/' };


           // this.rdbDecimal.Checked = true;
           // this.cmbOperacion.SelectedItem = "";
        }

        private Numeracion GetOperando(string value)
        {
            if (Calculadora.Sistema == ESistema.Binario)
            {
                return new SistemaBinario(value);
            }
            return new SistemaDecimal(value);
        }

        private Numeracion GetOperador(string value)
        {
            if (Calculadora.Sistema == ESistema.Binario)
            {
                return new SistemaBinario(value);
            }
            return new SistemaDecimal(value);
        }


        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            Calculadora.Sistema = ESistema.Decimal;
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            Calculadora.Sistema = ESistema.Binario;
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        private void btnOperar_Click(object sender, EventArgs e)
        {
            char operador;
            calculadora.PrimerOperando = this.GetOperador(this.txtPrimerOperando.Text);
            calculadora.SegundoOperando =this.GetOperador(this.txtSegundoOperando.Text);
            operador = (char)this.cmbOperacion.SelectedItem;
            this.calculadora.Calcular(operador);
            this.calculadora.ActualizaHistorialDeOperaciones(operador);
            this.lblResultado.Text = $"Resultado: { calculadora.Resultado.Valor}";
                                this.MostrarHistorial();

        }
        //el listbox es una coleccion, nos va a psar el codigo, peor hay distintos elementos,
        //la parte del formulario hay que casi despreocuparse porque el codigo lo pasa el profe

        //private void SetResultado() { }
    }
}