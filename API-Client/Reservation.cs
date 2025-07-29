using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Client
{
    public class Reservation
    {
        public int ID_RESERVATION { get; set; }
        public int ID_LIAISON { get; set; }
        public int ID_TRAVERSE { get; set; }
        public int ID_CLIENT { get; set; }
        public string Nomres { get; set; }

        public Reservation(int ID_RESERVATION, int ID_LIAISON, int ID_TRAVERSE, int ID_CLIENT, string Nomres) { 

            this.ID_RESERVATION = ID_RESERVATION;
            this.ID_LIAISON = ID_RESERVATION;
            this.ID_TRAVERSE = ID_TRAVERSE;
            this.ID_CLIENT = ID_CLIENT;
            this.Nomres = Nomres;
        }

    }
}
