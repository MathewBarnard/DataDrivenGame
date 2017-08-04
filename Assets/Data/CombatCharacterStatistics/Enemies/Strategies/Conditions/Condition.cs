using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Conditions {
    public abstract class Condition {

        protected BattleAction actionToPerform;
        public BattleAction ActionToPerform {
            get { return actionToPerform; }
        }

        public Condition(BattleAction actionToPerform) {
            this.actionToPerform = actionToPerform;
        }

        /// <summary>
        /// An abstract function used to determine if the condition has been met.
        /// </summary>
        /// <returns></returns>
        public abstract Combatant HasBeenMet();
    }

    public enum StatCondition { ABOVE, BELOW, EQUAL };
}
