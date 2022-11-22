CREATE DATABASE `qualyteste` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;

CREATE TABLE `documentos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Título` varchar(155) NOT NULL,
  `Processoid` int NOT NULL,
  `Categoria` varchar(155) NOT NULL,
  `Arquivo` blob,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ID_UNIQUE` (`Id`),
  KEY `Id_idx` (`Processoid`),
  CONSTRAINT `Id` FOREIGN KEY (`Processoid`) REFERENCES `processos` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;


CREATE TABLE `processos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Processo` varchar(150) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;

