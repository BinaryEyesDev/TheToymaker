using System;
using Microsoft.Xna.Framework;
using TheToymaker.Components;

namespace TheToymaker.Data
{
    [Serializable]
    public class HotSpot
    {
        public string Name;
        public Transform2D Transform;
        public Sprite DebugSprite;
        public Sprite Sprite;
        public BoundingBox BoundingBox;
    }
}
