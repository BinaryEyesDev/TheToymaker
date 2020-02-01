using System;
using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    [Serializable]
    public class DeskClock
    {
        public int Hour;
        public int Minute;

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
            _minuteAngle += angle;
            if (_minuteAngle > 0.0f)
            {
                _minuteAngle -= 6.0f;
                if (Minute < 59)
                    Minute += 1;
            }

            CheckHourPassed();
        }

        private void CheckHourPassed()
        {
            if (MinuteHandTransform.Angle <= 360.0f)
                return;

            Hour += 1;
            Minute = 0;
            if (Hour > 24)
                Hour -= 24;

            MinuteHandTransform.Angle -= 360.0f;
            HourHandTransform.Angle += 30.0f;
            if (HourHandTransform.Angle > 360.0f)
                HourHandTransform.Angle -= 360.0f;
        }

        public static DeskClock Initialize(GameDriver driver)
        {
            var path = DataPath.Get("Elements\\DeskClock.json");
            var clock = JsonData.DeserializeFromFile<DeskClock>(path);
            clock.Hour = 8;
            clock.Minute = 0;
            clock.MinuteHandTransform.Angle = 0.0f;
            clock.HourHandTransform.Angle = 240.0f;
            clock._minuteAngle = 0.0f;
            return clock;
        }

        private float _minuteAngle;
    }
}
