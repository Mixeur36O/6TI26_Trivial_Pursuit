Drop table joueurs;
Drop table carte;

Create table joueur(
joueurID int not null auto_increment,
joueurPseudo varchar(30),
primary key (joueurID));

Create table carte(
carteID int not null auto_increment,
carteQuestion varchar(200),
carteReponse varchar(200),
primary key (carteID));

Create table caseP(
casePID int not null auto_increment,
casePNom varchar(30),
casePEvent int,
primary key (casePID));

create table couleur(
couleurID int not null auto_increment,
couleurType varchar(30),
FOREIGN KEY (carteID) REFERENCES carte (carteID),
FOREIGN KEY (joueurID) REFERENCES joueur (joueurID));

create table paquetCarte(
paquetCarteID int not null auto_increment,
paquetCarteNom varchar(30),
FOREIGN KEY (carteID) REFERENCES carte (carteID),
FOREIGN KEY (casePID) REFERENCES caseP (casePID));
