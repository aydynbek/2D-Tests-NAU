using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Accord.Math;
using Accord.Math.Geometry;
using Accord;
using System.Windows;

namespace PathfindingTesting
{
    class PathfindingGeneralClass
    {
        public List<Vertex> listOfAllVerticees = new List<Vertex>();
        public List<Edge> listOfAllEdges = new List<Edge>();

        private int multiplier = 25;

        public PathfindingGeneralClass()
        {
        }
        
        public void addDefaultVerticees()
        {
            listOfAllVerticees.Add(new Vertex(1, 2, 3));
        }

        public void addDefaultEdges()
        {
            int width = -3;

            listOfAllEdges.Add(new Edge(new Vertex(0, 0, 0), new Vertex(6, 8, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(6, 8, 0), new Vertex(12, 7, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(12, 7, 0), new Vertex(14, 9, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(14, 9, 0), new Vertex(20, 13, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(20, 13, 0), new Vertex(23, 8, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(23, 8, 0), new Vertex(26, 13, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(26, 13, 0), new Vertex(30, 14, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(30, 14, 0), new Vertex(33, 16, 0)));

            listOfAllEdges.Add(new Edge(new Vertex(33, 16, 0), new Vertex(40, 0, 0)));

            listOfAllEdges.Add(new Edge(new Vertex(0, 0 - width, 0), new Vertex(6, 8 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(6, 8 - width, 0), new Vertex(12, 7 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(12, 7 - width, 0), new Vertex(14, 9 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(14, 9 - width, 0), new Vertex(20, 13 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(20, 13 - width, 0), new Vertex(23, 11 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(23, 11 - width, 0), new Vertex(26, 13 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(26, 13 - width, 0), new Vertex(30, 14 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(30, 14 - width, 0), new Vertex(33, 16 - width, 0)));
            listOfAllEdges.Add(new Edge(new Vertex(33, 16 - width, 0), new Vertex(50, 100 - width, 0)));
        }

        public void drawLine(float x1, float y1, float x2, float y2, Brush outer, Brush inner)
        {
            System.Windows.Shapes.Line objLine = new System.Windows.Shapes.Line();

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
            MainWindow.mainGrid.Children.Add(objLine);
            //</ show in maingrid > 
        }

        public void CreateAPolygon(float x, float y)
        {
            // Create a blue and a black Brush
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            // Create a Polygon
            System.Windows.Shapes.Polygon yellowPolygon = new System.Windows.Shapes.Polygon();
            yellowPolygon.Stroke = blackBrush;
            yellowPolygon.Fill = yellowBrush;
            yellowPolygon.StrokeThickness = 1;

            int ammount = 5;

            // Create a collection of points for a polygon
            System.Windows.Point Point1 = new System.Windows.Point(x - ammount, y - ammount);
            System.Windows.Point Point2 = new System.Windows.Point(x - ammount, y + ammount);
            System.Windows.Point Point3 = new System.Windows.Point(x + ammount, y - ammount);
            System.Windows.Point Point4 = new System.Windows.Point(x + ammount, y + ammount);
            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(Point1);
            polygonPoints.Add(Point2);
            polygonPoints.Add(Point3);
            polygonPoints.Add(Point4);

            // Set Polygon.Points properties
            yellowPolygon.Points = polygonPoints;

            // Add Polygon to the page
            MainWindow.mainGrid.Children.Add(yellowPolygon);
        }

        public void drawXMark(float x1, float y1, float x2, float y2, Brush outer, Brush inner)
        {
            System.Windows.Shapes.Polygon poly = new System.Windows.Shapes.Polygon();
        }

        public List<Edge> getListOfAllIntersections(Edge edgeToIntersect)
        {
            List<Edge> returnList = new List<Edge>();
            float x = 0.0f, y = 0.0f;

            drawLine((multiplier * edgeToIntersect.positionBeginning[0]), (multiplier * edgeToIntersect.positionBeginning[1]),
                                    (multiplier * edgeToIntersect.positionEnd[0]), (multiplier * edgeToIntersect.positionEnd[1]),
                                    Brushes.Blue, Brushes.Blue);

            foreach (Edge edgeIterated in listOfAllEdges)
            {
                drawLine((multiplier * edgeIterated.positionBeginning[0]), (multiplier * edgeIterated.positionBeginning[1]),
                                    (multiplier * edgeIterated.positionEnd[0]), (multiplier * edgeIterated.positionEnd[1]),
                                    Brushes.Red, Brushes.Red);
                if (doEdgesIntersect(edgeToIntersect, edgeIterated, ref x, ref y))
                {
                    CreateAPolygon(multiplier * x, multiplier * y);
                    returnList.Add(edgeIterated);
                }
            }

            return returnList;
        }

        public bool doEdgesIntersect(Edge edge1, Edge edge2, ref float x, ref float y)
        {
            Line line1 = Line.FromPoints(new Accord.Point(edge1.positionBeginning[0], edge1.positionBeginning[1]),
                new Accord.Point(edge1.positionEnd[0], edge1.positionEnd[1]));

            Line line2 = Line.FromPoints(new Accord.Point(edge2.positionBeginning[0], edge2.positionBeginning[1]),
                new Accord.Point(edge2.positionEnd[0], edge2.positionEnd[1]));
            
            float[,] matrix =
            {
                { -1 * line1.Slope, 1},
                { -1 * line2.Slope, 1},
            };

            // Define a right side matrix b:
            float[,] rightSide = { { line1.Intercept }, { line2.Intercept } };

            float[,] xx = matrix.Solve(rightSide, leastSquares: true);
            Accord.Point possibleIntersection = new Accord.Point(xx[0, 0], xx[1, 0]);
            x = xx[0, 0];
            y = xx[1, 0];

            System.Diagnostics.Debug.WriteLine(xx[0, 0] + "," + xx[1, 0]);

            if (isPointWithinEdge(possibleIntersection, edge1) && isPointWithinEdge(possibleIntersection, edge2))
            {
                System.Diagnostics.Debug.WriteLine("Intersected");
                return true;
            } else
            {
                System.Diagnostics.Debug.WriteLine("Not Intersected");
                return false;
            }
            
        }

        private bool isPointWithinEdge(Accord.Point point1, Edge edge1)
        {
            if ((point1.X > edge1.positionBeginning[0] && point1.X < edge1.positionEnd[0]) 
                || (point1.X < edge1.positionBeginning[0] && point1.X > edge1.positionEnd[0]))
            {
                if ((point1.Y > edge1.positionBeginning[1] && point1.Y < edge1.positionEnd[1])
                    || (point1.Y < edge1.positionBeginning[1] && point1.Y > edge1.positionEnd[1]))
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }



    }
    
    class Vertex
    {
        public float[] position = new float[3];
        public List<Vertex> vertexList = new List<Vertex>();
        public List<Edge> edgeList = new List<Edge>();
        bool isObstacle = true;

        public Vertex(float x, float y, float z)
        {
            position[0] = x;
            position[1] = y;
            position[2] = z;
        }
    }

    class Edge
    {
        public float[] positionBeginning = new float[3];
        public float[] positionEnd = new float[3];

        public Edge(Vertex vertex1, Vertex vertex2)
        {
            positionBeginning = vertex1.position;
            positionEnd = vertex2.position;
        }
    }
}
