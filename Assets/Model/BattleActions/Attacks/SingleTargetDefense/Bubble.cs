using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCGame.System.Math;


namespace MVCGame.MVC.Model.BattleActions {
    public class Bubble : SingleTargetAction {

        public Bubble(string name) : base(name) { }

        public static TargetingType targetingType = TargetingType.ALLY;

        public override ActionResult ProcessAction() {

            SingleTargetActionResult actionResult = new SingleTargetActionResult();

            if(targetCombatant.Stats.Shield.CurrentValue < targetCombatant.Stats.Shield.MaxValue)
                targetCombatant.Stats.Shield.CurrentValue += 1;

            actionResult.DamageDealt = 0;
            actionResult.EnemyKilled = false;
            actionResult.ShieldDamageDealt = -1;

            return actionResult;
        }


        public override TargetingType GetTargetType() {
            return TargetingType.ALLY;
        }

        public override string ToString() {
            return "[Bubble] [Target:" + this.targetCombatant.Name + "]";
        }
    }
}
