using Assets.Menu;
using Assets.Menu.BattleMenu;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.Encounters;
using MVCGame.System.Menus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controller {
    public class TakeTurnController : MonoBehaviour {

        /// <summary>
        /// A control boolean to indicate that the turn has been performed and is ready to be processed.
        /// </summary>
        public bool isFinished = false;

        private RandomEncounter randomEncounterModel;
        public RandomEncounter RandomEncounterModel {
            set { randomEncounterModel = value; }
            get { return randomEncounterModel; }
        }

        // The combatant whose turn this is
        private Combatant combatant;
        public Combatant Combatant {
            set { combatant = value; }
            get { return combatant; }
        }

        // The currently active menu
        private BaseMenu activeMenu;

        // The action being performed by the character
        private BattleAction action;
        public BattleAction Action {
            get { return action; }
        }

        // Use this for initialization
        void Awake() {
            // Load the acting characters action menu.
            activeMenu = new SelectActionMenu("BasicMenu", new BaseMenu.MenuCallback(ActionSelected));
        }

        // Update is called once per frame
        void Update() {

            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                activeMenu.MoveDown();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                activeMenu.MoveUp();
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                activeMenu.Select();
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                activeMenu.Cancel();
            }
        }

        public void ActionSelected(object selection) {

            // The player has selected an action to target a single target.
            if (selection is SingleTargetAction) {
                action = (SingleTargetAction)selection;

                SingleTargetAction singleTargetAction = (SingleTargetAction)action;

                if (singleTargetAction.GetTargetType() == TargetingType.ENEMY)
                    activeMenu = new SingleTargetMenu(randomEncounterModel.EnemyParty.PartyMembers, new BaseMenu.MenuCallback(TargetSelected));
                else if (singleTargetAction.GetTargetType() == TargetingType.ALLY)
                    activeMenu = new SingleTargetMenu(randomEncounterModel.PlayerParty.PartyMembers, new BaseMenu.MenuCallback(TargetSelected));
            }
        }

        private void TargetSelected(object target) {

            if(action is SingleTargetAction) {
                SingleTargetAction singleTargetAction = (SingleTargetAction)this.action;
                singleTargetAction.SetTarget((Combatant)target);
            }

            isFinished = true;
        }
    }
}