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
        public int height { get { return Math.Max(this.left == null ? 1 : this.left.height + 1, this.right == null ? 1 : this.right.height + 1); } }

        public int balanceFactor { get { return (this.left?.height ?? 0) - (this.right?.height ?? 0); } }

        public static void balance(ref TreeNode node)
        {
            if (node.balanceFactor < -1)
            {
                if (node.right!.balanceFactor > 1)
                {
                    rotateRightLeft(ref node);
                }
                else
                {
                    rotateLeft(ref node);
                }
            }
            if (node.balanceFactor > 1)
                if (node.left!.balanceFactor < -1)
                {
                    rotateLeftRight(ref node);
                }
                else
                {
                    rotateRight(ref node);
                }
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
            buff.left = root.right;
            root!.right = buff;
        }

        public static void rotateLeft(ref TreeNode root)
        {
            var buff = root;
            root = buff.right!;
            buff.right = root.left;
            root!.left = buff;
        }

        public void rotateLeft()
        {
            // var buff = this;
            // this = buff.right!;
            // buff.right = root.left;
            // root!.left = buff;
        }

        public static void rotateRightLeft(ref TreeNode root)
        {
            rotateRight(ref root.right!);
            rotateLeft(ref root);
        }

        public static void rotateLeftRight(ref TreeNode root)
        {
            rotateLeft(ref root.left!);
            rotateRight(ref root);
        }


    }

}