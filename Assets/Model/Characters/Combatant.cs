using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    /// <summary>
    /// This is the abstract class that represents a combatant within a battle.
    /// </summary>
    public class Combatant : Model {

        // The characters unique battle ID
        private Guid id;

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// The combatants stats.
        /// </summary>
        private Stats stats;
        public Stats Stats {
            get { return stats; }
            set { stats = value; }
        }
    }
}
