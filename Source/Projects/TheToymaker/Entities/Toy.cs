using System;
using System.Collections.Generic;
using TheToymaker.Components;

namespace TheToymaker.Entities
{
    [Serializable]
    public class Toy
    {
        public string Name;
        public Sprite LargeSprite;
        public List<ToyDamagePoint> DamagePoints;
    }
}
