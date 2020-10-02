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
using System.Windows.Shapes;

namespace WpfLesson5
{
    public class MyPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = new Size();
            foreach (UIElement Child in InternalChildren)
            {
                Child.Measure(availableSize);
                size = Child.DesiredSize;
            }
            return size;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            double y = 0;
            //foreach (UIElement Child in InternalChildren)
            //{
            //    Child.Arrange(new Rect(new Point(x, y), Child.DesiredSize));
            //}
            for (int i=0;i<InternalChildren.Count;i++)
            {
                InternalChildren[i].Arrange(new Rect(new Point(x, y), InternalChildren[i].DesiredSize));
                x += InternalChildren[i].DesiredSize.Width;
                y += InternalChildren[i].DesiredSize.Height;
            }
            return finalSize;
        }

        public MyPanel() : base()
        {

        }
    }
}
