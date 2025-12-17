using DiagonAlley2._0.Models;
using DiagonAlley2._0.Models.Enum;

namespace DiagonAlley2._0.Services
{
    public class LoginService
    {
        private readonly MongoDbService _db;
        private readonly StorageService _storage;

        public LoginService(MongoDbService db, StorageService storage)
        {
            _db = db;
            _storage = storage;
        }

        public Wizard? CurrentWizard { get; private set; }

        public bool IsLoggedIn => CurrentWizard != null;
        public bool IsAdmin => CurrentWizard?.IsAdmin == true;

        public async Task<bool> LoginAsync(string username, string password)
        {
            var wizards = await _db.GetAllAsync<Wizard>("Wizards");

            var wizard = wizards.FirstOrDefault(w =>
                w.Name == username && w.Password == password);

            if (wizard == null)
                return false;

            CurrentWizard = wizard;
            await _storage.SetWizardId(wizard.Id!);

            return true;
        }

        public async Task<string?> RegisterAsync(
            string username,
            string password,
            WizardLevel level)
        {
            var existing = await _db.GetAllAsync<Wizard>("Wizards");

            if (existing.Any(w => w.Name == username))
                return "A wizard with this username already exists.";

            var wizard = new Wizard
            {
                Name = username,
                Password = password,
                Level = level,
                Cart = new()
            };

            wizard.UpdateDiscount();

            await _db.CreateAsync("Wizards", wizard);

            return null;
        }

        public async Task TryRestoreLoginAsync()
        {
            var wizardId = await _storage.GetWizardId();
            if (wizardId == null)
                return;

            CurrentWizard = await _db.GetByIdAsync<Wizard>(
                "Wizards", wizardId);
        }

        public async Task LogoutAsync()
        {
            CurrentWizard = null;
            await _storage.ClearWizardId();
        }

        public bool ValidatePassword(string password)
        {
            return CurrentWizard?.Password == password;
        }
    }
}
