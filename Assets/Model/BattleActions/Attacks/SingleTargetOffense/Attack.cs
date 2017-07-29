using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCGame.System.Math;
using Assets.Model.Characters;

namespace MVCGame.MVC.Model.BattleActions {

    /// <summary>
    /// Name: Valiant Strike
    /// DMG MOD: 100%
    /// PEN MOD: 10%
    /// ACC MOD: 100%
    /// HITS: 1
    /// Notes: None
    /// </summary>
    public class Attack : SingleTargetAction {

        public Attack(string name) : base(name) { }

        public override RangeType Range {
            get { return RangeType.INHERIT; }
        }

        public override ActionResult ProcessAction() {

            SingleTargetActionResult actionResult = new SingleTargetActionResult();

            // Shield step: inflict 1 damage to shields.
            if (targetCombatant.Stats.Shield.CurrentValue > 0) {
                targetCombatant.Stats.Shield.CurrentValue -= 1;
                actionResult.ShieldDamageDealt = 1;
            }

            // Get the base damage of the attack.
            actionResult.DamageDealt = DamageCalculator.GetInstance().CalculateBasePhysicalDamage(targetCombatant.Stats.Attack.CurrentValue);

            if(actionResult.ShieldDamageDealt > 0)
                actionResult.DamageDealt = actionResult.DamageDealt / 10;

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
            return "[ValiantStrike] [Target:" + this.targetCombatant.Name + "]";
        }
    }
}
