using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFUnderline
{
    public class UnderlineLabel : Label
    {
        public static readonly BindableProperty HasUnderlineProperty =
            BindableProperty.Create("HasUnderline", typeof(bool), typeof(UnderlineLabel), false);

        public bool HasUnderline
        {
            get { return (bool)GetValue(HasUnderlineProperty); }
            set { SetValue(HasUnderlineProperty, value); }
        }
    }
}
