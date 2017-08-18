using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Buffs {
    public class FrontRow : Buff {

        // Buff values as a percentage
        private int baseDamageMod;
        private int baseDefenseMod;

        public FrontRow(Combatant combatant, int damageMod = 10, int defenseMod = 10) : base(combatant) {
            this.baseDamageMod = damageMod;
            this.baseDefenseMod = defenseMod;
        }

        public override void Apply() {
            this.affectedCombatant.Stats.BaseDamageModifier.CurrentValue += baseDamageMod;
            this.affectedCombatant.Stats.BaseDefenseModifier.CurrentValue += baseDefenseMod;
        }

        public override void Remove() {
            this.affectedCombatant.Stats.BaseDamageModifier.CurrentValue += baseDamageMod;
            this.affectedCombatant.Stats.BaseDefenseModifier.CurrentValue += baseDefenseMod;
        }

    }
}
