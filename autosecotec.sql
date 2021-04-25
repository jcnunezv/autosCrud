-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               5.7.24 - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for autosecotec
DROP DATABASE IF EXISTS `autosecotec`;
CREATE DATABASE IF NOT EXISTS `autosecotec` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `autosecotec`;

-- Dumping structure for table autosecotec.autos
DROP TABLE IF EXISTS `autos`;
CREATE TABLE IF NOT EXISTS `autos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `marca` varchar(50) DEFAULT NULL,
  `modelo` varchar(50) DEFAULT NULL,
  `precio` varchar(5) DEFAULT NULL,
  `estado` varchar(10) DEFAULT 'ACTIVO',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table autosecotec.autos: ~16 rows (approximately)
/*!40000 ALTER TABLE `autos` DISABLE KEYS */;
INSERT INTO `autos` (`id`, `marca`, `modelo`, `precio`, `estado`) VALUES
	(1, 'cheverolet', 'optra', '5000', 'ACTIVO'),
	(2, 'cheverolet', 'aveo', '3455', 'ACTIVO'),
	(3, 'nissa', 'centra', '56788', 'ACTIVO'),
	(4, 'audi', 'a34', '17000', 'ACTIVO'),
	(5, 'Nissa', 'tidda', '18000', 'ACTIVO'),
	(6, 'audi g', 'a67', '17000', 'ACTIVO'),
	(7, 'cheverolet', 'tracker', '30000', 'ACTIVO'),
	(8, 'nissa', 'armada', '89299', 'ACTIVO'),
	(9, 'yundai', 'tucson', '67899', 'ACTIVO'),
	(10, 'kia', 'sportage', '67888', 'ACTIVO'),
	(11, 'mazda', '323', '78888', 'ACTIVO'),
	(12, 'kia', 'picanto', '67677', 'ACTIVO'),
	(13, 'cheverolet', 'spark', '55444', 'ACTIVO'),
	(14, 'yuiopl', 'hjhjhjh', '78888', 'ACTIVO'),
	(15, 'hdjhd', 'hdhdhdj', '65747', 'ACTIVO'),
	(16, 'audi', 'hjhjh', '17000', 'ACTIVO');
/*!40000 ALTER TABLE `autos` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
