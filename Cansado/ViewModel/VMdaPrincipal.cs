using Cansado.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Cansado.Model;

namespace Cansado.ViewModel
{
    public class VMdaPrincipal : BindableObject
    {
        private string _NomeCompleto;

        public string NomeCompleto
        {
            get { return _NomeCompleto; }
            set { _NomeCompleto = value; }
        } 
        public ICommand IrParaAulas { get; }
        public ICommand IrParaRecados { get; }
        public ICommand IrParaNoticias { get; }
        public INavigation Navigation { get; }

        public VMdaPrincipal(INavigation navigation)
        {
            Navigation = navigation;
            IrParaAulas = new Command(async () => await IrParaPaginaAulas());
            IrParaRecados = new Command(async () => await IrParaPaginaRecados());
            IrParaNoticias = new Command(async () => await IrParaPaginaNoticias());
        }

        private async Task IrParaPaginaNoticias()
        {
            await Navigation.PushAsync(new PaginaDeNoticias());
        }

        private async Task IrParaPaginaRecados()
        {
            await Navigation.PushAsync(new PaginaDeRecados());
        }

        private async Task IrParaPaginaAulas()
        {
            await Navigation.PushAsync(new PaginaDeAulas());
        }
    }
}
