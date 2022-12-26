using System;
using System.Collections.Generic;

namespace SaveSystem.Models
{
    [Serializable]
    class WeaponsModel
    {
        public List<string> AvailableWeapons = new();
        public string SelectedPistol = String.Empty;
        public string SelectedRifle = String.Empty;
        public string SelectedShotgun = String.Empty;
    }
}
