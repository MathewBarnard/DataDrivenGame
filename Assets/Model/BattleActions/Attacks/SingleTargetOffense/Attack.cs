using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCGame.System.Math;
using Assets.Model.Characters;
using Assets.Model.BattleActions.BaseTypes;
using MVCGame.MVC.Model.Characters;

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

            // Get the base damage of the attack.
            actionResult.DamageDealt = DamageCalculator.GetInstance().CalculateBasePhysicalDamage(targetCombatant.Stats.Attack.CurrentValue, 
                actingCombatant.Stats.BaseDamageModifier.CurrentValue, 
                targetCombatant.Stats.BaseDefenseModifier.CurrentValue);

            // Shield step: inflict 1 damage to shields.
            if (targetCombatant.Stats.Shield.CurrentValue > 0) {
                targetCombatant.Stats.Shield.CurrentValue -= actingCombatant.Stats.Hits.CurrentValue;
                actionResult.ShieldDamageDealt = actingCombatant.Stats.Hits.CurrentValue;
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

        public override RedirectType GetRedirectType() {
            return RedirectType.NEW_ENEMY_TARGET;
        }

        public override void Redirect(Party party) {

            List<Combatant> targetsInRange = new List<Combatant>();

            targetsInRange = party.PartyMembers;

            targetsInRange = targetsInRange.Where(c => !c.IsDead()).ToList();

            if (targetsInRange.Count > 0) {
                int numTargets = targetsInRange.Count;

                int index = UnityEngine.Random.Range(0, numTargets - 1);

                this.targetCombatant = targetsInRange[index];
            }
        }
        public override string ToString() {
            return "[Attack] [Target:" + this.targetCombatant.Name + "]";
        }
    }
}
