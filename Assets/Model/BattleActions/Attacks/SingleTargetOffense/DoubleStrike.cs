using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCGame.System.Math;

namespace MVCGame.MVC.Model.BattleActions {

    /// <summary>
    /// Name: Double Strike
    /// DMG MOD: 60%
    /// PEN MOD: 5%
    /// ACC MOD: 100%
    /// HITS: 2
    /// Notes: None
    /// </summary>
    public class DoubleStrike : SingleTargetAction {

        public override ActionResult ProcessAction() {

            SingleTargetActionResult actionResult = new SingleTargetActionResult();

            // Two full attacks are performed.
            for (int i = 0; i < 2; i++) {

                bool shieldHit = false;

                if(targetCombatant.Stats.Shield.CurrentValue > 0) {
                    targetCombatant.Stats.Shield.CurrentValue -= 1;
                    actionResult.ShieldDamageDealt += 1;
                    shieldHit = true;
                }

                int damage = actionResult.DamageDealt = DamageCalculator.GetInstance().CalculateBasePhysicalDamage(targetCombatant.Stats.Attack.CurrentValue);

                if (shieldHit)
                    actionResult.DamageDealt += damage / 20;
            }

            if (actionResult.DamageDealt > 0)
                targetCombatant.Stats.HealthPoints.CurrentValue -= actionResult.DamageDealt;
            else
                actionResult.DamageDealt = 0;

            if (targetCombatant.Stats.HealthPoints.CurrentValue <= 0) {
                actionResult.EnemyKilled = true;
            }
            else {
                actionResult.EnemyKilled = false;
            }

            return actionResult;
        }

        public override TargetingType GetTargetType() {
            return TargetingType.ENEMY;
        }
    }
}