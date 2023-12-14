namespace Increasing_Order_Search_Tree;

internal sealed class Solution
{
    
    public TreeNode IncreasingBST(TreeNode root)
    {
        var finalNode = VisitNode(root);
        return finalNode.head;
    }

    //slow and memory efficient.
    private (TreeNode head, TreeNode tail) VisitNode(TreeNode node)
    {
        if (node.left is null && node.right is null)
        {
            return (node, node);
        }

        var left = node.left is not null ? VisitNode(node.left) : (null, null);
        var right = node.right is not null ? VisitNode(node.right) : (null, null);

        TreeNode head;

        if (left.head is not null)
        {
            left.tail!.right = node;
            node.left = null;
            head = left.head;
        }
        else
        {
            head = node;
        }

        if (right.head is null) 
            return (head, node);
        
        node.right = right.head;

        return (head, right.tail!);
    }
}

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}