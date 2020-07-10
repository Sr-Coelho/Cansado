using Cansado.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cansado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaLoginAdmin : ContentPage
    {
        public PaginaLoginAdmin()
        {
            InitializeComponent();
            BindingContext = new VMadminLogin(Navigation);
        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PaginaDeRegistroDeAdmin());
        }
    }
}