using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CSharp_OO_Voiture.Models
{
    public class Participant
    {
        private List<double> _TempsTours = [];

        public int Numero { get; set; }
        public Voiture Voiture { get; set; }
        public Pilote Pilote { get; set; }
        public IEnumerable<double> TempsTours
        {
            get { return _TempsTours.AsReadOnly(); }
        }
        public double TempsTotal
        {
            get
            {
                double total = 0;
                foreach (double temp in TempsTours)
                {
                    total += temp;
                }
                return Math.Round(total, 2);
            }
        }
        public double? BestTours
        {
            get
            {
                double? best = null;
                foreach (double temp in TempsTours)
                {
                    if (best is null || temp < best) {
                        best = temp;
                    }
                }
                return best;
            }

        }

        public void FaireTour(Circuit circuit)
        {
            double temps = Voiture.FaireTourCircuit(circuit, Pilote);
            _TempsTours.Add(temps);
        }
    }
}
