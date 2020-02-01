using System;
using TheToymaker.Components;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    [Serializable]
    public class PaintingKit
    {
        public Transform2D Transform;
        public Sprite Sprite;

        public static PaintingKit Initialize(GameDriver driver)
        {
            var path = DataPath.Get("Elements\\PaintingKit.json");
            return JsonData.DeserializeFromFile<PaintingKit>(path);
        }
    }
}
