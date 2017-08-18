using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Controller {

    public delegate void EnemyKilled(Combatant combatant);
    public delegate void BattleStart();

    public class BattleEvents {

        public BattleStart battleStartEventHandler;
        public EnemyKilled enemyKilledEventHandler;

        private static BattleEvents battleEventManager;

        public static BattleEvents ActiveInstance() {
            if(battleEventManager == null) {
                battleEventManager = new BattleEvents();
            }

            return battleEventManager;
        }

        public void onBattleStart() {
            battleStartEventHandler.Invoke();
        }

        public void OnEnemyKilled(Combatant combatant) {
            enemyKilledEventHandler.Invoke(combatant);
        }
    }
}
