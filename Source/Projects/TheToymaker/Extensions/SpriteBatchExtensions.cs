using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;
using TheToymaker.Data;

namespace TheToymaker.Extensions
{
    public static class SpriteBatchExtensions
    {
        public static void DrawHotspot(this SpriteBatch batch, HotSpot spot)
        {
            var sprite = !string.IsNullOrEmpty(spot.Sprite.ImageId) ? spot.Sprite : spot.DebugSprite;
            batch.DrawSprite(spot.Transform, sprite);
        }

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
