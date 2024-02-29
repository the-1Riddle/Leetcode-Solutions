/**
 * Runtime: 66 ms
 * Memory Usage: 42.9 MB
 */


/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
using System;
using System.Collections.Generic;

public class MyQueue
{
    private List<int> A;
    private List<int> B;

    public MyQueue()
    {
        A = new List<int>();
        B = new List<int>();
    }

    public void Push(int x)
    {
        A.Add(x);
    }

    public int Pop()
    {
        Peek();
        int lastElement = B[B.Count - 1];
        B.RemoveAt(B.Count - 1);
        return lastElement;
    }

    public int Peek()
    {
        if (B.Count == 0)
        {
            while (A.Count > 0)
            {
                B.Add(A[A.Count - 1]);
                A.RemoveAt(A.Count - 1);
            }
        }
        return B[B.Count - 1];
    }

    public bool Empty()
    {
        return A.Count == 0 && B.Count == 0;
    }
}
