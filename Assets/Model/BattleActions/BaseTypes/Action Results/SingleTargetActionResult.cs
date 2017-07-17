using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {

    public class SingleTargetActionResult : ActionResult {

        private bool enemyKilled;
        public bool EnemyKilled {
            get { return enemyKilled; }
            set { enemyKilled = value; }
        }

        private int damageDealt;
        public int DamageDealt {
            get { return damageDealt; }
            set { damageDealt = value; }
        }

        private int shieldDamageDealt;
        public int ShieldDamageDealt {
            get { return shieldDamageDealt; }
            set { shieldDamageDealt = value; }
        }

        /// <summary>
        /// Default constructor for result.
        /// </summary>
        public SingleTargetActionResult() {
            this.enemyKilled = false;
            this.damageDealt = 0;
            this.shieldDamageDealt = 0;
        }

        /// <summary>
        /// Initialise a SingleTargetActionResult.
        /// </summary>
        /// <param name="enemyKilled">Flag indicating if the enemy was killed by this action.</param>
        /// <param name="damageDealt">How much damage was dealt by the action.</param>
        public SingleTargetActionResult(bool enemyKilled, int damageDealt, int shieldDamageDealt) {
            this.enemyKilled = enemyKilled;
            this.damageDealt = damageDealt;
            this.shieldDamageDealt = shieldDamageDealt;
        }
    }
}
