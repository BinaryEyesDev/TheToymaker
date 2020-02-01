using TheToymaker.Data;
using TheToymaker.Extensions;
using TheToymaker.Utilities;

namespace TheToymaker.Systems
{
    public static class GenerateNewCustomer
    {
        public static void Perform(GameDriver driver)
        {
            foreach (var toy in driver.Toys)
                toy.Active = false;

            var selectedToy = driver.Toys.GetRandom();
            foreach (var damagePoint in selectedToy.DamagePoints)
            {
                var activationChance = GetRandom.Float(0.0f, 100.0f);
                damagePoint.Active = activationChance < 50.0f;
            }

            selectedToy.Active = true;
            driver.CurrentToy = selectedToy;
            driver.ChangeState(GameState.FixingToy);
        }
    }
}
