using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    public class Money
    {
        public int Value;
        public Sprite Sprite;
        public List<Transform2D> Transforms;

        public static Money Initialize(GameDriver driver)
        {
            return new Money
            {
                Value = 0,
                Transforms = new List<Transform2D>(),
                Sprite = new Sprite
                {
                    ImageId = "MoneyBill",
                    Tint = Color.White,
                    Layer = 0.55f,
                    Pivot = new Vector2(0.5f, 0.5f),
                    Effects = SpriteEffects.None
                },
            };
        }

        public void AddMoney(int value)
        {
            Value += value;
            if (Value > 10)
                return;

            var center = GameDriver.Instance.GameInterface.MoneyLocation.Position;
            var transform = new Transform2D
            {
                Angle = GetRandom.Float(0.0f, 359.0f),
                Position = new Vector2(
                    GetRandom.Float(center.X, -10.0f, +10.0f),
                    GetRandom.Float(center.Y, -10.0f, +10.0f)),

                Scale = new Vector2(
                    GetRandom.Float(0.2f, -0.05f, +0.05f),
                    GetRandom.Float(0.2f, -0.05f, +0.05f)),
            };

            Transforms.Add(transform);
        }
    }
}
