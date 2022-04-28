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



--You want to calculate the difference between the Ratearies of DEPTNO 20 and
--DEPTNO 10 and between DEPTNO 20 and DEPTNO 30.

--Transpose the totals using the aggregate function SUM and a CASE expression. Then
--code your expressions in the select list:

 select d20_Rate - d10_Rate as d20_10_diff
 from (
 select sum(case when PayFrequency=1 then Rate end) as d10_Rate,
		sum(case when PayFrequency=2 then Rate end) as d20_Rate
 from HumanResources.EmployeePayHistory
 ) totals_by_dept
 ------------------------------------------------------------------------------------
select DepartmentID,LoginID
from emp
where DepartmentID=10

select DepartmentID,
count(*) as cnt,
max(Rate) as hi_Rate,
min(Rate) as lo_Rate
from emp
where DepartmentID=10
group by DepartmentID

--Groups are nonempty
create table fruits (name varchar(10))
select name
from fruits
group by name;

select count(*) as cnt
from fruits
group by name;

select name, count(*) as cnt
from fruits
group by name
--Groups are distinct
insert into fruits values ('Oranges')
insert into fruits values ('Oranges')
insert into fruits values ('Oranges')
insert into fruits values ('Apple')
insert into fruits values ('Peach')

select *
from fruits

select name
from fruits
group by name;

select name, count(*) as cnt
from fruits
group by name;

insert into fruits values (null)
insert into fruits values (null)
insert into fruits values (null)
insert into fruits values (null)
insert into fruits values (null)

select coalesce(name,'NULL') as name
from fruits

select coalesce(name,'NULL') as name,
count(name) as cnt
from fruits
group by name

select coalesce(name,'NULL') as name,
count(*) as cnt
from fruits
group by name


select coalesce(name,'NULL') as name,
count(*) as cnt
from fruits
group by name
union all
select coalesce(name,'NULL') as name,
count(*) as cnt
from fruits
group by name

select x.*
from (
select coalesce(name,'NULL') as name,
count(*) as cnt
from fruits
group by name
) x,
(select DEPARTMENTID from emp) y


--Column 'emp.DepartmentID' is invalid in the select list because it is not contained in either an aggregate function or the GROUP BY clause.
select DEPARTMENTID, count(*) as cnt
from emp;

select DEPARTMENTID, count(*) as cnt
from emp
group by DEPARTMENTID;

select 'hello' as msg,
1 as num,
DEPARTMENTID,
(select count(*) from emp) as total,
count(*) as cnt
from emp
group by DEPARTMENTID;

-------
select DEPARTMENTID, JobTitle, count(*) as cnt
from emp
group by DEPARTMENTID, JobTitle;

select count(*) as cnt
from emp;

select LoginID,
DEPARTMENTID,
count(*) over() as cnt
from emp
order by 2;

select LoginID,
DEPARTMENTID,
count(*) over() as cnt
from emp
where DEPARTMENTID = 10
order by 2;

--Partition by
select LoginID,
DEPARTMENTID,
count(*) over(partition by DEPARTMENTID) as cnt
from emp
order by 2;

select e.LoginID,
e.DEPARTMENTID,
(select count(*) from emp d
where e.DEPARTMENTID=d.DEPARTMENTID) as cnt
from emp e
order by 2;

select distinct LoginID,
DEPARTMENTID,
count(*) over(partition by DEPARTMENTID) as dept_cnt,
JobTitle,
count(*) over(partition by JobTitle) as job_cnt
from emp
order by 2;


--select coalesce(comm,-1) as comm,
--count(*)over(partition by comm) as cnt
--from

---When Order matters
--Consider the following query, which sums and computes a running total of salaries
--for employees in DEPTNO 10
select DepartmentID,LoginID,StartDate,Rate,
	sum(Rate)over(partition by DepartmentID) as total1,
	sum(Rate)over() as total2,
	sum(Rate)over(order by StartDate) as running_total
from emp where DepartmentID = 10;

--Just to keep you on your toes, I’ve included a sum with empty
--parentheses. Notice how TOTAL1 and TOTAL2 have the same values.
--Why? Once again, the order in which window functions are
--evaluated answers the question. The WHERE clause filters the
--result set such that only salaries from DEPTNO 10 are considered
--for summation. In this case, there is only one partition—the entire
--result set, which consists of only salaries from DEPTNO 10. Thus
--TOTAL1, and TOTAL2 are the same.

-----------------------------------------------------------------------------------------
--The RANGE BETWEEN clause that you see in this query is termed the framing clause
--by ANSI, and we’ll use that term here. Now, it should be easy to see why specifying an
--ORDER BY in the OVER clause created a running total; we’ve (by default) told the
--query to sum all rows starting from the current row and include all prior rows
--(“prior” as defined in the ORDER BY, in this case ordering the rows by HIREDATE).
select DepartmentID,LoginID,StartDate,Rate,
	sum(Rate)over(partition by DepartmentID) as total1,
	sum(Rate)over() as total2,
sum(Rate)over(order by StartDate
range between unbounded preceding
and current row) as running_total
from emp
where DepartmentID = 10;
------------------------------------------------------------------------------------------
select DepartmentID,LoginID,Rate,
sum(Rate)over(order by StartDate
range between unbounded preceding
and current row) as run_total1,
sum(Rate)over(order by StartDate
rows between 1 preceding
and current row) as run_total2,
sum(Rate)over(order by StartDate
range between current row
and unbounded following) as run_total3,
sum(Rate)over(order by StartDate
rows between current row
and 1 following) as run_total4
from emp
where DepartmentID=10;

--RUN_TOTAL2
--Rather than the keyword RANGE, this framing clause specifies ROWS, which
--means the frame, or window, is going to be constructed by counting some number
--of rows. The 1 PRECEDING means that the frame will begin with the row
--immediately preceding the current row. The range continues through the CURRENT
--ROW. So what you get in RUN_TOTAL2 is the sum of the current
--employee’s salary and that of the preceding employee, based on HIREDATE.
--[[sqlckbk-APP-A-NOTE-11]]
--It so happens that RUN_TOTAL1 and RUN_TOTAL2 are the
--same for both CLARK and KING. Why? Think about which
--values are being summed for each of those employees, for each
--of the two window functions. Think carefully, and you’ll get
--the answer.
--RUN_TOTAL3
--The window function for RUN_TOTAL3 works just the opposite of that for
--RUN_TOTAL1; rather than starting with the current row and including all prior
--rows in the summation, summation begins with the current row and includes all
--subsequent rows in the summation.
--RUN_TOTAL4
--This is the inverse of RUN_TOTAL2; rather than starting from the current row
--and including one prior row in the summation, start with the current row and
--include one subsequent row in the summation.
----------------------------------------------------------------------------------------------
select distinct LoginID,
Rate,
min(Rate)over(order by Rate) min1,
max(Rate)over(order by Rate) max1,
min(Rate)over(order by Rate
range between unbounded preceding
and unbounded following) min2,
max(Rate)over(order by Rate
range between unbounded preceding
and unbounded following) max2,
min(Rate)over(order by Rate
range between current row
and current row) min3,
max(Rate)over(order by Rate
range between current row
and current row) max3,
max(Rate)over(order by Rate
rows between 3 preceding
and 3 following) max4
from emp

--MIN1
--The window function generating this column does not specify a framing clause,
--so the default framing clause of UNBOUNDED PRECEDING AND CURRENT
--ROW kicks in. Why is MIN1 800 for all rows? It’s because the lowest salary
--comes first (ORDER BY SAL), and it remains the lowest, or minimum, salary
--forever after.
--MAX1
--The values for MAX1 are much different from those for MIN1. Why? The
--answer (again) is the default framing clause UNBOUNDED PRECEDING AND
--CURRENT ROW. In conjunction with ORDER BY SAL, this framing clause
--ensures that the maximum salary will also correspond to that of the current row.
--Consider the first row, for SMITH. When evaluating SMITH’s salary and all prior
--salaries, MAX1 for SMITH is SMITH’s salary, because there are no prior salaries.
--Moving on to the next row, JAMES, when comparing JAMES’s salary to all prior
--salaries, in this case comparing to the salary of SMITH, JAMES’s salary is the
--higher of the two, and thus it is the maximum. If you apply this logic to all rows,
--you will see that the value of MAX1 for each row is the current employee’s salary.
--MIN2 and MAX2
--The framing clause given for these is UNBOUNDED PRECEDING AND
--UNBOUNDED FOLLOWING, which is the same as specifying empty parentheses.
--Thus, all rows in the result set are considered when computing MIN and
--MAX. As you might expect, the MIN and MAX values for the entire result set are
--constant, and thus the value of these columns is constant as well.
--MIN3 and MAX3
--The framing clause for these is CURRENT ROW AND CURRENT ROW, which
--simply means use only the current employee’s salary when looking for the MIN
--and MAX salary. Thus, both MIN3 and MAX3 are the same as SAL for each row.
--That was easy, wasn’t it?
--MAX4
--The framing clause defined for MAX4 is 3 PRECEDING AND 3 FOLLOWING,
--which means, for every row, consider the three rows prior and the three rows
--after the current row, as well as the current row itself. This particular invocation
--of MAX(SAL) will return from those rows the highest salary value.
--If you look at the value of MAX4 for employee MARTIN, you can see how the
--framing clause is applied. MARTIN’s salary is 1250, and the three employee salaries
--prior to MARTIN’s are WARD’s (1250), ADAMS’s (1100) and JAMES’s (950).
--The three employee salaries after MARTIN’s are MILLER’s (1300), TURNER’s
--(1500), and ALLEN’s (1600). Out of all those salaries, including MARTIN’s, the
--highest is ALLEN’s, and thus the value of MAX4 for MARTIN is 1600.
-------------------------------------------------------------------------------
--“What is the number of employees in each
--department? How many different types of employees are in each department (e.g.,
--how many clerks are in department 10)? How many total employees are in table
--EMP?”

select distinct DepartmentID,
JobTitle,
count(*) over (partition by DepartmentID) as emp_cnt,
count(JobTitle) over (partition by DepartmentID,JobTitle) as job_cnt,
count(*) over () as total
from emp;

--Returning the same result set without using window functions would require a bit
--more work:
select a.DepartmentID, a.JobTitle,
(select count(*) from emp b
where b.DepartmentID = a.DepartmentID) as emp_cnt,
(select count(*) from emp b
where b.DepartmentID = a.DepartmentID and b.JobTitle = a.JobTitle) as job_cnt,
(select count(*) from emp) as total
from emp a
order by 1,2

-------------------------------------------------------------------------------------------------
--The previous query returns each department, the total number of employees in each
--department, the total number of employees in table EMP, and a breakdown of the
--number of different job types in each department. All this is done in one query,
--without additional joins or temp tables!

select DepartmentID,
emp_cnt as dept_total,
total,
max(case when JobTitle = 'Design Engineer' then job_cnt else 0 end) as [Design Engineer],
max(case when JobTitle = 'Sales Representative' then job_cnt else 0 end) as [Sales Representative],
max(case when JobTitle = 'Marketing Assistant' then job_cnt else 0 end) as [Marketing Assistant],
max(case when JobTitle = 'Buyer' then job_cnt else 0 end) as [Buyer],
max(case when JobTitle = 'Research and Development Engineer' then job_cnt else 0 end) as [Research and Development Engineer]
from (
select DepartmentID,
JobTitle,
count(*) over (partition by DepartmentID) as emp_cnt,
count(JobTitle) over (partition by DepartmentID,JobTitle) as job_cnt,
count(*) over () as total
from emp
) x
group by DepartmentID, emp_cnt, total
--------------------------------------------------------------------------------------------------------
--Who makes the highest salary of all employees (HI)
--Who makes the lowest salary of all employees (LO)
--Who makes the highest salary in the department (HIDPT)
--Who makes the lowest salary in the department (LODPT)
--Who makes the highest salary in their job (HIJOB)
--Who makes the lowest salary in their job (LOJOB)
--What is the sum of all salaries (TTL)
--What is the sum of salaries per department (DPTSUM)
--What is the running total of all salaries per department (DPTRT)

select LoginID as [name],
Rate,
max(Rate)over(partition by DepartmentID) as hiDpt,
min(Rate)over(partition by DepartmentID) as loDpt,
max(Rate)over(partition by JobTitle) as hiJob,
min(Rate)over(partition by JobTitle) as loJob,
max(Rate)over() as hi,
min(Rate)over() as lo,
sum(Rate)over(partition by DepartmentID
order by Rate,BusinessEntityID) as dptRT,
sum(Rate)over(partition by DepartmentID) as dptSum,
sum(Rate)over() as ttl
from emp
order by JobTitle,dptRT