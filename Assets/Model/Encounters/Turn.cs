using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Encounters {

    public class Turn {

        // The combatants that are acting this turn.
        private List<Combatant> actingCombatants;
        public List<Combatant> ActingCombatants {
            get { return actingCombatants; }
            set { actingCombatants = value; }
        }

        // The current phase of this turn.
        private Phase currentPhase;
        public Phase CurrentPhase {
            get { return currentPhase; }
        }

        // The upkeep phase of this turn
        private UpkeepPhase upkeepPhase;
        public UpkeepPhase UpkeepPhase {
            get { return upkeepPhase; }
        }

        // The planning phase of this turn
        private PlanningPhase planningPhase;
        public PlanningPhase PlanningPhase {
            get { return planningPhase; }
        }

        // The action phase of this turn
        private ActionPhase actionPhase;
        public ActionPhase ActionPhase {
            get { return actionPhase; }
        }

        // A turn always begins on upkeep
        public Turn(List<Combatant> actingCombatants) {
            ActingCombatants = actingCombatants;
            upkeepPhase = new UpkeepPhase();
            currentPhase = upkeepPhase;
        }

        public Phase NextPhase() {

            switch (currentPhase.Name) {

                case Phase.PhaseName.UPKEEP:
                    planningPhase = new PlanningPhase();
                    currentPhase = planningPhase;
                    break;
                case Phase.PhaseName.PLANNING:
                    actionPhase = new ActionPhase(planningPhase.ActionsToPerform);
                    break;
                case Phase.PhaseName.ACTION:
                    break;
                default:
                    break;
            }


            return currentPhase;
        }

        public void BeginTurn() {

            // Returns a list of all combatants that can act this turn
            actingCombatants = upkeepPhase.GetCombatantsToAct(actingCombatants);

            NextPhase();
        }
    }
}
