using DiagonAlley2._0.Models;

namespace DiagonAlley2._0.Services
{
    public class LoginService
    {
        public Wizard? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public bool IsAdmin => CurrentUser?.IsAdmin == true;

        public void Login(Wizard user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
