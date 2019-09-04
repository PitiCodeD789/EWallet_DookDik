using EWallet.Mobile.Services.Interfaces;
using EWallet.Mobile.Services.Services;
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
        private readonly IAuthService _authService;

        public AuthViewModel()
        {
            _authService = new AuthService();

            SignInCommand = new Command(SignIn);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Email { get; set; }

        public Command SignInCommand { get; set; }

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
                    // TODO: valid or invalid
                    await Application.Current.MainPage.Navigation.PushAsync(new Page());
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "Please Enter email.", "Ok");
            }
        }
    }
}
