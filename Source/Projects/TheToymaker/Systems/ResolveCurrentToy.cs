using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class ResolveCurrentToy
    {
        public static void Perform(GameDriver driver)
        {
            var currentToy = driver.CurrentToy;
            if (!currentToy.IsFixed)
                return;

            HandleHotspotInteraction.SendCurrentToolToStart();
            driver.ChangeState(GameState.ClientPayment);
        }
    }
}
