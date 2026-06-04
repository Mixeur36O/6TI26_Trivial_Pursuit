-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: localhost    Database: projet_tfe
-- ------------------------------------------------------
-- Server version	8.0.44

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
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartequestion`
--

LOCK TABLES `cartequestion` WRITE;
/*!40000 ALTER TABLE `cartequestion` DISABLE KEYS */;
INSERT INTO `cartequestion` VALUES (1,'Quel est la formule général de ln(a)-ln(b) ?',1),(2,'Quel est la formule de la moyenne dans les intégrales ?',1),(3,'Comment résoudre (a-b)² ?',1),(4,'Que vaut l\"intégrale de 1/x ?',1),(5,'Que vaut la somme entre Z1 et Z2, Z1 = 3+2i et Z2 = 1-4i ?',1),(6,'Quel est la dérivées de arccos(x) ?',1),(7,'Quel est la valeur d\"arccotan(1) ?',1),(8,'Que vaut la base de log(x) ?',1),(9,'Que vaut la base de ln(x) ?',1),(10,'Que vaut 1000^0 . (1-1)^100/0,0001+999^999',1),(11,'Qui a écris le dernier jour d un condamné ?',2),(12,'La glace quand elle fond elle pleure. Quel est cette figure de style ?',2),(13,'Quelle est l association qui lutte contre la peine de mort ?',2),(14,'De quelle famille les mots prennent deux r ?',2),(15,'Corrige moi le mot suivant \"terace\"',2),(16,'Peut tu me donner la nature du mot \"tranquillement\"',2),(17,'Comment écrire t on le mot lancer \"Il a ......\" ?',2),(18,'Quel est la figure de style qui compare sans utiliser le comparant ?',2),(19,'Donne moi la nature du mot \"ordinateurs\" ',2),(20,'Quel est la figure de style qui utilise des mots opposés les uns à côter des autres ?',2),(21,'Traduis moi le mot \"commettre\" ',3),(22,'Que veut dire \"Review\" en français',3),(23,'A quel temps est cette phrase \"He is eating\"',3),(24,'Traduis moi le mot \"limousine\"',3),(25,'Comment dit on en anglais \"commencer\", de plus donne le moi au passé',3),(26,'Traduis moi \"Bruxelles\" en anglais',3),(27,'Que veut dire \"lose\" en français',3),(28,'A quel temps est cette phrase \"She lies to their parents\"',3),(29,'Que veut dire \"to turn on\" en français',3),(30,'Traduis moi le mot \"avocat (le métier)\"',3),(31,'Dans quel ville japonnaise à eu lieu le grand tsunami ?',4),(32,'Dans la périurbanisation quel est le dernier pillier si on a déja le social et l économie ?',4),(33,'Qui est le premier producteur de sapin en Europe ?',4),(34,'Quel est la région en Belgique qui possède un taux de chômage peu élevé ?',4),(35,'De quoi parle les revenus de substitution ?',4),(36,'Quel est la province de Belgique qui abrite Mons ?',4),(37,'Quel est la capital du Danemark ?',4),(38,'Quel est le biôme qui est désertique mais avec quelque plante ?',4),(39,'La taiga ce trouve t elle dans un biôme méditerranéen ? (oui ou non)',4),(40,'La sécuritée informatique du bitcoin s appelle t elle la blockchaine ? (oui ou non) ',4),(41,'Comment appelle t on le phénomène lorsque les gens vont habiter au alentour des grandes ville ?',4),(42,'Date la grippe espagnole ?',5),(43,'Quel est le nom du parti d extrême droite belge allier au nazisme ?',5),(44,'Qui était premier ministre français pour le traiter de versaille ?',5),(45,'Qui était président des états-unis lors de la guerre froide ? (nom de famille uniquement)',5),(46,'Date la crise des missiles à cuba en entier',5),(47,'Qui était Orlando après la première guerre mondial ?',5),(48,'Qui fut le premier à creer le fachisme ?',5),(49,'De quel pays est issus la familles des Romanov ?',5),(50,'Qui était le roi belge lors de la première guerre ?',5),(51,'Comment s appellait le parti communiste de Russie ?',5),(52,'Quel est le mot en trois lettre qui nous définis ?',6),(53,'Esque le monoxyde de carbone est dangereux ? (oui ou non uniquement)',6),(54,'Quel est l unité de la fréquence d une onde ?',6),(55,'Quel est la formule pour trouver la période d un onde ?',6),(56,'C est quoi CnH2n ?',6),(57,'Avant 20 Hz comment appel t-on ces sons ?',6),(58,'Quel est le nom de la grille pour trouver la génétique des êtres ?',6),(59,'La terre existe depuis combient de temps ?',6),(60,'Quel est la masse atomique de l oxygène ?',6),(61,'Que vaux la masse sur la masse atomique ?',6);
/*!40000 ALTER TABLE `cartequestion` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-04 11:42:44
