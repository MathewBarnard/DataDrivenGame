using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {

    /// <summary>
    /// This is the abstract class that represents a combatant within a battle.
    /// </summary>
    public abstract class BattleAction : Model {

        // The combatant who is performing this action
        protected Combatant actingCombatant;

        public abstract ActionResult ProcessAction();

        public void SetActingCombatant(Combatant actingCombatant) {
            this.actingCombatant = actingCombatant;
        }
    }
}
