using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using SelfBalancedTree;
using TreeNode = SelfBalancedTree.TreeNode;
using Point = System.Windows.Point;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private Point rootCoord;
        private TreeNode sbt = new TreeNode(2, null, null); 

        public MainWindow()
        {
            InitializeComponent();
            rootCoord = new Point(MyCanvas.Width / 2, circleRadius);
            DrawTree(sbt, rootCoord);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            var value = Convert.ToDouble(valueTextBox.Text == "" ? null : valueTextBox.Text);
            if (value != 0)
            {
                sbt = SBT_Actions.Insert(sbt, value);
            }
            MyCanvas.Children.Clear();
            DrawTree(sbt, rootCoord);
        }

        private const double circleRadius = 20.0;
        private const double initialNodesDistanceX = 10 * circleRadius;
        private const double initialNodesDistanceY = 2.5 * circleRadius;
        private void DrawCircle(Point coords)
        {
            var circle = new Ellipse();
            circle.Height = 2 * circleRadius;
            circle.Width = circle.Height;
            circle.Stroke = System.Windows.Media.Brushes.Black;
            MyCanvas.Children.Add(circle);
            Canvas.SetLeft(circle, coords.X - circleRadius);
            Canvas.SetTop(circle, coords.Y - circleRadius);
        }

        private void DrawLabel(string value, Point coords)
        {
            var label = new System.Windows.Controls.Label();
            label.Content = value;
            MyCanvas.Children.Add(label);
            Canvas.SetLeft(label, coords.X - circleRadius / 2);
            Canvas.SetTop(label, coords.Y - circleRadius / 2);
        }

        private void DrawLine(Point point1, Point point2)
        {
            var line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Black;
            line.X1 = point1.X;
            line.Y1 = point1.Y;
            line.X2 = point2.X;
            line.Y2 = point2.Y;
            MyCanvas.Children.Add(line);
        }

        private void DrawTree(TreeNode node, Point nodeCoords)
        {
            if (node != null)
            {
                DrawCircle(nodeCoords);
                DrawLabel(node.value.ToString(), nodeCoords);
                var spreadingFactor = rootCoord.Y / nodeCoords.Y;
                var nodeDeltaX = initialNodesDistanceX * spreadingFactor;
                var nodeDeltaY = initialNodesDistanceY;
                var nodesDistance = Math.Sqrt(nodeDeltaX * nodeDeltaX + nodeDeltaY * nodeDeltaY);
                var lineDeltaX = circleRadius * nodeDeltaX / nodesDistance;
                var lineDeltaY = circleRadius * nodeDeltaY / nodesDistance;
                if (node.left != null)
                {
                    var leftNodeX = nodeCoords.X - nodeDeltaX;
                    var leftNodeY = nodeCoords.Y + nodeDeltaY;
                    DrawLine(
                        new Point(nodeCoords.X - lineDeltaX, nodeCoords.Y + lineDeltaY),
                        new Point(leftNodeX + lineDeltaX, leftNodeY - lineDeltaY)
                    );
                    DrawTree(node.left, new Point(leftNodeX, leftNodeY));
                }
                if (node.right != null)
                {
                    var rightNodeX = nodeCoords.X + nodeDeltaX;
                    var rightNodeY = nodeCoords.Y + initialNodesDistanceY;
                    DrawLine(
                        new Point(nodeCoords.X + lineDeltaX, nodeCoords.Y + lineDeltaY),
                        new Point(rightNodeX - lineDeltaX, rightNodeY - lineDeltaY)
                    );
                    DrawTree(node.right, new Point(rightNodeX, rightNodeY));
                }
            }

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
            sbt = new TreeNode(1, null, null);
        }
    }
}
