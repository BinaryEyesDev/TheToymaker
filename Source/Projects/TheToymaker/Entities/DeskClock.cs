using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    public class DeskClock
    {
        public Transform2D HourHandTransform;
        public Sprite HourHandSprite;

        public Transform2D MinuteHandTransform;
        public Sprite MinuteHandSprite;

        public void Update(FrameTime time)
        {
            MinuteHandTransform.Angle += time.Elapsed*15.0f;
            if (MinuteHandTransform.Angle > 360.0f)
            {
                MinuteHandTransform.Angle -= 360.0f;
                HourHandTransform.Angle += 30.0f;
                if (HourHandTransform.Angle > 360.0f)
                    HourHandTransform.Angle -= 360.0f;
            }
        }

        public static DeskClock Initialize(GameDriver driver)
        {
            var path = DataPath.Get("Elements\\DeskClock.json");
            return JsonData.DeserializeFromFile<DeskClock>(path);
        }
    }
}
