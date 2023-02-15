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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plastic
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        static TextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(typeof(TextBox)));
        }

        public static readonly DependencyProperty OutBorderOpacityProperty = DependencyProperty.Register("OutBorderOpacity", typeof(double), typeof(TextBox), new PropertyMetadata((double)0));

        public double OutBorderOpacity
        {
            get { return (double)GetValue(OutBorderOpacityProperty); }
            set { SetValue(OutBorderOpacityProperty, value); }
        }

        public static readonly DependencyProperty OnSelectingStatusProperty = DependencyProperty.Register("OnSelectingStatus", typeof(bool), typeof(TextBox), new PropertyMetadata(false));

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
            VisualStateManager.GoToState(this, "Focused", true);
        }



        public static readonly DependencyProperty IsComboBoxProperty = DependencyProperty.Register("IsComboBox", typeof(bool), typeof(TextBox), new PropertyMetadata(false));

        public bool IsComboBox
        {
            get { return (bool)GetValue(IsComboBoxProperty); }
            set { SetValue(IsComboBoxProperty, value);}
        }
    }
}
