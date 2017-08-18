using Assets.Data.System;
using Assets.View.Metadata;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.Encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        private EnemyTurnController enemyTurnController;

        public GameObject view;

        private int combatantIndex;

        private void Start() {

            // Initialise the actions list that we will populate each turn.
            actions = new List<BattleAction>();

            // Load the random encounter model based on the configuration of the current party, and the next encounter.
            randomEncounterModel = new RandomEncounter(PersistentDataRepository.ActiveInstance().PlayerParty, "TestEnemyParty");

            // We need to load the current party set to the view.
            this.view.GetComponent<GenerateEnemyView>().SetGuids(randomEncounterModel.EnemyParty);

            // Initialise the current combatant index then begin the fight
            combatantIndex = 0;
            this.Begin();
        }

        private void Begin() {

            BattleEvents.ActiveInstance().enemyKilledEventHandler += this.Test;
            BattleEvents.ActiveInstance().onBattleStart();
            NextCombatant();
        }

        private void Test(Combatant combatant) {
            Debug.Log("BIG MEMEY CUMS");
        }

        public void Update() {

            // Keep checking to see if the turn controller. If it has finished, we store the action and move to the next combatant.
            if(takeTurnController != null && takeTurnController.isFinished) {
                actions.Add(this.takeTurnController.Action);
                Destroy(this.takeTurnController);
                this.takeTurnController = null;

                if (combatantIndex == randomEncounterModel.PlayerParty.PartyMembers.Count) {
                    GetEnemyActions();
                    ProcessActions();
                }
                else {
                    NextCombatant();
                }
            }
        }

        private void NextCombatant() 
        {
            if (!randomEncounterModel.PlayerParty.PartyMembers[combatantIndex].IsDead()) 
            {
                // Set up the controller for this characters turn
                this.takeTurnController = this.gameObject.AddComponent<TakeTurnController>();
                this.takeTurnController.RandomEncounterModel = randomEncounterModel;
                this.takeTurnController.Combatant = randomEncounterModel.PlayerParty.PartyMembers[combatantIndex];

                // Increase te index so that we move to the next combatant on the next pass
                if (combatantIndex < randomEncounterModel.PlayerParty.PartyMembers.Count)
                    combatantIndex += 1;
             }
            else {
                // Increase te index so that we move to the next combatant on the next pass
                if (combatantIndex < randomEncounterModel.PlayerParty.PartyMembers.Count)
                    combatantIndex += 1;

                this.NextCombatant();
            }
        }

        private void GetEnemyActions() {

            if(enemyTurnController == null) {
                this.enemyTurnController = new EnemyTurnController(this.randomEncounterModel.PlayerParty, this.randomEncounterModel.EnemyParty);
            }
            actions.AddRange(this.enemyTurnController.GetEnemyActions());
        }

        private void ProcessActions() {

            List<ActionResult> actionResults = new List<ActionResult>();

            PreActionController preActionController = new PreActionController();
            PostActionController postActionController = new PostActionController();

            // Process each action
            foreach(BattleAction action in actions) {

                // Check if the action is still valid
                if(!action.CheckActionStillValid())
                {
                    // If not, handle the invalid action. Usually just a redirect.
                    preActionController.HandleInvalidAction(action, randomEncounterModel);
                }

                // Process the action.
                ActionResult result = action.ProcessAction();

                postActionController.CheckResult(result);
            }

            combatantIndex = 0;

            // TEMPORARY CLEANUP FUNCTION!
            this.ClearDeadEnemies();
            this.ProcessUpkeep();
            NextCombatant();
        }

        private void ProcessUpkeep() {

            bool enemyAlive = false;

            foreach(Combatant combatant in randomEncounterModel.EnemyParty.PartyMembers) {
                if(!combatant.IsDead()) {
                    enemyAlive = true;
                }
            }

            if(enemyAlive == false) {
                SceneManager.LoadSceneAsync("Overworld");
            }
        }

        private void ClearDeadEnemies() {

            List<Combatant> ids = new List<Combatant>();

            ids.AddRange(this.randomEncounterModel.EnemyParty.PartyMembers.Where(c => c.IsDead()));

            foreach(Combatant combatant in ids) {
                GameObject obj = GameObject.Find(combatant.Id.ToString());

                if (obj != null) {
                    obj.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}
