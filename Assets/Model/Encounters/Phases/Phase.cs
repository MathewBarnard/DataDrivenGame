using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Encounters {

    public class Phase {

        public enum PhaseName { UPKEEP, PLANNING, ACTION };

        protected PhaseName name;
        public PhaseName Name {
            get { return name; }
        }
    }
}
