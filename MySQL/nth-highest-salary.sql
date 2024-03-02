# Time:  O(n^2)
# Space: O(n)

CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
SET N = N-1;
  RETURN (SELECT DISTINCT(salary) FROM Employee ORDER BY salary DESC
  LIMIT 1 Offset N   
  );
END

