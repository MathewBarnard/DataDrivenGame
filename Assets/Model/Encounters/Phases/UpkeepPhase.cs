using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Encounters {

    public class UpkeepPhase : Phase {

        public UpkeepPhase() {
            this.name = PhaseName.UPKEEP;
        }
    }
}
