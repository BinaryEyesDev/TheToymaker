using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Entities;

namespace TheToymaker.Extensions
{
    public static class SpriteBatchExtensions
    {
        public static void DrawToy(this SpriteBatch batch, Toy toy)
        {
            var ui = GameDriver.Instance.GameInterface;
            var scale = ui.ToyLocationInFront.Scale;

            ui.ToyLocationInFront.Scale = new Vector2(1.0f, 1.0f);
            batch.DrawSprite(ui.ToyLocationInFront, toy.LargeSprite);

            ui.ToyLocationOnTable.Scale = new Vector2(0.3f, 0.3f);
            batch.DrawSprite(ui.ToyLocationOnTable, toy.LargeSprite);

            foreach (var damagePoint in toy.DamagePoints.Where(element => element.Active))
                batch.DrawSprite(damagePoint.GetGlobalTransform(), damagePoint.Sprite);

            ui.ToyLocationInFront.Scale = scale;
            ui.ToyLocationOnTable.Scale = scale;
        }
        
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
                MathHelper.ToRadians(transform.Angle),
                texturePivot,
                transform.Scale,
                sprite.Effects,
                sprite.Layer);
        }
    }
}
