using System;

namespace TheToymaker.Components
{
    [Serializable]
    public class ToyDamagePoint
    {
        public bool Active;
        public string Type;
        public Transform2D Transform;
        public Sprite Sprite;
    }
}
