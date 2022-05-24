namespace SelfBalancedTree.Tests;
using SelfBalancedTree;

public class SelfBalancedTree_Balance
{

    private TreeNode? sbt = null;

    // [Fact]
    // public void Heght_Should_Be_Three()
    // {
    //     var leftLeft = new TreeNode(-1, null, null);
    //     var left = new TreeNode(0, leftLeft, null);
    //     var root = new TreeNode(1, left, null);
    //     Assert.True(root.height == 3);
    // }

    [Fact]
    public void Should_Be_Balanced()
    {
        var leftLeft = new TreeNode(-1, null, null);
        var left = new TreeNode(0, leftLeft, null);
        var root = new TreeNode(1, left, null);
        TreeNode.balance(ref root);
        Action<TreeNode?> checkBalancedFactor = null;
        checkBalancedFactor = (TreeNode? node) =>
        {
            if (node != null)
            {
                Assert.True(Math.Abs(node.balanceFactor) < 2, "Node " + node.value.ToString() + " with balanced factor: " + node.balanceFactor.ToString());
                checkBalancedFactor!(node.left);
                checkBalancedFactor(node.right);
            }
        };
        checkBalancedFactor(root);
    }


    [Fact]
    public void Balanced_Factor_Should_Be_Minus_Two()
    {
        var rightRight = new TreeNode(1, null, null);
        var right = new TreeNode(0, null, rightRight);
        var root = new TreeNode(-1, null, right);
        Assert.True(root.balanceFactor == -2);
    }


}