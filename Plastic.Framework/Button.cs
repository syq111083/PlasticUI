using Plastic.Framework.Enums;
using Plastic.Themes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Plastic.Framework
{
    public class Button : System.Windows.Controls.Button
    {
        static Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(typeof(Button)));
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Button), new PropertyMetadata(new CornerRadius(6)));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register("Theme", typeof(Theme), typeof(Button), new PropertyMetadata(Theme.Primary));

        public Theme Theme
        {
            get => (Theme)GetValue(ThemeProperty);
            set => SetValue(ThemeProperty, value);
        }

        public static readonly DependencyProperty IsGroupProperty = DependencyProperty.Register("IsGroup", typeof(bool), typeof(Button), new PropertyMetadata(false));

        public bool IsGroup
        {
            get => (bool)GetValue(IsGroupProperty);
            set => SetValue(IsGroupProperty, value);
        }


        public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(Button), new FrameworkPropertyMetadata((double)0,
      FrameworkPropertyMetadataOptions.AffectsRender,
      new PropertyChangedCallback(OnBrightnessChanged)));

        public double Brightness
        {
            get => (double)GetValue(BrightnessProperty);
            set => SetValue(BrightnessProperty, value);
        }

        public Color? OriginBrush;

        public LinearGradientBrush OriginGradient = null;

        private static void OnBrightnessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = (Button)d;
            Type type = btn.Background.GetType();
            if (type == typeof(SolidColorBrush))
            {
                SolidColorBrush background = (SolidColorBrush)btn.Background;
                Color backcolor = background.Color;
                if (btn.OriginBrush == null)
                {
                    btn.OriginBrush = backcolor;
                }
                byte r = (byte)(btn.OriginBrush?.R * btn.Brightness);
                if (r < btn.OriginBrush?.R && btn.Brightness > 1)
                    r = 255;
                byte g = (byte)(btn.OriginBrush?.G * btn.Brightness);
                if (g < btn.OriginBrush?.G && btn.Brightness > 1)
                    g = 255;
                byte b = (byte)(btn.OriginBrush?.B * btn.Brightness);
                if (b < btn.OriginBrush?.B && btn.Brightness > 1)
                    b = 255;
                Color newColor = Color.FromArgb(255, r, g, b);
                btn.Background = new SolidColorBrush(newColor);
            }
            else if (type == typeof(LinearGradientBrush))
            {
                LinearGradientBrush linear = (LinearGradientBrush)btn.Background;
                if (btn.OriginGradient == null)
                {
                    btn.OriginGradient = linear.CloneCurrentValue();
                }
                var stops = btn.OriginGradient.GradientStops;
                List<GradientStop> gradientStops = new List<GradientStop>();
                for (int i = 0; i < linear.GradientStops.Count; i++)
                {
                    Color backcolor =stops[i].Color;
                    byte r = (byte)(stops[i].Color.R * btn.Brightness);
                    if (r < backcolor.R && btn.Brightness > 1)
                        backcolor.R = 255;
                    else
                        backcolor.R = r;
                    byte g = (byte)(stops[i].Color.G * btn.Brightness);
                    if (g < backcolor.G && btn.Brightness > 1)
                        backcolor.G = 255;
                    else
                        backcolor.G = g;
                    byte b = (byte)(stops[i].Color.B * btn.Brightness);
                    if (b < backcolor.B && btn.Brightness > 1)
                        backcolor.B = 255;
                    else backcolor.B = b;
                    GradientStop stop = new GradientStop(){Color = backcolor,Offset=stops[i].Offset};
                    gradientStops.Add(stop);
                }
                linear.GradientStops.Clear();
                foreach (var item in gradientStops)
                {
                    linear.GradientStops.Add(item);
                }
            }
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(SizeEnum), typeof(Button), new PropertyMetadata(SizeEnum.Default));

        public SizeEnum Size
        {
            get => (SizeEnum)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
    }
}
