namespace SelfBalancedTree.Tests;
using SelfBalancedTree;

public class SelfBalancedTree_Intalization
{
    [Theory]
    [InlineData(1)]
    public void Intilize_SBT_root(int val)
    {
        var sbt = new TreeNode(val, null, null);
        Assert.True(sbt.value == val);
        Assert.True(sbt.left == null);
        Assert.True(sbt.right == null);
    }

    [Theory]
    [InlineData(1, 0, 1)]
    public void Intilize_SBT_With_Leafs(int rootVal, int leftVal, int rightVal)
    {
        var left = new TreeNode(leftVal, null, null);
        var right = new TreeNode(rightVal, null, null);
        var root = new TreeNode(rootVal, left, right);
        Assert.True(root.value == rootVal);
        Assert.True(root.left?.value == leftVal);
        Assert.True(root.right?.value == rightVal);
    }

}