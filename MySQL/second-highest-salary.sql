# Time:  O(n)
# Space: O(1)

SELECT 
AVG(salary) AS SecondHighestSalary FROM (SELECT id, salary,
DENSE_RANK() OVER(ORDER BY salary DESC) AS ranking
FROM Employee ) x WHERE x.ranking = 2;

## /** OR **/

SELECT (SELECT MAX(Salary) FROM Employee WHERE Salary NOT IN (SELECT MAX(Salary) FROM Employee)) SecondHighestSalary;

## /** OR **/

SELECT 
(SELECT DISTINCT(salary )FROM Employee ORDER BY salary DESC LIMIT 1,1) AS SecondHighestSalary;

