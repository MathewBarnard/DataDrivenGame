using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {

    /// <summary>
    /// The abstract class represented an action to be performed during a turn.
    /// </summary>
    public abstract class SingleTargetAction : BattleAction {

        protected Combatant targetCombatant;

        public void SetTarget(Characters.Combatant combatant) {

            this.targetCombatant = combatant;
        }
    }
}
