namespace SelfBalancedTree.Tests;
using SelfBalancedTree;

public class SelfBalancedTree_Insertion
{

    private TreeNode? sbt = null;


    [Theory]
    [InlineData(1)]
    public void Inserted_Node_Into_Bare_Tree_Should_Be_Rigth(int nodeVal)
    {
        var root = new TreeNode(nodeVal - 1, null, null);
        var node = new TreeNode(nodeVal, null, null);
        root = SBT_Actions.Insert(root, node);
        Assert.True(root.right == node);
        Assert.True(root.left == null);
    }

    [Theory]
    [InlineData(1)]
    public void Inserted_Node_Into_Bare_Tree_Should_Be_Left(int nodeVal)
    {
        var root = new TreeNode(nodeVal + 1, null, null);
        var node = new TreeNode(nodeVal, null, null);
        root = SBT_Actions.Insert(root, node);
        Assert.True(root.left == node);
        Assert.True(root.right == null);
    }

    [Theory]
    [InlineData(1)]
    public void Inserted_Node_Should_Be_Left(int nodeVal)
    {
        var left = new TreeNode(nodeVal + 1, null, null);
        var right = new TreeNode(nodeVal + 3, null, null);
        var root = new TreeNode(nodeVal + 2, left, right);
        var node = new TreeNode(nodeVal, null, null);
        root = SBT_Actions.Insert(root, node);
        Assert.True(root.left?.left == node);
        Assert.True(root.right?.right == null);
    }

    [Theory]
    [InlineData(1)]
    public void Inserted_Node_Should_Be_Right(int nodeVal)
    {
        var left = new TreeNode(nodeVal - 3, null, null);
        var right = new TreeNode(nodeVal - 1, null, null);
        var root = new TreeNode(nodeVal - 2, left, right);
        var node = new TreeNode(nodeVal, null, null);
        root = SBT_Actions.Insert(root, node);
        Assert.True(root.left?.left == null);
        Assert.True(root.right?.right == node);
    }

    [Fact]
    public void Should_Be_Balanced_After_Insertion()
    {
        var root = new TreeNode(-1, null, null);
        root = SBT_Actions.Insert(root, 2);
        root = SBT_Actions.Insert(root, 3);
        Assert.True(root.left?.value == -1);
        Assert.True(root.value == 2);
        Assert.True(root.right?.value == 3);
    }

    // [Fact]
    // public void Should_Be_Balanced_After_Insertion()
    // {
    //     var rightRight = new TreeNode(1, null, null);
    //     var right = new TreeNode(0, null, rightRight);
    //     var root = new TreeNode(-1, null, right);
    //     root = SBT_Actions.Insert(root, right);
    //     Assert.True(root.left?.value == -1);
    //     Assert.True(root.value == 0);
    //     Assert.True(root.right?.value == 1);
    // }
}
