using Assets.Model.BattleActions.BaseTypes;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.Encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Controller {
    public class PreActionController {

        public void CheckActionIsValid(BattleAction action) {

        }

        public void HandleInvalidAction(BattleAction action, RandomEncounter encounterModel) {

            // Check if the acting combatant is an ally or not
            bool isAlly = encounterModel.PlayerParty.PartyMembers.Exists(c => c.Id == action.ActingCombatant.Id);

            Party enemyFromActorPerspective = null;
            Party allyFromActorPerspective = null;

            if(isAlly) {
                allyFromActorPerspective = encounterModel.PlayerParty;
                enemyFromActorPerspective = encounterModel.EnemyParty;
            }
            else {
                allyFromActorPerspective = encounterModel.EnemyParty;
                enemyFromActorPerspective = encounterModel.PlayerParty;
            }

            RedirectType redirect = action.GetRedirectType();

            switch(redirect) {

                case RedirectType.NEW_ENEMY_TARGET:
                    action.Redirect(enemyFromActorPerspective);
                    break;
                case RedirectType.NEW_ALLY_TARGET:
                    action.Redirect(allyFromActorPerspective);
                    break;
            }
        }
    }
}
