using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CSharp_OO_Voiture.Models
{
    public class Course
    {
        private List<Participant> _Participants = [];

        public string Nom { get; set; }
        public Circuit Circuit { get; set; }
        public IEnumerable<Participant> Participants
        {
            get { return _Participants.AsReadOnly(); }
        }
        public int NbTour { get; set; }
        public int TourActuel { get; private set; } = 0;
        public bool EstFini
        {
            get { return TourActuel >= NbTour; }
        }

        public bool AjouterParticipant(int numero, Pilote pilote, Voiture voiture)
        {
            if (_Participants.Any(participant => participant.Numero == numero))
            {
                return false;
            }

            Participant participant = new Participant();
            participant.Numero = numero;
            participant.Pilote = pilote;
            participant.Voiture = voiture;

            _Participants.Add(participant);
            return true;
        }

        public void LancerSimulationTour()
        {
            if (EstFini)
            {
                throw new Exception("Bah, c'est fini :o");
            }

            foreach (Participant participant in _Participants)
            {
                participant.FaireTour(Circuit);
            }

            TourActuel++;
        }

        public Participant ObtenirLeVainqueur()
        {
            if (_Participants.Count <= 0)
            {
                throw new Exception("Bah, il y a personne...");
            }
            if (!EstFini)
            {
                throw new Exception("Il faut lancer la simulation avant...");
            }

            Participant winner = _Participants.First();

            for (int i = 1; i < _Participants.Count; i++)
            {
                if (winner.TempsTotal > _Participants[i].TempsTotal)
                {
                    winner = _Participants[i];
                }
            }

            return winner;
        }
    }
}
