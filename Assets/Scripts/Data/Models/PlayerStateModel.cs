using System;

namespace SaveSystem.Models
{
    [Serializable]
    class PlayerStateModel
    {
        public int Money = 0;
        public string MaxLevel = String.Empty;
        public string MaxWave = String.Empty;
    }
}
