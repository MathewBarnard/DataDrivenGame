using MVCGame.MVC.Model.BattleActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.BattleActions {
    public class BattleActionFactory {

        public static BattleAction CreateAction(int id) {

            switch(id) {
                case BattleActions.VALIANT_STRIKE:
                    return new ValiantStrike();
                case BattleActions.DUAL_STRIKE:
                    return new DoubleStrike();
                case BattleActions.AETHER_STRIKE:
                    return new AetherStrike();
                case BattleActions.BUBBLE:
                    return new Bubble();
                default:
                    break;
            }

            return null;
        }
    }
}
