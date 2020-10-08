using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public abstract class Excursion
    {
        private int id = 0;
        private static int ultId = 1000;
        private string descripcion;
        private DateTime fechaInicioViaje;
        private List<Destino> destino = new List<Destino>();
        private int cantidadDiasTraslados;
        private int stockDisponible;
        public Excursion(string descripcion, DateTime fechaInicioViaje, int cantidadDiasTraslados, int stockDisponible)
        {
            this.id = ultId;
            ultId += 100;
            this.descripcion = descripcion;
            this.fechaInicioViaje = fechaInicioViaje;
            this.cantidadDiasTraslados = cantidadDiasTraslados;
            this.stockDisponible = stockDisponible;
        }

        public string Descripcion
        {
            get { return descripcion; }
        }

        public DateTime FechaInicioViaje
        {
            get { return fechaInicioViaje; }
        }

        public int CantidadDiasTraslados
        {
            get { return cantidadDiasTraslados; }
        }

        public int StockDisponible
        {
            get { return stockDisponible; }
        }

        public List<Destino> Destinos
        {
            get { return destino; }
            set { destino = value; }
        }

        public double CostoTotal()
        {
            double costoTotal = 0;
            foreach (var item in destino)
            {
                costoTotal += item.CostoDiario * item.CantidadDias;
            }
            return costoTotal;
        }

        public override string ToString()
        {
            
            string mensaje = "";
            mensaje += "Descripcion " + descripcion + "\n";
            mensaje += "Ciudades de la excursión:" + "\n";
            for (int i = 0; i < Destinos.Count; i++)
            {
                mensaje += Destinos[i].Ciudad +", " + Destinos[i].Pais + "\n";
            }
            mensaje += "Fecha de Inicio de viaje " + fechaInicioViaje + "\n";
            mensaje += "Cantidad de dias de traslados " + cantidadDiasTraslados + "\n";
            mensaje += "Stock disponible " + stockDisponible + "\n";
            mensaje += "Costo total por persona U$S " + CostoTotal() + "\n";
            return mensaje;
        }

        

    }
}
