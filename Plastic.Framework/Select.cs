using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plastic.Framework
{
    public class Select : System.Windows.Controls.ComboBox
    {
        static Select()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Select), new FrameworkPropertyMetadata(typeof(Select)));
        }

        private TextBlock tb0;
        public TextBlock Tb0
        {
            get { return tb0; }
            set { tb0 = value; }
        }

        private Popup popup0;
        public Popup Popup0
        {
            get { return popup0; }
            set { popup0 = value; }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Tb0 = GetTemplateChild("tb0") as TextBlock;
            Popup0 = GetTemplateChild("popup0") as Popup;
        }



        protected override void OnDropDownOpened(EventArgs e)
        {
            base.OnDropDownOpened(e);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
        }

        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register("Placeholder", typeof(string), typeof(Select), new PropertyMetadata(null));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly DependencyProperty OutBorderOpacityProperty = DependencyProperty.Register("OutBorderOpacity", typeof(double), typeof(Select), new PropertyMetadata((double)0));

        public double OutBorderOpacity
        {
            get { return (double)GetValue(OutBorderOpacityProperty); }
            set { SetValue(OutBorderOpacityProperty, value); }
        }
    }
}
