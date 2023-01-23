using System;
using System.Collections.Generic;
using Resources;
using UnityEngine;

namespace Saves {
    
    [Serializable]
    public class ResourceSaveData {
        public ResourceType Type;

        public int MinOrCurrent;
        public int Max;

        public string AdvancedData;
    }
}