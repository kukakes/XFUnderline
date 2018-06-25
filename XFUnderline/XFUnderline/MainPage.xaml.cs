using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFUnderline
{
	public partial class MainPage : ContentPage
	{
        public bool NeedsUnderline { get; set; }
        public string Name { get; set; } = "Hello";

        public MainPage()
		{
			InitializeComponent();
            this.BindingContext = this;

            btn.Clicked += Btn_Clicked;
		}

        private void Btn_Clicked(object sender, EventArgs e)
        {
            //Name += "1";
            //OnPropertyChanged(nameof(Name));

            NeedsUnderline = !NeedsUnderline;
            OnPropertyChanged(nameof(NeedsUnderline));
        }
    }
}
