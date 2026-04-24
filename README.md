# SC Atlas

**SC Atlas** est un utilitaire Windows dédié à **Star Citizen**.  
Il permet d’installer facilement la **traduction française communautaire**, de gérer le **cache du jeu**, et de centraliser quelques accès utiles pour les joueurs francophones.

> SC Atlas n’est **pas un outil officiel** de Cloud Imperium Games.

---

## Fonctionnalités

### Traduction FR
- détection du dossier du jeu
- installation de la traduction française
- sauvegarde automatique de l’ancien fichier
- restauration de la sauvegarde
- affichage de la version locale et distante
- détection des mises à jour de traduction

### Gestion du cache
- affichage du dossier de cache
- calcul de l’espace utilisé
- suppression dossier par dossier
- ouverture rapide du dossier dans l’explorateur Windows

### Outils SC
- accès rapide à **SCMDB FR**
- centralisation de ressources utiles pour les joueurs francophones

### Paramètres
- mémorisation du dossier du jeu
- lancement au démarrage de Windows
- vérification des mises à jour du logiciel au lancement
- vérification des mises à jour de la traduction au lancement

### Mise à jour du logiciel
- vérification automatique d’une nouvelle version
- fenêtre d’alerte dédiée
- téléchargement et lancement de l’installateur

---

## Objectif du projet

Le but de **SC Atlas** est simple : proposer une application claire, légère et compréhensible pour éviter les manipulations inutiles autour de la traduction française de Star Citizen.

L’idée n’est pas de faire une usine à gaz.  
L’idée est de faire un outil propre, pratique, et utile.

---

## Configuration requise

- **Windows**
- **Star Citizen** installé
- accès Internet pour :
  - récupérer les informations de version
  - télécharger la traduction
  - vérifier les mises à jour de l’application

---

## Installation

### Utilisation classique
Télécharge la dernière version de **SC Atlas**, lance l’application, puis :

1. clique sur **Choisir le dossier du jeu**
2. sélectionne le dossier de **Star Citizen**
3. va dans l’onglet **Traduction**
4. clique sur **Installer la traduction**

SC Atlas se charge du reste.

---

## Utilisation

### Installer la traduction
- choisis le dossier du jeu
- vérifie le chemin cible détecté
- clique sur **Installer la traduction**

### Restaurer la sauvegarde
Si besoin, tu peux revenir au fichier précédent via :
- **Traduction**
- **Restaurer la sauvegarde**

### Gérer le cache
Dans l’onglet **Cache**, tu peux :
- voir la taille totale
- ouvrir le dossier
- supprimer les dossiers un par un

### Ouvrir SCMDB FR
Dans **Outils SC > SCMDB FR**, tu peux ouvrir rapidement la version française du site via ton navigateur.

---

## SCMDB FR

SC Atlas propose un accès rapide à **SCMDB FR**, une ressource externe liée à Star Citizen.

Lien utilisé :
- SCMDB : `https://scmdb.net/`
- Traduction FR SCMDB : `https://raw.githubusercontent.com/Nagalty/scmdb-fr/main/lang-FR.json`

SC Atlas n’héberge pas le contenu de SCMDB FR.  
L’application sert uniquement de point d’accès rapide.

---

## Structure générale

Le projet inclut actuellement :
- installation de traduction
- gestion du cache
- accès SCMDB FR
- système de paramètres
- détection de mises à jour
- interface Windows customisée

Le projet reste évolutif.  
D’autres outils communautaires pourront être ajoutés plus tard si ça a un vrai intérêt.

---

## Roadmap possible

- ajout d’autres outils SC utiles
- amélioration de l’interface
- meilleure finition visuelle
- tests plus poussés sur les mises à jour
- amélioration de la release / distribution

---

## Limitations

- application **Windows uniquement**
- dépend de la structure actuelle du dossier de Star Citizen
- dépend de la disponibilité des fichiers distants GitHub
- SCMDB FR s’ouvre dans le navigateur, ce n’est pas un module embarqué

---
```md
## Captures

Tu peux ajouter ici plus tard des captures de l’application :


![Accueil](./Assets/screenshot-home.png)
![Traduction](./Assets/screenshot-translation.png)
![Cache](./Assets/screenshot-cache.png)
