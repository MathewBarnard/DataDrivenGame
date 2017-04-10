using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.System.Math {

    public class DamageCalculator {

        public static float LowEndPhysicalDamageMod = 1.1f;
        public static float HighEndPhysicalDamageMod = 1.2f;

        private static DamageCalculator instance = null;

        private Random randomNumberGenerator;

        public static DamageCalculator GetInstance() {

            if (instance == null) {
                instance = new DamageCalculator();
            }

            return instance;
        }

        public DamageCalculator() {
            randomNumberGenerator = new Random();
        }

        public int CalculateBasePhysicalDamage(int attack) {

            // Determine low and high ranges
            float lowRange = (float)attack * DamageCalculator.LowEndPhysicalDamageMod;
            float highRange = (float)attack * DamageCalculator.HighEndPhysicalDamageMod;

            int result = Convert.ToInt32(randomNumberGenerator.Next(Convert.ToInt32(lowRange), Convert.ToInt32(highRange)));

            return result;
        }
    }
}
