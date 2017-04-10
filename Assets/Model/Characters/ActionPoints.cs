using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    public class ActionPoints {

        private int currentActionPoints;
        public int CurrentActionPoints {
            get { return currentActionPoints; }
        }

        private int actionPointsPerTurn;
        public int ActionPointsPerTurn {
            get { return actionPointsPerTurn; }
        }

        public ActionPoints(int speedIncrement) {
            currentActionPoints = speedIncrement / 2;
            actionPointsPerTurn = speedIncrement;
        }

        // Adds action points to this character that reflects their speed at the point of the Upkeep phase
        public int AddActionPointsForTurn() {

            currentActionPoints += actionPointsPerTurn;

            return currentActionPoints;
        }
    }
}
