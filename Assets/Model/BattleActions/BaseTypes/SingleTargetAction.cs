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

        public SingleTargetAction(string name) : base(name) { }

        protected Combatant targetCombatant;
        public Combatant TargetCombatant {
            get { return targetCombatant; }
        }

        public void SetTarget(Characters.Combatant combatant) {

            this.targetCombatant = combatant;
        }

        public abstract TargetingType GetTargetType();
    }
}
