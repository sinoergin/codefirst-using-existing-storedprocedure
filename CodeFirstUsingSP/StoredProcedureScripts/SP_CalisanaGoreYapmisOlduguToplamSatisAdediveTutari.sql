CREATE PROCEDURE [dbo].[CalisanaGoreYapmisOlduguToplamSatisAdediveTutari] (@employeeId int) as
SELECT E.FirstName + ' ' + E.LastName AS CalisanAdSoyad,
COUNT(O.OrderID) AS SatisAdedi,SUM(OD.UnitPrice) AS SatisTutari 
FROM Employees E
	LEFT OUTER JOIN Orders O ON O.EmployeeID = E.EmployeeID
	LEFT OUTER JOIN [Order Details] OD ON OD.OrderID = O.OrderID
WHERE E.EmployeeID = @employeeId
GROUP BY E.FirstName + ' ' + E.LastName
