using Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Strategies;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.CombatCharacterStatistics.Enemies.Strategies {
    public class StrategyFactory {

        public static Strategy CreateStrategy(Combatant combatant) {

            switch (combatant.Name) {
                case "Goblin":
                case "goblin":
                    return new Goblin(combatant);
                default:
                    break;
            }

            return null;
        }
    }
}
