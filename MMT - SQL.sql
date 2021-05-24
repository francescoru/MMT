
CREATE DATABASE `mmtshop` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE mmtshop;
CREATE TABLE `categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SKU` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(18,2) NOT NULL,
  `ProductCategoryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Products_ProductCategoryId` (`ProductCategoryId`),
  CONSTRAINT `FK_Products_Categories_ProductCategoryId` FOREIGN KEY (`ProductCategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

ALTER TABLE `categories`;
INSERT INTO `categories` VALUES (1,'Home'),(2,'Garden'),(3,'Electronics'),(4,'Fitness'),(5,'Toys');
ALTER TABLE `products`;
INSERT INTO `products` VALUES (1,'100','Product1','This is product 1',12.00,1),(2,'200','product 2 ','This is product 2',21.00,2),(3,'300','product 3','This is product 3',4.00,3);

CREATE PROCEDURE `productByCategoryId`(IN category_id int)
AS
SELECT * FROM mmtshop.products as p where p.ProductCategoryId = category_id ;
GO;
