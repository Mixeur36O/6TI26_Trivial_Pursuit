Drop table casep;
Drop table cartequestion;
Drop table cartereponse;

create table cartequestion(
carteQID int not null auto_increment,
carteQ varchar(200),
categorieID int,
primary key (carteQID),
foreign key (categorieID) references categorie (categorieID));

insert into cartequestion (carteQ, categorieID)
values
('Quel est la formule général de ln(a)-ln(b) ?', 1),
('Quel est la formule de la moyenne dans les intégrales ?', 1),
('Comment résoudre (a-b)² ?', 1),
('Que vaut l"intégrale de 1/x ?', 1),
('Que vaut la somme entre Z1 et Z2, Z1 = 3+2i et Z2 = 1-4i ?', 1),
('Quel est la dérivées de arccos(x) ?', 1),
('Quel est la valeur d"arccotan(1) ?', 1),
('Que vaut la base de log(x) ?', 1),
('Que vaut la base de ln(x) ?', 1),
('Que vaut 1000^0 . (1-1)^100/0,0001+999^999', 1);

create table cartereponse(
carteRID int not null auto_increment,
carteR varchar(200),
categorieID int,
primary key (carteRID),
foreign key (categorieID) references categorie (categorieID));
 
 
insert into cartereponse(carteR, categorieID)
values
('ln(a/b)', 1),
('1/b-a . integrale(f(x))', 1),
('a²-2ab+b²', 1),
('ln|x|', 1),
('4-2i', 1),
('1/sqrt(1-x²)', 1),
('pi/4', 1),
('10', 1),
('e', 1),
('0', 1);

Insert into cartequestion(carteQ, categorieID) values
("Qui est le plus grand producteur de sapin en Europe ?", 4),
("Quel est le dernier pillier de la périurbanisation après le social et économique ?", 4),
("Ville japonnaise qui à subi l'énorme tsunami ?", 4),
("", 4),
("", 4),
("", 4),
("", 4),
("", 4),
("", 4),
("", 4);

Insert into cartereponse(carteR, categorieID) values
("Danemark", 4),
("L'environnement", 4),
("Fukushima", 4),
("", 4),
("", 4),
("", 4),
("", 4),
("", 4),
("", 4),
("", 4);

insert into cartequestion (carteQ, categorieID)
values
('Date la grippe espagnole ?', 5),
('Quel est le nom du parti d extrême droite belge allier au nazisme ?', 5),
('Qui était premier ministre français pour le traiter de versaille ?', 5),
('Qui était président des états-unis lors de la guerre froide ? (nom de famille uniquement)', 5),
('Date la crise des missiles à cuba en entier', 5),
('Qui était Orlando après la première guerre mondial ?', 5),
('Qui fut le premier à creer le fachisme ?', 5),
('De quel pays est issus la familles des Romanov ?', 5),
('Qui était le roi belge lors de la première guerre ?', 5),
('Comment s appellait le parti communiste de Russie ?', 5);

insert into cartereponse(carteR, categorieID)
values
('1918-1920', 5),
('REX', 5),
('Clemenceau', 5),
('Kennedy', 5),
('16 octobre 1962–29 octobre 1962', 5),
('Premier ministre Italien', 5),
('Mussolini', 5),
('Russie', 5),
('Albert 1', 5),
('URSS', 5);

insert into cartequestion (carteQ, categorieID)
values
('Quel est le mot en trois lettre qui nous définis ?', 6),
('Esque le monoxyde de carbone est dangereux ? (oui ou non uniquement)', 6),
('Quel est l unité de la fréquence d une onde ?', 6),
('Quel est la formule pour trouver la période d un onde ?', 6),
('C est quoi CnH2n ?', 6),
('Avant 20 Hz comment appel t-on ces sons ?', 6),
('Quel est le nom de la grille pour trouver la génétique des êtres ?', 6),
('La terre existe depuis combient de temps ?', 6),
('Quel est la masse atomique de l oxygène ?', 6),
('Que vaux la masse sur la masse atomique ?', 6);

insert into cartereponse(carteR, categorieID)
values
('ADN', 6),
('oui', 6),
('Hz', 6),
('1/T', 6),
('alcène', 6),
('infrasons', 6),
('Punnett', 6),
('4,6 millards', 6),
('16', 6),
('une mole', 6);

