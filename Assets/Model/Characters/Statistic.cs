using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    public class Statistic : Model {

        public Statistic(string name, int defaultValue) {
            this.name = name;
            this.defaultValue   = defaultValue;
            this.currentValue   = defaultValue;
            this.maxValue       = defaultValue;
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
}
