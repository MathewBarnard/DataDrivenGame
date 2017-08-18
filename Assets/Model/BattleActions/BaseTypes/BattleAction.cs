using Assets.Model.BattleActions.BaseTypes;
using Assets.Model.Characters;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {

    public enum TargetingType { ENEMY, ALLY, ALL, SELF };

    /// <summary>
    /// This is the abstract class that represents a combatant within a battle.
    /// </summary>
    public abstract class BattleAction : Model {

        protected RangeType range;
        public virtual RangeType Range {
            get { return range; }
        }

        protected string name;
        public string Name {
            get { return name; }
        }

        // The combatant who is performing this action
        protected Combatant actingCombatant;
        public Combatant ActingCombatant {
            get { return actingCombatant; }
        }

        public abstract bool CheckActionStillValid();
  
        public abstract ActionResult ProcessAction();

        public BattleAction(string name) {
            this.name = name;
        }

        public void SetActingCombatant(Combatant actingCombatant) {
            this.actingCombatant = actingCombatant;
        }

        /// <summary>
        /// Dynamically sets the target of a battle action based on the type of the provided action
        /// </summary>
        public static void SetTarget(BattleAction action, Combatant combatant) {

            if(action is SingleTargetAction) {
                (action as SingleTargetAction).SetTarget(combatant);
            }
        }

        public abstract void Redirect(Party party);

        public abstract RedirectType GetRedirectType();
    }
}
