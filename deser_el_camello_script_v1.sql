CREATE DATABASE  IF NOT EXISTS `deser_el_camello` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `deser_el_camello`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: deser_el_camello
-- ------------------------------------------------------
-- Server version	8.3.0
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
-- Table structure for table `categoria_aspirante`
--
DROP TABLE IF EXISTS `categoria_aspirante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria_aspirante` (
  `id_aspirante_ca` int NOT NULL,
  `id_categoria_ca` int NOT NULL,
  `experiencia` varchar(45) NOT NULL,
  KEY `id_categoria_aspirante_idx` (`id_aspirante_ca`),
  KEY `id_categoria_ca_idx` (`id_categoria_ca`),
  CONSTRAINT `id_aspirante_ca` FOREIGN KEY (`id_aspirante_ca`) REFERENCES `perfil_aspirante` (`id_perfil_aspirante`),
  CONSTRAINT `id_categoria_ca` FOREIGN KEY (`id_categoria_ca`) REFERENCES `categoria_empleo` (`id_categoria_empleo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria_aspirante`
--

LOCK TABLES `categoria_aspirante` WRITE;
/*!40000 ALTER TABLE `categoria_aspirante` DISABLE KEYS */;
/*!40000 ALTER TABLE `categoria_aspirante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria_empleo`
--

DROP TABLE IF EXISTS `categoria_empleo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria_empleo` (
  `id_categoria_empleo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id_categoria_empleo`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria_empleo`
--
-- ORDER BY:  `id_categoria_empleo`

LOCK TABLES `categoria_empleo` WRITE;
/*!40000 ALTER TABLE `categoria_empleo` DISABLE KEYS */;
INSERT INTO `categoria_empleo` VALUES (1,'Plomero'),(2,'Plomero'),(3,'Plomero'),(4,'Fontaneria'),(5,'Carpintería'),(6,'Fontaneria'),(7,'Fontaneria'),(8,'Albañilería'),(9,'Albañilería'),(10,'Albañilería'),(11,'Albañilería'),(12,'Albañilería'),(13,'Plomería'),(14,'Jardineria'),(15,'Plomería'),(16,'Plomería'),(17,'Plomería'),(18,'Plomería'),(19,'Plomería'),(21,'Pedrería'),(24,'Teniente en la COG'),(26,'Fontanería');
/*!40000 ALTER TABLE `categoria_empleo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contratacion_empleo`
--

DROP TABLE IF EXISTS `contratacion_empleo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contratacion_empleo` (
  `id_contratacion_empleo` int NOT NULL AUTO_INCREMENT,
  `id_oferta_empleo_coe` int NOT NULL,
  `fecha_contratacion` date NOT NULL,
  `fecha_finalizacion` date NOT NULL,
  `estatus` int NOT NULL,
  `id_conversacion_coe` int NOT NULL,
  PRIMARY KEY (`id_contratacion_empleo`),
  KEY `id_oferta_empleo_coe_idx` (`id_oferta_empleo_coe`),
  KEY `id_conversacion_coe_idx` (`id_conversacion_coe`),
  CONSTRAINT `id_conversacion_coe` FOREIGN KEY (`id_conversacion_coe`) REFERENCES `conversacion` (`id_conversacion`),
  CONSTRAINT `id_oferta_empleo_coe` FOREIGN KEY (`id_oferta_empleo_coe`) REFERENCES `oferta_empleo` (`id_oferta_empleo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contratacion_empleo`
--
-- ORDER BY:  `id_contratacion_empleo`

LOCK TABLES `contratacion_empleo` WRITE;
/*!40000 ALTER TABLE `contratacion_empleo` DISABLE KEYS */;
/*!40000 ALTER TABLE `contratacion_empleo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contratacion_empleo_aspirante`
--

DROP TABLE IF EXISTS `contratacion_empleo_aspirante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contratacion_empleo_aspirante` (
  `id_contratacion_empleo_cea` int NOT NULL,
  `id_perfil_aspirante_cea` int NOT NULL,
  `id_perfil_empleador_cea` int NOT NULL,
  `valoracion_aspirante` int DEFAULT NULL,
  `valoracion_empleador` int DEFAULT NULL,
  KEY `id_contratacion_empleo_cea_idx` (`id_contratacion_empleo_cea`),
  KEY `id_perfil_aspirante_cea_idx` (`id_perfil_aspirante_cea`),
  KEY `id_perfil_empleador_cea_idx` (`id_perfil_empleador_cea`),
  CONSTRAINT `id_contratacion_empleo_cea` FOREIGN KEY (`id_contratacion_empleo_cea`) REFERENCES `contratacion_empleo` (`id_contratacion_empleo`),
  CONSTRAINT `id_perfil_aspirante_cea` FOREIGN KEY (`id_perfil_aspirante_cea`) REFERENCES `perfil_aspirante` (`id_perfil_aspirante`),
  CONSTRAINT `id_perfil_empleador_cea` FOREIGN KEY (`id_perfil_empleador_cea`) REFERENCES `perfil_empleador` (`id_perfil_empleador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contratacion_empleo_aspirante`
--

LOCK TABLES `contratacion_empleo_aspirante` WRITE;
/*!40000 ALTER TABLE `contratacion_empleo_aspirante` DISABLE KEYS */;
/*!40000 ALTER TABLE `contratacion_empleo_aspirante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contratacion_servicio`
--

DROP TABLE IF EXISTS `contratacion_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contratacion_servicio` (
  `id_contratacion_servicio` int NOT NULL AUTO_INCREMENT,
  `id_perfil_demandante_cs` int NOT NULL,
  `id_perfil_aspirante_cs` int NOT NULL,
  `estatus` int NOT NULL,
  `valoracion_aspirante` int NOT NULL,
  `fecha_contratacion` date NOT NULL,
  `fecha_finalizacion` date NOT NULL,
  `id_conversacion_cs` int NOT NULL,
  PRIMARY KEY (`id_contratacion_servicio`),
  KEY `id_perfil_demandante_cs_idx` (`id_perfil_demandante_cs`),
  KEY `id_perfil_aspirante_cs_idx` (`id_perfil_aspirante_cs`),
  KEY `id_conversacion_cs_idx` (`id_conversacion_cs`),
  CONSTRAINT `id_conversacion_cs` FOREIGN KEY (`id_conversacion_cs`) REFERENCES `conversacion` (`id_conversacion`),
  CONSTRAINT `id_perfil_aspirante_cs` FOREIGN KEY (`id_perfil_aspirante_cs`) REFERENCES `perfil_aspirante` (`id_perfil_aspirante`),
  CONSTRAINT `id_perfil_demandante_cs` FOREIGN KEY (`id_perfil_demandante_cs`) REFERENCES `perfil_demandante` (`id_perfil_demandante`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contratacion_servicio`
--
-- ORDER BY:  `id_contratacion_servicio`

LOCK TABLES `contratacion_servicio` WRITE;
/*!40000 ALTER TABLE `contratacion_servicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `contratacion_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conversacion`
--

DROP TABLE IF EXISTS `conversacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `conversacion` (
  `id_conversacion` int NOT NULL AUTO_INCREMENT,
  `nombre_empleo` varchar(100) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `fecha_contratacion` date DEFAULT NULL,
  PRIMARY KEY (`id_conversacion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conversacion`
--
-- ORDER BY:  `id_conversacion`

LOCK TABLES `conversacion` WRITE;
/*!40000 ALTER TABLE `conversacion` DISABLE KEYS */;
INSERT INTO `conversacion` VALUES (1,'Nobre o','nombre','2022-10-10');
/*!40000 ALTER TABLE `conversacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `estadisticas_empleos`
--

DROP TABLE IF EXISTS `estadisticas_empleos`;
/*!50001 DROP VIEW IF EXISTS `estadisticas_empleos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `estadisticas_empleos` AS SELECT 
 1 AS `fecha`,
 1 AS `solicitudes_publicadas`,
 1 AS `categoria`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `estadisticas_ofertas_empleo`
--

DROP TABLE IF EXISTS `estadisticas_ofertas_empleo`;
/*!50001 DROP VIEW IF EXISTS `estadisticas_ofertas_empleo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `estadisticas_ofertas_empleo` AS SELECT 
 1 AS `fecha_anio`,
 1 AS `ofertas_publicadas`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `estadisticas_uso_plataforma`
--

DROP TABLE IF EXISTS `estadisticas_uso_plataforma`;
/*!50001 DROP VIEW IF EXISTS `estadisticas_uso_plataforma`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `estadisticas_uso_plataforma` AS SELECT 
 1 AS `fecha`,
 1 AS `ofertas_publicadas`,
 1 AS `categoria`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `fotografia`
--

DROP TABLE IF EXISTS `fotografia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fotografia` (
  `id_fotografia` int NOT NULL AUTO_INCREMENT,
  `id_oferta_empleo_fotografia` int NOT NULL,
  `imagen` blob NOT NULL,
  PRIMARY KEY (`id_fotografia`),
  KEY `id_oferta_empleo_fotografia_idx` (`id_oferta_empleo_fotografia`),
  CONSTRAINT `id_oferta_empleo_fotografia` FOREIGN KEY (`id_oferta_empleo_fotografia`) REFERENCES `oferta_empleo` (`id_oferta_empleo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fotografia`
--
-- ORDER BY:  `id_fotografia`

LOCK TABLES `fotografia` WRITE;
/*!40000 ALTER TABLE `fotografia` DISABLE KEYS */;
/*!40000 ALTER TABLE `fotografia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mensaje`
--

DROP TABLE IF EXISTS `mensaje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mensaje` (
  `id_mensaje` int NOT NULL AUTO_INCREMENT,
  `id_conversación_mensaje` int NOT NULL,
  `id_usuario_remitente` int NOT NULL,
  `mensaje` varchar(255) NOT NULL,
  `fechaRegistro` datetime NOT NULL,
  PRIMARY KEY (`id_mensaje`),
  KEY `id_conversación_mensaje_idx` (`id_conversación_mensaje`),
  KEY `id_usuario_remitente_idx` (`id_usuario_remitente`),
  CONSTRAINT `id_conversación_mensaje` FOREIGN KEY (`id_conversación_mensaje`) REFERENCES `conversacion` (`id_conversacion`),
  CONSTRAINT `id_usuario_remitente` FOREIGN KEY (`id_usuario_remitente`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mensaje`
--
-- ORDER BY:  `id_mensaje`

LOCK TABLES `mensaje` WRITE;
/*!40000 ALTER TABLE `mensaje` DISABLE KEYS */;
/*!40000 ALTER TABLE `mensaje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oferta_empleo`
--

DROP TABLE IF EXISTS `oferta_empleo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `oferta_empleo` (
  `id_oferta_empleo` int NOT NULL AUTO_INCREMENT,
  `id_perfil_oe_empleador` int NOT NULL,
  `id_categoria_oe` int NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `descripcion` varchar(255) NOT NULL,
  `vacantes` int NOT NULL,
  `dias_laborales` varchar(7) NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cantidad_pago` int NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `hora_inicio` time NOT NULL,
  `hora_fin` time NOT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_finalizacion` date NOT NULL,
  PRIMARY KEY (`id_oferta_empleo`),
  KEY `id_perfil_oe_empleador_idx` (`id_perfil_oe_empleador`),
  KEY `id_categoria_oe_idx` (`id_categoria_oe`),
  CONSTRAINT `id_categoria_oe` FOREIGN KEY (`id_categoria_oe`) REFERENCES `categoria_empleo` (`id_categoria_empleo`),
  CONSTRAINT `id_perfil_oe_empleador` FOREIGN KEY (`id_perfil_oe_empleador`) REFERENCES `perfil_empleador` (`id_perfil_empleador`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oferta_empleo`
--
-- ORDER BY:  `id_oferta_empleo`

LOCK TABLES `oferta_empleo` WRITE;
/*!40000 ALTER TABLE `oferta_empleo` DISABLE KEYS */;
INSERT INTO `oferta_empleo` VALUES (1,1,4,'Carpintería don luis','Realización de closets, teniendo en cuenta que se hará lijado y pintado de los mismos muebles',5,'12345','Por día',250,'Privada Adolfo López Mateos #12, Rafael Lucio, Ver.','10:46:00','19:59:00','1987-05-30','1947-01-25'),(2,1,4,'Carpintería don Lencho','Pintado de muebles',5,'1345','Por día',350,'Privada Adolfo López Mateos #12, Rafael Lucio, Ver.','10:46:00','19:59:00','2022-05-30','2022-08-23'),(4,2,4,'Carpintería don luis','Realización de closets, teniendo en cuenta que se hará lijado y pintado de los mismos muebles',5,'12345','Por día',250,'Privada Adolfo López Mateos #12, Rafael Lucio, Ver.','10:46:00','19:59:00','1987-05-30','1947-01-25'),(5,1,5,'Carpintería don nacho','Instalación de tuberías en una casa',5,'3456','Por día',100,'Privada Adolfo López Mateos #12, Rafael Lucio, Ver.','08:18:00','18:56:00','2022-06-05','2022-10-15');
/*!40000 ALTER TABLE `oferta_empleo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `participacion_conversacion`
--

DROP TABLE IF EXISTS `participacion_conversacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `participacion_conversacion` (
  `id_conversacion_participacion` int NOT NULL,
  `id_perfil_usuario_participacion` int NOT NULL,
  KEY `id_conversacion_participacion_idx` (`id_conversacion_participacion`),
  KEY `id_perfil_usuario_participacion_idx` (`id_perfil_usuario_participacion`),
  CONSTRAINT `id_conversacion_participacion` FOREIGN KEY (`id_conversacion_participacion`) REFERENCES `conversacion` (`id_conversacion`),
  CONSTRAINT `id_perfil_usuario_participacion` FOREIGN KEY (`id_perfil_usuario_participacion`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `participacion_conversacion`
--

LOCK TABLES `participacion_conversacion` WRITE;
/*!40000 ALTER TABLE `participacion_conversacion` DISABLE KEYS */;
INSERT INTO `participacion_conversacion` VALUES (1,3);
/*!40000 ALTER TABLE `participacion_conversacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfil_administrador`
--

DROP TABLE IF EXISTS `perfil_administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfil_administrador` (
  `id_perfil_administrador` int NOT NULL AUTO_INCREMENT,
  `id_perfil_usuario_admin` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  PRIMARY KEY (`id_perfil_administrador`),
  KEY `id_perfil_usuario_idx` (`id_perfil_usuario_admin`),
  CONSTRAINT `id_perfil_usuario` FOREIGN KEY (`id_perfil_usuario_admin`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_administrador`
--
-- ORDER BY:  `id_perfil_administrador`

LOCK TABLES `perfil_administrador` WRITE;
/*!40000 ALTER TABLE `perfil_administrador` DISABLE KEYS */;
INSERT INTO `perfil_administrador` VALUES (1,1,'Abraham Cervantes','5561151502');
/*!40000 ALTER TABLE `perfil_administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfil_aspirante`
--

DROP TABLE IF EXISTS `perfil_aspirante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfil_aspirante` (
  `id_perfil_aspirante` int NOT NULL AUTO_INCREMENT,
  `id_perfil_usuario_aspirante` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `curriculum` blob,
  `video` longblob,
  PRIMARY KEY (`id_perfil_aspirante`),
  KEY `id_perfil_usuario_aspirante_idx` (`id_perfil_usuario_aspirante`),
  CONSTRAINT `id_perfil_usuario_aspirante` FOREIGN KEY (`id_perfil_usuario_aspirante`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_aspirante`
--
-- ORDER BY:  `id_perfil_aspirante`

LOCK TABLES `perfil_aspirante` WRITE;
/*!40000 ALTER TABLE `perfil_aspirante` DISABLE KEYS */;
INSERT INTO `perfil_aspirante` VALUES (2,3,'Carlos Alberto Andrade','Lomas verdes, banderilla #14','1999-04-16','2282393962',NULL,NULL);
/*!40000 ALTER TABLE `perfil_aspirante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfil_demandante`
--

DROP TABLE IF EXISTS `perfil_demandante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfil_demandante` (
  `id_perfil_demandante` int NOT NULL AUTO_INCREMENT,
  `id_perfil_usuario_demandante` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  PRIMARY KEY (`id_perfil_demandante`),
  KEY `id_perfil_usuario_idx` (`id_perfil_usuario_demandante`),
  CONSTRAINT `fk_perfil_usuario` FOREIGN KEY (`id_perfil_usuario_demandante`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_demandante`
--
-- ORDER BY:  `id_perfil_demandante`

LOCK TABLES `perfil_demandante` WRITE;
/*!40000 ALTER TABLE `perfil_demandante` DISABLE KEYS */;
/*!40000 ALTER TABLE `perfil_demandante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfil_empleador`
--

DROP TABLE IF EXISTS `perfil_empleador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfil_empleador` (
  `id_perfil_empleador` int NOT NULL AUTO_INCREMENT,
  `id_perfil_usuario_empleador` int NOT NULL,
  `nombre_organizacion` varchar(95) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `amonestaciones` int NOT NULL,
  PRIMARY KEY (`id_perfil_empleador`),
  KEY `id_perfil_usuario_empleador_idx` (`id_perfil_usuario_empleador`),
  CONSTRAINT `id_perfil_usuario_empleador` FOREIGN KEY (`id_perfil_usuario_empleador`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_empleador`
--
-- ORDER BY:  `id_perfil_empleador`

LOCK TABLES `perfil_empleador` WRITE;
/*!40000 ALTER TABLE `perfil_empleador` DISABLE KEYS */;
INSERT INTO `perfil_empleador` VALUES (1,2,'Nombre organización','Eduardo Martinez','Santa Ines','1999-05-17','2281000000',0),(2,5,'Universidad Veracruzana','Víctor Manuel Arredondo Reyes','Priv. Adolfo López Mateos #10','2000-05-15','2282393962',0);
/*!40000 ALTER TABLE `perfil_empleador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfil_usuario`
--

DROP TABLE IF EXISTS `perfil_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfil_usuario` (
  `id_perfil_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre_usuario` varchar(50) NOT NULL,
  `estatus` int NOT NULL,
  `clave` varchar(50) NOT NULL,
  `correo_electronico` varchar(50) NOT NULL,
  `fotografia` blob,
  `tipo_usuario` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_perfil_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_usuario`
--
-- ORDER BY:  `id_perfil_usuario`

LOCK TABLES `perfil_usuario` WRITE;
/*!40000 ALTER TABLE `perfil_usuario` DISABLE KEYS */;
INSERT INTO `perfil_usuario` VALUES (1,'skylake',1,'123456','danielcrv7@outlook.com',NULL,'Administrador'),(2,'eduardoLeoLim',1,'passsword','eduardoleolim@hotmail.com',NULL,'Empleador'),(3,'carlangas',1,'12345','correo@dominio.com',NULL,'Aspirante'),(4,'levathos16',1,'usagitsukino','vctmanuel.arrys@gmail.com',NULL,'Administrador'),(5,'Manuel Arredondo Reyes',1,'usagitsukino','reyesthorlevi@gmail.com',NULL,'Empleador');
/*!40000 ALTER TABLE `perfil_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reporte_empleo`
--

DROP TABLE IF EXISTS `reporte_empleo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reporte_empleo` (
  `id_reporte_empleo` int NOT NULL AUTO_INCREMENT,
  `id_perfil_aspirante_re` int NOT NULL,
  `id_oferta_empleo_re` int NOT NULL,
  `motivo` varchar(500) NOT NULL,
  `estatus` int NOT NULL,
  `fecha_registro` date NOT NULL,
  PRIMARY KEY (`id_reporte_empleo`),
  KEY `id_perfil_aspirante_re_idx` (`id_perfil_aspirante_re`),
  KEY `id_oferta_empleo_re_idx` (`id_oferta_empleo_re`),
  CONSTRAINT `id_oferta_empleo_re` FOREIGN KEY (`id_oferta_empleo_re`) REFERENCES `oferta_empleo` (`id_oferta_empleo`),
  CONSTRAINT `id_perfil_aspirante_re` FOREIGN KEY (`id_perfil_aspirante_re`) REFERENCES `perfil_aspirante` (`id_perfil_aspirante`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reporte_empleo`
--
-- ORDER BY:  `id_reporte_empleo`

LOCK TABLES `reporte_empleo` WRITE;
/*!40000 ALTER TABLE `reporte_empleo` DISABLE KEYS */;
INSERT INTO `reporte_empleo` VALUES (1,2,2,'No paga lo prometido',0,'2022-05-15');
/*!40000 ALTER TABLE `reporte_empleo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitud_aspirante`
--

DROP TABLE IF EXISTS `solicitud_aspirante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitud_aspirante` (
  `id_solicitud_aspirante` int NOT NULL AUTO_INCREMENT,
  `id_perfil_aspirante_sa` int NOT NULL,
  `id_oferta_empleo_sa` int NOT NULL,
  `estatus` int NOT NULL,
  `fecha_registro` date NOT NULL,
  PRIMARY KEY (`id_solicitud_aspirante`),
  KEY `id_perfil_aspirante_sa_idx` (`id_perfil_aspirante_sa`),
  KEY `id_oferta_empleo_sa_idx` (`id_oferta_empleo_sa`),
  CONSTRAINT `id_oferta_empleo_sa` FOREIGN KEY (`id_oferta_empleo_sa`) REFERENCES `oferta_empleo` (`id_oferta_empleo`),
  CONSTRAINT `id_perfil_aspirante_sa` FOREIGN KEY (`id_perfil_aspirante_sa`) REFERENCES `perfil_aspirante` (`id_perfil_aspirante`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitud_aspirante`
--
-- ORDER BY:  `id_solicitud_aspirante`

LOCK TABLES `solicitud_aspirante` WRITE;
/*!40000 ALTER TABLE `solicitud_aspirante` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitud_aspirante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitud_servicio`
--

DROP TABLE IF EXISTS `solicitud_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitud_servicio` (
  `id_solicitud_servicio` int NOT NULL AUTO_INCREMENT,
  `id_perfil_ss_aspirante` int NOT NULL,
  `id_perfil_ss_demandante` int NOT NULL,
  `titulo` varchar(50) NOT NULL,
  `estatus` int NOT NULL,
  `registro` date NOT NULL,
  PRIMARY KEY (`id_solicitud_servicio`),
  KEY `id_perfil_ss_aspirante_idx` (`id_perfil_ss_aspirante`),
  KEY `id_perfil_ss_demandante_idx` (`id_perfil_ss_demandante`),
  CONSTRAINT `id_perfil_ss_aspirante` FOREIGN KEY (`id_perfil_ss_aspirante`) REFERENCES `perfil_aspirante` (`id_perfil_aspirante`),
  CONSTRAINT `id_perfil_ss_demandante` FOREIGN KEY (`id_perfil_ss_demandante`) REFERENCES `perfil_demandante` (`id_perfil_demandante`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitud_servicio`
--
-- ORDER BY:  `id_solicitud_servicio`

LOCK TABLES `solicitud_servicio` WRITE;
/*!40000 ALTER TABLE `solicitud_servicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitud_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `valoraciones_aspirantes`
--
-- Final view structure for view `estadisticas_empleos`
--

/*!50001 DROP VIEW IF EXISTS `estadisticas_empleos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `estadisticas_empleos` AS select `solicitud_aspirante`.`fecha_registro` AS `fecha`,count(distinct `solicitud_aspirante`.`id_solicitud_aspirante`) AS `solicitudes_publicadas`,`categoria_empleo`.`nombre` AS `categoria` from ((`solicitud_aspirante` join `oferta_empleo` on((`oferta_empleo`.`id_oferta_empleo` = `solicitud_aspirante`.`id_oferta_empleo_sa`))) join `categoria_empleo` on((`oferta_empleo`.`id_categoria_oe` = `categoria_empleo`.`id_categoria_empleo`))) group by `fecha`,`categoria` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `estadisticas_ofertas_empleo`
--

/*!50001 DROP VIEW IF EXISTS `estadisticas_ofertas_empleo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `estadisticas_ofertas_empleo` AS select year(`oferta_empleo`.`fecha_inicio`) AS `fecha_anio`,count(distinct `oferta_empleo`.`id_oferta_empleo`) AS `ofertas_publicadas` from `oferta_empleo` group by `fecha_anio` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `estadisticas_uso_plataforma`
--

/*!50001 DROP VIEW IF EXISTS `estadisticas_uso_plataforma`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `estadisticas_uso_plataforma` AS select `oferta_empleo`.`fecha_inicio` AS `fecha`,count(distinct `oferta_empleo`.`id_oferta_empleo`) AS `ofertas_publicadas`,`categoria_empleo`.`nombre` AS `categoria` from (`oferta_empleo` join `categoria_empleo` on((`oferta_empleo`.`id_categoria_oe` = `categoria_empleo`.`id_categoria_empleo`))) group by `fecha`,`categoria` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `valoraciones_aspirantes`
--

/*!50001 DROP VIEW IF EXISTS `valoraciones_aspirantes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `valoraciones_aspirantes` AS select `perfil_aspirante`.`nombre` AS `aspirante`,`contratacion_empleo_aspirante`.`id_perfil_aspirante_cea` AS `id_aspirante`,avg(`contratacion_empleo_aspirante`.`valoracion_aspirante`) AS `valoracion_aspirante` from (`contratacion_empleo_aspirante` join `perfil_aspirante` on((`perfil_aspirante`.`id_perfil_aspirante` = `contratacion_empleo_aspirante`.`id_perfil_aspirante_cea`))) group by `aspirante` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `valoraciones_empleadores`
--

/*!50001 DROP VIEW IF EXISTS `valoraciones_empleadores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `valoraciones_empleadores` AS select `perfil_empleador`.`nombre` AS `empleador`,`contratacion_empleo_aspirante`.`id_perfil_aspirante_cea` AS `id_empleador`,avg(`contratacion_empleo_aspirante`.`valoracion_empleador`) AS `valoracion_empleador` from (`contratacion_empleo_aspirante` join `perfil_empleador` on((`perfil_empleador`.`id_perfil_empleador` = `contratacion_empleo_aspirante`.`id_perfil_empleador_cea`))) group by `empleador` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2024-02-03 23:19:14
