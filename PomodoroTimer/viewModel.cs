using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PomodoroTimer
{
    //ON CRÉE UN OBJET MODEL À PARTIR DUQUEL ON APPELLERA LES MÉTHODES NÉCESSAIRES
    class ViewModel : INotifyPropertyChanged
    {
      
        private model leModele;
        public event PropertyChangedEventHandler? PropertyChanged;

        
        private Tache tacheSelectionnee;

        public ViewModel()
        {
            //Déclaration du modèle
            leModele = new model();
            //Chargement du fichier XML à partir du modèle
            leModele.ChargerXML();
        }

        //Déclaration de la structure des tâches à partir du modèle
       public  ObservableCollection<Tache> TachesListe
        {
            get
            {
                return leModele.LesTaches;
            }
        }

        //Déclaration de la propriété relative au statut de la tâche sélectionnée
        public string StatutTache
        {
            get
            {
                //Ceci est une série de conditions définissant le statut de la tâche en enum selon la chaine de caractères passée en paramètre
                if (tacheSelectionnee == null)
                {
                    return "";
                }

                if (tacheSelectionnee.enumStatut == Tache.Statut.PLANIFIEE)
                {
                    
                    return "PLANIFIÉE";
                }
                else if (tacheSelectionnee.enumStatut == Tache.Statut.COMPLETEE)
                {
                    return "COMPLÉTÉE";
                }
                else
                {
                    return "EN COURS";
                }
            }
          
        }

        //Déclaration de la propriété relative à la tâche sélectionnée
        public Tache TacheSelectionne
        {
            get
            {
                return tacheSelectionnee;
            }

            set
            {
                tacheSelectionnee = value;
                //Permet la modification sur l'interface graphique de la tâche sélectionnée
                OnPropertyChange("StatutTache");
                OnPropertyChange("nbrPomodorosCompletes");
                OnPropertyChange("nbrPomodorosPrevus");
            }
        }
        //Déclaration de la propriété relative au nombre de pomodoros complétés
        public int nbrPomodorosCompletes
        {
            get
            {
                if (tacheSelectionnee == null)
                {
                    return 0;
                }
                else
                {
                    return tacheSelectionnee.NbrPomodorosTermines;
                }
            }
    
        }
        //Déclaration de la propriété relative au nombre de pomodoros prévus
        public int nbrPomodorosPrevus
        {
            get
            {
                if (tacheSelectionnee == null)
                {
                    return 0;
                }
                else
                {
                    return tacheSelectionnee.NbrPomodorosPrevus;
                }
            }
         
        }
        public void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        

        /// <summary>
        /// Cette méthode permet de créer des tâches en utilisant les paramètres passés dans la vue et à ajouter la tâche dans la liste
        /// </summary>
        public void CreationTache(String desc, int nbrPomodorosPrevus, int nbrPomodorosTermines,String statutCommande)
        {
            Tache nouvelleTache = new Tache(desc, nbrPomodorosPrevus, nbrPomodorosTermines, statutCommande);
            
            TachesListe.Add(nouvelleTache);
            

        }
        /// <summary>
        /// Cette méthode permet de supprimer une tâche passée en paramètres par la vue
        /// </summary>
        public void SupprimerTache(Tache tacheSupp)
        {
            TachesListe.Remove(tacheSupp);

        }
        /// <summary>
        /// Cette méthode permet la sauvegarde du fichier XML à partir du modèle
        /// </summary>
        public void SauvegarderXml()
        {
            leModele.SauvegarderXML();

        }
        /// <summary>
        /// Cette méthode permet la modification du statut ainsi que du nombre de pomodoros complétés une fois la tâche interrompue
        /// </summary>
        public void InterrompPomodoroOui(Tache tacheCompl)
        {
            if (tacheCompl != null) { 
            tacheCompl.NbrPomodorosTermines += 1;
            tacheCompl.enumStatut = Tache.Statut.COMPLETEE;
            TacheSelectionne = tacheCompl;
            }
        }
        /// <summary>
        /// Cette méthode permet la modification  du nombre de pomodoros complétés une fois la minuterie à 0
        /// </summary>
        public void FinMinuteriePomoTermine(Tache tacheCompl)
        {
            if (tacheCompl != null) {
            tacheCompl.NbrPomodorosTermines += 1;           
            TacheSelectionne = tacheCompl;
            }
        }
        /// <summary>
        /// Cette méthode permet la modification du statut de la tâche une fois la minuterie à 0
        /// </summary>
        public void FinMinuterieTacheComp(Tache tacheCompl)
        {
            if (tacheCompl != null)
            {
                tacheCompl.enumStatut = Tache.Statut.COMPLETEE;
            TacheSelectionne = tacheCompl;
        }
        }
        /// <summary>
        /// Cette méthode permet d'afficher ou pas les tâches en cours sur la listBox en fonction du contenu de la checkBox à partir du modèle
        /// </summary>
        public void tachesEnCours(bool cocheOuPas)
        {
          
            if(cocheOuPas==true)
            {

                leModele.listeTriee("EN_COURS");
                
            }else if (cocheOuPas == false)
            {
                leModele.listeTrieeEnlever("EN_COURS");
            }
           
        }
        /// <summary>
        /// Cette méthode permet d'afficher ou pas les tâches planifiées sur la listBox en fonction du contenu de la checkBox à partir du modèle
        /// </summary>
        public void tachesPlanifiees(bool cocheOuPas)
        {

            if (cocheOuPas == true)
            {

                leModele.listeTriee("PLANIFIEE");
            }
            else if (cocheOuPas == false)
            {
                leModele.listeTrieeEnlever("PLANIFIEE");
            }

        }
        /// <summary>
        /// Cette méthode permet d'afficher ou pas les tâches complétées sur la listBox en fonction du contenu de la checkBox à partir du modèle
        /// </summary>
        public void tachesCompletees(bool cocheOuPas)
        {

            if (cocheOuPas == true)
            {

                leModele.listeTriee("COMPLETEE");
            }
            else if (cocheOuPas == false)
            {
                leModele.listeTrieeEnlever("COMPLETEE");
            }


        }
    }
}
