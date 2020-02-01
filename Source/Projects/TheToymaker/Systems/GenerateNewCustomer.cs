using System.Collections.Generic;
using System.Linq;
using TheToymaker.Data;
using TheToymaker.Entities;
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

            if (driver.WaitingToyLine == null || driver.WaitingToyLine.Count == 0)
                driver.WaitingToyLine = RegenerateToyLine(driver.Toys);

            var selectedToy = driver.WaitingToyLine.PopRandom();
            foreach (var damagePoint in selectedToy.DamagePoints)
            {
                var activationChance = GetRandom.Float(0.0f, 100.0f);
                damagePoint.Active = activationChance < 50.0f;
            }

            selectedToy.Active = true;
            driver.CurrentToy = selectedToy;
            driver.ChangeState(GameState.FixingToy);
        }

        private static List<Toy> RegenerateToyLine(List<Toy> toys)
        {
            toys = toys.ToList();

            var toyLine = new List<Toy>();
            while (toys.Count > 0)
                toyLine.Add(toys.PopRandom());

            return toyLine;
        }
    }
}
