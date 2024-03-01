# Time:  O(n), n is size of Person Table
# Space: O(n)

SELECT P.firstName, P.lastName, A.city, A.state FROM Person P
LEFT JOIN Address A ON P.personId = A.personId;

