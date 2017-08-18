using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    public class Party : Model {

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string formation;
        public string Formation {
            get { return formation; }
            set { formation = value; }
        }

        private List<Combatant> partyMembers;
        public List<Combatant> PartyMembers {
            get 
            {
                List<Combatant> allCombatants = new List<Combatant>();
                allCombatants.AddRange(frontRow);
                allCombatants.AddRange(backRow);
                return allCombatants;
            }
            set { partyMembers = value; }
        }

        private List<Combatant> frontRow;
        public List<Combatant> FrontRow {
            get { return frontRow; }
        }
        private List<Combatant> backRow;
        public List<Combatant> BackRow {
            get { return backRow; }
        }

        public Party() {
            partyMembers = new List<Combatant>();
            frontRow = new List<Combatant>();
            backRow = new List<Combatant>();
        }
    }
}
