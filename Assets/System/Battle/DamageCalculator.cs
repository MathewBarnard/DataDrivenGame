using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MVCGame.System.Math {

    public class DamageCalculator {

        public static float LowEndPhysicalDamageMod = 1.1f;
        public static float HighEndPhysicalDamageMod = 1.2f;

        private static DamageCalculator instance = null;

        private UnityEngine.Random randomNumberGenerator;

        public static DamageCalculator GetInstance() {

            if (instance == null) {
                instance = new DamageCalculator();
            }

            return instance;
        }

        public DamageCalculator() {
            randomNumberGenerator = new UnityEngine.Random();
        }

        public int CalculateBasePhysicalDamage(int attack, int attackModifier, int defenseModifier) {

            // Determine low and high ranges
            float lowRange = (float)attack * DamageCalculator.LowEndPhysicalDamageMod;
            float highRange = (float)attack * DamageCalculator.HighEndPhysicalDamageMod;

            float result = UnityEngine.Random.Range(lowRange, highRange);
            result = ((result / 100.0f) * ((float)attackModifier - (float)defenseModifier)) + result;

            return (int)result;
        }

        public int GetShieldDamageReduction(int shieldNumber) {

            if(shieldNumber == 0) {
                return 0;
            }
            else if(shieldNumber == 1) {
                return 40;
            }
            else if (shieldNumber == 2) {
                return 50;
            }
            else if (shieldNumber == 3) {
                return 60;
            }
            else if(shieldNumber == 4) {
                return 65;
            }
            else if(shieldNumber == 5) {
                return 70;
            }
            else {
                return 75;
            }
        }
    }
}
