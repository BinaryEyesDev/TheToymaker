using System;
using Microsoft.Xna.Framework;
using TheToymaker.Components;

namespace TheToymaker.Data
{
    [Serializable]
    public class Hotspot
    {
        public Transform2D Transform;
        public Sprite DebugSprite;
        public Sprite Sprite;
        public BoundingBox BoundingBox;
        public string DamageTarget;
        public float ActivationTime;

        [NonSerialized]
        public string Name;
    }
}
