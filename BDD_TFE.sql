Drop table joueur;
Drop table carte;
Drop table caseP;
Drop table couleur;
Drop table paquetCarte;
Drop table categorie;

Create table joueur(
joueurID int not null auto_increment,
joueurPseudo varchar(30),
primary key (joueurID));

Create table carteQuestion(
carteID int not null auto_increment,
carteQuestion varchar(200),

primary key (carteID));

Create table categorie(
categorieID int not null auto_increment,
categorieMatiere varchar(100),
primary key (categorieID));

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

insert into categorie(categorieMatiere)
values
('Math'),
('Fr'),
('Anglais'),
('Geo'),
('Hist'),
('Sc');
