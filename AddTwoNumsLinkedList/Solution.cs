namespace AddTwoNumsLinkedList;

public sealed class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

internal sealed class Solution
{
    public ListNode AddTwoNumbers(
        ListNode l1,
        ListNode l2)
    {
        var current1 = l1;
        var finished1 = false;
        
        var current2 = l2;
        var finished2 = false;

        int incNext = 0;

        ListNode? resultNode = null;
        ListNode? prevResultNode = null;
            
        while (true)
        {
            int first = !finished1? current1.val : 0;
            int second = !finished2? current2.val : 0;

            int sum = first + second + incNext;

            int currentResult = sum % 10;
            incNext = sum <= 9 ? 0 : 1;

            var currentNode = new ListNode(currentResult);
            if (prevResultNode is null)
            {
                resultNode = prevResultNode = currentNode;
            }
            else
            {
                prevResultNode.next = currentNode;
                prevResultNode = currentNode;
            }

            if (!finished1)
            {
                if (current1.next is not null)
                {
                    current1 = current1.next;
                }
                else
                {
                    finished1 = true;
                }
            }
            

            if (!finished2)
            {
                if (current2.next is not null)
                {
                    current2 = current2.next;
                }
                else
                {
                    finished2 = true;
                }
            }


            if (finished1 && finished2)
            {
                if (incNext is 1)
                    currentNode.next = new ListNode(1); 
                break;
            }
        }

        return resultNode!;
    }
}