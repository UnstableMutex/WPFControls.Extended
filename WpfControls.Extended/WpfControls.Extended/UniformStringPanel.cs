using System.Windows;
using System.Windows.Controls;
namespace WpfControls_Extended
{
   public class UniformStringPanel : Panel
    {
       public UniformStringPanel()
       {
           HorizontalAlignment= HorizontalAlignment.Stretch;
       }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var widthdeled = finalSize.Width / InternalChildren.Count;
            var curpoint=new Point(0,0);
            foreach (UIElement element in InternalChildren)
            {
                var bounds = new Rect( curpoint, new Size(widthdeled, finalSize.Height));
                curpoint.X += widthdeled;
                element.Arrange(bounds);
            }
            return finalSize;
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            double maxH=0;
            double maxw = 0;
            foreach (UIElement element in InternalChildren)
            {
                element.Measure(availableSize);
                var ds = element.DesiredSize;
                if (ds.Height > maxH)
                {
                    maxH = ds.Height;
                }
                maxw += ds.Width;
            }
            return new Size(maxw,maxH);
        }
    }
}
