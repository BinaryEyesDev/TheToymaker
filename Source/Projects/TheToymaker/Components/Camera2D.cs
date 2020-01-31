using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheToymaker.Components
{
    public class Camera2D
    {
        public Transform2D Transform;
        public Matrix Transformation;

        public void Update(Viewport viewport)
        {
            var positionOffset = new Vector3(-Transform.Position.X, -Transform.Position.Y, 0.0f);
            var viewportOffset = new Vector3(viewport.Width*0.5f, viewport.Height*0.5f, 0.0f);
            var radianAngle = MathHelper.ToRadians(Transform.Angle);

            var positionTranslation = Matrix.CreateTranslation(positionOffset);
            var rotation = Matrix.CreateRotationZ(radianAngle);
            var scale = Matrix.CreateScale(Transform.Scale.X, Transform.Scale.Y, 1.0f);
            var viewportTranslation = Matrix.CreateTranslation(viewportOffset);

            Transformation = positionTranslation*rotation*scale*viewportTranslation;
        }
    }
}
