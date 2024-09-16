﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Mobile.Models
{
    public partial class LoginRegisterModel :ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        public bool IsNewUser => !string.IsNullOrWhiteSpace(Name);

        public bool Validate(bool isRegistrationMode)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                return false;
          
            if(isRegistrationMode && string.IsNullOrWhiteSpace(Name))
                return false;

            return true;
        }
    }
}
