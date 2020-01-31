using System.Collections.Generic;
using Discord.Logging;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Utilities;

namespace TheToymaker.Data
{
    public class TextureBank
    {
        public Texture2D GetTexture(string id)
        {
            return _textures[id];
        }

        public TextureBank Initialize(GameDriver driver)
        {
            Log.Message("Initializing: Texture Bank");
            _textures = new Dictionary<string, Texture2D>();

            var pathMapPath = DataPath.Get("TextureBank.json");
            var pathMap = JsonData.DeserializeFromFile<StringConfiguration>(pathMapPath);
            foreach (var entry in pathMap)
            {
                var texture = driver.Content.Load<Texture2D>(entry.Value);
                _textures.Add(entry.Key, texture);
            }

            return this;
        }

        private Dictionary<string, Texture2D> _textures;
    }
}
