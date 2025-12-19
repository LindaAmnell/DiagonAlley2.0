using DiagonAlley2._0.Models;
using DiagonAlley2._0.Models.Enum;
using DiagonAlley2._0.Services;

namespace DiagonAlley2._0.Data
{
    public static class WizardSeeder
    {
        private const string WizardCollection = "Wizards";

        public static async Task SeedAsync(MongoDbService mongo)
        {
            var existingWizards = await mongo.GetAllAsync<Wizard>(WizardCollection);

            // If wizards already exist, do nothing
            if (existingWizards.Any())
                return;

            // 🧙‍♂️ ADMIN WIZARD
            var admin = new Wizard
            {
                Name = "Albus Dumbledore",
                Password = "elderwand",
                Level = WizardLevel.Gold,
                IsAdmin = true
            };
            admin.UpdateDiscount();

            // 🧙 NORMAL WIZARD
            var user = new Wizard
            {
                Name = "Harry Potter",
                Password = "expelliarmus",
                Level = WizardLevel.Bronze,
                IsAdmin = false
            };
            user.UpdateDiscount();

            await mongo.CreateAsync(WizardCollection, admin);
            await mongo.CreateAsync(WizardCollection, user);
        }
    }
}
