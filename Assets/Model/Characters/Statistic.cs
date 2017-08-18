using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    public class Statistic : Model {

        public Statistic(StatisticType type, int defaultValue) {
            this.type = type;
            this.defaultValue   = defaultValue;
            this.currentValue   = defaultValue;
            this.maxValue       = defaultValue;
        }

        private StatisticType type;
        public StatisticType Type {
            get { return type; }
        }

        /// <summary>
        /// The name of this stat.
        /// </summary>
        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// The current value of the stat.
        /// </summary>
        private int currentValue;
        public int CurrentValue {
            get { return currentValue; }
            set { currentValue = value; }
        }

        /// <summary>
        /// The characters max of this stat.
        /// </summary>
        private int maxValue;
        public int MaxValue {
            get { return maxValue; }
            set { maxValue = value; }
        }

        /// <summary>
        /// The characters default health points. 
        /// </summary>
        private readonly int defaultValue;
        public int DefaultValue {
            get { return defaultValue; }
        }
    }

    public enum StatisticType       
    {
        HEALTH,
        ATTACK,
        DEFENSE,
        SPEED,
        SHIELD,
        HITS,
        BASE_DAM_MOD,
        BASE_DAM_RED
    };
}
