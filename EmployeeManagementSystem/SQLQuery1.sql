CREATE DATABASE EmployeeDB;
USE EmployeeDB;

CREATE TABLE Employees (
    ID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100),
    Age INT,
    Department NVARCHAR(100)
);
SELECT * FROM Employees