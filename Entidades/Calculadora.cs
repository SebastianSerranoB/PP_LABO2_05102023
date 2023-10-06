using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private static ESistema sistema;

        static Calculadora()
        {
            Calculadora.sistema = ESistema.Decimal;
        }

        public Calculadora()
        {
            this.operaciones = new List<string>();
        }

        public Calculadora(string nombreAlumno)
        {
            this.nombreAlumno = nombreAlumno;
        }

        public string NombreAlumno
        {
            get
            { return this.nombreAlumno; }

            set { this.nombreAlumno = value; }

        }

        public static ESistema Sistema
        {
            get
            {
                return Calculadora.sistema;
            }

            set
            {

                Calculadora.sistema = value;
            }
        }


        public List<string> Operaciones 
        {
            get
            {
                return this.operaciones;
            }

          
        
        }

        public Numeracion PrimerOperando
        {
            get
            {
                return this.primerOperando;
            }


            set
            {

                this.primerOperando = value;

            }
        }

        public Numeracion SegundoOperando
        {
            get
            {
                return this.segundoOperando;
            }


            set
            {

                this.segundoOperando = value;

            }
        }

        public Numeracion Resultado
        {
            get
            {
                return this.resultado;
            }
        
        }


        public void Calcular()
        {
             double valor = this.primerOperando.ValorNumerico + this.segundoOperando.ValorNumerico; ;
            this.resultado =  MapeaResultado(valor);
        }

        public void Calcular(char operador)
        {
            if (this.PrimerOperando != this.SegundoOperando)
            {
                this.MapeaResultado(double.MinValue);

            }
            else
            {


                //fala validar igualdad
                switch (operador)
                {
                    case '-':
                        this.MapeaResultado( this.PrimerOperando.ValorNumerico - this.SegundoOperando.ValorNumerico);
                        break;

                    case '/':
                        if (this.SegundoOperando.ValorNumerico == 0 || this.PrimerOperando.ValorNumerico == 0)
                        {
                            this.MapeaResultado(double.MinValue);
                        }
                        else
                        {
                            this.MapeaResultado( this.PrimerOperando.ValorNumerico / this.SegundoOperando.ValorNumerico);
                        }
                        break;

                    case '*':
                         this.MapeaResultado(this.PrimerOperando.ValorNumerico * this.SegundoOperando.ValorNumerico);
                        break;

                    default:
                        Calcular();
                        break;

                }
            }
        }



        public string ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder sB = new StringBuilder();

            sB.AppendLine($"Sistema: {Calculadora.Sistema}");
            sB.AppendLine($"Primer operando: {PrimerOperando.Valor}");
            sB.AppendLine($"Segundo operando: {segundoOperando.Valor}");
            sB.AppendLine($"Operador: {operador}");

            return sB.ToString();
        }




        private Numeracion MapeaResultado(double valor)
        {
            if (Calculadora.Sistema == ESistema.Decimal)
            {
                return new SistemaDecimal(valor.ToString());
            }

            return new SistemaBinario(valor.ToString());
        }


        public void EliminarHistorialDeOperaciones()
        {
            operaciones.Clear();
        }




























    }


}
