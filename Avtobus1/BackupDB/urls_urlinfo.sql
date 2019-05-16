CREATE DATABASE  IF NOT EXISTS `urls` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `urls`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: urls
-- ------------------------------------------------------
-- Server version	5.5.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `urlinfo`
--

DROP TABLE IF EXISTS `urlinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `urlinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fullurl` varchar(500) NOT NULL,
  `shorturl` varchar(100) NOT NULL,
  `createdate` date NOT NULL,
  `amount` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `urlinfo`
--

LOCK TABLES `urlinfo` WRITE;
/*!40000 ALTER TABLE `urlinfo` DISABLE KEYS */;
INSERT INTO `urlinfo` VALUES (1,'https://www.youtube.com/watch?v=sMpGCcbjlus','https://www.youtube.com/sjNBtq','2019-05-13',1),(2,'https://fenglish.ru/movie/how_i_met_your_mother-s03e18/','https://fenglish.ru/cReGbq','2019-05-16',2),(4,'https://ru.stackoverflow.com/questions/689967/%D0%9A%D0%B0%D0%BA-%D0%BF%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D1%8C%D0%BD%D0%BE-%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D1%8C-model-view-%D0%B2-qml','https://ru.stackoverflow.com/dMRFsP','2019-05-16',1),(6,'https://mychords.net/dorn/24812-ivan-dorn-severnoe-siyanie.html','https://mychords.net/EYawQU','2019-05-16',1),(7,'https://ru.wikipedia.org/wiki/%D0%90%D1%80%D0%B8%D1%82%D0%BC%D0%B8%D1%8F_%D1%81%D0%B5%D1%80%D0%B4%D1%86%D0%B0','https://ru.wikipedia.org/KSBMp1','2019-05-16',3),(8,'https://www.google.com/search?ei=KTvZXMzkJ4TdwQLbnYPAAw&q=%D0%BA%D0%B0%D0%BA+%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%D0%B5%D1%82+%D1%81%D0%BE%D0%BA%D1%80%D0%B0%D1%89%D0%B5%D0%BD%D0%B8%D0%B5+url&oq=%D0%BA%D0%B0%D0%BA+%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%D0%B5%D1%82+%D1%81%D0%BE%D0%BA%D1%80%D0%B0%D1%89%D0%B5%D0%BD%D0%B8%D0%B5+url&gs_l=psy-ab.3..33i22i29i30l2.13285.22154..22411...5.0..2.107.3282.43j1......0....1..gws-wiz.....6..35i39j0j0i20i263j0i22i30j0i22i10i30j0i131j0i10i1i67i42j0i67j0i10i1j0i10i42','https://www.google.com/FfQiVF','2019-05-16',3);
/*!40000 ALTER TABLE `urlinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-16 21:08:30
