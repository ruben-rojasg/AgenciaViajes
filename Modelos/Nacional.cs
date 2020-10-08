using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
   public class Nacional : Excursion
    {
        private bool interesNacional = false;
        public Nacional(bool interesNacional, string descripcion, DateTime fechaInicioViaje, int cantidadDiasTraslados, int stockDisponible) : base( descripcion,  fechaInicioViaje,  cantidadDiasTraslados,  stockDisponible)
        {
            this.interesNacional = interesNacional;
        }

        public bool InteresNacional
        {
            get { return interesNacional; }
        }
    }
}
