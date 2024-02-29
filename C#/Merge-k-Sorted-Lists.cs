/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode curr = new ListNode(0);
            ListNode dummy = curr;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }
            curr.next = l1 ?? l2;
            return dummy.next;
        }

        ListNode MergeKListsHelper(ListNode[] lists, int begin, int end)
        {
            if (begin > end)
                return null;
            if (begin == end)
                return lists[begin];
            return MergeTwoLists(MergeKListsHelper(lists, begin, (begin + end) / 2),
                                 MergeKListsHelper(lists, (begin + end) / 2 + 1, end));
        }

        return MergeKListsHelper(lists, 0, lists.Length - 1);
    }
}
