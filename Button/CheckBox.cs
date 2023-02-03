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

namespace Plastic
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

        private Rectangle? rect0;

        public Rectangle? Rect0
        {
            get { return rect0; }
            set
            {
                if (rect0 != null)
                    rect0.MouseLeftButtonDown -= new MouseButtonEventHandler(LeftButtonDown);
                rect0 = value;
                if (rect0 != null)
                    rect0.MouseLeftButtonDown += new MouseButtonEventHandler(LeftButtonDown);
            }
        }

        private Border? border0;

        public Border? Border0
        {
            get { return border0; }
            set
            {
                if (border0 != null)
                {
                    border0.FocusableChanged -= Border0_FocusableChanged;
                    border0.MouseLeftButtonDown -= new MouseButtonEventHandler(LeftButtonDown);
                }
                border0 = value;
                if (border0 != null)
                {
                    border0.FocusableChanged += Border0_FocusableChanged;
                    border0.MouseLeftButtonDown += new MouseButtonEventHandler(LeftButtonDown);
                }
            }
        }

        private void Border0_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            base.OnGotFocus(null);
            if (Border0?.IsFocused == true)
            {
                VisualStateManager.GoToState(this, "Focused", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Unfocused", true);

            }
        }

        void LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnClick();
            if (IsChecked == true)
            {
                IsChecked = false;
                VisualStateManager.GoToState(this, "Unselected", true);
            }
            else
            {
                IsChecked = true;
                VisualStateManager.GoToState(this, "Selected", true);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnClick();
            VisualStateManager.GoToState(this, "Unselected", true);
            Rect0 = GetTemplateChild("rect0") as Rectangle;
            Border0 = GetTemplateChild("border") as Border;
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
