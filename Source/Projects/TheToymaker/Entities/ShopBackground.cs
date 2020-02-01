using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;

namespace TheToymaker.Entities
{
    public class ShopBackground
    {
        public Transform2D Transform;
        public Sprite Sprite;

        public static ShopBackground Initialize(GameDriver driver)
        {
            return new ShopBackground
            {
                Transform = Transform2D.Identity,
                Sprite = new Sprite
                {
                    ImageId = "ShopBackground",
                    Tint = Color.RosyBrown,
                    Layer = 0.0001f,
                    Pivot = new Vector2(0.5f, 0.5f),
                    Effects = SpriteEffects.None,
                },
            };
        }
    }
}
