using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace WpfControls_Extended
{
   public class TriangleDecorator : Decorator
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            base.OnRender(drawingContext);
            var ps = new PathSegment[] { new LineSegment(new Point(LegLength, 0), true), new LineSegment(new Point(0, LegLength), true) };
            PathFigure pf = new PathFigure(new Point(0, 0), ps, true);
            PathGeometry pg = new PathGeometry(new List<PathFigure>() { pf });
            var b = new SolidColorBrush(Background);
            drawingContext.DrawGeometry(b, new Pen(b, 1), pg);
        }
        public int LegLength
        {
            get { return (int)GetValue(LegLengthProperty); }
            set { SetValue(LegLengthProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LegLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegLengthProperty =
            DependencyProperty.Register("LegLength", typeof(int), typeof(TriangleDecorator), new PropertyMetadata(5));
        public Color Background
        {
            get { return (Color)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Color), typeof(TriangleDecorator), new PropertyMetadata(Colors.Red));
    }
}
