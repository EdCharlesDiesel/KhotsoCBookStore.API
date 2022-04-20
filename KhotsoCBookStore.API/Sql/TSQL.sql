--PROMBLEM 1.3
SELECT * FROM HumanResources.Department WHERE
(DepartmentID = 11 OR GroupName IS NOT NULL OR ModifiedDate <= '2008-04-30')
AND DepartmentID = 10;

--PROMBLEM 1.7
SELECT [Name]  + '-' + GroupName as [Id and Name] FROM HumanResources.Department WHERE
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
SELECT LoginID,JobTitle FROM  [HumanResources].Employee WHERE [OrganizationLevel] = 3
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
		) ;

--PROMBLEM 2.5
SELECT *
FROM  (
	SELECT *,
		CASE WHEN EndDate IS NULL THEN '2022-04-01'
		END	
		AS [EndDate]
		FROM [HumanResources].EmployeeDepartmentHistory
		) x; 

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

SELECT e.[Name], e.GroupName, d.ShiftID FROM [HumanResources].[Department] e,
HumanResources.EmployeeDepartmentHistory d Where e.DepartmentID = 6;
SELECT e.[Name], e.GroupName, d.ShiftID FROM [HumanResources].[Department] e,
HumanResources.EmployeeDepartmentHistory d Where e.DepartmentID = 6 AND d.DepartmentID = 6;
 
 --Problem 3.8 
 SELECT EDH.DepartmentID,EDH.ShiftID,EPH.PayFrequency,EPH.Rate,
SUM(DISTINCT EPH.Rate) OVER
(partition by EHD.ShiftID) as Total,
EDH.DepartmentID,
sum(EPH.Rate * CASE when EPH.BusinessEntityID = 1 then 2
WHEN EPH.BusinessEntityID = 1 ) OVER
(PARTITION BY Rate) AS total_bonus
FROM HumanResources.EmployeeDepartmentHistory EDH, HumanResources.EmployeePayHistory EPH
WHERE EPH.BusinessEntityID = EPH.BusinessEntityID
AND EDH.ShiftID = 10



 SELECT  
 JobTitle,LoginID from HumanResources.Employee
  SELECT BusinessEntityID, Rate, PayFrequency FROM HumanResources.EmployeePayHistory


SELECT e.JobTitle,e.Gender,e.LoginID,eph.Rate * 
CASE WHEN eph.PayFrequency = 1 then .1
	WHEN eph.PayFrequency = 2 then .2			
	ELSE .3
	END AS Bonus
FROM HumanResources.Employee e,
HumanResources.EmployeePayHistory eph
Where e.JobTitle = 'Marketing Manager';
----------------------------
SELECT JobTitle,
SUM(Bonus) AS total_bonus
from 
(SELECT e.JobTitle,e.Gender,e.LoginID,eph.Rate * 
CASE WHEN eph.PayFrequency = 1 then .1
	WHEN eph.PayFrequency = 2 then .2			
	ELSE .3
	END AS Bonus
FROM HumanResources.Employee e,
HumanResources.EmployeePayHistory eph
WHERE e.JobTitle = 'Marketing Manager')
x
GROUP BY JobTitle;
------------------------------

select e.BusinessEntityID,
e.JobTitle,
sum(distinct e.LoginID) over
(partition by e.JobTitle) as total_sal,
e.BusinessEntityID,
sum(eph.Rate * 
CASE WHEN eph.PayFrequency = 1 then .1
	WHEN eph.PayFrequency = 2 then .2			
	ELSE .3
	END) over
(partition by JobTitle) as total_bonus
FROM HumanResources.Employee e,HumanResources.EmployeePayHistory eph
WHERE e.BusinessEntityID = eph.BusinessEntityID
AND e.JobTitle = 'Marketing Manager'
---------------------------------------
--3.11 Returning Missing Data from Multiple Tables
 SELECT  BusinessEntityID,
 JobTitle,LoginID from HumanResources.Employee
  SELECT BusinessEntityID, Rate, PayFrequency FROM HumanResources.EmployeePayHistory

SELECT e.JobTitle,e.LoginID,eph.PayFrequency,eph.Rate  FROM  HumanResources.Employee e
LEFT OUTER JOIN HumanResources.EmployeePayHistory eph
ON (e.BusinessEntityID = eph.BusinessEntityID)
-----------------------------------------
--3.12 Using NULLs in Operations and Comparisons

SELECT * FROM HumanResources.JobCandidate
WHERE COALESCE(BusinessEntityID,0)< (SELECT BusinessEntityID FROM HumanResources.Employee
WHERE JobTitle LIKE '%Director');
--------------------------------------------
--4.5 Copying a Table Definition
CREATE TABLE Employee2
AS
SELECT * from HumanResources.Employee
--------------------------------------------
--4.7 Blocking Inserts to Certain Columns
CREATE VIEW EmployeeMin AS
select BusinessEntityID, NationalIDNumber, LoginID,JobTitle
from HumanResources.Employee

insert into EmployeeMin
(BusinessEntityID, NationalIDNumber, LoginID, JobTitle)
values (1, 8808056170812, 'Editor','DEVELOPER')
--------------------------------------------
--4.8 Modifying Records in a Table

SELECT BusinessEntityID,Rate,
Rate as orig_sal,
Rate * .10 as amt_to_add,
Rate * 1.10 as new_sal
FROM HumanResources.EmployeePayHistory
WHERE Rate < 50;


--------------------------------------------
--4.8 Modifying Records in a Table
UPDATE HumanResources.EmployeePayHistory
SET Rate = Rate * .10
WHERE Rate < 50;
--------------------------------------------
--4.9 Updating When Corresponding Rows Exist
UPDATE HumanResources.EmployeePayHistory
SET Rate = Rate * .10
WHERE Rate IN (SELECT BusinessEntityID FROM HumanResources.EmployeePayHistory)
-----------------------------------------------
--4.10 Updating with Values from Another Table
UPDATE e
set e.OrganizationLevel = n.PayFrequency
from EmployeeMinView e, HumanResources.EmployeePayHistory n
where n.BusinessEntityID = e.BusinessEntityID
-----------------------------------------------
--4.11 Merging Records
-----------------------------------------------
SELECT BusinessEntityID, DepartmentID, ShiftID FROM HumanResources.EmployeeDepartmentHistory
select DepartmentID,
case when DepartmentID=1 then 1 else 0 end as Department1,
case when DepartmentID=2 then 1 else 0 end as Department2,
case when DepartmentID=3 then 1 else 0 end as Department3,
case when DepartmentID=4 then 1 else 0 end as Department4,
case when DepartmentID=5 then 1 else 0 end as Department5,
case when DepartmentID=6 then 1 else 0 end as Department6,
case when DepartmentID=7 then 1 else 0 end as Department7,
case when DepartmentID=8 then 1 else 0 end as Department8,
case when DepartmentID=9 then 1 else 0 end as Department9,
case when DepartmentID=10 then 1 else 0 end as Department10,
case when DepartmentID=11 then 1 else 0 end as Department11,
case when DepartmentID=12 then 1 else 0 end as Department12,
case when DepartmentID=13 then 1 else 0 end as Department13,
case when DepartmentID=14 then 1 else 0 end as Department14,
case when DepartmentID=15 then 1 else 0 end as Department15,
case when DepartmentID=16 then 1 else 0 end as Department16
from HumanResources.EmployeeDepartmentHistory
order by 1



