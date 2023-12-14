namespace Increasing_Order_Search_Tree;

internal sealed class Solution3
{
    private Queue<TreeNode> _nodes;
    
    public TreeNode IncreasingBST(TreeNode root)
    {
        _nodes = new Queue<TreeNode>();
        
        VisitNode(root);

        var head = _nodes.Dequeue();
        head.left = null;
        
        var current = head;

        while (true)
        {
            if (_nodes.Count is 0)
                return head;

            var next = _nodes.Dequeue();
            current.right = next;
            next.left = null;

            current = next;
        }
    }

    private void VisitNode(TreeNode node)
    {
        if (node.left is not null)
            VisitNode(node.left);
        
        _nodes.Enqueue(node);
        
        if (node.right is not null)
            VisitNode(node.right);
    }
}