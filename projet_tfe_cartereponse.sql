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
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartereponse`
--

LOCK TABLES `cartereponse` WRITE;
/*!40000 ALTER TABLE `cartereponse` DISABLE KEYS */;
INSERT INTO `cartereponse` VALUES (1,'ln(a/b)',1),(2,'1/b-a . integrale(f(x))',1),(3,'a²-2ab+b²',1),(4,'ln(x)',1),(5,'4-2i',1),(6,'1/sqrt(1-x²)',1),(7,'pi/4',1),(8,'10',1),(9,'e',1),(10,'0',1),(11,'Victor Hugo',2),(12,'Personnification',2),(13,'Amnesty international',2),(14,'Terre',2),(15,'terrasse',2),(16,'Adverbe',2),(17,'lancé',2),(18,'Métaphore',2),(19,'Nom commun m p',2),(20,'Oxymore',2),(21,'To commit',3),(22,'Une critique',3),(23,'Présent continu',3),(24,'Limousine',3),(25,'Began',3),(26,'Brussels',3),(27,'Perdre',3),(28,'Présent',3),(29,'Allumer',3),(30,'Lawyer',3),(31,'Fukushima',4),(32,'L environnement',4),(33,'Le Danemark',4),(34,'La flandre',4),(35,'Des mégas bassines',4),(36,'Le hainaut',4),(37,'Copenhague',4),(38,'Steppe',4),(39,'non',4),(40,'oui',4),(41,'La périurbannisation',4),(42,'1918-1920',5),(43,'REX',5),(44,'Clemenceau',5),(45,'Kennedy',5),(46,'16 octobre 1962–29 octobre 1962',5),(47,'Premier ministre Italien',5),(48,'Mussolini',5),(49,'Russie',5),(50,'Albert 1',5),(51,'URSS',5),(52,'ADN',6),(53,'oui',6),(54,'Hz',6),(55,'1/T',6),(56,'alcène',6),(57,'infrasons',6),(58,'Punnett',6),(59,'4,6 millards',6),(60,'16',6),(61,'une mole',6);
/*!40000 ALTER TABLE `cartereponse` ENABLE KEYS */;
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
