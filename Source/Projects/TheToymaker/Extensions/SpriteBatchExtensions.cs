using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;

namespace TheToymaker.Extensions
{
    public static class SpriteBatchExtensions
    {
        public static void DrawSprite(this SpriteBatch spriteBatch, Transform2D transform, Sprite sprite)
        {
            var texture = GameDriver.Instance.TextureBank.GetTexture(sprite.ImageId);
            var textureSize = new Vector2(texture.Width, texture.Height);
            var textureFrame = new Rectangle(0, 0, texture.Width, texture.Height);
            var texturePivot = Vector2.Multiply(textureSize, sprite.Pivot);
            spriteBatch.Draw(
                texture,
                transform.Position,
                textureFrame,
                sprite.Tint,
                transform.Angle,
                texturePivot,
                transform.Scale,
                sprite.Effects,
                sprite.Layer);
        }
    }
}
