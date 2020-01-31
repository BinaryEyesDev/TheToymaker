using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheToymaker.Components
{
    public class Sprite
    {
        public Transform2D Transform;
        public Texture2D Image;
        public Rectangle? Frame;
        public Color Tint;
        public float Layer;
        public Vector2 Pivot;
        public SpriteEffects Effects;
    }
}
