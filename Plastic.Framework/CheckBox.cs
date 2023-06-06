using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Plastic.Framework
{
    [TemplatePart(Name = "rect0", Type = typeof(Rectangle))]
    [TemplatePart(Name = "rect1", Type = typeof(Rectangle))]
    public class CheckBox : System.Windows.Controls.CheckBox
    {
        static CheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBox), new FrameworkPropertyMetadata(typeof(CheckBox)));
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
        }

        public override void OnApplyTemplate()
        {
            Focusable = true;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (IsChecked == null)
                VisualStateManager.GoToState(this, "CheckedPressing", true);
            else if((bool)IsChecked)
                VisualStateManager.GoToState(this, "CheckedPressing", true);
            else
                VisualStateManager.GoToState(this, "UncheckedPressing", true);

        }

        public static readonly DependencyProperty BorderWidthProperty = DependencyProperty.Register("BorderWidth", typeof(double), typeof(CheckBox), new PropertyMetadata((double)24));

        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly DependencyProperty BorderHeightProperty = DependencyProperty.Register("BorderHeight", typeof(double), typeof(CheckBox), new PropertyMetadata((double)24));

        public double BorderHeight
        {
            get { return (double)GetValue(BorderHeightProperty); }
            set { SetValue(BorderHeightProperty, value); }
        }

        public new double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        public new double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set
            {
                SetValue(HeightProperty, value);
            }
        }
    }
}
