using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Encounters {

    public class UpkeepPhase : Phase {

        public UpkeepPhase() {
            this.name = PhaseName.UPKEEP;
        }

        // Increase the action points of the party who are next to act
        public List<Combatant> GetCombatantsToAct(List<Combatant> party) {

            List<Combatant> combatantsToAct = new List<Combatant>();

            foreach(Combatant combatant in party) {

                combatant.ActionPoints.AddActionPointsForTurn();

                if(combatant.ActionPoints.CurrentActionPoints > RandomEncounter.ActionPointCap) {
                    combatantsToAct.Add(combatant);
                }
            }

            return combatantsToAct;
        }
    }
}
