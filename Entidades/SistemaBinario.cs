using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        public SistemaBinario(string valor) : base(valor)
        { }

        internal override double ValorNumerico 
        {

            get
            {

                //REUTILIZAR
                if (this.EsSistemaBinarioValido(base.valor) && base.valor != Numeracion.msgError)
                {
                    double valorDecimal = 0;
                    int longitudValor = base.valor.Length;
                    int digito;


                    for (int i = 0; i < longitudValor; i++)
                    {
                        digito = valor[i] - '0';

                        valorDecimal += digito * (int)Math.Pow(2, longitudValor - 1 - i);
                    }

                    return valorDecimal;
                }

                return double.MinValue;
            }
        
        }
        //prop valorNumerico hay que convertir a decimal


        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (ESistema.Decimal == sistema)
            {
                return this.BinarioADecimal();
            }

            return this;
        }



        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaBinarioValido(Valor);
        }

        private bool EsSistemaBinarioValido(string valor)
        {
            foreach (char c in valor)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }

        private SistemaDecimal BinarioADecimal()
        {
            
            if (this.EsSistemaBinarioValido(base.valor) && base.valor != Numeracion.msgError)
            {
                double valorDecimal = 0;
                int longitudValor = base.valor.Length;
                int digito;


                for (int i = 0; i < longitudValor; i++)
                {
                    digito = valor[i] - '0';

                    valorDecimal += digito * (int)Math.Pow(2, longitudValor - 1 - i);
                }

                return new SistemaDecimal(valorDecimal.ToString());
            }

            return new SistemaDecimal(double.MinValue.ToString());

        }



        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }

       

    }
}
