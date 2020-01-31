using System;
using System.Collections.Generic;
using TheToymaker.Components;

namespace TheToymaker.Entities
{
    [Serializable]
    public class Toy
    {
        public bool Active;
        public string Name { get; set; }
        public Sprite LargeSprite;
        public List<ToyDamagePoint> DamagePoints;
    }
}
