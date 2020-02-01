using System;
using System.Collections.Generic;
using TheToymaker.Components;

namespace TheToymaker.Entities
{
    [Serializable]
    public class Toy
    {
        [NonSerialized] public string Name;
        public bool Active;
        public Sprite LargeSprite;
        public List<ToyDamagePoint> DamagePoints;
        public bool IsFixed => DamagePoints.TrueForAll(element => !element.Active);
    }
}
