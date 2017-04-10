using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    public class Party : Model {

        public Party() {
            partyMembers = new List<Combatant>();
        }

        private List<Combatant> partyMembers;
        public List<Combatant> PartyMembers {
            get { return partyMembers; }
            set { partyMembers = value; }
        }
    }
}
