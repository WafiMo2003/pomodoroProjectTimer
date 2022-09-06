using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly:InternalsVisibleTo("TestTache")]

namespace PomodoroTimer
{
    public class Tache
    {
        //Déclaration des attributs d'une tâche
        public String Description
        {
            set;
            get;

        }
        public int NbrPomodorosPrevus
        {
            set;
            get;

        }
        public int NbrPomodorosTermines
        {
            set;
            get;

        }
        public enum Statut
        {
            COMPLETEE,
            PLANIFIEE,
            EN_COURS
        }
        //Déclaration de la variable de type statut
        public Statut enumStatut
        {

            get;
            set;
        }
        /// <summary>
        /// Cette méthode contient le constructeur d'une tâche
        /// </summary>
        public Tache(String description, int nbrPomodorosPrevus, int nbrPomodorosTermines,String statut) 

        {
            Description = description;
            NbrPomodorosPrevus = nbrPomodorosPrevus;
            NbrPomodorosTermines = nbrPomodorosTermines;
            
            //Ce code permet de définir la valeur de l'enum statut en fonction de la châine de caractères passéee en paramètres
            if (statut.Equals("PLANIFIEE"))
            {
                Statut StatutCommande = Tache.Statut.PLANIFIEE;
                enumStatut = StatutCommande;
            }
            else if (statut.Equals("EN_COURS"))
            {
                Statut StatutCommande = Tache.Statut.EN_COURS;
                enumStatut = StatutCommande;
            }
            else if (statut.Equals("COMPLETEE"))
            {

                Statut StatutCommande = Tache.Statut.COMPLETEE;
                enumStatut = StatutCommande;
            }
           


        }

        //Ceci est un constructeur vide
        public Tache()
        {

        }
        //Méthode pour afficher la description d'une tâche
        public override string ToString()
        {

            return Description;
        }

    }
}
