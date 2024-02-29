/**
 * Runtime: 109 ms
 * Memory Usage: 41.4 MB
 */

#include <stdbool.h>


/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
/*struct ListNode {
    int val;
    struct ListNode* next;
};
*/
bool isPalindrome(struct ListNode* head) {
    struct ListNode* reverse = NULL;
    struct ListNode* fast = head;

    while (fast != NULL && fast->next != NULL) {
        fast = fast->next->next;
        struct ListNode* temp = head->next;
        head->next = reverse;
        reverse = head;
        head = temp;
    }
    struct ListNode* tail = (fast != NULL) ? head->next : head;

    bool isPalindrome = true;
    while (reverse != NULL) {
        isPalindrome = isPalindrome && (reverse->val == tail->val);
        struct ListNode* tempReverse = reverse->next;
        reverse->next = head;
        head = reverse;
        reverse = tempReverse;
        tail = tail->next;
    }

    return isPalindrome;
}
