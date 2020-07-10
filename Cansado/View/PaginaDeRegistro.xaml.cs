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
    public partial class PaginaDeRegistro : ContentPage
    {
        public PaginaDeRegistro()
        {
            InitializeComponent();
            BindingContext = new VMdeRegistro();
        }
    }
}