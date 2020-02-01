using System;
using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    [Serializable]
    public class DeskClock
    {
        public float Rate;
        public Transform2D HourHandTransform;
        public Sprite HourHandSprite;

        public Transform2D MinuteHandTransform;
        public Sprite MinuteHandSprite;

        public void AddMinutes(float value)
        {
            UpdateMinutes(value);
        }

        public void Update(FrameTime time)
        {
            UpdateMinutes(time.Elapsed*20.0f);
        }

        private void UpdateMinutes(float angle)
        {
            MinuteHandTransform.Angle += angle;
            CheckHourPassed();
        }

        private void CheckHourPassed()
        {
            if (MinuteHandTransform.Angle <= 360.0f)
                return;

            MinuteHandTransform.Angle -= 360.0f;
            HourHandTransform.Angle += 30.0f;
            if (HourHandTransform.Angle > 360.0f)
                HourHandTransform.Angle -= 360.0f;
        }

        public static DeskClock Initialize(GameDriver driver)
        {
            var path = DataPath.Get("Elements\\DeskClock.json");
            return JsonData.DeserializeFromFile<DeskClock>(path);
        }
    }
}
