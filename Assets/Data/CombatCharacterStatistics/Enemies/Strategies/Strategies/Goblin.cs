using Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Conditions;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Strategies {
    public class Goblin : Strategy {

        public Goblin(Combatant actingCombatant) 
            :base(actingCombatant) {
            // Priority is dictated by the order that the conditions have been added.
            this.conditions.Add(new PercentageOfStatCondition(BattleActionFactory.CreateAction(0), StatisticType.HEALTH, 1, StatCondition.ABOVE));
        }

        public override BattleAction GetAction() {

            BattleAction actionToPerform = null;
           
            foreach(Condition condition in this.conditions) {
                Combatant combatant = condition.HasBeenMet();

                if(combatant != null) { 
                    actionToPerform = condition.ActionToPerform;
                    actionToPerform.SetActingCombatant(this.actingCombatant);
                    BattleAction.SetTarget(actionToPerform, combatant);
                }
            }

            return actionToPerform;
        }

        public override BattleAction DefaultAction() {
            return null;
        }
    }
}
