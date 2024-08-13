
using Exo_CSharp_OO_Voiture.Models;

Circuit spa = new Circuit();
spa.Nom = "Circuit de Spa-Francorchamps";
spa.Longueur = 6.947;

Course course = new Course();
course.Nom = "La course des petits nuages de TFTIC";
course.NbTour = 5;
course.Circuit = spa;

Pilote p1 = new Pilote();
p1.Prenom = "Della";
p1.Nom = "Duck";
p1.Categorie = Pilote.CategorieEnum.MOYEN;

Pilote p2 = new Pilote();
p2.Prenom = "Zaza";
p2.Nom = "Vanderquack";
p2.Categorie = Pilote.CategorieEnum.LEGER;

Pilote p3 = new Pilote();
p3.Prenom = "Riri";
p3.Nom = "Duck";
p3.Categorie = Pilote.CategorieEnum.LEGER;

Pilote p4 = new Pilote();
p4.Prenom = "Flagada";
p4.Nom = "Jones";
p4.Categorie = Pilote.CategorieEnum.LOURD;

Voiture v1 = new Voiture();
v1.Marque = "Tata";
v1.Modele = "Super Nano";
v1.VitesseMax = 175;
v1.VitesseMin = 100;

Voiture v2 = new Voiture();
v2.Marque = "Porsche";
v2.Modele = "GT3 RS";
v2.VitesseMax = 270;
v2.VitesseMin = 130;

Voiture v3 = new Voiture();
v3.Marque = "Tesla";
v3.Modele = "CyberTruck";
v3.VitesseMax = 170;
v3.VitesseMin = 150;

course.AjouterParticipant(42, p1, v2);
course.AjouterParticipant(11, p2, v3);
course.AjouterParticipant(25, p3, v1);
course.AjouterParticipant(-5, p4, v1);


Console.WriteLine("Simulation de la course");
while(!course.EstFini)
{
    course.LancerSimulationTour();

    Console.WriteLine($"Tour {course.TourActuel}");
    foreach (Participant participant in course.Participants)
    {
        Console.WriteLine($" - {participant.Pilote.NomComplet} : {participant.TempsTotal}");
    }
    Console.ReadLine();
}
Console.WriteLine();


Console.WriteLine("Resultat de la course");
Participant winner = course.ObtenirLeVainqueur();
Console.WriteLine($"Le vainqueur est {winner.Pilote.NomComplet} avec un temps total de {winner.TempsTotal} et son meilleur tour est de {winner.BestTours}");