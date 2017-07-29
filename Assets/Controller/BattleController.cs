using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The main interface for the player during battles.
/// </summary>
namespace Assets.Controller {
    public class BattleController : MonoBehaviour {

        private RandomEncounter randomEncounterModel;
        public RandomEncounter RandomEncounterModel {
            get { return randomEncounterModel; }
        }

        private List<BattleAction> actions;

        private TakeTurnController takeTurnController;

        private int combatantIndex;

        private void Awake() {

            actions = new List<BattleAction>();
            randomEncounterModel = new RandomEncounter("TestParty", "TestEnemyParty");
            combatantIndex = 0;

            this.Begin();
        }

        private void Begin() {

            NextCombatant();
        }

        public void Update() {

            // Keep checking to see if the turn controller. If it has finished, we store the action and move to the next combatant.
            if(takeTurnController != null && takeTurnController.isFinished) {
                actions.Add(this.takeTurnController.Action);
                Destroy(this.takeTurnController);
                this.takeTurnController = null;

                NextCombatant();
            }
        }

        private void NextCombatant() {

            if (combatantIndex == randomEncounterModel.PlayerParty.PartyMembers.Count)
                ProcessActions();
            else {
                // Set up the controller for this characters turn
                this.takeTurnController = this.gameObject.AddComponent<TakeTurnController>();
                this.takeTurnController.RandomEncounterModel = randomEncounterModel;
                this.takeTurnController.Combatant = randomEncounterModel.PlayerParty.PartyMembers[combatantIndex];

                // Increase te index so that we move to the next combatant on the next pass
                if (combatantIndex < randomEncounterModel.PlayerParty.PartyMembers.Count)
                    combatantIndex += 1;
            }
        }

        private void ProcessActions() {

            List<ActionResult> actionResults = new List<ActionResult>();

            foreach(BattleAction action in actions) {
                actionResults.Add(action.ProcessAction());
            }

            combatantIndex = 0;

            NextCombatant();

            Debug.Log("Turn over");
        }
    }
}
