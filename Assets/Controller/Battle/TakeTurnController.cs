using Assets.Model.Characters;
using Assets.View.UserInterfaces;
using Assets.View.UserInterfaces.Battle.SelectTargetUI;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.DataStorage.XML;
using MVCGame.MVC.Model.Encounters;
using MVCGame.System.Configuration;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Controller {
    public class TakeTurnController : MonoBehaviour {

        // The base range of this character. Required for establishing UI.
        private RangeType range;

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

        // The action being performed by the character
        private BattleAction action;
        public BattleAction Action {
            get { return action; }
        }

        private SelectActionUI selectActionUI;
        private SelectTargetUI selectTargetUI;

        // Boot up the interface that allows the user to select an action.
        public void Start() {

            this.InitialiseSelectActionUI();
        }

        private void InitialiseSelectActionUI() {

            // Get the menu layout store.
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration config = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);

            // Load the Select Action Menu layout.
            SelectActionMenuDAL dal = new SelectActionMenuDAL();
            MVCGame.MVC.Model.Menu.SelectActionMenu menu = (MVCGame.MVC.Model.Menu.SelectActionMenu)dal.LoadModel("CombatantMenus/" + combatant.Name);

            // Instantiate the interface.
            this.selectActionUI = this.gameObject.AddComponent<SelectActionUI>();
            this.selectActionUI.SetParameters(menu, this);
        }

        private void InitialiseSelectTargetUI() {
            this.selectActionUI.enabled = false;
            this.selectTargetUI = this.gameObject.AddComponent<SelectTargetUI>();

            List<Combatant> possibleTargets = randomEncounterModel.EnemyParty.PartyMembers.Where(pt => !pt.IsDead()).ToList();

            this.selectTargetUI.SetParameters(possibleTargets, this);
        }

        public void ActionSelected(int actionId) {

            selectActionUI.Hide();
            BattleAction selection = BattleActionFactory.CreateAction(actionId);
            selection.SetActingCombatant(this.combatant);

            // The player has selected an action to target a single target.
            if (selection is SingleTargetAction) {
                action = (SingleTargetAction)selection;

                SingleTargetAction singleTargetAction = (SingleTargetAction)action;

                if (singleTargetAction.GetTargetType() == TargetingType.ENEMY)
                    this.InitialiseSelectTargetUI();
            }
        }

        public void TargetSelected(Guid targetId) {

            try {
                Debug.Log(targetId);
                if (action is SingleTargetAction) {
                    SingleTargetAction singleTargetAction = (SingleTargetAction)this.action;
                    singleTargetAction.SetTarget((Combatant)randomEncounterModel.EnemyParty.PartyMembers.Find(c => c.Id == targetId));
                }

                isFinished = true;
            }
            catch(Exception e) {

            }
        }

        // Let's clean up the other GameObjects shall we?
        void OnDestroy() {
            Destroy(this.selectActionUI);
            Destroy(this.selectTargetUI);
        }
    }
}