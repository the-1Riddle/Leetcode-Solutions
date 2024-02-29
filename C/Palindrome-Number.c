/**
 * O(n)
 * O(n)
 */

bool isPalindrome(int x)
{
        if (x < 0)
        {
            return false;
        }

        long copy = x, reverse = 0;

        while (copy != 0)
        {
            reverse *= 10;
            reverse += copy % 10;
            copy /= 10;
        }

        return x == reverse;
}
