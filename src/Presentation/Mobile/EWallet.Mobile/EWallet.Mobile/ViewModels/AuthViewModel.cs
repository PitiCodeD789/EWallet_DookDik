using EWallet.Services.Interfaces;
using EWallet.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;
using Xamarin.Forms;

namespace EWallet.Mobile.ViewModels
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IAuthService _authService;

        public AuthViewModel()
        {
            _authService = new AuthService();

            SignInCommand = new Command(SignIn);
        }

        private async void SignIn()
        {
            bool isEmail = Helpers.Utilities.CheckEmailFormat(Email);
            if (isEmail)
            {
                var result = await _authService.SignIn(Email);
                if (result.IsError || result.Model == null)
                {
                   await Application.Current.MainPage.DisplayAlert("", "Error", "Ok");
                }
                else
                {
                    //valid or invalid
                    await Application.Current.MainPage.Navigation.PushAsync(new Page());
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "Please Enter email.", "Ok");
            }
        }

        public string Email { get; set; }

        public Command  SignInCommand { get; set; }

    }
}
