-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: deser_el_camello
-- ------------------------------------------------------
-- Server version	8.0.29

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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria_empleo`
--

LOCK TABLES `categoria_empleo` WRITE;
/*!40000 ALTER TABLE `categoria_empleo` DISABLE KEYS */;
INSERT INTO `categoria_empleo` VALUES (1,'Plomero'),(2,'Plomero'),(3,'Plomero'),(4,'Fontaneria'),(5,'Fontaneria'),(6,'Fontaneria'),(7,'Fontaneria'),(8,'Albañilería'),(9,'Albañilería'),(10,'Albañilería'),(11,'Albañilería'),(12,'Albañilería'),(13,'Plomería'),(14,'Jardineria'),(15,'Plomería');
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

LOCK TABLES `conversacion` WRITE;
/*!40000 ALTER TABLE `conversacion` DISABLE KEYS */;
INSERT INTO `conversacion` VALUES (1,'Nobre o','nombre','2022-10-10');
/*!40000 ALTER TABLE `conversacion` ENABLE KEYS */;
UNLOCK TABLES;

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
  `descripcion` varchar(45) NOT NULL,
  `vacantes` int NOT NULL,
  `dias_laborales` varchar(7) NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cantidad_pago` int NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `hora_inicio` time NOT NULL,
  `hora_fin` time NOT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_finalizacion` date NOT NULL,
  PRIMARY KEY (`id_oferta_empleo`),
  KEY `id_perfil_oe_empleador_idx` (`id_perfil_oe_empleador`),
  KEY `id_categoria_oe_idx` (`id_categoria_oe`),
  CONSTRAINT `id_categoria_oe` FOREIGN KEY (`id_categoria_oe`) REFERENCES `categoria_empleo` (`id_categoria_empleo`),
  CONSTRAINT `id_perfil_oe_empleador` FOREIGN KEY (`id_perfil_oe_empleador`) REFERENCES `perfil_empleador` (`id_perfil_empleador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oferta_empleo`
--

LOCK TABLES `oferta_empleo` WRITE;
/*!40000 ALTER TABLE `oferta_empleo` DISABLE KEYS */;
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
  `video` longblob NOT NULL,
  PRIMARY KEY (`id_perfil_aspirante`),
  KEY `id_perfil_usuario_aspirante_idx` (`id_perfil_usuario_aspirante`),
  CONSTRAINT `id_perfil_usuario_aspirante` FOREIGN KEY (`id_perfil_usuario_aspirante`) REFERENCES `perfil_usuario` (`id_perfil_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_aspirante`
--

LOCK TABLES `perfil_aspirante` WRITE;
/*!40000 ALTER TABLE `perfil_aspirante` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_empleador`
--

LOCK TABLES `perfil_empleador` WRITE;
/*!40000 ALTER TABLE `perfil_empleador` DISABLE KEYS */;
INSERT INTO `perfil_empleador` VALUES (1,2,'Nombre organización','Eduardo Martinez','Santa Ines','1999-05-17','2281000000',0);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfil_usuario`
--

LOCK TABLES `perfil_usuario` WRITE;
/*!40000 ALTER TABLE `perfil_usuario` DISABLE KEYS */;
INSERT INTO `perfil_usuario` VALUES (1,'skylake',1,'123456','danielcrv7@outlook.com',NULL,'Administrador'),(2,'eduardoLeoLim',1,'passsword','eduardoleolim@hotmail.com',NULL,'Empleador'),(3,'Aspiarente 1',1,'12345','correo@dominio.com',NULL,'Aspirante');
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reporte_empleo`
--

LOCK TABLES `reporte_empleo` WRITE;
/*!40000 ALTER TABLE `reporte_empleo` DISABLE KEYS */;
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

LOCK TABLES `solicitud_servicio` WRITE;
/*!40000 ALTER TABLE `solicitud_servicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitud_servicio` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-24 17:44:30
