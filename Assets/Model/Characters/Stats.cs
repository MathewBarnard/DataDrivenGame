using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    /// <summary>
    /// A combatants combat statistics.
    /// </summary>
    public class Stats : Model {

        public Stats(int health, int attack, int defense, int speed) {
            healthPoints = new Characters.Statistic("HealthPoints", health);
            attackValue = new Characters.Statistic("AttackValue", attack);
            defenseValue = new Characters.Statistic("DefenseValue", defense);
            speedValue = new Characters.Statistic("SpeedValue", speed);
        }

        /// <summary>
        /// The characters Health points. Determines how resilient a character is.
        /// </summary>
        private Statistic healthPoints;
        public Statistic HealthPoints {
            get { return healthPoints; }
        }

        /// <summary>
        /// The characters Attack stat. Dictates the damage of physical attacks.
        /// </summary>
        private Statistic attackValue;
        public Statistic Attack {
            get { return attackValue; }
        }

        /// <summary>
        /// The characters Defense stat. Dictates the damage reduction of physical attacks.
        /// </summary>
        private Statistic defenseValue;
        public Statistic Defense {
            get { return defenseValue; }
        }

        /// <summary>
        /// The characters Speed stat. Dictates how often the character is able to act.
        /// </summary>
        private Statistic speedValue;
        public Statistic Speed {
            get { return speedValue; }
        }
    }
}
