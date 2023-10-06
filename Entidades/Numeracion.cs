using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Numeracion
    {
        protected static string msgError;
        protected string valor;


        static Numeracion()
        {
            Numeracion.msgError = "Numero Invalido";
        }

        protected Numeracion(string valor)
        {
            InicializaValor(valor);
        }

        public string Valor 
        { 
            get { return this.valor; }
        }

        internal abstract double ValorNumerico { get; }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);

        protected virtual bool EsNumeracionValida(string valor)
        {
            return !String.IsNullOrWhiteSpace(valor);
        }

        private void InicializaValor(string valor)
        {
            this.valor = Numeracion.msgError;
           
            if(EsNumeracionValida(valor))
            {
                if (decimal.TryParse(valor, out decimal result))
                {
                    //es una forma de validar que solo ingrese numeros, 0101 o 232324, vale para decimal o bin.
                    this.valor = valor;
                }
               
            }
        }


        //i. Dos numeraciones serán iguales si no son nulas y son del mismo tipo. 
        //asumo que del mismo tipo Numeracion o derivadas
        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            //n1.GetType() == typeof(Numeracion) && n2.GetType() == typeof(Numeracion);
            //si comparo por GetType tambien permito a las derivadas.
            //n1.GetType() == n2.GetType();
            return n1 is not null && n2 is not null && n1.GetType() == typeof(Numeracion) && n2.GetType() == typeof(Numeracion);
        }
        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }

        public static explicit operator double(Numeracion numeracion)
        {
           // double.TryParse(numeracion.Valor, out double result);
           //numeracion.ValorNumerico -> por polimorfismo convierte
            return double.Parse(numeracion.Valor);
        }




    }
}
