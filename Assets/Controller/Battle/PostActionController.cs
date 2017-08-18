using MVCGame.MVC.Model.BattleActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This class controls the logic surrounding what we do after an action is performed. We need to check the result of actions, resolve conditions of 
/// actions, etc.
/// </summary>
namespace Assets.Controller {
    public class PostActionController {

        public void CheckResult(ActionResult result) {

            if (result is SingleTargetActionResult) {

                // The target has been killed. We should clear them from the battlefield
                if((result as SingleTargetActionResult).EnemyKilled) {

                    BattleEvents.ActiveInstance().enemyKilledEventHandler.Invoke(new MVCGame.MVC.Model.Characters.Combatant());
                }
            }
        }
    }
}
