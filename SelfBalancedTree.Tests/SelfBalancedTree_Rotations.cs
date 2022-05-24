namespace SelfBalancedTree.Tests;
using SelfBalancedTree;

public class SelfBalancedTree_Rotations
{

    private TreeNode? sbt = null;

    [Fact]
    public void Check_Right_Rotation()
    {
        var leftLeft = new TreeNode(-1, null, null);
        var left = new TreeNode(0, leftLeft, null);
        var root = new TreeNode(1, left, null);
        TreeNode.rotateRight(ref root);
        Assert.True(root.left?.value == -1);
        Assert.True(root.value == 0);
        Assert.True(root.right?.value == 1);
    }

    [Fact]
    public void Check_Left_Rotation()
    {
        var rightRight = new TreeNode(1, null, null);
        var right = new TreeNode(0, null, rightRight);
        var root = new TreeNode(-1, null, right);
        TreeNode.rotateLeft(ref root);
        Assert.True(root.left?.value == -1);
        Assert.True(root.value == 0);
        Assert.True(root.right?.value == 1);
    }

    [Fact]
    public void Check_Right_Left_Rotation()
    {
        var rightLeft = new TreeNode(0, null, null);
        var right = new TreeNode(1, rightLeft, null);
        var root = new TreeNode(-1, null, right);
        TreeNode.rotateRightLeft(ref root);
        Assert.True(root.left?.value == -1);
        Assert.True(root.value == 0);
        Assert.True(root.right?.value == 1);
    }

    [Fact]
    public void Check_Left_Right_Rotation()
    {
        var leftRight = new TreeNode(0, null, null);
        var left = new TreeNode(-1, null, leftRight);
        var root = new TreeNode(1, left, null);
        TreeNode.rotateLeftRight(ref root);
        Assert.True(root.left?.value == -1);
        Assert.True(root.value == 0);
        Assert.True(root.right?.value == 1);
    }
}