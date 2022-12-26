using SaveSystem.Models;

namespace SaveSystem
{
    partial class SaveManager
    {
        private void LoadModel(SaveModel model)
        {
            LoadWeapons(model);
            LoadPlayerSate(model);
            LoadUpdates(model);
        }

        private void LoadWeapons(SaveModel model)
        {
            AvailableWeapons = new();
            var weapons = model.Weapons;
            foreach (var id in weapons.AvailableWeapons)
                AvailableWeapons.Add(serializer.Get<WeaponInfo>(id));
            SelectedPistol = serializer.Get<WeaponInfo>(weapons.SelectedPistol);
            SelectedRifle = serializer.Get<WeaponInfo>(weapons.SelectedRifle);
            SelectedShotgun = serializer.Get<WeaponInfo>(weapons.SelectedShotgun);
        }

        private void LoadPlayerSate(SaveModel model)
        {
            var playerState = model.PlayerState;
            MaxLevel = serializer.Get<LevelScriptable>(playerState.MaxLevel);
            MaxWave = serializer.Get<WaveScriptable>(playerState.MaxWave);
            Money = playerState.Money;
        }

        private void LoadUpdates(SaveModel model)
        {
            AvailableBoxUpdates = new();
            var updates = model.Updates;
            foreach (var id in updates.AvailableBoxUpdates)
                AvailableBoxUpdates.Add(serializer.Get<BoxUpdate>(id));
            foreach (var id in updates.AvailableStatUpdates)
                AvailableStatUpdates.Add(serializer.Get<StatUpdate>(id));
        }
    }
}
