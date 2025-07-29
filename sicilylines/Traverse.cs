using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sicilylines
{
    public class Traverse
    {
        public int ID_LIAISON { get; set; }
        public int ID_TRAVERSE { get; set; }
        public int ID_BATEAU { get; set; }
        public string NOM { get; set; }
        public DateTime DATETRAVERSE { get; set; }

        public Traverse(int ID_LIAISON, int ID_TRAVERSE, int ID_BATEAU, string NOM, DateTime DATETRAVERSE)
        {
            this.ID_LIAISON = ID_LIAISON;
            this.ID_TRAVERSE = ID_TRAVERSE;
            this.ID_BATEAU = ID_BATEAU;
            this.NOM = NOM;
            this.DATETRAVERSE = DATETRAVERSE;
        }
    }
}