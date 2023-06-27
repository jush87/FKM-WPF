using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKM
{
    public class Parcours
    { public string Date{ get; set; }
      public string Depart { get; set; }
      public string Arrivee { get; set; }
      public string Distance { get; set; }
      public string Ticket { get; set; }
       


        public Parcours (string dat, string dep, string ar, string dist, string tick)
           : base()//constructeur de la base de la classe Client
        {
            Date = dat;
            Depart = dep;
            Arrivee = ar;
            Distance = dist;
            Ticket = tick;
            
            
        }
    }
}
