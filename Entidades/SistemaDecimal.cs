using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {

        public SistemaDecimal(string valor) : base(valor)
        { }





        internal override double ValorNumerico 
        {

            /*Sin importar el sistema en el que estés, 
             * siempre tiene que devolver la conversión a decimal de lo que tenga guardado*/


            get
            {
                if (this.EsSistemaDecimalValido(base.valor))
                {
                    return double.Parse(base.valor);
                }
                else
                {
                    return -1;
                }
              
            }
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Binario)
            {
                return this.DecimalABinario();
            }
         
            return this;
        }



        /*Que el sistema decimal valida que se pueda convertir
            Y el metodo numeracion valida hace las 2 cosas*/
        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaDecimalValido(valor);
        }

        private  bool EsSistemaDecimalValido(string valor)
        {
            //base.EsNumeracionValida(valor)
            return decimal.TryParse(valor, out decimal result);
        }







        //falta terminar
       private SistemaBinario DecimalABinario()
        {
            string valorBinario = "Numero invalido";
            int numeroEntero = (int)this.ValorNumerico;


            if (numeroEntero > 0)
            {
                int resto;
                valorBinario = string.Empty;
                while (numeroEntero > 0)
                {
                    resto = numeroEntero % 2;
                    numeroEntero /= 2;
                    valorBinario = resto.ToString() + valorBinario;
                }
                //retornamos un sist binario con este valor.
                return new SistemaBinario(valorBinario);
            }
            //return sist. binario con valor = msg.error
            return new SistemaBinario(Numeracion.msgError);
         }


        public static implicit operator SistemaDecimal(double valor)
        {
            return new SistemaDecimal(valor.ToString());
        }

        public static implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }













    }
}
