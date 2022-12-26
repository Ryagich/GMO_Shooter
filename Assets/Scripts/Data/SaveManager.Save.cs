using SaveSystem.Models;

namespace SaveSystem
{
    partial class SaveManager
    {
        private SaveModel SaveModel()
        {
            var model = new SaveModel();
            SaveWeapons(model);
            SavePlayerSate(model);
            SaveUpdates(model);
            return model;
        }

        private void SaveWeapons(SaveModel model)
        {
            var weapons = model.Weapons;
            foreach (var weapon in AvailableWeapons)
                weapons.AvailableWeapons.Add(weapon.Id);

            weapons.SelectedPistol = SelectedPistol.Id;
            weapons.SelectedRifle = SelectedRifle.Id;            
            weapons.SelectedShotgun = SelectedShotgun.Id;
        }

        private void SavePlayerSate(SaveModel model)
        {
            var playerState = model.PlayerState;
            playerState.MaxLevel = MaxLevel.Id;
            playerState.MaxWave = MaxWave.Id;
            playerState.Money = Money;
        }

        private void SaveUpdates(SaveModel model)
        {
            var updates = model.Updates;
            foreach (var update in AvailableBoxUpdates)
                updates.AvailableBoxUpdates.Add(update.Id);
            foreach (var update in AvailableStatUpdates)
                updates.AvailableStatUpdates.Add(update.Id);
        }
    }
}
