using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;

namespace TheToymaker.Utilities
{
    public static class GenerateSprite
    {
        public static Sprite Default()
        {
            return new Sprite
            {
                ImageId = "",
                Tint = Color.White,
                Layer = 0.5f,
                Effects = SpriteEffects.None,
            };
        }
    }
}
