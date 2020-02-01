using System;
using TheToymaker.Data;

namespace TheToymaker.Events
{
    public class HotspotClicked
        : EventArgs
    {
        public readonly Hotspot Target;

        public HotspotClicked(Hotspot target)
        {
            Target = target;
        }
    }
}
