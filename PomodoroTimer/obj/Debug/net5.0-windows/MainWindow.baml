   M S B A M L   `   `   `  ????H  DPomodoroTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PomodoroTimerPomodoroTimer  5   	       PomodoroTimer.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PomodoroTimer     5   	     ? Title$  Pomodoro??5   	   $	??450??6   $	??800??6'    J? CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5        CommandedDemarrerPomodoro??   PomodoroTimer.MainWindow   cmdDemarrerPomodoro   Command# Z 5      5        5   
   -   5        CommandeInterromprePomodoro??   cmdInterromprePomodoro# Z 5      5        5   
   -   5        CommandeAjouterTache??   cmdAjouterTache# Z 5      5        5   
   -   5        CommandeAjouterPomodoro??   cmdAjouterPomodoro# Z 5      5        5"   
   -   5        CommandeDiminuerPomodoro??   cmdDiminuerPomodoro# Z 5#      5%        5'   
   -   5        CommandeSupprimerTache??   cmdSupprimerTache# Z 5(      5*      .??5/      ?? .+?50   
   ?? 	 ?? Left$		 350??51      

 ?? Top$	
 120??52      .+?54      ??  ?? Bottom$ 20??6   $	??270??6,   .+?55      ? .+?56      ?? $??12(?6    $??5q?6.   $	 19??69   $

 -100??6J   Statut de la tâche:6q   ?? 57      -   5        $??statutTache??57   ?   $??12(?6    $??5q?6.   $	 19??69   $

 -100??6J   ??6\   ?? *StatutTache+ ?? Mode$ OneWay=?6?   58      ? 59      .+?5:      ?? $??12(?6    $??5q?6.   $	 19??69   $

 -100??6J   Pomodoros complétés:6r   ?? 5;      -   5        $??pomodorosCompletes??5;   ?   $??12(?6    $??5q?6.   $	 19??69   $

 -100??6J   ??6\   ?? *nbrPomodorosCompletes+$ OneWay=?6?   5<      ? 5=      .+?5>      ?? $??12(?6    $??5q?6.   $	 19??69   $

 -100??6J   Pomodoros prévus:6o   ?? 5?      -	   5        $??pomodorosPrevus??5?   ?   $??12(?6    $??5q?6.   $	 19??69   $

 -100??6J   ??6]   ?? *nbrPomodorosPrevus+$ OneWay=?6?   5@      5A      ? 5B      .+?5D      ?? #??Z 5E      $??Démarrer pomodoro??5F      $	??150??5G      $??2q?5H      ?? 5J      #??Z 5K      $??Interrompre pomodoro??5L      $	??150??5M      $??2q?5N      5P      ?? 5Q      -
   5        $??	TextTemps??5Q      $??00:00??6)   $??60(?66   $	 64??6D   $
 30??6U   ?? 5R      $??12(?6   $??5q?6&   $	
 120??61   Nouvelle tâche:6S   ?? 5S      -   5        $??	descTache??5S   /   $	??100??6   $	??320??6#   $	
 150??6@   6S   ? 5U      $	
 255??6   $	 5??6)   .+?5V      ?? $??12(?6   $??5q?6*   Prévisions (pomodoros):6N   ?? 5W      -   5        $??NbrPomodorosPrevus??5W      $??5q?66   06D   ?? 5X      -   5        $??PlusUnPomodoro??5X   /   $??5q?6   $??20??6$   #??Z 6F   .??6   +6?   ?? 5Y      -   5        $??MoinsUnPomodoro??5Y   0   $??5q?6   $??20??6%   #??Z 6G   .??6?   -6?   ?? 5Z      $??5q?6   #??Z 6'   .??6]   Ajouter tâche6l   5]      5^      ?? 5a   
    ?? Right$	 780??5b      $	
 120??5c      .+?5d      ?? $
 -250??6   .+?5e      ?? $??12(?6   $??5q?6*   $	 19??65   $

 -100??6F   Liste des tâches:6k   ?? 5f      -   5        $??ListeTaches??5f   3   $	??250??6   $	??300??6'   $	
 -75??6F   $	 25??6W   ??5h      ?? *TachesListe+$ OneWay=?6M   ? 5i      .+?5j      ?? $??12(?6    
Filtres:6:   ?? 5k      .+?5l      ?? -   5        $??tachesEncoursCheckBox??5l   ?   $??5q?6#    d? 	IsChecked$
 TrueY?6.   .??5m      ?? -   5         ??Name$ tachesEnCours??5m   $   Tâches en cours6L   5n      ?? 5o      -   5        $??tachesPlanifieesCheckBox??5o   ?   $??5q?6#   $
 TrueY?6.   .??5p      ?? -   5        $ tachesPlanifiees??5p   (   Tâches planifiées6U   5q      ?? 5r      -   5        $??tachesCompleteesCheckBox??5r   @   $??5q?6#   $ FalseY?6.   .??5s      ?? -   5        $ tachesCompletees??5s   (   Tâches complétées6U   5t      ?? 5u      $	??150??6!   $??2q?6-   $??20??68   #??Z 6D   .??6|   Supprimer la tâche6?   5v      5w      5x      5z      5|      5}      