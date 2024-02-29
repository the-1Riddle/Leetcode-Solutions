/**
 * O(n)
 * O(n)
 * Runtime: 9 ms
 * Memory Usage: 7.1 MB
 */

int evalRPN(char **tokens, int tokensSize) {
    int stack[tokensSize];
    int top = -1;

    for (int i = 0; i < tokensSize; i++) {
        if (strcmp(tokens[i], "+") == 0) {
            int y = stack[top--];
            int x = stack[top--];
            stack[++top] = x + y;
        } else if (strcmp(tokens[i], "-") == 0) {
            int y = stack[top--];
            int x = stack[top--];
            stack[++top] = x - y;
        } else if (strcmp(tokens[i], "*") == 0) {
            int y = stack[top--];
            int x = stack[top--];
            stack[++top] = x * y;
        } else if (strcmp(tokens[i], "/") == 0) {
            int y = stack[top--];
            int x = stack[top--];
            stack[++top] = x / y;
        } else {
            stack[++top] = atoi(tokens[i]);
        }
    }

    return stack[top];
}
