using Assets.Model.Characters;
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
        public Guid ID {
            get { return id; }
        }

        private RangeType range;
        public RangeType Range {
            get { return range; }
            set { range = value; }
        }

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

        /// <summary>
        /// This characters moveset
        /// </summary>
        private MoveSet moveSet;
        public MoveSet MoveSet {
            get { return moveSet; }
            set { moveSet = value; }
        }

        public Combatant() {
            id = Guid.NewGuid();
        }
    }
}
