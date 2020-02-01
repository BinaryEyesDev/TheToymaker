using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class HandlePaymentProcess
    {
        public static void Perform(GameDriver driver)
        {
            driver.Money.AddMoney(1);
            driver.ChangeState(GameState.ClientLeaving);
        }
    }
}
