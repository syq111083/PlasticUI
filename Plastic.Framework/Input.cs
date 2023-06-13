using Plastic.Framework.Enums;
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

namespace Plastic.Framework
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

        public static readonly DependencyProperty PrefixProperty = DependencyProperty.Register("Prefix", typeof(bool), typeof(Input));

        public bool Prefix
        {
            get => (bool)GetValue(PrefixProperty);
            set => SetValue(PrefixProperty, value);
        }

        public static readonly DependencyProperty PrefixContentProperty = DependencyProperty.Register("PrefixContent", typeof(object), typeof(Input));

        public object PrefixContent
        {
            get => (object)GetValue(PrefixContentProperty);
            set => SetValue(PrefixContentProperty, value);
        }

        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register("Suffix", typeof(bool), typeof(Input));

        public bool Suffix
        {
            get => (bool)GetValue(SuffixProperty);
            set => SetValue(SuffixProperty, value);
        }        
        
        public static readonly DependencyProperty SuffixContentProperty = DependencyProperty.Register("SuffixContent", typeof(object), typeof(Input));

        public object SuffixContent
        {
            get => (bool)GetValue(SuffixContentProperty);
            set => SetValue(SuffixContentProperty, value);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (string.IsNullOrEmpty(FloatingLabelText))
                return;

            VisualStateManager.GoToState(this, "Focused", true);
            VisualStateManager.GoToState(this, "WithText", true);
            VisualStateManager.GoToState(this, "LabelDown", true);
            VisualStateManager.GoToState(this, "LabelGray", true);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (string.IsNullOrEmpty(FloatingLabelText))
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

        public static readonly DependencyProperty FloatingLabelProperty = DependencyProperty.Register("FloatingLabel", typeof(bool), typeof(Input));

        public bool FloatingLabel
        {
            get=>(bool)GetValue(FloatingLabelProperty);
            set => SetValue(FloatingLabelProperty, value);
        }


        public static readonly DependencyProperty FloatingLabelTextProperty = DependencyProperty.Register("FloatingLabelText", typeof(string), typeof(Input));

        public string FloatingLabelText
        {
            get => (string)GetValue(FloatingLabelTextProperty);
            set => SetValue(FloatingLabelTextProperty, value);
        }

        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register("PlaceHolder",typeof(string), typeof(Input));

        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty); 
            set => SetValue(PlaceHolderProperty, value);
        }

        public static readonly DependencyProperty IsComboBoxProperty = DependencyProperty.Register("IsComboBox",typeof (bool), typeof(Input),new PropertyMetadata(false));

        public bool IsComboBox
        {
            get => (bool)GetValue(IsComboBoxProperty);
            set => SetValue(IsComboBoxProperty, value);
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(SizeEnum), typeof(Input), new PropertyMetadata(SizeEnum.Default));

        public SizeEnum Size
        {
            get => (SizeEnum)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
    }
}
