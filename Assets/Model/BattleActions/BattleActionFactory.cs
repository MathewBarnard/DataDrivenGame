using MVCGame.MVC.Model.BattleActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {
    public class BattleActionFactory {

        public static BattleAction CreateAction(int id) {

            switch(id) {
                case BattleActions.ATTACK:
                    return new Attack("Attack");
                default:
                    break;
            }

            return null;
        }
    }
}
