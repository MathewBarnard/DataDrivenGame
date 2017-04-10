using MVCGame.MVC.Model.BattleActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Encounters {

    public class PlanningPhase : Phase {

        private List<BattleAction> actionsToPerform;
        public List<BattleAction> ActionsToPerform {
            get { return actionsToPerform; }
        }

        public PlanningPhase() {
            this.name = PhaseName.PLANNING;
            actionsToPerform = new List<BattleAction>();
        }
    }
}
