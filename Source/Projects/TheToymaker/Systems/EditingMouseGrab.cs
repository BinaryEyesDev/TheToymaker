using Discord.Logging;
using Microsoft.Xna.Framework;
using TheToymaker.Components;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class EditingMouseGrab
    {
        public static Transform2D Parent;
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
                Parent = null;
                Grabbed = null;
                return;
            }

            if (Parent == null)
                Grabbed.Position = MouseInput.WorldPosition;
            else
                Grabbed.Position = MouseInput.WorldPosition - Parent.Position;
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

                Grab(transform, null, $"Hotspot: {hotspot.Name}");
                return;
            }

            foreach (var toy in driver.Toys)
            {
                foreach (var damagePoint in toy.DamagePoints)
                {
                    var transform = damagePoint.Transform;
                    if (!IsGrabbed(damagePoint.GetGlobalTransform())) 
                        continue;

                    Grab(transform, GameDriver.Instance.GameInterface.ToyLocationInFront,  $"DamagePoint: {damagePoint.Type}");
                    return;
                }
            }

            if (IsGrabbed(driver.Clock.HourHandTransform))
                Grab(driver.Clock.HourHandTransform, null, "Clock: Hour Hand");
            else if (IsGrabbed(driver.Clock.MinuteHandTransform))
                Grab(driver.Clock.MinuteHandTransform, null, "Clock: Minute Hand");
        }

        private static void Grab(Transform2D target, Transform2D parent, string msg)
        {
            Log.Message($"Grabbed: {msg}");
            Parent = parent;
            Grabbed = target;
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
