using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CSharp_OO_Voiture.Models
{
    public class Pilote
    {
        public enum CategorieEnum
        {
            LEGER, MOYEN, LOURD
        }

        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string NomComplet
        {
            get { return $"{Prenom} {Nom}"; }
        }
        public CategorieEnum Categorie { get; set; }

    }
}
