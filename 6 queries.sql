--1
SELECT g.Name, m.Material
FROM Goods AS g
LEFT OUTER JOIN Material AS m
ON g.MaterialID=m.ID
WHERE g.RetailPrice BETWEEN 10 AND 20; /*Варират, може да бъдат различни или параметрични*/

--2

SELECT g.Name, g.RetailPrice*o.Quantity AS 'Profit', o.InvoiceID
FROM Goods as g
INNER JOIN Orders as o
on g.ID=o.GoodID 
WHERE InvoiceID = '4'; /*n-FAKTURA*/


--3
SELECT t.Name, i.Date, i.ID AS InvoiceNumber
FROM Invoice AS i
INNER JOIN Trader AS t
ON i.TraderID=t.ID
WHERE i.Date='2021-12-28'; /*виж дали такъв е нормалния формат на датата*/

--4 /*!!!*/
SELECT t.Name
FROM Trader AS t
WHERE ID  IN (SELECT TraderID
				 FROM Invoice
				 WHERE NOT DATEDIFF(day, GETDATE(), Date)<)  /*n-дни*/

--5
SELECT g.ID, g.Name, m.Material, g.RetailPrice
FROM Goods AS g
INNER JOIN Orders AS o 
ON g.ID=o.GoodID
INNER JOIN Invoice AS i
ON o.InvoiceID=i.ID
INNER JOIN Material AS m
ON m.ID=g.MaterialID
WHERE i.Date BETWEEN '2022-01-13' AND '2022-01-15'; /*n-дати*/

--6
SELECT COUNT(o.ID) AS [Count Orders]
FROM Orders AS o
INNER JOIN Invoice AS i
ON o.InvoiceID=i.ID
WHERE TraderID IN (SELECT ID
				 FROM Trader AS t
				 WHERE t.MOL LIKE '%Симеонов'); /*MOL-името е n*/

--7


--8
SELECT TOP(1) g.Name
FROM Goods AS g
WHERE MaterialID IN (SELECT ID
					 FROM Material AS m
					 WHERE Material='акрил') /*NAME-N*/
ORDER BY g.RetailPrice DESC;

--9
SELECT m.Material, o.Quantity, g.RetailPrice
FROM Material AS m
INNER JOIN Goods AS g
ON M.ID = G.MaterialID
INNER JOIN Orders AS o
ON G.ID=O.GoodID

