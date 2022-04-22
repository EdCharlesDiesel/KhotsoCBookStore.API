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
------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------
--12.2 Pivoting a Result Set into Multiple Rows

--The first step is to use the window function ROW_NUMBER OVER to help make
--each JOB/ENAME combination unique:
SELECT TOP 10 JobTitle,LoginID,
row_number()OVER(PARTITION BY JobTitle ORDER BY LoginID) rowNumbers
FROM HumanResources.Employee;


--At this point, the rows are transposed into columns, and the last step is to remove the
--NULLs to make the result set more readable. To remove the NULLs, use the aggregate
--function MAX and group by RN.
select rowNumbers,
case when JobTitle='Accountant' then LoginID else null end as Accountant,
case when JobTitle='Accounts Manager' then LoginID else null end as analysts,
case when JobTitle='Accounts Payable Specialist' then LoginID else null end as mgrs,
case when JobTitle='Accounts Receivable Specialist' then LoginID else null end as prez,
case when JobTitle='Application Specialist' then LoginID else null end as [Application Specialist]
from (
select JobTitle,
LoginID,
row_number()over(partition by JobTitle order by LoginID) rowNumbers
FROM HumanResources.Employee
) x

--At this point, the rows are transposed into columns, and the last step is to remove the
--NULLs to make the result set more readable. To remove the NULLs, use the aggregate
--function MAX and group by RN.
select max(case when JobTitle='Accountant' then LoginID else null end) as Accountant,
max(case when JobTitle='Accounts Manager' then LoginID else null end) as [Accounts Manager],
max(case when JobTitle='Accounts Payable Specialist' then LoginID else null end) as [Accounts Payable Specialist],
max(case when JobTitle='Accounts Receivable Specialist' then LoginID else null end) as [Accounts Receivable Specialist],
max(case when JobTitle='Application Specialist' then LoginID else null end) as [Application Specialist]
from (
select JobTitle,
LoginID,
row_number()over(partition by JobTitle order by LoginID) rowNumbers
FROM HumanResources.Employee
) x
group by rowNumbers
---------------------------------------------------------------------------------
--12.2 Pivoting a Result Set into Multiple Rows
--The view EMP_CNTS represents the denormalized view, or “wide” result set that you
CREATE VIEW emp_cunts as
(Select 
SUM(case when DepartmentID=1 then 1 else 0 end )as Department1,
SUM(case when DepartmentID=2 then 1 else 0 end )as Department2,
SUM(case when DepartmentID=3 then 1 else 0 end )as Department3
from HumanResources.EmployeeDepartmentHistory
)

--Because there are three columns, you will create three rows. Begin by creating a Cartesian
--product between inline view EMP_CNTS and some table expression that has at
--least three rows The following code uses table DEPT to create the Cartesian product;


select dept.DepartmentID,
emp_cnts.DepartmentID_10,
emp_cnts.DepartmentID_30,
emp_cnts.DepartmentID_30
from (
Select sum(case when DepartmentID=1 then 1 else 0 end) as DepartmentID_10,
sum(case when DepartmentID=2 then 1 else 0 end) as DepartmentID_20,
sum(case when DepartmentID=3 then 1 else 0 end) as DepartmentID_30
from HumanResources.EmployeeDepartmentHistory
) emp_cnts,
(select DepartmentID from HumanResources.EmployeeDepartmentHistory where DepartmentID <= 30) dept

--The Cartesian product enables you to return a row for each column in inline view
--EMP_CNTS. Since the final result set should have only the DepartmentID and the number
--of employees in said DepartmentID, use a CASE expression to transform the three columns
--into one:

select dept.DepartmentID,
case dept.DepartmentID
when 1 then emp_cnts.DepartmentID_10
when 2 then emp_cnts.DepartmentID_20
when 3 then emp_cnts.DepartmentID_30
end as counts_by_dept
from (
emp_cnts
cross join 
(select DepartmentID from 
HumanResources.EmployeeDepartmentHistory where DepartmentID <= 30) 
dept);

------------------------------------------------------------------------------------------------
--12.4Reverse Pivoting a Result Set into One Column

--The first step is to use the window function ROW_NUMBER OVER to create a ranking
--for each employee in DEPTNO 10:

select e.JobTitle,e.LoginID,
row_number()over(partition by e.BusinessEntityID
order by e.BusinessEntityID) rn
from HumanResources.Employee e
where e.BusinessEntityID = 10

--At this point, the ranking doesn’t mean much. You are partitioning by EMPNO, so
--the rank is 1 for all three rows in DEPTNO 10. Once you add the Cartesian product,
--the rank will begin to take shape, as shown in the following results:

with four_rows (id)
as
(select 1
union all
select id+1
from four_rows
where id < 4
)

select e.JobTitle,e.LoginID,
row_number()over(partition by e.BusinessEntityID
order by e.BusinessEntityID) rn
from HumanResources.Employee e
join four_rows on 1=1

--erstand two key points:
--• RN is no longer 1 for each employee; it is now a repeating sequence of values
--from 1 to 4, the reason being that window functions are applied after the FROM
--and WHERE clauses are evaluated. So, partitioning by EMPNO causes the RN to
--reset to 1 when a new employee is encountered.
--• We’ve used a recursive CTE to ensure that for each employee there are four rows.
--We don’t need the RECURSIVE keyword in SQL Server or DB2, but we do for
--Oracle, MySQL, and PostgreSQL.

with four_rows (id)
as
(select 1
union all
select id+1
from four_rows
where id < 4
),
x_tab (JobTitle,LoginID,rn )
as
(select e.JobTitle,e.LoginID,
row_number()over(partition by e.BusinessEntityID
order by e.BusinessEntityID) 
from HumanResources.Employee e
join four_rows on 1=1)

select case rn
when 1 then LoginID
when 2 then JobTitle

end emps
from x_tab
--------------------------------------------------------------------------
--12.5 Suppressing Repeating Values from a Result Set
--You are generating a report, and when two rows have the same value in a column,
--you want to display that value only once. For example, you want to return DEPTNO
--and ENAME from table EMP, you want to group all rows for each DEPTNO, and you
--want to display each DEPTNO only one time

--The first step is to use the window function LAG OVER to return the prior DEPTNO
--for each row:

select
 case when
 lag(e.DepartmentID)over(order by DepartmentID) = DepartmentID then null
 else DepartmentID end DEPTNO
 , e.ShiftID
from HumanResources.EmployeeDepartmentHistory e

--If you inspect the previous result set, you can easily see where DEPTNO matches
--LAG_ DEPTNO. For those rows, you want to set DEPTNO to NULL. Do that by
--using DECODE (TO_NUMBER is included to cast DEPTNO as a number):

select to_number(
CASE WHEN (lag(DepartmentID)over(order by DepartmentID)
= DepartmentID THEN null else deptno END DepartmentID ,
DepartmentID,null,DepartmentID)
) deptno, ename
from HumanResources.EmployeeDepartmentHistory
-----------------------------------------------------------------------------
--12.6 Pivoting a Result Set to Facilitate Inter-Row Calculations

select  d10_Rate -d01_Rate as d01_10_diff,
 d10_Rate - d02_Rate as d02_10_diff
from (
 select sum(case when DepartmentID=10 then Rate end) as d10_Rate,
 sum(case when DepartmentID=1 then Rate end) as d01_Rate,
 sum(case when DepartmentID=2 then Rate end) as d02_Rate
 from emp
 ) totals_by_dept
-------------------------------------------------------------------------------------------------
--12.7 Creating Buckets of Data, of a Fixed Size.
/*
You want to organize data into evenly sized buckets, with a predetermined number of
elements in each bucket. The total number of buckets may be unknown, but you want
to ensure that each bucket has five elements.
*/

select ceiling(row_number()over(order by BusinessEntityID)/5.0) grp,
BusinessEntityID,LoginID
from emp;
-----------------------------------------------------------------------------------
--12.8 Creating a Predefined Number of Buckets
/*
You want to organize your data into a fixed number of buckets. For example, you
want to organize the employees in table EMP into four buckets
*/

select ntile(4)over(order by BusinessEntityID) grp,
BusinessEntityID,
LoginID
from emp;
-------------------------------------------------------------------------------
--12.9 Creating Horizontal Histograms.
/*
You want to use SQL to generate histograms that extend horizontally. For example,
you want to display the number of employees in each department as a horizontal histogram
with each employee represented by an instance of *.
*/

select DepartmentID,
replicate('*',count(*)) cnt
from emp
group by DepartmentID;

---------------------------------------------------------------------------------
--12.10 Creating Vertical Histograms
/*
You want to generate a histogram that grows from the bottom up. For example, you
want to display the number of employees in each department as a vertical histogram
with each employee represented by an instance of *.
*/
select max(deptno_1) d1,
 max(deptno_2) d2,
 max(deptno_3) d3
 from (
 select row_number()over(partition by DepartmentID order by BusinessEntityID) rn,
 case when DepartmentID=1 then '*' else null end deptno_1,
 case when DepartmentID=2 then '*' else null end deptno_2,
 case when DepartmentID=3 then '*' else null end deptno_3
 from emp
 ) x
 group by rn
 order by 1 desc, 2 desc, 3 desc
 --------------------------------------------------------------------------------------
 --12.11 Returning Non-GROUP BY Columns
/*
You are executing a GROUP BY query, and you want to return columns in your select
list that are not also listed in your GROUP BY clause. This is not normally possible,
as such ungrouped columns would not represent a single value per row.
Say that you want to find the employees who earn the highest and lowest salaries in
each department, as well as the employees who earn the highest and lowest salaries in
each job. You want to see each employee’s name, the department he works in, his job
title, and his salary.
*/

select DepartmentID,LoginID,JobTitle,Rate,
case when Rate = max_by_dept then 'TOP SAL IN DEPT'
 when Rate = min_by_dept  then 'LOW SAL IN DEPT'  
 end dept_status,
case when Rate = max_by_job then 'TOP SAL IN JOB'
 when Rate = min_by_job then 'LOW SAL IN JOB'
end job_status from (
select DepartmentID,LoginID,JobTitle,Rate,
max(Rate)over(partition by DepartmentID) max_by_dept,
max(Rate)over(partition by JobTitle) max_by_job,
min(Rate)over(partition by DepartmentID) min_by_dept,
min(Rate)over(partition by JobTitle) min_by_job
from emp
) emp_sals
where Rate in (max_by_dept,max_by_job,
 min_by_dept,min_by_job)

---------------------------------------------------------------------------------------------------
--12.12 Calculating Simple Subtotals.
/*
A simple subtotal is defined as a result set that contains
values from the aggregation of one column along with a grand total value for the
table.
*/

select coalesce(JobTitle,'TOTAL') JobTitle,
sum(Rate) Rate
from emp
group by JobTitle with rollup
---------------------------------------------------------------------------------------------------
--12.13 Calculating Subtotals for All Possible Expression Combinations
/*
You want to find the sum of all salaries by DEPTNO, and by JOB, for every JOB/
DEPTNO combination. You also want a grand total for all salaries in table EMP.
*/

select DepartmentID,JobTitle,
case cast(grouping(DepartmentID)as char(1))+
cast(grouping(JobTitle)as char(1))
when '00' then 'TOTAL BY DEPT AND JOB'
when '10' then 'TOTAL BY JOB'
when '01' then 'TOTAL BY DEPT'
when '11' then 'GRAND TOTAL FOR TABLE'
end category,
sum(JobTitle) sal
from emp
group by DepartmentID,JobTitle with cube
order by grouping(JobTitle),grouping(DepartmentID);

------------------------------------------------------------------------------------------------
--12.14 Identifying Rows That Are Not Subtotals
/*
You’ve used the CUBE extension of the GROUP BY clause to create a report, and you
need a way to differentiate between rows that would be generated by a normal 
GROUP BY clause and those rows that have been generated as a result of using CUBE
or ROLLUP.
*/

select DepartmentID, JobTitle, sum(Rate) sal, grouping(DepartmentID) deptno_subtotals,
grouping(JobTitle) job_subtotals
from emp
group by DepartmentID,JobTitle with cube;
------------------------------------------------------------------------------------------
--12.15 Using Case Expressions to Flag Rows
/*
You want to map the values in a column, perhaps the EMP table’s JOB column, into a
series of “Boolean” flags.
*/

select LoginID,
case when JobTitle = 'Accountant' then 1 else 0 end as [Accountant],
case when JobTitle = 'Accounts Manager' then 1 else 0 end as [Accounts Manager],
case when JobTitle = 'Accounts Payable Specialist' then 1 else 0 end as [Accounts Payable Specialist],
case when JobTitle = 'Accounts Receivable Specialist' then 1 else 0 end as [Accounts Receivable Specialist],
case when JobTitle = 'Application Specialist' then 1 else 0 end as [Application Specialist]
from emp
order by 2,3,4,5,6;

--------------------------------------------------------------------------------------
--12.16 Creating a Sparse Matrix
/*
You want to create a sparse matrix, such as the following one transposing the
DEPTNO and JOB columns of table EMP:
*/
select case DepartmentID when 1 then LoginID end as d1,
case DepartmentID when 2 then LoginID end as d2,
case DepartmentID when 3 then LoginID end as d3,
case when JobTitle = 'Accountant' then 1 else 0 end as [Accountant],
case when JobTitle = 'Accounts Manager' then 1 else 0 end as [Accounts Manager],
case when JobTitle = 'Accounts Payable Specialist' then 1 else 0 end as [Accounts Payable Specialist],
case when JobTitle = 'Accounts Receivable Specialist' then 1 else 0 end as [Accounts Receivable Specialist],
case when JobTitle = 'Application Specialist' then 1 else 0 end as [Application Specialist]
from emp
--------------------------------------------------------------------------------------------------------------
--12.17 Grouping Rows by Units of Time
/*
You want to summarize data by some interval of time. For example, you have a transaction
log and want to summarize transactions by five-second intervals. The rows in
table TRX_LOG are shown here:
*/
select Ceiling(trx_id/5.0) as grp,
min(trx_date) as trx_start,
max(trx_date) as trx_end,
sum(trx_cnt) as total
from trx_log
group by Ceiling(trx_id/5.0)
-----------------------------------------------------------------------------------------------------------------
--12.18 Performing Aggregations over Different Groups/Partitions Simultaneously.
/*
You want to aggregate over different dimensions at the same time. For example, you
want to return a result set that lists each employee’s name, their department, the number
of employees in their department (themselves included), the number of employees
that have the same job (themselves included in this count as well), and the total
number of employees in the EMP table.
*/

select LoginID,
DepartmentID,
count(*)over(partition by DepartmentID) deptno_cnt,
JobTitle,
count(*)over(partition by JobTitle) job_cnt,
count(*)over() total
from emp;
------------------------------------------------------------------------------------------------------------
--12.19 Performing Aggregations over a Moving Range of Values
/*
You want to compute a moving aggregation, such as a moving sum on the salaries in
table EMP. You want to compute a sum for every 90 days, starting with the HIREDATE
of the first employee. You want to see how spending has fluctuated for every
90-day period between the first and last employee hired.
*/

select e.StartDate,e.Rate,
(select sum(Rate) from emp d
where d.StartDate between e.StartDate - 90
and e.StartDate) as spending_pattern
from emp e
order by 1;

select e.StartDate,
e.Rate,
sum(d.Rate) as spending_pattern
from emp e, emp d
where d.StartDate
between e.StartDate-90 and e.StartDate
group by e.StartDate,e.Rate
order by 1;
--------------------------------------------------------------------------------------------------------------
--12.20 Pivoting a Result Set with Subtotals
-- select mgr,
 select LoginID,
 sum(case DepartmentID when 10 then sal else 0 end) dept10,
 sum(case DepartmentID when 20 then sal else 0 end) dept20,
 sum(case DepartmentID when 30 then sal else 0 end) dept30,
 sum(case flag when '11' then sal else null end) total
 from (
 select DepartmentID,LoginID,sum(Rate) sal,
 cast(grouping(DepartmentID) as char(1))+
 cast(grouping(LoginID) as char(1)) flag
 from emp
 where LoginID is not null
 group by DepartmentID,LoginID with rollup
 ) x
 group by LoginID;