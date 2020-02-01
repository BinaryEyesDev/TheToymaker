using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;

namespace TheToymaker.Entities
{
    public class Customer
    {
        public Sprite Sprite;
        public Transform2D Transform;

        public static Customer Initialize(GameDriver driver)
        {
            return new Customer
            {
                Transform = Transform2D.Identity,
                Sprite = new Sprite
                {
                    ImageId = "",
                    Tint = Color.White,
                    Layer = 0.01f,
                    Pivot = new Vector2(0.5f, 1.0f),
                    Effects = SpriteEffects.None,
                },
            };
        }
    }
}
