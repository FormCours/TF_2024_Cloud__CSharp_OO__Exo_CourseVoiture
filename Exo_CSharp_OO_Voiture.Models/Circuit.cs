using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CSharp_OO_Voiture.Models
{
    public class Circuit
    {
		private double _Longueur;

        public string Nom { get; set; }
		public double Longueur
        {
			get { return _Longueur; }
			set { _Longueur = value; }
		}
	}
}
