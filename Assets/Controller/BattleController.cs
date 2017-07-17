using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// The main interface for the player during battles.
/// </summary>
namespace Assets.Controller {
    public class BattleController : MonoBehaviour {

        private RandomEncounter randomEncounterModel;

        private TakeTurnController takeTurnController;

        private void Start() {

            randomEncounterModel = new RandomEncounter("TestParty", "TestParty");
            this.Begin();
        }

        private void Begin() {

            // Set up the controller for this characters turn
            this.takeTurnController = this.gameObject.AddComponent<TakeTurnController>();
            this.takeTurnController.RandomEncounterModel = randomEncounterModel;
            this.takeTurnController.Combatant = randomEncounterModel.PlayerParty.PartyMembers[0];
        }

        public void Update() {

            if(takeTurnController != null && takeTurnController.isFinished) {
                SingleTargetActionResult result = (SingleTargetActionResult)this.takeTurnController.Action.ProcessAction();
                Debug.Log(result.DamageDealt);
                Debug.Log(result.ShieldDamageDealt);
                Debug.Log(result.EnemyKilled);
                Destroy(this.takeTurnController);
                this.takeTurnController = null;
            }
        }
    }
}
