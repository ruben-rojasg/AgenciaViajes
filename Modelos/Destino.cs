using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Destino
    {
        string ciudad;
        string pais;
        int cantidadDias;
        double costoDiario;
        public Destino(string ciudad, string pais, int cantidadDias, double costoDiario)
        {
            this.ciudad = ciudad;
            this.pais = pais;
            this.cantidadDias = cantidadDias;
            this.costoDiario = costoDiario;
        }

        public string Ciudad
        {
            get { return ciudad; }
        }

        public string Pais
        {
            get { return pais; }
        }

        public int CantidadDias
        {
            get { return cantidadDias; }
        }

        public double CostoDiario
        {
            get { return costoDiario; }
        }

        public static bool EsMayor3(string valor)
        {
            bool retorno = false;
            if (valor.Length >= 3)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool ComprobarQueSeaPositivo(double valor)
        {
            bool retorno = false;
            if (valor >= 0)
            {
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            string respuesta = "";

            respuesta += "Ciudad " + ciudad + "\n";
            respuesta += "Pais " + pais + "\n";
            respuesta += "Cantidad de dias " + cantidadDias + "\n";
            respuesta += "Costo diario " + "U$S " + costoDiario + "\n";
            respuesta += "Estadia " + "U$S " + (costoDiario * cantidadDias) + "\n";

            return respuesta;
        }
    }
}
