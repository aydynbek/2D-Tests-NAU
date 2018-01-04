using System;

public class GeneralAlgorithms
{
    private int multiplier = 25;

    public GeneralAlgorithms()
	{

	}

    public void drawYellowPoligon(float x, float y)
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

    public void drawGreenPoligon(float x, float y)
    {
        // Create a blue and a black Brush
        SolidColorBrush yellowBrush = new SolidColorBrush();
        yellowBrush.Color = Colors.Green;
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

}
