using Assets.Data.CombatCharacterStatistics.Enemies.Strategies;
using Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Strategies;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Controller {
    public class EnemyTurnController {

        private Party playerParty;
        private Party enemyParty;

        public EnemyTurnController(Party playerParty, Party enemyParty) {
            this.playerParty = playerParty;
            this.enemyParty = enemyParty;
        }

        public List<BattleAction> GetEnemyActions() {

            List<BattleAction> actions = new List<BattleAction>();

            foreach(Combatant enemy in enemyParty.PartyMembers) {

                if (!enemy.IsDead()) {
                    Strategy strategy = StrategyFactory.CreateStrategy(enemy);

                    strategy.SetParties(enemyParty, playerParty);

                    actions.Add(strategy.GetAction());
                }
            }

            return actions;
        }
    }
}
