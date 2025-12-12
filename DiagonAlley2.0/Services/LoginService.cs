using DiagonAlley2._0.Models;

namespace DiagonAlley2._0.Services
{
    public class LoginService
    {
        public Wizard? CurrentWizard { get; private set; }

        public bool IsLoggedIn => CurrentWizard != null;

        public bool IsAdmin => CurrentWizard?.IsAdmin == true;

        public void Login(Wizard user)
        {
            CurrentWizard = user;
        }

        public void Logout()
        {
            CurrentWizard = null;
        }

    }
}
