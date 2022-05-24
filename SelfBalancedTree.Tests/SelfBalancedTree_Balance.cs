namespace SelfBalancedTree.Tests;
using SelfBalancedTree;

public class SelfBalancedTree_Balance
{

    private TreeNode? sbt = null;

    private void CheckBalancedFactor(TreeNode? node)
    {
        if (node != null)
        {
            Assert.True(Math.Abs(node.balanceFactor) <= 1, "Node " + node.value.ToString() + " with balanced factor: " + node.balanceFactor.ToString());
            CheckBalancedFactor(node.left);
            CheckBalancedFactor(node.right);
        }
    }

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
        root = SBT_Actions.Balance(root);
        CheckBalancedFactor(root);
    }


    [Fact]
    public void Balanced_Factor_Should_Be_Minus_Two()
    {
        var rightRight = new TreeNode(1, null, null);
        var right = new TreeNode(0, null, rightRight);
        var root = new TreeNode(-1, null, right);
        Assert.True(root.balanceFactor == -2);
    }

    [Fact]
    public void Should_Be_Balanced_After_Insertions()
    {
        var leftLeft = new TreeNode(-1, null, null);
        var left = new TreeNode(0, leftLeft, null);
        var root = new TreeNode(1, left, null);
        root = SBT_Actions.Insert(root, -111);
        root = SBT_Actions.Insert(root, -112);
        root = SBT_Actions.Insert(root, -110);
        root = SBT_Actions.Insert(root, -111);
        root = SBT_Actions.Insert(root, -112);
        root = SBT_Actions.Insert(root, -110);
        root = SBT_Actions.Insert(root, 11);
        root = SBT_Actions.Insert(root, 12);
        root = SBT_Actions.Insert(root, 3);
        root = SBT_Actions.Insert(root, 100);
        root = SBT_Actions.Insert(root, 5);
        root = SBT_Actions.Insert(root, 4.5);
        root = SBT_Actions.Insert(root, 4);
        root = SBT_Actions.Insert(root, 4);
        root = SBT_Actions.Insert(root, 4);
        CheckBalancedFactor(root);
    }



}