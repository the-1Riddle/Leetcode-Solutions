/**
 * lengthOfLastWord - a function to find the length of
 * the last word.
 * @s: string
 *
 * Return: length of last word
 */
int lengthOfLastWord(char* s)
{
    int len = strlen(s);
    int i = len - 1, j;

    while (i >= 0 && s[i] == ' ')
    {
        i--;
    }
    j = i;
    while (j >= 0 && s[j] != ' ')
    {
        j--;
    }
    return (i - j);
}
