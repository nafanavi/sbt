namespace SelfBalancedTree.Tests;
using SelfBalancedTree;

public class SelfBalancedTree_Balanced_Factor
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
    public void Balanced_Factor_Should_Be_Two()
    {
        var leftLeft = new TreeNode(-1, null, null);
        var left = new TreeNode(0, leftLeft, null);
        var root = new TreeNode(1, left, null);
        Assert.True(root.balanceFactor == 2);
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