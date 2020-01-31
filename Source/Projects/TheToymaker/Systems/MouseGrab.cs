using Discord.Logging;
using Microsoft.Xna.Framework;
using TheToymaker.Components;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class MouseGrab
    {
        public static Transform2D Grabbed;

        public static void Perform(GameDriver driver)
        {
            if (!driver.EditingMode)
                return;

            if (Grabbed == null)
                SearchForGrabbed(driver);
            else
                DragGrabbed(driver);
        }

        private static void DragGrabbed(GameDriver driver)
        {
            if (MouseInput.LeftButtonJustReleased)
            {
                Log.Message("Released: Grabbed");
                Grabbed = null;
                return;
            }

            Grabbed.Position = MouseInput.WorldPosition;
        }

        private static void SearchForGrabbed(GameDriver driver)
        {
            if (!MouseInput.LeftButtonJustPressed)
                return;

            foreach (var hotspot in driver.HotSpots)
            {
                var transform = hotspot.Transform;
                if (!IsGrabbed(transform))
                    continue;

                Log.Message($"Grabbed: Hotspot: {hotspot.Name}");
                Grabbed = transform;
                return;
            }

            foreach (var toy in driver.Toys)
            {
                foreach (var damagePoint in toy.DamagePoints)
                {
                    var transform = damagePoint.Transform;
                    if (!IsGrabbed(transform))
                        continue;

                    Log.Message($"Grabbed: DamagePoint: {damagePoint.Type}");
                    Grabbed = transform;
                }
            }
        }

        private static bool IsGrabbed(Transform2D transform)
        {
            var center = new Vector3(transform.Position.X, transform.Position.Y, 0.0f);

            var boundingMin = center + new Vector3(-10.0f, -10.0f, 0.0f);
            var boundingMax = center + new Vector3(+10.0f, +10.0f, 0.0f);
            var boundingBox = new BoundingBox(boundingMin, boundingMax);

            var worldPosition = new Vector3(MouseInput.WorldPosition.X, MouseInput.WorldPosition.Y, 0.0f);
            var containmentType = boundingBox.Contains(worldPosition);
            var containsMouse = containmentType == ContainmentType.Contains;
            return containsMouse;
        }
    }
}
