// See https://aka.ms/new-console-template for more information

using Increasing_Order_Search_Tree;

var tree = new TreeNode(
    4,
    new TreeNode(2,
        new TreeNode(1),
        new TreeNode(3)),
    new TreeNode(6,
        new TreeNode(5),
        new TreeNode(7)));

var sln = new Solution3();
var head = sln.IncreasingBST(tree);

Console.WriteLine(head.val);