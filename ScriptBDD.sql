-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 10.10.51.98    Database: maxence
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cartequestion`
--

DROP TABLE IF EXISTS `cartequestion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartequestion` (
  `carteQID` int NOT NULL AUTO_INCREMENT,
  `carteQ` varchar(200) DEFAULT NULL,
  `categorieID` int DEFAULT NULL,
  PRIMARY KEY (`carteQID`),
  KEY `categorieID` (`categorieID`),
  CONSTRAINT `cartequestion_ibfk_1` FOREIGN KEY (`categorieID`) REFERENCES `categorie` (`categorieID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartequestion`
--

LOCK TABLES `cartequestion` WRITE;
/*!40000 ALTER TABLE `cartequestion` DISABLE KEYS */;
INSERT INTO `cartequestion` VALUES (1,'Quel est la formule général de ln(a)-ln(b) ?',1),(2,'Quel est la formule de la moyenne dans les intégrales ?',1),(3,'Comment résoudre (a-b)² ?',1),(4,'Que vaut l\"intégrale de 1/x ?',1),(5,'Que vaut la somme entre Z1 et Z2, Z1 = 3+2i et Z2 = 1-4i ?',1),(6,'Quel est la dérivées de arccos(x) ?',1),(7,'Quel est la valeur d\"arccotan(1) ?',1),(8,'Que vaut la base de log(x) ?',1),(9,'Que vaut la base de ln(x) ?',1),(10,'Que vaut 1000^0 . (1-1)^100/0,0001+999^999',1),(11,'Date la grippe espagnole ?',5),(12,'Quel est le nom du parti d extrême droite belge allier au nazisme ?',5),(13,'Qui était premier ministre français pour le traiter de versaille ?',5),(14,'Qui était président des états-unis lors de la guerre froide ? (nom de famille uniquement)',5),(15,'Date la crise des missiles à cuba en entier',5),(16,'Qui était Orlando après la première guerre mondial ?',5),(17,'Qui fut le premier à creer le fachisme ?',5),(18,'De quel pays est issus la familles des Romanov ?',5),(19,'Qui était le roi belge lors de la première guerre ?',5),(20,'Comment s appellait le parti communiste de Russie ?',5),(21,'Quel est le mot en trois lettre qui nous définis ?',6),(22,'Esque le monoxyde de carbone est dangereux ? (oui ou non uniquement)',6),(23,'Quel est l unité de la fréquence d une onde ?',6),(24,'Quel est la formule pour trouver la période d un onde ?',6),(25,'C est quoi CnH2n ?',6),(26,'Avant 20 Hz comment appel t-on ces sons ?',6),(27,'Quel est le nom de la grille pour trouver la génétique des êtres ?',6),(28,'La terre existe depuis combient de temps ?',6),(29,'Quel est la masse atomique de l oxygène ?',6),(30,'Que vaux la masse sur la masse atomique ?',6);
/*!40000 ALTER TABLE `cartequestion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cartereponse`
--

DROP TABLE IF EXISTS `cartereponse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartereponse` (
  `carteRID` int NOT NULL AUTO_INCREMENT,
  `carteR` varchar(200) DEFAULT NULL,
  `categorieID` int DEFAULT NULL,
  PRIMARY KEY (`carteRID`),
  KEY `categorieID` (`categorieID`),
  CONSTRAINT `cartereponse_ibfk_1` FOREIGN KEY (`categorieID`) REFERENCES `categorie` (`categorieID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartereponse`
--

LOCK TABLES `cartereponse` WRITE;
/*!40000 ALTER TABLE `cartereponse` DISABLE KEYS */;
INSERT INTO `cartereponse` VALUES (1,'ln(a/b)',1),(2,'1/b-a . integrale(f(x))',1),(3,'a²-2ab+b²',1),(4,'ln|x|',1),(5,'4-2i',1),(6,'1/sqrt(1-x²)',1),(7,'pi/4',1),(8,'10',1),(9,'e',1),(10,'0',1),(11,'1918-1920',5),(12,'REX',5),(13,'Clemenceau',5),(14,'Kennedy',5),(15,'16 octobre 1962–29 octobre 1962',5),(16,'Premier ministre Italien',5),(17,'Mussolini',5),(18,'Russie',5),(19,'Albert 1',5),(20,'URSS',5),(21,'ADN',6),(22,'oui',6),(23,'Hz',6),(24,'1/T',6),(25,'alcène',6),(26,'infrasons',6),(27,'Punnett',6),(28,'4,6 millards',6),(29,'16',6),(30,'une mole',6);
/*!40000 ALTER TABLE `cartereponse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorie` (
  `categorieID` int NOT NULL AUTO_INCREMENT,
  `categorieMatiere` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`categorieID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorie`
--

LOCK TABLES `categorie` WRITE;
/*!40000 ALTER TABLE `categorie` DISABLE KEYS */;
INSERT INTO `categorie` VALUES (1,'Math'),(2,'Fr'),(3,'Anglais'),(4,'Geo'),(5,'Hist'),(6,'Sc');
/*!40000 ALTER TABLE `categorie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `joueur`
--

DROP TABLE IF EXISTS `joueur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `joueur` (
  `joueurID` int NOT NULL AUTO_INCREMENT,
  `joueurPseudo` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`joueurID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `joueur`
--

LOCK TABLES `joueur` WRITE;
/*!40000 ALTER TABLE `joueur` DISABLE KEYS */;
INSERT INTO `joueur` VALUES (3,'Max'),(4,'Nath');
/*!40000 ALTER TABLE `joueur` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-02 13:39:37
