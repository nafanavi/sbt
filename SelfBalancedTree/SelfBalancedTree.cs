namespace SelfBalancedTree
{
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
        private int height { get { return Math.Max(this.left == null ? 0 : this.left.height + 1, this.right == null ? 0 : this.right.height + 1); } }

        private int balancedFactor { get { return (this.left?.height ?? 0) - (this.right?.height ?? 0); } }

        public static void balance(ref TreeNode node)
        {
            if (node.balancedFactor < -1)
            {
                rotateRight(ref node);
            }
            if (node.balancedFactor > 1)
            {
                rotateLeft(ref node);
            }
        }

        public void checkBalancedFactorAndBalance()
        {

        }

        public void insert(int value)
        {
            if (value > this.value)
            {
                if (this.right != null)
                {
                    this.right.insert(value);
                }
                else
                {
                    this.right = new TreeNode(value, null, null);
                }

            }
            else
            {
                if (this.left != null)
                {
                    this.left.insert(value);
                }
                else
                {
                    this.left = new TreeNode(value, null, null);
                }
            }
        }

        public void insert(TreeNode node)
        {
            if (node.value > this.value)
            {
                if (this.right != null)
                {
                    this.right.insert(node);
                }
                else
                {
                    this.right = node;
                }

            }
            else
            {
                if (this.left != null)
                {
                    this.left.insert(node);
                }
                else
                {
                    this.left = node;
                }
            }
        }

        public static void rotateRight(ref TreeNode root)
        {
            var buff = root;
            root = buff.left!;
            buff.left = null;
            root!.right = buff;
        }

        public static void rotateLeft(ref TreeNode root)
        {
            var buff = root;
            root = buff.right!;
            buff.right = null;
            root!.left = buff;
        }

    }

}