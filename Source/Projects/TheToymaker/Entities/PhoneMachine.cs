using System;
using Discord.Logging;
using TheToymaker.Systems;

namespace TheToymaker.Entities
{
    public class PhoneMachine
    {
        public StateType State;

        public PhoneMachine()
        {
            HandleHotspotInteraction.Clicked += (sender, args) => Log.Message($"Clicked: {args.Target.Name}");
        }

        public static PhoneMachine Initialize(GameDriver driver)
        {
            return new PhoneMachine();
        }

        public enum StateType
        {
            Silent,
            Ringing,
            Talking,
        }
    }
}
