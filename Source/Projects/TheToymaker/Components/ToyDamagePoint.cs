using System;

namespace TheToymaker.Components
{
    [Serializable]
    public class ToyDamagePoint
    {
        public static Transform2D Parent => GameDriver.Instance.GameInterface.ToyLocationInFront;
        public bool Active;
        public string Type;
        public Transform2D Transform;
        public Sprite Sprite;

        public Transform2D GetGlobalTransform()
        {
            _globalTransform.Position = Transform.Position + Parent.Position;
            _globalTransform.Angle = Transform.Angle + Parent.Angle;
            _globalTransform.Scale = Transform.Scale;
            return _globalTransform;
        }

        private Transform2D _globalTransform = new Transform2D();
    }
}
