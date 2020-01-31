using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;

namespace TheToymaker.Utilities
{
    public static class GenerateSprite
    {
        public static Sprite Default(Texture2D texture)
        {
            return new Sprite
            {
                Transform = Transform2D.Identity,
                Image = texture,
                Frame = new Rectangle(0, 0, texture.Width, texture.Height),
                Tint = Color.White,
                Layer = 0.5f,
                Pivot = new Vector2(texture.Width, texture.Height)*0.5f,
                Effects = SpriteEffects.None,
            };
        }
    }
}
