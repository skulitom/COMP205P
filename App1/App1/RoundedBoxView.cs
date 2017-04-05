using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class RoundedBoxView : BoxView
    {
        public RoundedBoxView()
        {

        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create<RoundedBoxView, double>(
                p => p.CornerRadius, default(double));

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CornerColorProperty =
            BindableProperty.Create<RoundedBoxView, Color>(
                p => p.OutlineColor, default(Color));

        public Color OutlineColor
        {
            get { return (Color)GetValue(CornerColorProperty); }
            set { SetValue(CornerColorProperty, value); }
        }
    }
}