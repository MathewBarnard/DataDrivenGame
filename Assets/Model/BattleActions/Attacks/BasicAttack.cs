using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCGame.System.Math;

namespace MVCGame.MVC.Model.BattleActions {

    public class BasicAttack : SingleTargetAction {

        public override ActionResult ProcessAction() {

            int damageDealt = DamageCalculator.GetInstance().CalculateBasePhysicalDamage(targetCombatant.Stats.Attack.CurrentValue);

            if (damageDealt > 0)
                targetCombatant.Stats.HealthPoints.CurrentValue -= damageDealt;
            else
                damageDealt = 0;

            bool targetKilled;

            if (targetCombatant.Stats.Defense.CurrentValue <= 0) {
                targetKilled = true;
            }
            else {
                targetKilled = false;
            }

            SingleTargetActionResult actionResult = new SingleTargetActionResult(targetKilled, damageDealt);

            return actionResult;
        }
    }
}
