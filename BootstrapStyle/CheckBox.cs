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

namespace BootstrapStyle
{
    [TemplatePart(Name = "rect0", Type = typeof(Rectangle))]
    [TemplatePart(Name = "rect1", Type = typeof(Rectangle))]
    [TemplateVisualState(GroupName = "SelectStates", Name = "Unselected")]
    [TemplateVisualState(GroupName = "SelectStates", Name = "Selected")]
    [TemplateVisualState(GroupName = "FocusStates", Name = "Focused")]
    [TemplateVisualState(GroupName = "FocusStates", Name = "Unfocused")]
    public class CheckBox : System.Windows.Controls.CheckBox
    {
        static CheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBox), new FrameworkPropertyMetadata(typeof(CheckBox)));
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            VisualStateManager.GoToState(this, "Focused", true);
        }

        public override void OnApplyTemplate()
        {
            Focusable = true;
            VisualStateManager.GoToState(this, "Unselected", true);
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            VisualStateManager.GoToState(this, "Selected", true);
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            base.OnUnchecked(e);
            VisualStateManager.GoToState(this, "Unselected", true);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (IsChecked == true)
                VisualStateManager.GoToState(this, "CheckedPressing", true);
            else
                VisualStateManager.GoToState(this, "UncheckedPressing", true);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            VisualStateManager.GoToState(this, "NotPressing", true);

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
