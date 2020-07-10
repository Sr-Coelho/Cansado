using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cansado.Helpers;
using Cansado.Model;
using Cansado.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cansado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaDeAulas : ContentPage
    {
        public PaginaDeAulas()
        {
            InitializeComponent();
            PegarAulas();
        }
        private async void PegarAulas()
        {
            ListViewAulas.ItemsSource = await ApiServices.ServiceClientInstance.PegarAulas();
        }
    }
}