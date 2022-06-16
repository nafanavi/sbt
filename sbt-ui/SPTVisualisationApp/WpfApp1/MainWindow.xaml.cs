using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using SelfBalancedTree;
using TreeNode = SelfBalancedTree.TreeNode;
using Point = System.Windows.Point;
using System.Windows.Input;
using System.Windows.Media;

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
        private void InitCircle(Point coords)
        {
            var circle = new Ellipse();
            MyCanvas.Children.Add(circle);
            circle.Height = 2 * circleRadius;
            circle.Width = circle.Height;
            circle.Stroke = System.Windows.Media.Brushes.Black;
            circle.Fill = System.Windows.Media.Brushes.Aqua;
            circle.MouseMove += new MouseEventHandler(CircleMoveHandler);
            SetCircleCoord(circle, coords);
        }
        private void CircleMoveHandler(object sender, MouseEventArgs e)
        {
            Ellipse circle = sender as Ellipse;
            if (circle != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var point = e.GetPosition(MyCanvas);
                SetCircleCoord(circle, point);
                //DragDrop.DoDragDrop(circle,
                //    circle.Fill.ToString(),
                //     DragDropEffects.Move);
            }
        }

        private void SetCircleCoord(Ellipse circle, Point coords)
        {
            Canvas.SetLeft(circle, coords.X - circleRadius);
            Canvas.SetTop(circle, coords.Y - circleRadius);
        }

        private void SetLabelCoords(Label label, Point coords)
        {
            Canvas.SetLeft(label, coords.X - circleRadius / 2);
            Canvas.SetTop(label, coords.Y - circleRadius / 2);
        }


        private void InitLabel(string value, Point coords)
        {
            var label = new Label();
            label.Content = value;
            MyCanvas.Children.Add(label);
            SetLabelCoords(label, coords);
        }

        private void InitLine(Point point1, Point point2)
        {
            var line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Black;
            SetLineCoords(line, point1, point2);
            MyCanvas.Children.Add(line);
        }


        private void SetLineCoords(Line line, Point point1, Point point2)
        {
            //MyCanvas.Children.Remove(line);
            line.X1 = point1.X;
            line.Y1 = point1.Y;
            line.X2 = point2.X;
            line.Y2 = point2.Y;
            //MyCanvas.Children.Add(line);
        }

        private void DrawTree(TreeNode node, Point nodeCoords)
        {
            if (node != null)
            {
                InitCircle(nodeCoords);
                InitLabel(node.value.ToString(), nodeCoords);
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
                    InitLine(
                        new Point(nodeCoords.X - lineDeltaX, nodeCoords.Y + lineDeltaY),
                        new Point(leftNodeX + lineDeltaX, leftNodeY - lineDeltaY)
                    );
                    DrawTree(node.left, new Point(leftNodeX, leftNodeY));
                }
                if (node.right != null)
                {
                    var rightNodeX = nodeCoords.X + nodeDeltaX;
                    var rightNodeY = nodeCoords.Y + initialNodesDistanceY;
                    InitLine(
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

        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(ellipse,
                                     ellipse.Fill.ToString(),
                                     DragDropEffects.Copy);
            }
        }


        private void ellipse_MouseMove_Test(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(ellipse,
                                     ellipse.Fill.ToString(),
                                     DragDropEffects.Move);
            }
        }

        private Brush previousFill = null;
        //private void ellipse_DragEnter(object sender, DragEventArgs e)
        //{
        //    Ellipse ellipse = sender as Ellipse;
        //    if (ellipse != null)
        //    {
        //        // Save the current Fill brush so that you can revert back to this value in DragLeave.
        //        _previousFill = ellipse.Fill;

        //        // If the DataObject contains string data, extract it.
        //        if (e.Data.GetDataPresent(DataFormats.StringFormat))
        //        {
        //            string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

        //            // If the string can be converted into a Brush, convert it.
        //            BrushConverter converter = new BrushConverter();
        //            if (converter.IsValid(dataString))
        //            {
        //                Brush newFill = (Brush)converter.ConvertFromString(dataString);
        //                ellipse.Fill = newFill;
        //            }
        //        }
        //    }
        //}

        private void ellipse_DragOver(object sender, DragEventArgs e)
        {
            //e.Effects = DragDropEffects.None;
            var circle = e.Source as Ellipse;
            if (circle != null)
            {
                SetCircleCoord(circle, e.GetPosition(MyCanvas));
            }
            // If the DataObject contains string data, extract it.
            //if (e.Data.GetDataPresent(DataFormats.StringFormat))
            //{
            //    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

            //    // If the string can be converted into a Brush, allow copying.
            //    BrushConverter converter = new BrushConverter();
            //    if (converter.IsValid(dataString))
            //    {
            //        e.Effects = DragDropEffects.Copy | DragDropEffects.Move;
            //    }
            //}
        }

        //private void ellipse_DragLeave(object sender, DragEventArgs e)
        //{
        //    Ellipse ellipse = sender as Ellipse;
        //    if (ellipse != null)
        //    {
        //        ellipse.Fill = _previousFill;
        //    }
        //}

        //private void ellipse_Drop(object sender, DragEventArgs e)
        //{
        //    Ellipse ellipse = sender as Ellipse;
        //    if (ellipse != null)
        //    {
        //        // If the DataObject contains string data, extract it.
        //        if (e.Data.GetDataPresent(DataFormats.StringFormat))
        //        {
        //            string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

        //            // If the string can be converted into a Brush,
        //            // convert it and apply it to the ellipse.
        //            BrushConverter converter = new BrushConverter();
        //            if (converter.IsValid(dataString))
        //            {
        //                Brush newFill = (Brush)converter.ConvertFromString(dataString);
        //                ellipse.Fill = newFill;
        //            }
        //        }
        //    }
        //}

    }
}
