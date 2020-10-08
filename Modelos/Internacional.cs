using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Internacional : Excursion
    {
        private CompaniaAerea companiaAerea;
        public Internacional(CompaniaAerea companiaAerea, string descripcion, DateTime fechaInicioViaje, int cantidadDiasTraslados, int stockDisponible) : base( descripcion,  fechaInicioViaje,  cantidadDiasTraslados,  stockDisponible)
        {
            this.companiaAerea = companiaAerea;
        }

        public CompaniaAerea CompaniaAerea
        {
            get { return companiaAerea; }
        }

    }
}
