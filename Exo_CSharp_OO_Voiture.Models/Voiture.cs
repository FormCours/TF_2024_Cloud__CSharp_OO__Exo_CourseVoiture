using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CSharp_OO_Voiture.Models
{
    public class Voiture
    {
        private const int SECONDES_DANS_HEURE = 3600;
        private double _VitesseMin;
        private double _VitesseMax;

        public string Marque { get; set; }
        public string Modele { get; set; }
        public double VitesseMin
        {
            get { return _VitesseMin; }
            set 
            {
                if (value < 0 || value > VitesseMax)
                {
                    throw new ArgumentException();
                }
                _VitesseMin = value;
            }
        }
        public double VitesseMax
        {
            get { return _VitesseMax; }
            set 
            {
                if (value < 0 || value < VitesseMin)
                {
                    throw new ArgumentException();
                }
                _VitesseMax = value; 
            }
        }


        public double FaireTourCircuit(Circuit circuit, Pilote pilote)
        {
            double vitesseMoy = GenerateVitesseMoyenne(pilote);
            double distance = circuit.Longueur;

            double temps = (distance / vitesseMoy) * SECONDES_DANS_HEURE;
            return Math.Round(temps, 2);
        }

        private double GenerateVitesseMoyenne(Pilote pilote)
        {
            double vitesseMinReel = VitesseMin * GetModificateurVitesseMin(pilote);
            double vitesseMaxReel = Math.Max(VitesseMax * GetModificateurVitesseMax(pilote), vitesseMinReel);

            double deltaVitesse = vitesseMaxReel - vitesseMinReel;
            double vitesse = (Random.Shared.NextDouble() * deltaVitesse) + vitesseMinReel;

            return Math.Round(vitesse, 2);
        }

        private double GetModificateurVitesseMax(Pilote pilote)
        {
            switch (pilote.Categorie)
            {
                case Pilote.CategorieEnum.LEGER:
                    return 0.7;
                case Pilote.CategorieEnum.LOURD:
                    return 1.4;
                default: 
                    return 1;
            }
        }

        private double GetModificateurVitesseMin(Pilote pilote)
        {
            switch (pilote.Categorie)
            {
                case Pilote.CategorieEnum.LEGER:
                    return 1.1;
                case Pilote.CategorieEnum.LOURD:
                    return 0.5;
                default:
                    return 1;
            }
        }
    }
}
