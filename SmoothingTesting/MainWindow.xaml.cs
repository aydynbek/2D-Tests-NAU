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

namespace PathfindingTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Grid mainGrid;
        private int multiplier = 20;
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

            Edge edge1 = new Edge(new Vertex(1, 1, 0), new Vertex(6, 8, 0));
            Edge edge2 = new Edge(new Vertex(1, 4, 0), new Vertex(2.5f, 3.5f, 0));

            List<Vertex> originalVerticees = new List<Vertex>();
            List<Vertex> smoothedVerticees = new List<Vertex>();
            originalVerticees.Add(new Vertex(1, 1, 0));
            originalVerticees.Add(new Vertex(3, 1, 0));
            originalVerticees.Add(new Vertex(5, 5, 0));
            originalVerticees.Add(new Vertex(6, 7, 0));
            originalVerticees.Add(new Vertex(7, 11, 0));
            originalVerticees.Add(new Vertex(8, 10, 0));
            originalVerticees.Add(new Vertex(11, 15, 0));
            originalVerticees.Add(new Vertex(14, 12, 0));
            originalVerticees.Add(new Vertex(15, 15, 0));
            originalVerticees.Add(new Vertex(17, 13, 0));
            originalVerticees.Add(new Vertex(19, 14, 0));
            originalVerticees.Add(new Vertex(21, 20, 0));
            originalVerticees.Add(new Vertex(23, 26, 0));
            originalVerticees.Add(new Vertex(25, 24, 0));
            originalVerticees.Add(new Vertex(26, 27, 0));
            originalVerticees.Add(new Vertex(27, 32, 0));
            originalVerticees.Add(new Vertex(30, 33, 0));
            originalVerticees.Add(new Vertex(32, 34, 0));
            originalVerticees.Add(new Vertex(33, 37, 0));
            originalVerticees.Add(new Vertex(36, 37, 0));
            originalVerticees.Add(new Vertex(38, 35, 0));
            originalVerticees.Add(new Vertex(39, 30, 0));
            originalVerticees.Add(new Vertex(42, 33, 0));
            originalVerticees.Add(new Vertex(43, 29, 0));
            originalVerticees.Add(new Vertex(45, 24, 0));
            originalVerticees.Add(new Vertex(47, 26, 0));
            originalVerticees.Add(new Vertex(49, 20, 0));
            originalVerticees.Add(new Vertex(50, 15, 0));
            originalVerticees.Add(new Vertex(53, 11, 0));
            originalVerticees.Add(new Vertex(55, 13, 0));
            originalVerticees.Add(new Vertex(57, 14, 0));
            originalVerticees.Add(new Vertex(60, 12, 0));
            originalVerticees.Add(new Vertex(62, 8, 0));
            originalVerticees.Add(new Vertex(64, 5, 0));
            originalVerticees.Add(new Vertex(66, 2, 0));

            Vertex[] vertArr = originalVerticees.ToArray();
            int i = 0;
            float xx, yy;

            for(i = 0; i < originalVerticees.Count; i++)
            {
                pathfinding.CreateAPolygon(multiplier * vertArr[i].position[0], multiplier * vertArr[i].position[1]);

                if (i > 0 && i < (originalVerticees.Count - 1))
                {
                    xx = (vertArr[i - 1].position[0] + vertArr[i].position[0] + vertArr[i + 1].position[0]) / 3;
                    yy = (vertArr[i - 1].position[1] + (vertArr[i].position[1] * 0.0f) + vertArr[i + 1].position[1]) / 2;
                    
                    //pathfinding.CreateABluePolygon(multiplier * (vertArr[i].position[0]), multiplier * (yy));
                }

                if (i > 1 && i < (originalVerticees.Count - 2))
                {
                    yy = (vertArr[i - 2].position[1] + vertArr[i - 1].position[1] + vertArr[i + 1].position[1] + vertArr[i + 2].position[1]) / 4;

                    pathfinding.CreateARedPolygon(multiplier * (vertArr[i].position[0]), multiplier * (yy));
                }
            }
            
            /*
            pathfinding.CreateAPolygon(multiplier * 1, multiplier * 1);
            pathfinding.CreateAPolygon(multiplier * 5, multiplier * 5);
            pathfinding.CreateAPolygon(multiplier * 8, multiplier * 10);
            pathfinding.CreateAPolygon(multiplier * 14, multiplier * 12);
            pathfinding.CreateAPolygon(multiplier * 19, multiplier * 14);
            pathfinding.CreateAPolygon(multiplier * 21, multiplier * 20);
            pathfinding.CreateAPolygon(multiplier * 26, multiplier * 27);
            pathfinding.CreateAPolygon(multiplier * 30, multiplier * 33);
            pathfinding.CreateAPolygon(multiplier * 36, multiplier * 37);
            pathfinding.CreateAPolygon(multiplier * 39, multiplier * 30);
            pathfinding.CreateAPolygon(multiplier * 44, multiplier * 22);
            pathfinding.CreateAPolygon(multiplier * 50, multiplier * 15);
            pathfinding.CreateAPolygon(multiplier * 53, multiplier * 11);
            pathfinding.CreateAPolygon(multiplier * 60, multiplier * 13);
            pathfinding.CreateAPolygon(multiplier * 62, multiplier * 8);
            pathfinding.CreateAPolygon(multiplier * 66, multiplier * 2);
            */

            //pathfinding.addDefaultEdges();
            //pathfinding.getListOfAllIntersections(new Edge(new Vertex(0, 1, 0), new Vertex(40, 30, 0)));
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
