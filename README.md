# 6TI26_Trivial_Pursuit
Projet TFE de 6TTI de Nathan Marcq et Maxence Limet

-----------------------------------------------------------------------------------------------------

Pour la connexion à la BDD, il faut aller dans le fichier Config, connectDB.cs,
et modifier la ligne 21 :
  return "server=localhost;database=projet_tfe;port=3306;User Id=root;password=NM-Nathan2006.";
Par rapport à la BDD utilisée.

-----------------------------------------------------------------------------------------------------
Menu principal :

Jouer (Permet d'aller directement sur la partie pseudo)
Paramètres (Permet de prédéfinir le nombre de joueurs)
Quitter (Permet de quitter le jeu et de réinitialiser la BDD dans les joueurs)


Parti Pseudo : 

Définir le pseudo du joueur 1 et confirmer directement l'entrée sur le bouton "Veuillez confirmer votre pseudo", puis passer au prochain joueur et faites la même chose (Taper le pseudo, confirmer directement aprèset passé au suivant).

Parti Plateau :

Pour l'instant, nous avons juste la fonctionnalité "Lancer le dé", la sélection des paquets de cartes.
Mais pas de distribution de point ou de couleur, la couleur du pion est prédéfinie par le programme.

Carte : 

Cliquer sur une matière (géo, maths, français, etc.) et répondre à la question.
Une  fois avoir mis votre réponse, confirmez votre entrée et si elle est mauvaise, recommencez jusqu'à ce qu'elle soit bonne, aidez-vous de vos collègues pour répondre s'il le faut.

