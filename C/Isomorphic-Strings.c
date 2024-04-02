/**
 * isIsomorphic - check if two strings are isomorphic
 * @s: the string to be checked
 * @t: the second string to be equalized to
 *
 * Return: true if isomorphic, false otherwise
 */
bool isIsomorphic(char* s, char* t)
{
    int len = strlen(s), i;
    char map[256] = {0};
    char rmap[256] = {0};

        /**checks if the lengths are the same **/
    if (len != strlen(t))
    {
        return (false);
    }
    
    for (i = 0; i < len; i++)
    {
        if (map[s[i]] == 0 && rmap[t[i]] == 0)
        {
            map[s[i]] = t[i];
            rmap[t[i]] = s[i];
        }
        else if (map[s[i]] != t[i] || rmap[t[i]] != s[i])
        {
            return (false);
        }
    }
    return (true);
}

/** the best code **/

bool isIsomorphic(char* s, char* t)
{

    int hash_1[127] = {0};
    int hash_2[127] = {0};
    int len = strlen(s), i = 0;

    while (i < len)
    {
        if(hash_1[s[i]] != hash_2[t[i]])
            return (false);
        
        else
        {
            hash_1[s[i]] = i+1;
            hash_2[t[i]] = i+1;
        }
        i++;
    }
    return (true);
}

/** something to try **/
bool isIsomorphic(char* s, char* t)
{
    int hashS[128], hashT[128];
    int index = 0, i;


    for (i = 0; i < 128; i++) {
        hashS[i] = -1;
        hashT[i] = -1;
    }
    while (s[index] != '\0')
    {
        if (hashS[s[index]] == -1 && hashT[t[index]] == -1)
        {
            hashS[s[index]] = t[index];
            hashT[t[index]] = s[index];
        }
        else if (hashS[s[index]] != t[index] || hashT[t[index]] != s[index])
            return (false);
        index++;
    }
    return (true);
}
