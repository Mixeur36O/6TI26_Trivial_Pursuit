Drop table casep;

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
carteQID int,
categorieID int,
primary key (carteRID),
foreign key (categorieID) references categorie (categorieID),
foreign key (carteQID) references cartequestion (carteQID));
 
 
insert into cartereponse(carteR, carteQID, categorieID)
values
('ln(a/b)', 1, 1),
('1/b-a . integrale(f(x))', 2, 1),
('a²-2ab+b²', 3,1),
('ln(x)', 4, 1),
('4-2i', 5, 1),
('1/sqrt(1-x²)', 6, 1),
('pi/4', 7, 1),
('10', 8, 1),
('e', 9, 1),
('0', 10, 1);
 