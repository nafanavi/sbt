namespace SelfBalancedTree
{

    public static class SBT_Actions
    {
        public static TreeNode Balance(TreeNode node)
        {
            if (node.balanceFactor <= -2)
            {
                if (node.right!.balanceFactor >= 1)
                {
                    return RotateRightLeft(node);
                }
                else
                {
                    return RotateLeft(node);
                }
            }
            if (node.balanceFactor >= 2)
            {
                if (node.left!.balanceFactor <= -1)
                {
                    return RotateLeftRight(node);
                }
                else
                {
                    return RotateRight(node);
                }
            }
            return node;
        }

        public static TreeNode Insert(TreeNode root, double value)
        {
            if (value > root.value)
            {
                if (root.right != null)
                {
                    root.right = Insert(root.right, value);
                }
                else
                {
                    root.right = new TreeNode(value, null, null);
                }

            }
            else
            {
                if (root.left != null)
                {
                    root.left = Insert(root.left, value);
                }
                else
                {
                    root.left = new TreeNode(value, null, null);
                }
            }
            return Balance(root);
        }

        public static TreeNode Insert(TreeNode root, TreeNode newNode)
        {
            if (newNode.value > root.value)
            {
                if (root.right != null)
                {
                    root.right = Insert(root.right, newNode);
                }
                else
                {
                    root.right = newNode;
                }

            }
            else
            {
                if (root.left != null)
                {
                    root.left = Insert(root.left, newNode);
                }
                else
                {
                    root.left = newNode;
                }
            }
            return Balance(root);
        }

        public static TreeNode RotateRight(TreeNode node)
        {
            var buff = node;
            node = buff.left!;
            buff.left = node.right;
            node!.right = buff;
            return node;
        }

        public static TreeNode RotateLeft(TreeNode node)
        {
            var buff = node;
            node = buff.right!;
            buff.right = node.left;
            node!.left = buff;
            return node;
        }

        public static TreeNode RotateRightLeft(TreeNode node)
        {
            node.right = RotateRight(node.right!);
            return RotateLeft(node);
        }

        public static TreeNode RotateLeftRight(TreeNode node)
        {
            node.left = RotateLeft(node.left!);
            return RotateRight(node);
        }
    }
    public class TreeNode
    {
        public TreeNode(double value, TreeNode? left, TreeNode? right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public double value;
        public TreeNode? left;
        public TreeNode? right;
        public int height { get { return Math.Max(this.left == null ? 1 : this.left.height + 1, this.right == null ? 1 : this.right.height + 1); } }

        public int balanceFactor { get { return (this.left?.height ?? 0) - (this.right?.height ?? 0); } }




    }

}