--12.1 Pivoting a Result Set into One Row
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
----------------------------------------------------------------------------
Select DepartmentID,
SUM(case when DepartmentID=1 then 1 else 0 end )as Department1,
SUM(case when DepartmentID=2 then 1 else 0 end )as Department2,
SUM(case when DepartmentID=3 then 1 else 0 end )as Department3,
SUM(case when DepartmentID=4 then 1 else 0 end )as Department4,
SUM(case when DepartmentID=5 then 1 else 0 end )as Department5,
SUM(case when DepartmentID=6 then 1 else 0 end )as Department6,
SUM(case when DepartmentID=7 then 1 else 0 end )as Department7,
SUM(case when DepartmentID=8 then 1 else 0 end )as Department8,
SUM(case when DepartmentID=9 then 1 else 0 end )as Department9,
SUM(case when DepartmentID=10 then 1 else 0 end )as Department10,
SUM(case when DepartmentID=11 then 1 else 0 end )as Department11,
SUM(case when DepartmentID=12 then 1 else 0 end )as Department12,
SUM(case when DepartmentID=13 then 1 else 0 end )as Department13,
SUM(case when DepartmentID=14 then 1 else 0 end )as Department14,
SUM(case when DepartmentID=15 then 1 else 0 end )as Department15,
SUM(case when DepartmentID=16 then 1 else 0 end )as Department16
from HumanResources.EmployeeDepartmentHistory
group by DepartmentID
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

SELECT * FROM HumanResources.EmployeePayHistory
--You want to make calculations involving data from multiple rows. To make your job
--easier, you want to pivot those rows into columns such that all values you need are
--then in a single row.
select [PayFrequency] as [Name], sum(rate) as rate
from HumanResources.EmployeePayHistory
group by PayFrequency


--You want to calculate the difference between the salaries of DEPTNO 20 and
--DEPTNO 10 and between DEPTNO 20 and DEPTNO 30.

--Transpose the totals using the aggregate function SUM and a CASE expression. Then
--code your expressions in the select list:

 select d20_sal - d10_sal as d20_10_diff
 from (
 select sum(case when PayFrequency=1 then Rate end) as d10_sal,
		sum(case when PayFrequency=2 then Rate end) as d20_sal
 from HumanResources.EmployeePayHistory
 ) totals_by_dept

