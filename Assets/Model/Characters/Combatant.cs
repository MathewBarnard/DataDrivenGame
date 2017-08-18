using Assets.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    /// <summary>
    /// This is the abstract class that represents a combatant within a battle.
    /// </summary>
    public class Combatant : Model {

        /// <summary>
        /// The combatants stats.
        /// </summary>
        private Stats stats;
        public Stats Stats {
            get { return stats; }
            set { stats = value; }
        }

        /// <summary>
        /// This characters moveset
        /// </summary>
        private MoveSet moveSet;
        public MoveSet MoveSet {
            get { return moveSet; }
            set { moveSet = value; }
        }

        /// <summary>
        /// This characters currently active buffs/debuffs.
        /// </summary>
        private BuffSet buffSet;
        public BuffSet BuffSet {
            get { return buffSet; }
            set { buffSet = value; }
        }

        public bool IsDead() {
            if(this.stats.HealthPoints.CurrentValue <= 0) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
