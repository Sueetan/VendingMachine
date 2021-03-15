using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Authentication
{
    public interface IAuthenticationService
    {
        bool IsUserAuthenticated { get; }

        void Login(string password);

        void Logout();
    }
}
