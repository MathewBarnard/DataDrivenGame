using Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Conditions;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Strategies {
    public abstract class Strategy {

        protected Combatant actingCombatant;
        protected List<Condition> conditions;
        protected Party enemyParty;
        protected Party playerParty;

        public Strategy(Combatant actingCombatant) {
            conditions = new List<Condition>();
            this.actingCombatant = actingCombatant;
        }

        public virtual void SetParties(Party enemyParty, Party playerParty) {
            this.enemyParty = enemyParty;
            this.playerParty = playerParty;
            this.WireUpConditions();
        }

        public virtual void WireUpConditions() {

            foreach(Condition condition in this.conditions) {

                if(condition is IPlayerPartyCondition) {
                    (condition as IPlayerPartyCondition).SetPlayerParty(playerParty);
                }
            }
        }

        public abstract BattleAction DefaultAction();

        public abstract BattleAction GetAction();
    }
}
