using Cansado.Model;
using Cansado.ViewModel;
using Firebase.Database;
using Firebase.Database.Query;
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
    public partial class PaginaDeLogin : ContentPage
    {
        public PaginaDeLogin()
        {
            InitializeComponent();
            BindingContext = new VMdeLogin(Navigation);
        }

        async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaLoginAdmin());
        }
    }
}