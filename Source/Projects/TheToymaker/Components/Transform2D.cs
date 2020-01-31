using Microsoft.Xna.Framework;

namespace TheToymaker.Components
{
    public class Transform2D
    {
        public Vector2 Position;
        public Vector2 Scale;
        public float Angle;

        public static Transform2D Identity =>
            new Transform2D
            {
                Position = new Vector2(0.0f, 0.0f),
                Scale = new Vector2(1.0f, 1.0f),
                Angle = 0.0f,
            };
    }
}
