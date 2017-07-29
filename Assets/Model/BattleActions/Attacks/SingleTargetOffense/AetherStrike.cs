using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCGame.System.Math;

namespace MVCGame.MVC.Model.BattleActions {

    /// <summary>
    /// Name: Aether Strike
    /// DMG MOD: 150%
    /// PEN MOD: 0%
    /// ACC MOD: 90%
    /// HITS: 1
    /// Notes: Cannot inflict damage to shields.
    /// </summary>
    public class AetherStrike : SingleTargetAction {

        public AetherStrike(string name) : base(name) { }

        public override ActionResult ProcessAction() {

            SingleTargetActionResult actionResult = new SingleTargetActionResult();

            // If the target has no shields
            if (targetCombatant.Stats.Shield.CurrentValue == 0) {
                // Get the base damage of the attack.
                actionResult.DamageDealt = DamageCalculator.GetInstance().CalculateBasePhysicalDamage(targetCombatant.Stats.Attack.CurrentValue);
            }
            else {
                actionResult.DamageDealt = 0;
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

        public override string ToString() {
            return "[AetherStrike] [Target:" + this.targetCombatant.Name + "]";
        }
    }
}
