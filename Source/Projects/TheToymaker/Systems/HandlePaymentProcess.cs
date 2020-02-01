using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class HandlePaymentProcess
    {
        public static float Delay;
        public static bool Paid;

        public static void Perform(GameDriver driver, FrameTime time)
        {
            if (!Paid)
            {
                driver.Money.AddMoney(1);
                Paid = true;
            }

            if (Delay > 0.0f)
            {
                Delay -= time.Elapsed;
                return;
            }

            driver.CurrentToy.Active = false;
            driver.ChangeState(GameState.ClientLeaving);
        }
    }
}
