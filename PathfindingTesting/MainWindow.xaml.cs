using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accord.Math;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using Accord.Statistics;
using Accord.Controls;

namespace PathfindingTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Grid mainGrid;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainGrid = MainGrid;
            /*
            double[,] matrix =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };

            // Define a right side matrix b:
            double[,] rightSide = { { 1 }, { 2 }, { 3 } };

            double[,] x = matrix.Solve(rightSide, leastSquares: true);
            System.Diagnostics.Debug.WriteLine(x[0, 0] + "," + x[1, 0] + "," + x[2, 0]);
            */

            PathfindingGeneralClass pathfinding = new PathfindingGeneralClass();

            Edge edge1 = new Edge(new Vertex(1,1,0), new Vertex(6,8,0));
            Edge edge2 = new Edge(new Vertex(1,4,0), new Vertex(2.5f,3.5f,0));

            pathfinding.addDefaultEdges();
            pathfinding.getListOfAllIntersections(new Edge(new Vertex(0, 1, 0), new Vertex(40, 30, 0)));
        }

        private void drawOnGrid()
        {
            drawLine(10, 50, 300, 250, Brushes.Red, Brushes.Red);
        }

        public void drawLine(int x1, int y1, int x2, int y2, Brush outer, Brush inner)
        {
            Line objLine = new Line();

            objLine.Stroke = outer;
            objLine.Fill = inner;
            //objLine.Width = 1;

            //< Start-Point > 
            objLine.X1 = x1;
            objLine.Y1 = y1;
            //</ Start-Point > 

            //< End-Point > 
            objLine.X2 = x2;
            objLine.Y2 = y2;
            //</ End-Point > 

            //< show in maingrid > 
            MainGrid.Children.Add(objLine);
            //</ show in maingrid > 
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
