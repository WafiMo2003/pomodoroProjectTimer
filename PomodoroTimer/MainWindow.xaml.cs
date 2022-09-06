using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PomodoroTimer
{
    public partial class MainWindow : Window
    {
        //ON CRÉE UN OBJET VIEW MODEL A PARTIR DUQUEL ON VA APPELLER LES MÉTHODES QU'IL CONTIENT
        private ViewModel viewModel;

        //Déclaration des commandes 
        public static RoutedCommand cmdDemarrerPomodoro = new RoutedCommand();
        public static RoutedCommand cmdInterromprePomodoro = new RoutedCommand();
        public static RoutedCommand cmdAjouterPomodoro = new RoutedCommand();
        public static RoutedCommand cmdAjouterTache = new RoutedCommand();
        public static RoutedCommand cmdDiminuerPomodoro = new RoutedCommand();
        public static RoutedCommand cmdSupprimerTache = new RoutedCommand();

       

        //Déclaration des variables
        private const int NOMBRE_SECONDES =60;
        private BackgroundWorker _tempsPomodoro;
     

       
        


        public MainWindow()
        {
            viewModel = new ViewModel();
            InitializeComponent();
            //Mise en place du datacontext pour faire le lien avec l'interface graphique
            DataContext = viewModel;

            

        }

        /// <summary>
        /// Cette méthode permet l'ajout d'une tâche à la liste de tâches en faisant appel au viewModel
        /// </summary>
        private void ajouterTache_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(descTache.Text.Length > 0 && Int32.Parse(NbrPomodorosPrevus.Text) > 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
     
        private void ajouterTache_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            String descriptionTache = descTache.Text;
            int previsionNbrPomodoros =Int32.Parse(NbrPomodorosPrevus.Text);

            viewModel.CreationTache(descriptionTache,previsionNbrPomodoros,0, "PLANIFIEE");            
            MessageBox.Show("La tâche a été ajoutée!");
            descTache.Text = String.Empty;
            NbrPomodorosPrevus.Text = "0";
            viewModel.SauvegarderXml();
        }

        /// <summary>
        /// Cette méthode permet d'ajouter le nombre de pomodoros prévus à l'exécution d'une tâche
        /// </summary>
        private void CommandeAjouterPomodoro_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            
            if (Int32.Parse(NbrPomodorosPrevus.Text) < 0)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void CommandeAjouterPomodoro_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int pomodorosPrevusAfficher = Int32.Parse(NbrPomodorosPrevus.Text) +1;
            NbrPomodorosPrevus.Text = pomodorosPrevusAfficher.ToString();
           
        }
        /// <summary>
        /// Cette méthode permet de diminuer le nombre de pomodoros prévus à l'exécution d'une tâche
        /// </summary>

        private void CommandeDiminuerPomodoro_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Int32.Parse(NbrPomodorosPrevus.Text) <= 0)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void CommandeDiminuerPomodoro_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int pomodorosPrevusAfficher = Int32.Parse(NbrPomodorosPrevus.Text) - 1;
            NbrPomodorosPrevus.Text = pomodorosPrevusAfficher.ToString();
        }

        /// <summary>
        /// Cette méthode permet la suppression d'une tâche à partir de la liste des tâches
        /// </summary>
        private void CommandeSupprimerTache_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ListeTaches.SelectedItem!=null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }


        }

        private void CommandeSupprimerTache_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            viewModel.SupprimerTache(ListeTaches.SelectedItem as Tache);
            MessageBox.Show("La tâche a été supprimée avec succès");

            viewModel.SauvegarderXml();

        }

        /// <summary>
        /// Cette méthode permet d'affecter la tâche sélectionnée dans le listBox à la propriété TacheSelectionnee dans le viewModel
        /// </summary>
        private void ListeTaches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Tache tacheSelectionnee = ListeTaches.SelectedItem as Tache;

            viewModel.TacheSelectionne = tacheSelectionnee;

        }
        /// <summary>
        /// Cette méthode permet d'afficher les tâches complétées sur le listeBox une fois le checkBox coché en faisant appel au viewModel
        /// </summary>
        private void tachesCompleteesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.tachesCompletees(true);

        }
        /// <summary>
        /// Cette méthode permet de retirer les tâches complétées sur le listeBox une fois le checkBox décoché en faisant appel au viewModel
        /// </summary>
        private void tachesCompleteesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            viewModel.tachesCompletees(false);

        }
        /// <summary>
        /// Cette méthode permet d'afficher les tâches planifiées sur le listeBox une fois le checkBox coché en faisant appel au viewModel
        /// </summary>
        private void tachesPlanifieesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.tachesPlanifiees(true);
        }
        /// <summary>
        /// Cette méthode permet de retirer les tâches planifiées sur le listeBox une fois le checkBox décoché en faisant appel au viewModel
        /// </summary>
        private void tachesPlanifieesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            viewModel.tachesPlanifiees(false);
        }
        /// <summary>
        /// Cette méthode permet d'afficher les tâches en cours sur le listeBox une fois le checkBox coché en faisant appel au viewModel
        /// </summary>
        private void tachesEncoursCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.tachesEnCours(true);
        }
        /// <summary>
        /// Cette méthode permet de retirer les tâches en cours sur le listeBox une fois le checkBox décoché en faisant appel au viewModel
        /// </summary>
        private void tachesEncoursCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            viewModel.tachesEnCours(false);
        }
        /// <summary>
        /// Cette méthode permet d'activer ou désactiver le bouton démarrer pomodoro
        /// </summary>
        private void CommandedDemarrerPomodoro_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            
            if(statutTache.Text!= "COMPLÉTÉE" ) { 
            e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }

            
        }
        /// <summary>
        /// Cette méthode permet d'activer ou désactiver le bouton interrompre pomodoro
        /// </summary>
        private void CommandeInterromprePomodoro_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _tempsPomodoro != null && _tempsPomodoro.IsBusy;
        }
        /// <summary>
        /// Cette méthode permet de changer le statut de la tâche sélectionnée et ajouter un pomodoro complété une fois le pomodoro interrompu 
        /// en faisant appel au viewModel
        /// </summary>
        private void CommandeInterromprePomodoro_Executed(object sender, ExecutedRoutedEventArgs e)
        {
          
            var resultat = MessageBox.Show("Est-ce-que le pomodoro a été complété", "Temps expiré", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultat == MessageBoxResult.Yes)
            {
                Tache tacheCompl = ListeTaches.SelectedItem as Tache;           

                viewModel.InterrompPomodoroOui(tacheCompl);             
            }
            
                InterromprePomodoro();
            
                viewModel.SauvegarderXml();
        }
        /// <summary>
        /// Cette méthode permet de changer le statut de la tâche sélectionnée et ajouter un pomodoro complété une fois le pomodoro terminé 
        /// en faisant appel au viewModel
        /// </summary>
        private void TerminerPomodoro(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Pomodoro terminé");
            Tache tacheCompl = ListeTaches.SelectedItem as Tache;

            var res = MessageBox.Show("Est-ce-que le pomodoro a été complété", "Temps expiré", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {

                viewModel.FinMinuteriePomoTermine(tacheCompl);

                var res2 = MessageBox.Show("Est-ce-que la tâche a été complétée", "Construire l'interface graphique", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res2 == MessageBoxResult.Yes)
                {
                    viewModel.FinMinuterieTacheComp(tacheCompl);
                }



            }
        }




        // Début du code pour la minuterie, donné aux étudiants
        // Il devra être adapté aux spécifications du travail

        private void CommandedDemarrerPomodoro_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DemarrerPomodoro();

        }
        private void DemarrerPomodoro()
        {
            if (_tempsPomodoro != null && _tempsPomodoro.IsBusy)
            {
                _tempsPomodoro.RunWorkerCompleted -= TerminerPomodoro;
                _tempsPomodoro.ProgressChanged -= AfficherTemps;
                _tempsPomodoro.CancelAsync();
            }

            AfficherTemps(NOMBRE_SECONDES);

            _tempsPomodoro = new BackgroundWorker();
            _tempsPomodoro.WorkerSupportsCancellation = true;
            _tempsPomodoro.WorkerReportsProgress = true;
            _tempsPomodoro.DoWork += DeduireTemps;
            _tempsPomodoro.ProgressChanged += AfficherTemps;
            _tempsPomodoro.RunWorkerCompleted += TerminerPomodoro;
            _tempsPomodoro.RunWorkerAsync();
        }

        private void DeduireTemps(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int secondes = NOMBRE_SECONDES;

            BackgroundWorker worker = sender as BackgroundWorker;

            while (secondes > 0 && ! worker.CancellationPending)
            {
                Thread.Sleep(1000);
                secondes--;
                progress++;
                worker.ReportProgress(progress * 100 / NOMBRE_SECONDES, secondes);
            }
        }

        private void AfficherTemps(object sender, ProgressChangedEventArgs e)
        {
            AfficherTemps((int)e.UserState);
        }

        private void AfficherTemps(int secondesRestantes)
        {
            TimeSpan ts = TimeSpan.FromSeconds(secondesRestantes);
            TextTemps.Text = ts.ToString(@"mm\:ss");
        }

     

        private void InterromprePomodoro()
        {
            if (_tempsPomodoro != null && _tempsPomodoro.IsBusy)
            {
                _tempsPomodoro.RunWorkerCompleted -= TerminerPomodoro;
                _tempsPomodoro.ProgressChanged -= AfficherTemps;
                _tempsPomodoro.CancelAsync();
            }
            AfficherTemps(0);
            MessageBox.Show("Pomodoro interrompu");
        }

   

     

       



















        // Fin du code relié à la minuterie 

    }
}
