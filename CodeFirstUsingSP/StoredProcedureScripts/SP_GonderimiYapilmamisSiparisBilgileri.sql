CREATE PROCEDURE [dbo].[GonderimiYapilmamisSiparisBilgileri] as 
SELECT O.OrderDate as SiparisTarihi,C.CompanyName AS FirmaAdi,COUNT(O.OrderID) AS SiparisAdedi,
SUM(OD.UnitPrice) SiparisTutari,SUM(OD.Quantity) AS SiparisVerilenUrunAdedi from Orders O
	LEFT OUTER JOIN [Order Details] OD ON OD.OrderID = O.OrderID
	LEFT OUTER JOIN Customers C ON C.CustomerID = O.CustomerID
WHERE O.ShippedDate IS NULL	
GROUP BY O.OrderDate,C.CompanyName