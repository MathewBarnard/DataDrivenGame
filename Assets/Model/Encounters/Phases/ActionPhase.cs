using MVCGame.MVC.Model.BattleActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Encounters {

    public class ActionPhase : Phase {

        private List<BattleAction> actionsToPerform;
        public List<BattleAction> ActionsToPerform {
            get { return actionsToPerform; }
        }

        public ActionPhase(List<BattleAction> actionsToPerform) {
            this.name = PhaseName.ACTION;
            this.actionsToPerform = actionsToPerform;
        }
    }
}
