namespace Increasing_Order_Search_Tree;

internal sealed class Solution2
{
    public TreeNode IncreasingBST(TreeNode root)
    {
        if (root.left is null && root.right is null)
            return root;

        var dq = new Deque(root);

        if (root.left is not null)
        {
            VisitReverse(root.left, dq);
            root.left = null;
        }
            

        if (root.right is not null)
            Visit(root.right, dq);

        return dq.Head;
    }
    
    private void VisitReverse(TreeNode node, Deque deque)
    {
        if (node.right is not null)
            VisitReverse(node.right, deque);
        
        deque.AddHead(node);

        if (node.left is not null)
        {
            VisitReverse(node.left, deque);
            node.left = null;
        }
    }

    private void Visit(TreeNode node, Deque deque)
    {
        if (node.left is not null)
        {
            Visit(node.left, deque);
            node.left = null;
        }
        
        deque.AddTail(node);
        
        if (node.right is not null)
            Visit(node.right, deque);
    }

    private sealed class Deque
    {
        public TreeNode Head { get; private set; }
        public TreeNode Tail { get; private set; }

        public Deque(TreeNode root)
        {
            Head = Tail = root;
        }

        public void AddHead(TreeNode node)
        {
            node.right = Head;
            Head = node;
        }
        
        public void AddTail(TreeNode node)
        {
            Tail.right = node;
            Tail = node;
        }
    }
    
}