using Cansado.Helpers;
using Cansado.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cansado.ViewModel
{
    public class VMdeLogin : BindableObject
    {
        private string _CPF;

        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; OnPropertyChanged(); }
        }

        private string _Senha;

        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; OnPropertyChanged(); }
        }

        public ICommand LoginUsuario { get; }
        public ICommand IrParaRegistro { get; }
        public INavigation Navigation { get; }

        public VMdeLogin(INavigation navigation)
        {
            Navigation = navigation;
            LoginUsuario = new Command(async () => await RealizarLogin());
            IrParaRegistro = new Command(async () => await IrParaPaginaDeRegistro());
        }

        private async Task IrParaPaginaDeRegistro()
        {
            await Navigation.PushAsync(new PaginaDeRegistro());
        }

        private async Task RealizarLogin()
        {
            var resposta = await ApiServices.ServiceClientInstance.LogarUsuario(CPF, Senha);

            if(resposta!=null)
            {
                await Navigation.PushAsync(new PaginaPrincipal());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alerta!", "Erro", "Ok");
            }
        }
    }
}
