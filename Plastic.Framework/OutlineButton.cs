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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plastic.Framework
{
    public class OutlineButton : Button
    {
        static OutlineButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OutlineButton), new FrameworkPropertyMetadata(typeof(OutlineButton)));
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            switch (Theme)
            {
                case Theme.Primary:
                    VisualStateManager.GoToState(this, "prime", true);
                    break;
                case Theme.Secondary:
                    VisualStateManager.GoToState(this, "secondary", true);

                    break;
                case Theme.Success:
                    VisualStateManager.GoToState(this, "success", true);

                    break;
                case Theme.Danger:
                    VisualStateManager.GoToState(this, "danger", true);

                    break;
                case Theme.Warning:
                    VisualStateManager.GoToState(this, "warning", true);

                    break;
                case Theme.Info:
                    VisualStateManager.GoToState(this, "info", true);

                    break;
                case Theme.Light:
                    VisualStateManager.GoToState(this, "light", true);

                    break;
                case Theme.Dark:
                    VisualStateManager.GoToState(this, "dark", true);

                    break;
                default:
                    break;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            VisualStateManager.GoToState(this, "normal", true);
        }

    }
}
