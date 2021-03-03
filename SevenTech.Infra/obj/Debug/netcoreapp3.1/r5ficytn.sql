CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Clientes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DataCadastro` datetime(6) NOT NULL,
    `DataNascimento` datetime(6) NOT NULL,
    `Nome` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Sexo` int NOT NULL,
    CONSTRAINT `PK_Clientes` PRIMARY KEY (`Id`)
);

CREATE TABLE `Enderecos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DataCadastro` datetime(6) NOT NULL,
    `Bairro` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Cep` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `Cidade` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `ClienteId` int NOT NULL,
    `Complemento` varchar(250) CHARACTER SET utf8mb4 NOT NULL,
    `Estado` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Logradouro` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Numero` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Enderecos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Enderecos_Clientes_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `Clientes` (`Id`) ON DELETE CASCADE
);

CREATE UNIQUE INDEX `IX_Enderecos_ClienteId` ON `Enderecos` (`ClienteId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210124025119_EstruturaInicial', '3.1.3');

