--PROMBLEM 1.3
SELECT* FROM HumanResources.Department WHERE
(DepartmentID = 11 OR GroupName IS NOT NULL OR ModifiedDate <= '2008-04-30')
AND DepartmentID= 10;

--PROMBLEM 1.7
SELECT Name  + '-' +GroupName as [Id and Name] FROM HumanResources.Department WHERE
modifiedDate <= '2008-04-30';


--PROMBLEM 1.8
SELECT BusinessEntityID,Rate,
	CASE WHEN Rate >=100 THEN 'OVERPAID'
		WHEN Rate >=50 THEN 'OK'
		ELSE 'UNDERPAID' 
		END AS [SALARY RATE]
FROM  [HumanResources].[EmployeePayHistory]

--PROMBLEM 1.9
SELECT TOP 10 * FROM  [HumanResources].[EmployeePayHistory]

--PROMBLEM 1.10
SELECT TOP 5 LoginID,JobTitle 
FROM  [HumanResources].Employee
ORDER BY NEWID();

--PROMBLEM 1.12
SELECT 
	CASE WHEN [OrganizationLevel] IS NOT NULL THEN [OrganizationLevel]
	ELSE 0
	END
FROM  [HumanResources].[Employee];

SELECT COALESCE([OrganizationLevel],0) AS [OrganizationLevel]
FROM [HumanResources].[Employee];

--PROMBLEM 1.13
SELECT LoginID,JobTitle 
FROM  [HumanResources].Employee WHERE [OrganizationLevel] =3
AND ([JobTitle] LIKE '%WC60');

--PROMBLEM 2.3
SELECT LoginID,JobTitle 
FROM  [HumanResources].Employee ORDER BY SUBSTRING(LoginID,LEN(LoginID)-1,3);

--PROMBLEM 2.4
CREATE VIEW [Login_ID]
AS
SELECT LoginID + ' - ' +  NationalIDNumber AS [Login and ID]
FROM  [HumanResources].[Employee];

SELECT [Login and ID]
FROM [Login_ID]
 ORDER BY REPLACE([Login and ID],
		  REPLACE(
			TRANSLATE([Login and ID],'48#####','##########'),'#',''),'');

--PROMBLEM 2.4
SELECT [DepartmentID],[StartDate],[EndDate]
FROM  (
	SELECT *,
		CASE WHEN EndDate IS NULL THEN '2022-04-01'
		END	
		AS [EndDate]
		FROM [HumanResources].EmployeeDepartmentHistory
		) 

--PROMBLEM 2.5
SELECT [DepartmentID],[StartDate],[EndDate]
FROM  (
	SELECT *,
		CASE WHEN EndDate IS NULL THEN '2022-04-01'
		END	
		AS [EndDate]
		FROM [HumanResources].EmployeeDepartmentHistory
		); 

--PROMBLEM 2.6
SELECT [BusinessEntityID], [NationalIDNumber], [LoginID],[OrganizationLevel],[JobTitle]
FROM   [HumanResources].Employee
	ORDER BY CASE WHEN [JobTitle] LIKE 'Senior%' 
	THEN [OrganizationLevel]
	ELSE [BusinessEntityID]
	END;

--PROMBLEM 3.1
SELECT [ModifiedDate],[BusinessEntityID] FROM [HumanResources].[Employee]
WHERE [ModifiedDate] >='2009-01-13 00:00:00.000'
UNION ALL 
SELECT [ModifiedDate],[BusinessEntityID] FROM [HumanResources].[EmployeeDepartmentHistory];

--PROMBLEM 3.2
SELECT e.[LoginID], e.[JobTitle],j.[Resume]
FROM [HumanResources].[Employee] e, [HumanResources].[JobCandidate] j
WHERE e.OrganizationLevel = 3

SELECT e.[LoginID], e.[JobTitle],j.[Resume]
FROM [HumanResources].[Employee] e INNER JOIN [HumanResources].[JobCandidate] j
ON e.BusinessEntityID = j.BusinessEntityID
WHERE e.OrganizationLevel = 3

--PROMBLEM 3.3
CREATE VIEW EmployeeMinView
AS
SELECT [BusinessEntityID],
[NationalIDNumber],
[OrganizationLevel],
[JobTitle],
[BirthDate],
[HireDate]
FROM [HumanResources].Employee

SELECT *
FROM EmployeeMinView em INNER JOIN [HumanResources].[JobCandidate] j
ON (em.BusinessEntityID = j.BusinessEntityID
AND em.BirthDate = j.ModifiedDate)

--PROMBLEM 3.4
SELECT [BusinessEntityID] FROM [HumanResources].JobCandidate
EXCEPT
SELECT [BusinessEntityID] FROM [HumanResources].Employee

--PROMBLEM 3.5	 
SELECT J.*
FROM [HumanResources].JobCandidate J left outer join [HumanResources].Employee e
ON (J.BusinessEntityID = e.BusinessEntityID)
WHERE J.BusinessEntityID IS NULL

--PROMBLEM 3.6
SELECT e.[LoginID], p.[Rate],
 (SELECT ev.NationalIDNumber FROM EmployeeMinView ev
 WHERE ev.[BusinessEntityID]=e.BusinessEntityID) AS [ID_Number]
 FROM [HumanResources].[Employee] e,  [HumanResources].[EmployeePayHistory] p
 WHERE e.[BusinessEntityID]=p.[BusinessEntityID]
 ORDER BY [Rate]

SELECT e.[LoginID], p.[Rate],ev.[NationalIDNumber]
FROM [HumanResources].[Employee] e JOIN   [HumanResources].[EmployeePayHistory] p
ON ( e.[BusinessEntityID]=p.[BusinessEntityID])
LEFT JOIN EmployeeMinView ev
ON (ev.[BusinessEntityID]=e.BusinessEntityID)

--PROMBLEM 3.7