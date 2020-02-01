using System;
using TheToymaker.Data;

namespace TheToymaker.Events
{
    public class GameStateChanged
        : EventArgs
    {
        public readonly GameState Previous;
        public readonly GameState Current;

        public GameStateChanged(GameState previous, GameState current)
        {
            Previous = previous;
            Current = current;
        }
    }
}
