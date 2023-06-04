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
    public class Range : Slider
    {
        static Range()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Range), new FrameworkPropertyMetadata(typeof(Range)));
        }

        private Thumb thumb0;

        public Thumb Thumb0
        {
            get { return thumb0; }
            set { thumb0 = value; }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Thumb0 = GetTemplateChild("thumb0") as Thumb;
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);
            Thumb0.Focus();
        }

    }
}
