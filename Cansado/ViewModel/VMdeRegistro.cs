using Cansado.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cansado.ViewModel
{
    public class VMdeRegistro : BindableObject
    {
        private string _NomeCompleto;

        public string NomeCompleto
        {
            get { return _NomeCompleto; }
            set { _NomeCompleto = value; OnPropertyChanged(); }
        }

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

        private int _Idade;

        public int Idade
        {
            get { return _Idade; }
            set { _Idade = value; OnPropertyChanged(); }
        }

        public ICommand RegistrarUsuario { get; }

        public VMdeRegistro()
        {
            RegistrarUsuario = new Command(async () => await SetarRegistroDeUsuario());
        }

        private async Task SetarRegistroDeUsuario()
        {
            var resposta = await ApiServices.ServiceClientInstance.RegistrarUsuario(NomeCompleto, CPF, Senha, Idade);

            if (resposta == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Usuario Criado com sucesso", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Erro", "Ok");
            }
        }
    }
}
