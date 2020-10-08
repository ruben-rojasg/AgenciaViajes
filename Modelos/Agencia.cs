using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Agencia
    {
        private List<Excursion> excursiones = new List<Excursion>();
        private List<Destino> destinos = new List<Destino>();
        private List<CompaniaAerea> companias = new List<CompaniaAerea>();
        public double cotizacion { get; set; }
        public List<Excursion> listaExcursiones
        {
            get { return excursiones; }
        }

        public Agencia()
        {
            PreCargaDatos();
        }

        public void PreCargaDatos()
        {
            Destino destino = new Destino("Maldonado", "Uruguay", 3, 50);
            Destino destino1 = new Destino("Rocha", "Uruguay", 2, 80);
            List<Destino> destinos = new List<Destino>();
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionesNacional(true, "Excursion al Este", new DateTime(2020, 10, 01), 1, 20, destinos);

            destino = new Destino("Salto", "Uruguay", 3, 50);
            destino1 = new Destino("Artiga", "Uruguay", 4, 80);
            destinos = new List<Destino>();
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionesNacional(true, "Excursion al Norte", new DateTime(2020, 10, 01), 2, 20, destinos);

            destino = new Destino("Salto", "Uruguay", 4, 50);
            destino1 = new Destino("Paysandu", "Uruguay", 3, 80);
            destinos = new List<Destino>();
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionesNacional(true, "Excursion a las Termas", new DateTime(2020, 10, 01), 2, 20, destinos);

            destino = new Destino("Rocha", "Uruguay", 3, 50);
            destino1 = new Destino("Treinta y Tres", "Uruguay", 2, 80);
            destinos = new List<Destino>();
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionesNacional(true, "Excursion a la Paloma", new DateTime(2020, 10, 01), 1, 20, destinos);

            //Lista internacionales
            destinos = new List<Destino>();
            destino = new Destino("Rio", "Brasil", 5, 60);
            destino1 = new Destino("Buenos Aires", "Argentina", 3, 40);
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionInternacional("Brasil", 1, "Excursion Sur America", new DateTime(2020, 10, 15), 1, 30, destinos);

            destinos = new List<Destino>();
            destino = new Destino("Varadero", "Cuba", 7, 60);
            destino1 = new Destino("Cancun", "Mexico", 7, 40);
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionInternacional("Brasil", 1, "Excursion al Caribe", new DateTime(2020, 10, 15), 2, 30, destinos);

            destinos = new List<Destino>();
            destino = new Destino("Madrid", "España", 7, 60);
            destino1 = new Destino("Venecia", "Italia", 7, 40);
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionInternacional("Brasil", 1, "Excursion a Europa", new DateTime(2020, 10, 15), 3, 30, destinos);

            destinos = new List<Destino>();
            destino = new Destino("Hong kong", "China", 7, 60);
            destino1 = new Destino("Tokio", "Japon", 10, 40);
            destinos.Add(destino);
            destinos.Add(destino1);
            AgregarExcursionInternacional("Brasil", 1, "Excursion a Europa", new DateTime(2020, 10, 15), 3, 30, destinos);

        }

        public void AgregarExcursionesNacional(bool esInteresNacional, string descripcion, DateTime fechaInicioViaje, int cantidadDiasTraslados, int stockDisponible, List<Destino> destinos)
        {
            Nacional unaExcursion = new Nacional(esInteresNacional, descripcion, fechaInicioViaje, cantidadDiasTraslados, stockDisponible);
            unaExcursion.Destinos = destinos;
            excursiones.Add(unaExcursion);
        }

        public void AgregarExcursionInternacional(string paisQuePertenece, int id, string descripcion, DateTime fechaInicioViaje, int cantidadDiasTraslados, int stockDisponible, List<Destino> destinos)

        {
            CompaniaAerea unaCompania = new CompaniaAerea(paisQuePertenece, id);
            Internacional unaInternacional = new Internacional(unaCompania, descripcion, fechaInicioViaje, cantidadDiasTraslados, stockDisponible);
            unaInternacional.Destinos = destinos;
            excursiones.Add(unaInternacional);
        }

        public bool IngresarDestino(string ciudad, string pais, int cantidadDias, double costoDiario)
        {
            bool retorno = false;
            if (Destino.EsMayor3(ciudad) && Destino.EsMayor3(pais) && Destino.ComprobarQueSeaPositivo(cantidadDias) && Destino.ComprobarQueSeaPositivo(costoDiario) && CombinacionUnica(ciudad, pais))
            {
                Destino unDestino = new Destino(ciudad, pais, cantidadDias, costoDiario);
                destinos.Add(unDestino);
                retorno = true;
            }
            return retorno;
        }

        public bool CombinacionUnica(string ciudad, string pais)
        {
            bool retorno = true;
            foreach (var item in ObtenerDestinos())
            {
                if (item.Ciudad == ciudad && item.Pais == pais)
                {
                    retorno = false;
                    break;
                }

            }
            return retorno;
        }

        public List<Destino> ObtenerDestinos()
        {
            List<Destino> listaDestino = destinos;
            foreach (var excursion in excursiones)
            {
                foreach (var destino in excursion.Destinos)
                {
                    listaDestino.Add(destino);
                }
            }
            return listaDestino;
        }

        //public List<Excursion> ExcursionesXFecha(string destino, DateTime desde, DateTime hasta)
        //{
        //    List<Excursion> aux = new List<Excursion>();
        //    foreach (Excursion unaExcursion in excursiones)
        //    {
        //        if (unaExcursion.FechaInicioViaje >= desde && unaExcursion.FechaInicioViaje <= hasta)
        //        {
        //            aux.Add(unaExcursion);

        //        }

        //    }

        //    return aux;



        //}
    }
}
