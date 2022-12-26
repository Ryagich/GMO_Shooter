using System;

namespace SaveSystem.Models
{
    [Serializable]
    class SaveModel
    {
        public WeaponsModel Weapons = new();
        public UpdatesModel Updates = new();
        public PlayerStateModel PlayerState = new();
    }
}
