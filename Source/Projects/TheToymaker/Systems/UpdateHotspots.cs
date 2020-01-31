using Microsoft.Xna.Framework;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class UpdateHotspots
    {
        public static void Perform(GameDriver driver)
        {
            foreach (var hotspot in driver.HotSpots)
            {
                var transform = hotspot.Transform;
                var scale = new Vector3(transform.Scale.X, transform.Scale.Y, 1.0f);
                var position = new Vector3(transform.Position.X, transform.Position.Y, 0.0f);

                var boundingMin = Vector3.Multiply(hotspot.BoundingBox.Min, scale) + position;
                var boundingMax = Vector3.Multiply(hotspot.BoundingBox.Max, scale) + position;
                var boundingBox = new BoundingBox(boundingMin, boundingMax);

                var worldPosition = new Vector3(MouseInput.WorldPosition.X, MouseInput.WorldPosition.Y, 0.0f);
                var containmentType = boundingBox.Contains(worldPosition);
                var tint = containmentType == ContainmentType.Contains
                    ? new Color(Color.Green, 0.25f)
                    : new Color(Color.Gray, 0.25f);

                hotspot.DebugSprite.Tint = tint;
            }
        }
    }
}
