using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MainProject.Controls
{
    public class WrapBreakPanel : Panel
    {


        // Using a DependencyProperty as the backing store for LineBreakBefore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineBreakBeforeProperty =
            DependencyProperty.RegisterAttached("LineBreakBefore", typeof(bool), typeof(WrapBreakPanel), new PropertyMetadata(0));

        public static void SetLineBreakBefore(UIElement element, Boolean value)
        {
            element.SetValue(LineBreakBeforeProperty, value);
        }
        public static Boolean GetLineBreakBefore(UIElement element)
        {
            return (bool)element.GetValue(LineBreakBeforeProperty);
        }


        static WrapBreakPanel()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.AffectsArrange = true;
            metadata.AffectsMeasure = true;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size currentLineSize = new Size();
            Size panelSize = new Size();
            foreach (UIElement element in base.InternalChildren)
            {
                element.Measure(constraint);
                Size desiredSize = element.DesiredSize;
                if (GetLineBreakBefore(element) ||
                currentLineSize.Width + desiredSize.Width > constraint.Width)
                {
                    // Switch to a new line (either because the element has requested it
                    // or space has run out).
                    panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
                    panelSize.Height += currentLineSize.Height;
                    currentLineSize = desiredSize;
                    // If the element is too wide to fit using the maximum width
                    // of the line, just give it a separate line.
                    if (desiredSize.Width > constraint.Width)
                    {
                        panelSize.Width = Math.Max(desiredSize.Width, panelSize.Width);
                        panelSize.Height += desiredSize.Height;
                        currentLineSize = new Size();
                    }
                }
                else
                {
                    // Keep adding to the current line.
                    currentLineSize.Width += desiredSize.Width;
                    // Make sure the line is as tall as its tallest element.
                    currentLineSize.Height = Math.Max(desiredSize.Height,
                    currentLineSize.Height);
                }
            }
            // Return the size required to fit all elements.
            // Ordinarily, this is the width of the constraint, and the height
            // is based on the size of the elements.
            // However, if an element is wider than the width given to the panel,
            // the desired width will be the width of that line.
            panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width);
            panelSize.Height += currentLineSize.Height;
            return panelSize;
        }
    }

}

