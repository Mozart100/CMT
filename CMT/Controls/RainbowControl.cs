using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace CMT.Controls;

public class RainbowControl : Shape
{
    protected override Geometry DefiningGeometry
    {
        get { return GetRainbowGeometry(); }
    }

    public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double), typeof(RainbowControl),new FrameworkPropertyMetadata(0D, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty EndAngleProperty = DependencyProperty.Register("EndAngle", typeof(double), typeof(RainbowControl),new FrameworkPropertyMetadata(0D, FrameworkPropertyMetadataOptions.AffectsRender));

    public double StartAngle
    {
        get { return (double)GetValue(StartAngleProperty); }
        set { SetValue(StartAngleProperty, value); }
    }

    public double EndAngle
    {
        get { return (double)GetValue(EndAngleProperty); }
        set { SetValue(EndAngleProperty, value); }
    }

    private Geometry GetRainbowGeometry()
    {
        var startPoint = CalcAngle(Math.Min(StartAngle, EndAngle));
        var endPoint = CalcAngle(Math.Max(StartAngle, EndAngle));

        var arcSize = new Size(Math.Max(0, (RenderSize.Width - StrokeThickness) / 2), Math.Max(0, (RenderSize.Height - StrokeThickness) / 2));
        var isLargeArc = Math.Abs(EndAngle - StartAngle) > 180;

        var geometry = new StreamGeometry();
        using (StreamGeometryContext context = geometry.Open())
        {
            context.BeginFigure(startPoint, false, false);
            context.ArcTo(endPoint, arcSize, 0, isLargeArc, SweepDirection.Counterclockwise, true, false);
        }

        geometry.Transform = new TranslateTransform(StrokeThickness / 2, StrokeThickness / 2);
        return geometry;
    }

    private Point CalcAngle(double angle)
    {
        double radAngle = angle * (Math.PI / 180);

        double xRadius = (RenderSize.Width - StrokeThickness) / 2;
        double yRadius = (RenderSize.Height - StrokeThickness) / 2;

        double x = xRadius + xRadius * Math.Cos(radAngle);
        double y = yRadius - yRadius * Math.Sin(radAngle);

        return new Point(x, y);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        Size size = base.MeasureOverride(availableSize);
        return size;
    }

    protected override Size ArrangeOverride(Size size)
    {
        base.ArrangeOverride(size);
        return size;
    }
}
