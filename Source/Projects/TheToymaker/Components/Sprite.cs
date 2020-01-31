using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheToymaker.Components
{
    [Serializable]
    public class Sprite
    {
        public string ImageId;
        public Color Tint;
        public float Layer;
        public Vector2 Pivot;
        public SpriteEffects Effects;
    }
}
