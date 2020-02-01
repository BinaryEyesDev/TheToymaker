using System.Linq;
using Discord.Logging;
using Microsoft.Xna.Framework;
using TheToymaker.Data;
using TheToymaker.Utilities;

namespace TheToymaker.Systems
{
    public static class HandleHotspotInteraction
    {
        public static Vector2 StartPosition;
        public static Hotspot Current;
        public static Vector2 CurrentPosition => Current.Transform.Position;

        public static void Perform(GameDriver driver)
        {
            if (driver.EditingMode)
                return;

            if (Current != null)
                DragCurrentTools();
            else
                WaitForPlayerToPickupTool(driver);
        }

        private static void DragCurrentTools()
        {
            if (MouseInput.LeftButtonJustReleased)
            {
                Log.Message($"Released: Hotspot: {Current.Name}");
                Current.Transform.Position = StartPosition;
                Current = null;
                return;
            }

            Current.Transform.Position = MouseInput.WorldPosition;
            var toolPosition = new Vector3(CurrentPosition.X, CurrentPosition.Y, 0.0f);
            var toolMin = Current.BoundingBox.Min + toolPosition;
            var toolMax = Current.BoundingBox.Max + toolPosition;
            var toolBounds = new BoundingBox(toolMin, toolMax);

            foreach (var toy in GameDriver.Instance.Toys)
            {
                foreach (var damageModel in toy.DamagePoints.Where(element => element.Active))
                {
                    var pointTransform = damageModel.GetGlobalTransform();
                    var pointCenter = new Vector3(pointTransform.Position.X, pointTransform.Position.Y, 0.0f);
                    
                    var pointMin = pointCenter + new Vector3(-20.0f, -20.0f, 0.0f);
                    var pointMax = pointCenter + new Vector3(+20.0f, +20.0f, 0.0f);
                    var pointBounds = new BoundingBox(pointMin, pointMax);

                    if (!toolBounds.Intersects(pointBounds))
                        continue;

                    if (Current.DamageTarget != damageModel.Type)
                        continue;

                    damageModel.Active = false;
                    var timeSpent = GetRandom.Float(Current.ActivationTime, -5.0f, +5.0f);
                    GameDriver.Instance.Clock.AddMinutes(timeSpent);
                }
            }
        }

        private static void WaitForPlayerToPickupTool(GameDriver driver)
        {
            if (!MouseInput.LeftButtonJustPressed)
                return;

            var worldPosition = new Vector3(MouseInput.WorldPosition.X, MouseInput.WorldPosition.Y, 0.0f);
            foreach (var hotspot in driver.HotSpots)
            {
                var transform = hotspot.Transform;
                var position = new Vector3(transform.Position.X, transform.Position.Y, 0.0f);

                var boundingMin = hotspot.BoundingBox.Min + position;
                var boundingMax = hotspot.BoundingBox.Max + position;
                var boundingBox = new BoundingBox(boundingMin, boundingMax);

                var containmentType = boundingBox.Contains(worldPosition);
                var containsMouse = containmentType == ContainmentType.Contains;
                hotspot.DebugSprite.Tint = containsMouse ? new Color(0.1f, 1.0f, 0.1f, 0.25f) : new Color(1.0f, 1.0f, 1.0f, 0.25f);
                if (!containsMouse)
                    continue;

                if (string.IsNullOrEmpty(hotspot.DamageTarget))
                    continue;

                Log.Debug($"Hotspot Pressed: {hotspot.Name}");
                Current = hotspot;
                StartPosition = transform.Position;
            }
        }
    }
}
