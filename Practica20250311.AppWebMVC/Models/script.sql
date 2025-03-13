-- Creación de la base de datos Practica20250311DB
CREATE DATABASE Practica20250311DB;
GO

-- Usar la base de datos Practica20250311DB
USE Practica20250311DB;
GO



-- Crear la tabla Marcas
CREATE TABLE Marcas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL
);

-- Crear la tabla Categorías
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL
);

-- Crear la tabla Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10, 2) NOT NULL,
    MarcaId INT  NOT NULL,
    CategoriaId INT  NOT NULL,
    FOREIGN KEY (MarcaId) REFERENCES Marcas(Id),
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Password CHAR(32) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    UltimoInicioSesion DATETIME,
    Estatus TINYINT DEFAULT 1 -- Usamos TINYINT para Estatus y un valor predeterminado de 1
);
-- Pendiente o 2025-03-13 8:35 am 
ALTER TABLE Usuarios
ADD Rol VARCHAR(50);

-- actualizacion script 2025-03-13 11:29 am
-- contraseña 12345 
INSERT INTO Usuarios (Nombre, Password, Email, Rol)
VALUES
    ('Root', '827ccb0eea8a706c4c34a16891f84e7b ', 'admin@gmail.com', 'ADMINISTRADOR');




    INSERT INTO Productos (Nombre, Descripcion, Precio, MarcaId, CategoriaId) VALUES
('Producto 1', 'Descripción del Producto 1', 10.99, 1, 1),
('Producto 2', 'Descripción del Producto 2', 15.50, 1, 1),
('Producto 3', 'Descripción del Producto 3', 20.00, 1, 1),
('Producto 4', 'Descripción del Producto 4', 12.75, 1, 1),
('Producto 5', 'Descripción del Producto 5', 18.25, 1, 1),
('Producto 6', 'Descripción del Producto 6', 22.50, 1, 1),
('Producto 7', 'Descripción del Producto 7', 14.99, 1, 1),
('Producto 8', 'Descripción del Producto 8', 19.75, 1, 1),
('Producto 9', 'Descripción del Producto 9', 24.00, 1, 1),
('Producto 10', 'Descripción del Producto 10', 16.50, 1, 1),
('Producto 11', 'Descripción del Producto 11', 21.25, 1, 1),
('Producto 12', 'Descripción del Producto 12', 26.00, 1, 1),
('Producto 13', 'Descripción del Producto 13', 13.99, 1, 1),
('Producto 14', 'Descripción del Producto 14', 17.75, 1, 1),
('Producto 15', 'Descripción del Producto 15', 23.50, 1, 1),
('Producto 16', 'Descripción del Producto 16', 11.50, 1, 1),
('Producto 17', 'Descripción del Producto 17', 20.75, 1, 1),
('Producto 18', 'Descripción del Producto 18', 25.00, 1, 1),
('Producto 19', 'Descripción del Producto 19', 15.99, 1, 1),
('Producto 20', 'Descripción del Producto 20', 19.25, 1, 1),
('Producto 21', 'Descripción del Producto 21', 27.00, 1, 1),
('Producto 22', 'Descripción del Producto 22', 17.25, 1, 1),
('Producto 23', 'Descripción del Producto 23', 22.75, 1, 1),
('Producto 24', 'Descripción del Producto 24', 28.50, 1, 1),
('Producto 25', 'Descripción del Producto 25', 12.50, 1, 1),
('Producto 26', 'Descripción del Producto 26', 21.75, 1, 1),
('Producto 27', 'Descripción del Producto 27', 29.00, 1, 1),
('Producto 28', 'Descripción del Producto 28', 14.50, 1, 1),
('Producto 29', 'Descripción del Producto 29', 23.25, 1, 1),
('Producto 30', 'Descripción del Producto 30', 30.00, 1, 1),
('Producto 31', 'Descripción del Producto 31', 16.25, 1, 1),
('Producto 32', 'Descripción del Producto 32', 24.75, 1, 1),
('Producto 33', 'Descripción del Producto 33', 31.50, 1, 1),
('Producto 34', 'Descripción del Producto 34', 18.00, 1, 1),
('Producto 35', 'Descripción del Producto 35', 26.25, 1, 1),
('Producto 36', 'Descripción del Producto 36', 32.00, 1, 1),
('Producto 37', 'Descripción del Producto 37', 13.50, 1, 1),
('Producto 38', 'Descripción del Producto 38', 25.50, 1, 1),
('Producto 39', 'Descripción del Producto 39', 33.00, 1, 1),
('Producto 40', 'Descripción del Producto 40', 19.50, 1, 1);


INSERT INTO Productos (Nombre, Descripcion, Precio, MarcaId, CategoriaId) VALUES
('Producto 41', 'Descripción del Producto 41', 20.25, 1, 1),
('Producto 42', 'Descripción del Producto 42', 27.75, 1, 1),
('Producto 43', 'Descripción del Producto 43', 34.00, 1, 1),
('Producto 44', 'Descripción del Producto 44', 21.00, 1, 1),
('Producto 45', 'Descripción del Producto 45', 28.50, 1, 1),
('Producto 46', 'Descripción del Producto 46', 35.00, 1, 1),
('Producto 47', 'Descripción del Producto 47', 22.50, 1, 1),
('Producto 48', 'Descripción del Producto 48', 29.25, 1, 1),
('Producto 49', 'Descripción del Producto 49', 36.00, 1, 1),
('Producto 50', 'Descripción del Producto 50', 23.00, 1, 1),
('Producto 51', 'Descripción del Producto 51', 30.75, 1, 1),
('Producto 52', 'Descripción del Producto 52', 37.50, 1, 1),
('Producto 53', 'Descripción del Producto 53', 24.50, 1, 1),
('Producto 54', 'Descripción del Producto 54', 31.50, 1, 1),
('Producto 55', 'Descripción del Producto 55', 38.00, 1, 1),
('Producto 56', 'Descripción del Producto 56', 25.00, 1, 1),
('Producto 57', 'Descripción del Producto 57', 32.25, 1, 1),
('Producto 58', 'Descripción del Producto 58', 39.00, 1, 1),
('Producto 59', 'Descripción del Producto 59', 26.50, 1, 1),
('Producto 60', 'Descripción del Producto 60', 33.00, 1, 1),
('Producto 61', 'Descripción del Producto 61', 40.00, 1, 1),
('Producto 62', 'Descripción del Producto 62', 27.00, 1, 1),
('Producto 63', 'Descripción del Producto 63', 34.50, 1, 1),
('Producto 64', 'Descripción del Producto 64', 41.00, 1, 1),
('Producto 65', 'Descripción del Producto 65', 28.00, 1, 1),
('Producto 66', 'Descripción del Producto 66', 35.25, 1, 1),
('Producto 67', 'Descripción del Producto 67', 42.00, 1, 1),
('Producto 68', 'Descripción del Producto 68', 29.50, 1, 1),
('Producto 69', 'Descripción del Producto 69', 36.75, 1, 1),
('Producto 70', 'Descripción del Producto 70', 43.00, 1, 1),
('Producto 71', 'Descripción del Producto 71', 30.00, 1, 1),
('Producto 72', 'Descripción del Producto 72', 37.50, 1, 1),
('Producto 73', 'Descripción del Producto 73', 44.00, 1, 1),
('Producto 74', 'Descripción del Producto 74', 31.50, 1, 1),
('Producto 75', 'Descripción del Producto 75', 38.25, 1, 1),
('Producto 76', 'Descripción del Producto 76', 45.00, 1, 1),
('Producto 77', 'Descripción del Producto 77', 32.00, 1, 1),
('Producto 78', 'Descripción del Producto 78', 39.75, 1, 1),
('Producto 79', 'Descripción del Producto 79', 46.00, 1, 1),
('Producto 80', 'Descripción del Producto 80', 33.50, 1, 1),
('Producto 81', 'Descripción del Producto 81', 40.50, 1, 1),
('Producto 82', 'Descripción del Producto 82', 47.00, 1, 1),
('Producto 83', 'Descripción del Producto 83', 34.00, 1, 1),
('Producto 84', 'Descripción del Producto 84', 41.25, 1, 1),
('Producto 85', 'Descripción del Producto 85', 48.00, 1, 1),
('Producto 86', 'Descripción del Producto 86', 35.50, 1, 1),
('Producto 87', 'Descripción del Producto 87', 42.75, 1, 1),
('Producto 88', 'Descripción del Producto 88', 49.00, 1, 1),
('Producto 89', 'Descripción del Producto 89', 36.00, 1, 1),
('Producto 90', 'Descripción del Producto 90', 43.50, 1, 1),
('Producto 91', 'Descripción del Producto 91', 50.00, 1, 1),
('Producto 92', 'Descripción del Producto 92', 37.50, 1, 1),
('Producto 93', 'Descripción del Producto 93', 44.25, 1, 1),
('Producto 94', 'Descripción del Producto 94', 51.00, 1, 1),
('Producto 95', 'Descripción del Producto 95', 38.00, 1, 1),
('Producto 96', 'Descripción del Producto 96', 45.00, 1, 1),
('Producto 97', 'Descripción del Producto 97', 52.00, 1, 1),
('Producto 98', 'Descripción del Producto 98', 39.50, 1, 1),
('Producto 99', 'Descripción del Producto 99', 46.50, 1, 1),
('Producto 100', 'Descripción del Producto 100', 53.00, 1, 1);








