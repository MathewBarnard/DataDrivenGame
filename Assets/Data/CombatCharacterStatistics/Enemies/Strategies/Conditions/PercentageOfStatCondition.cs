using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Conditions {
    public class PercentageOfStatCondition : Condition, IPlayerPartyCondition {

        private Party playerParty;

        private StatisticType statType;
        private int percentage;
        private StatCondition aboveOrBelow;
    
        public void SetPlayerParty(Party playerParty) {
            this.playerParty = playerParty;
        }

        public PercentageOfStatCondition(BattleAction action, StatisticType statType, int percentage, StatCondition aboveOrBelow)
            : base(action) 
        {
            this.statType = statType;
            this.percentage = percentage;
            this.aboveOrBelow = aboveOrBelow;
        }

        public override Combatant HasBeenMet() {

            List<Combatant> potentialTargets = new List<Combatant>();

            foreach(Combatant combatant in playerParty.PartyMembers) {

                Statistic stat = combatant.Stats.AsList.Where(s => s.Type == this.statType).FirstOrDefault();

                if(this.aboveOrBelow == StatCondition.ABOVE) {

                    if(stat.CurrentValue > (stat.MaxValue / 100) * percentage) {
                        potentialTargets.Add(combatant);
                        continue;
                    }
                }
                else {
                    if (stat.CurrentValue < (stat.MaxValue / 100) * percentage) {
                        potentialTargets.Add(combatant);
                    }
                }
            }

            // Randomly select a target
            if (potentialTargets.Count > 0) {
                return potentialTargets[UnityEngine.Random.Range(0, potentialTargets.Count - 1)];
            }
            else
                return null;
        }
    }
}
