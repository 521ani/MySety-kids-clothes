--1 /*OK*/
CREATE OR ALTER PROC usp_1 (@minPrice INT , @maxPrice INT)
AS
SELECT g.Name, m.Material
FROM Goods AS g
LEFT OUTER JOIN Material AS m
ON g.MaterialID=m.ID
WHERE g.RetailPrice BETWEEN @minPrice AND @maxPrice; 
GO

EXEC usp_1 10, 20;

--2 /*!!!*/
CREATE OR ALTER PROC usp_2 (@invoiceNum INT)
AS
SELECT g.Name, g.RetailPrice*o.Quantity AS 'Profit', o.InvoiceID
FROM Goods as g
INNER JOIN Orders as o
on g.ID=o.GoodID 
WHERE InvoiceID = @invoiceNum; /*n-FAKTURA*/
GO

EXEC usp_2 4;

--3 /*OK*/
CREATE OR ALTER PROC usp_3 (@date DATE)
AS
SELECT t.Name, i.Date, i.ID AS InvoiceNumber
FROM Invoice AS i
INNER JOIN Trader AS t
ON i.TraderID=t.ID
WHERE i.Date=@date; 
GO

EXEC usp_3 '2021-12-28';

--4 /*!!!*/
SELECT t.Name
FROM Trader AS t
WHERE ID  IN (SELECT TraderID
				 FROM Invoice
				 WHERE NOT DATEDIFF(day, GETDATE(), Date)<5000)  /*n-дни*/

--5 /*OK*/
CREATE OR ALTER PROC usp_5 (@firstDate DATE, @seconDate DATE) /*OK*/
AS
SELECT g.ID, g.Name, m.Material, g.RetailPrice
FROM Goods AS g
INNER JOIN Orders AS o 
ON g.ID=o.GoodID
INNER JOIN Invoice AS i
ON o.InvoiceID=i.ID
INNER JOIN Material AS m
ON m.ID=g.MaterialID
WHERE i.Date BETWEEN @firstDate AND @seconDate; 
GO

EXEC usp_5 '2022-01-13','2022-01-15';

--6 /*OK*/
CREATE OR ALTER PROC usp_6 (@mol NVARCHAR(20))
AS
SELECT t.Name, t.Adress, t.MOL, COUNT(o.ID) AS [Count Orders] 
FROM Orders AS o
INNER JOIN Invoice AS i
ON o.InvoiceID=i.ID
INNER JOIN Trader AS t
ON i.TraderID=t.ID
WHERE t.MOL LIKE '%'+@mol
GROUP BY t.Name, t.Adress, t.MOL; 
GO

EXEC usp_6 'Симеонов';

--7



--8 /*OK*/
CREATE OR ALTER PROC usp_8 (@material NVARCHAR(20))
AS
SELECT TOP(1) g.Name
FROM Goods AS g
WHERE MaterialID IN (SELECT ID
					 FROM Material AS m
					 WHERE Material=@material) 
ORDER BY g.RetailPrice DESC;
GO

EXEC usp_8 'акрил';

--9 /*OK*/
SELECT m.Material, SUM(o.Quantity*g.RetailPrice) AS Income
FROM Material AS m
INNER JOIN Goods AS g
ON M.ID = G.MaterialID
INNER JOIN Orders AS o
ON G.ID=O.GoodID
GROUP BY m.Material;