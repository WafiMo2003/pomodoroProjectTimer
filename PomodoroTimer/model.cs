using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PomodoroTimer
{
    class model
    {
        //Déclaration des variables XML nécessaires
        private string fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/taches.xml";

        private XmlDocument document;

        //Déclaration de la structure de données contenant les tâches
        public ObservableCollection<Tache> LesTaches
        {
            get;           
            set;
        }
        //Déclaration de la structure de données immuables contenant les tâches
        public ObservableCollection<Tache> ListeDesTaches
        {
            get;
            set;
        }
        /// <summary>
        /// Cette méthode permet de retirer les tâches de la structure des tâches liée au listBox que l'on veut afficher en fonction de leur statut
        /// </summary>
        public ObservableCollection<Tache> listeTrieeEnlever(String statut)
        {

            
            foreach (Tache tache in ListeDesTaches)
            {

                if (statut == "PLANIFIEE")
                {
                    if (tache.enumStatut.ToString() == "PLANIFIEE")
                    {
                        LesTaches.Remove(tache);
                    }
                }


              else if (statut == "EN_COURS")
                {
                    if (tache.enumStatut.ToString() == "EN_COURS")
                    {
                        LesTaches.Remove(tache);
                    }
                }

                
            else if (statut == "COMPLETEE")
                {
                    if (tache.enumStatut.ToString() == "COMPLETEE")
                    {
                        LesTaches.Remove(tache);
                    }
                }

            }

            return LesTaches;

        }
        /// <summary>
        /// Cette méthode permet d'ajouter les tâches de la structure des tâches liée au listBox que l'on veut afficher en fonction de leur statut
        /// </summary>
        public ObservableCollection<Tache> listeTriee(String statut) {

            foreach(Tache tache in ListeDesTaches)
            {

                if(statut== "PLANIFIEE")
                {
                    if(tache.enumStatut.ToString()== "PLANIFIEE")
                    {
                        LesTaches.Add(tache);
                    }
                }


                 else if (statut == "EN_COURS")
                {
                    if (tache.enumStatut.ToString() == "EN_COURS")
                    {
                        LesTaches.Add(tache);
                    }
                }

                else
            if (statut == "COMPLETEE")
                {
                    if (tache.enumStatut.ToString() == "COMPLETEE")
                    {
                        LesTaches.Add(tache);
                    }
                }

            }

            return LesTaches;

        }
        //Déclaration de la structure des tâchhes
        public model(){

            ListeDesTaches = new ObservableCollection<Tache>();
            LesTaches = new ObservableCollection<Tache>();


        }
        /// <summary>
        /// Cette méthode permet de charger le fichier XML originel
        /// </summary>
        public void ChargerXML()
        {
            
            document = new XmlDocument();
            document.Load(fichierXML);
            XmlElement racine = document.DocumentElement;

            //MISE DE L'ENSEMBLE DES TACHES DANS UNE MÊME LISTE
            XmlNodeList tachesXML = racine.GetElementsByTagName("Tache");

            foreach (XmlNode tache in tachesXML)
            {
                String description = tache["Description"].InnerText;
                XmlElement elemTache = tache as XmlElement;
                
                int nbrPomodorosPrevus =Int32.Parse( elemTache.GetAttribute("PomodorosPrevus"));
                int nbrPomodorosTermines = Int32.Parse(elemTache.GetAttribute("PomodorosCompletes"));
                String statut= elemTache.GetAttribute("Statut");


                Tache tacheXML = new Tache(description,nbrPomodorosPrevus,nbrPomodorosTermines,statut);
                
        
                ListeDesTaches.Add(tacheXML);
            }



        }
        /// <summary>
        /// Cette méthode permet de sauvegarder les données les plus récentes en écrasant le fichier précédent et en créant un nouveau
        /// </summary>
        public void SauvegarderXML()
        {
            XmlDocument document = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/taches.xml";
            XmlElement racine = document.CreateElement("Taches");
            document.AppendChild(racine);

           

            foreach (Tache tache in ListeDesTaches)
            {
                XmlElement elementTache = document.CreateElement("Tache");
                racine.AppendChild(elementTache);

                XmlAttribute PomodorosCompletes = document.CreateAttribute("PomodorosCompletes");
                PomodorosCompletes.InnerText = tache.NbrPomodorosTermines.ToString();
                elementTache.SetAttributeNode(PomodorosCompletes);

                XmlAttribute PomodorosPrevus = document.CreateAttribute("PomodorosPrevus");
                PomodorosPrevus.InnerText = tache.NbrPomodorosPrevus.ToString();
                elementTache.SetAttributeNode(PomodorosPrevus);

                XmlAttribute Statut = document.CreateAttribute("Statut");
                Statut.InnerText = tache.enumStatut.ToString();
                elementTache.SetAttributeNode(Statut);

                XmlElement descTache = document.CreateElement("Description");
                descTache.InnerText = tache.Description;
                elementTache.AppendChild(descTache);

            }


            //SAUVEGARDE DU FICHIER
            document.Save(path);


        }
        /// <summary>
        /// Cette méthode permet d'ajouter une tâche à la structure des tâches
        /// </summary>

        public void AjouterTacheListe(Tache tacheAjouter)
        {
            ListeDesTaches.Add(tacheAjouter);

        }

    }
}
