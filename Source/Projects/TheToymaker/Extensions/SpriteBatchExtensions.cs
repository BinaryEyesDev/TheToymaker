using System;
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
        public static void DrawMoney(this SpriteBatch batch, Money money)
        {
            money.Sprite.Layer = 0.55f;
            foreach (var transform in money.Transforms)
            {
                money.Sprite.Layer += 0.001f;
                batch.DrawSprite(transform, money.Sprite);
            }
        }

        public static void DrawToy(this SpriteBatch batch, Toy toy)
        {
            var gameState = GameDriver.Instance.State;
            if (gameState == GameState.ClientLeaving || gameState == GameState.WaitingForClient)
                return;

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
        
        public static void DrawHotspot(this SpriteBatch batch, Hotspot spot)
        {
            var scale = spot.Transform.Scale;

            if (GameDriver.Instance.ShowHotspotBox)
            {
                var boundingBox = spot.BoundingBox;
                var width = Math.Abs(boundingBox.Max.X - boundingBox.Min.X);
                var height = Math.Abs(boundingBox.Max.Y - boundingBox.Min.Y);
                spot.Transform.Scale = new Vector2(width, height);
                batch.DrawSprite(spot.Transform, spot.DebugSprite);
            }

            spot.Transform.Scale = scale;
            if (!string.IsNullOrEmpty(spot.Sprite.ImageId))
                batch.DrawSprite(spot.Transform, spot.Sprite);
        }

        public static void DrawSprite(this SpriteBatch spriteBatch, Transform2D transform, Sprite sprite)
        {
            if (string.IsNullOrEmpty(sprite.ImageId))
                return;

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
