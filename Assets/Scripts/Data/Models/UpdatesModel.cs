using System;
using System.Collections.Generic;

namespace SaveSystem.Models
{
    [Serializable]
    class UpdatesModel
    {
        public List<string> AvailableStatUpdates = new();
        public List<string> AvailableBoxUpdates = new();
    }
}
