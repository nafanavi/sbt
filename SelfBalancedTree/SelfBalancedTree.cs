namespace SelfBalancedTree
{

    public class SBT_Actions
    {
        public TreeNode balance(TreeNode node)
        {
            if (node.balanceFactor < -1)
            {
                if (node.right!.balanceFactor > 1)
                {
                    return rotateRightLeft(node);
                }
                else
                {
                    return rotateLeft(node);
                }
            }
            if (node.balanceFactor > 1)
            {
                if (node.left!.balanceFactor < -1)
                {
                    return rotateLeftRight(node);
                }
                else
                {
                    return rotateRight(node);
                }
            }
            return node;
        }

        public TreeNode insert(TreeNode root, int value)
        {
            if (value > root.value)
            {
                if (root.right != null)
                {
                    root.right = insert(root.right, value);
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
                    root.left = insert(root.left, value);
                }
                else
                {
                    root.left = new TreeNode(value, null, null);
                }
            }
            return root;
        }

        public TreeNode insert(TreeNode root, TreeNode newNode)
        {
            if (newNode.value > root.value)
            {
                if (root.right != null)
                {
                    root.right = insert(root.right, newNode);
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
                    root.left = insert(root.left, newNode);
                }
                else
                {
                    root.left = newNode;
                }
            }
            return balance(root);
        }

        public TreeNode rotateRight(TreeNode node)
        {
            var buff = node;
            node = buff.left!;
            buff.left = node.right;
            node!.right = buff;
            return node;
        }

        public TreeNode rotateLeft(TreeNode node)
        {
            var buff = node;
            node = buff.right!;
            buff.right = node.left;
            node!.left = buff;
            return node;
        }

        public TreeNode rotateRightLeft(TreeNode node)
        {
            node = rotateRight(node.right!);
            return rotateLeft(node);
        }

        public TreeNode rotateLeftRight(TreeNode node)
        {
            node = rotateLeft(node.left!);
            return rotateRight(node);
        }
    }
    public class TreeNode
    {
        public TreeNode(int value, TreeNode? left, TreeNode? right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public int value;
        public TreeNode? left;
        public TreeNode? right;
        public int height { get { return Math.Max(this.left == null ? 1 : this.left.height + 1, this.right == null ? 1 : this.right.height + 1); } }

        public int balanceFactor { get { return (this.left?.height ?? 0) - (this.right?.height ?? 0); } }




    }

}