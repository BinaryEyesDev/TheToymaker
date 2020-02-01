using System;
using TheToymaker.Components;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    [Serializable]
    public class SewingKit
    {
        public Transform2D Transform;
        public Sprite Sprite;

        public static SewingKit Initialize(GameDriver driver)
        {
            var path = DataPath.Get("Elements\\SewingKit.json");
            return JsonData.DeserializeFromFile<SewingKit>(path);
        }
    }
}
