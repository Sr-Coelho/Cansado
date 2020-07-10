﻿using Cansado.Helpers;
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
    public partial class PaginaPrincipalAdmin : ContentPage
    {
        public PaginaPrincipalAdmin()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var response = await ApiServices.ServiceClientInstance.RegistrarAula(FNdaAula.Text, FURLdaAula.Text);
            if (response == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Aula Salva Com Sucesso", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", " Erro", "Ok");
            }

        }
    }
}