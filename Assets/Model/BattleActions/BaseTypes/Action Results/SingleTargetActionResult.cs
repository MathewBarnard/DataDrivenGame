using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {

    public class SingleTargetActionResult : ActionResult {

        private bool enemyKilled;
        public bool EnemyKilled {
            get { return enemyKilled; }
        }

        private int damageDealt;
        public int DamageDealt {
            get { return damageDealt; }
        }

        /// <summary>
        /// Initialise a SingleTargetActionResult.
        /// </summary>
        /// <param name="enemyKilled">Flag indicating if the enemy was killed by this action.</param>
        /// <param name="damageDealt">How much damage was dealt by the action.</param>
        public SingleTargetActionResult(bool enemyKilled, int damageDealt) {
            this.enemyKilled = enemyKilled;
            this.damageDealt = damageDealt;
        }
    }
}
