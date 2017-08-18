using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Buffs {
    public abstract class Buff {

        protected Combatant affectedCombatant;

        public Buff(Combatant combatant) {
            this.affectedCombatant = combatant;
        }

        public abstract void Apply();
        public abstract void Remove();
    }
}
