# Time:  O(n), n is size of Person Table
# Space: O(n)

SELECT p.firstName, p.lastName, a.city, a.state 
from Person p left outer join Address a 
on p.personId=a.personId;

