CREATE DATABASE OnlineRetailStore;
GO

USE OnlineRetailStore;
GO

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
GO

INSERT INTO Products VALUES
(1,'Laptop A','Electronics',80000),
(2,'Laptop B','Electronics',75000),
(3,'Phone X','Electronics',75000),
(4,'Headphones','Electronics',5000),

(5,'Bed','Furniture',60000),
(6,'Sofa','Furniture',40000),
(7,'Table','Furniture',25000),
(8,'Chair','Furniture',25000),

(9,'Jacket','Clothing',3500),
(10,'Jeans','Clothing',3500),
(11,'Shirt','Clothing',2000),
(12,'T-Shirt','Clothing',1500);
GO

SELECT * FROM Products;

SELECT
    ProductID,
    ProductName,
    Category,
    Price,

    ROW_NUMBER() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNumber,

    RANK() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RankNumber,

    DENSE_RANK() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS DenseRankNumber

FROM Products;

WITH RankedProducts AS
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER(
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS Row_Num
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE Row_Num <= 3;