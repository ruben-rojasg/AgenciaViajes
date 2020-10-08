using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class CompaniaAerea
    {
        string paisQuePertenece;
        int id;

        public CompaniaAerea(string paisQuePertenece, int id)
        {
            this.paisQuePertenece = paisQuePertenece;
            this.id = id;
        }

        public string PaisQuePertenece 
        {
            get { return paisQuePertenece; }        
        }

        public int Id
        {
            get { return id; }
        }

    }
}
