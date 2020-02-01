using Discord.Logging;
using Microsoft.Xna.Framework;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class UpdateHotspots
    {
        public static void Perform(GameDriver driver)
        {
            if (driver.EditingMode)
                return;

            foreach (var hotspot in driver.HotSpots)
            {
                var transform = hotspot.Transform;
                var position = new Vector3(transform.Position.X, transform.Position.Y, 0.0f);

                var boundingMin = hotspot.BoundingBox.Min + position;
                var boundingMax = hotspot.BoundingBox.Max + position;
                var boundingBox = new BoundingBox(boundingMin, boundingMax);

                var worldPosition = new Vector3(MouseInput.WorldPosition.X, MouseInput.WorldPosition.Y, 0.0f);
                var containmentType = boundingBox.Contains(worldPosition);
                var containsMouse = containmentType == ContainmentType.Contains;
                hotspot.DebugSprite.Tint = containsMouse ? new Color(0.1f, 1.0f, 0.1f, 0.25f)  : new Color(1.0f, 1.0f, 1.0f, 0.25f);

                if (MouseInput.LeftButtonJustPressed && containsMouse)
                    Log.Debug($"Hotspot Pressed: {hotspot.Name}");
            }
        }
    }
}
