using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    /// <summary>
    /// A combatants combat statistics.
    /// </summary>
    public class Stats : Model {

        public List<Statistic> AsList;

        public Stats(int health, int attack, int defense, int speed, int shield, int hits) {

            AsList = new List<Statistic>();
            AsList.Add(healthPoints = new Characters.Statistic(StatisticType.HEALTH, health));
            AsList.Add(attackValue = new Characters.Statistic(StatisticType.ATTACK, attack));
            AsList.Add(defenseValue = new Characters.Statistic(StatisticType.DEFENSE, defense));
            AsList.Add(speedValue = new Characters.Statistic(StatisticType.SPEED, speed));
            AsList.Add(shieldValue = new Characters.Statistic(StatisticType.SHIELD, shield));
            AsList.Add(hitsValue = new Characters.Statistic(StatisticType.HITS, hits));
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

        /// <summary>
        /// The characters shields. This represents how many 'hits' a character can suffer before they can be damaged fully.
        /// </summary>
        private Statistic shieldValue;
        public Statistic Shield {
            get { return shieldValue; }
        }

        /// <summary>
        /// The characters shields. This represents how many 'hits' a character can suffer before they can be damaged fully.
        /// </summary>
        private Statistic hitsValue;
        public Statistic Hits {
            get { return hitsValue; }
        }
    }
}
