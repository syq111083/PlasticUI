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

namespace Plastic
{
    public class Select : System.Windows.Controls.ComboBox
    {
        static Select()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Select), new FrameworkPropertyMetadata(typeof(Select)));
        }

        private Input tb0;
        public Input Tb0
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
            Tb0 = GetTemplateChild("tb0") as Input;
            Popup0 = GetTemplateChild("popup0") as Popup;
            Popup0.GotFocus += Popup0_GotFocus;
        }

        private void Popup0_GotFocus(object sender, RoutedEventArgs e)
        {
            Tb0.Focus();
        }

        protected override void OnDropDownOpened(EventArgs e)
        {
            base.OnDropDownOpened(e);
            Tb0.Focus();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            Tb0.Focus();
        }

        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register("Placeholder",typeof(string),typeof(Select), new PropertyMetadata(null));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
    }
}
