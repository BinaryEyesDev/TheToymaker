using System;
using Discord.Logging;
using TheToymaker.Components;
using TheToymaker.Utilities;

namespace TheToymaker.Entities
{
    [Serializable]
    public class GameInterface
    {
        public Sprite TableSprite;
        public Transform2D TableTransform;
        
        public Sprite Square;
        public Transform2D ToyLocationOnTable;
        public Transform2D ToyLocationInFront;

        public static GameInterface Initialize(GameDriver driver)
        {
            Log.Message("Initializing: Game Interface");
            var path = DataPath.Get("UI\\GameUI.json");
            return JsonData.DeserializeFromFile<GameInterface>(path);
        }
    }
}
