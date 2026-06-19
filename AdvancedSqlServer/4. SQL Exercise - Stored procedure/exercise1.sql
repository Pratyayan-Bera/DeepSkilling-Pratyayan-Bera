CREATE DATABASE EmployeeManagementSystem;
GO

USE EmployeeManagementSystem;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

INSERT INTO Departments VALUES
(1,'HR'),
(2,'Finance'),
(3,'IT'),
(4,'Marketing');
GO

INSERT INTO Employees
(FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES
('John','Doe',1,5000.00,'2020-01-15'),
('Jane','Smith',2,6000.00,'2019-03-22'),
('Michael','Johnson',3,7000.00,'2018-07-30'),
('Emily','Davis',4,5500.00,'2021-11-05');
GO

SELECT * FROM Departments;
GO

SELECT * FROM Employees;
GO

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees
    (
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate
    );
END;
GO

EXEC sp_InsertEmployee
    @FirstName='David',
    @LastName='Brown',
    @DepartmentID=3,
    @Salary=8000,
    @JoinDate='2022-06-15';
GO

SELECT * FROM Employees;
GO