using Cansado.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Cansado.View;

namespace Cansado.ViewModel
{
    public class VMadminLogin
    {
        private string _CPF;
        public string CPF
        {
            get { return _CPF; }
            set
            {
                _CPF = value;
            }
        }
        private string _Senha;
        public string Senha
        {
            get { return _Senha; }
            set
            {
                _Senha = value;
            }
        }
        public ICommand LoginAdmin { get; }
        public INavigation SharedNav { get; }
        public VMadminLogin(INavigation navigation)
        {
            SharedNav = navigation;
            LoginAdmin = new Command(async () => await RealizarLogin());
        }
        private async Task RealizarLogin()
        {
            var response = await ApiServices.ServiceClientInstance.LogarUsuarioAdmin(CPF, Senha);

            if (response != null)
            {
                await SharedNav.PushAsync(new PaginaPrincipalAdmin());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Server Error", "Ok");
            }
        }
    }
}
