using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class Input : System.Windows.Controls.TextBox
    {
        static Input()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Input), new FrameworkPropertyMetadata(typeof(Input)));
        }

        public static readonly DependencyProperty OutBorderOpacityProperty = DependencyProperty.Register("OutBorderOpacity", typeof(double), typeof(Input), new PropertyMetadata((double)0));

        public double OutBorderOpacity
        {
            get { return (double)GetValue(OutBorderOpacityProperty); }
            set { SetValue(OutBorderOpacityProperty, value); }
        }

        public static readonly DependencyProperty OnSelectingStatusProperty = DependencyProperty.Register("OnSelectingStatus", typeof(bool), typeof(Input), new PropertyMetadata(false));

        public bool OnSelectingStatus
        {
            get { return (bool)GetValue(OnSelectingStatusProperty); }
            set
            {
                SetValue(OnSelectingStatusProperty, value);
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (string.IsNullOrEmpty(FloatingLabel))
                return;

            VisualStateManager.GoToState(this, "Focused", true);
            VisualStateManager.GoToState(this, "WithText", true);
            VisualStateManager.GoToState(this, "LabelDown", true);
            VisualStateManager.GoToState(this, "LabelGray", true);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (string.IsNullOrEmpty(FloatingLabel))
                return;

            if (!string.IsNullOrEmpty(this.Text))
            {
                VisualStateManager.GoToState(this, "WithText", true);
                VisualStateManager.GoToState(this, "LabelDown", true);
                VisualStateManager.GoToState(this, "LabelGray", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "WithoutText", true);
                VisualStateManager.GoToState(this, "LabelUp", true);
                VisualStateManager.GoToState(this, "LabelBlack", true);
            }
        }

        public static readonly DependencyProperty FloatingLabelProperty = DependencyProperty.Register("FloatingLabel", typeof(string), typeof(Input));

        public string FloatingLabel
        {
            get => (string)GetValue(FloatingLabelProperty);
            set => SetValue(FloatingLabelProperty, value);
        }
    }
}
