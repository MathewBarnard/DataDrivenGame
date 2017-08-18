using MVCGame.MVC.Model.BattleActions;
using System;
using System.Xml;
using UnityEngine;
using Assets.System.Messaging;
using System.Collections.Generic;
using UnityEngine.UI;
using MVCGame.MVC.Model.Menu;
using Assets.Controller;

namespace Assets.View.UserInterfaces {
    public class SelectActionUI : MonoBehaviour {

        // The main canvas
        private GameObject menuAnchor;
        private GameObject skillsMenuAnchor;

        private SelectActionMenu selectActionMenu;

        private List<GameObject> menuItems;

        private TakeTurnController controller;

        public void SetParameters(SelectActionMenu selectActionMenu, TakeTurnController controller) {

            this.menuItems = new List<GameObject>();

            this.selectActionMenu = selectActionMenu;
            this.controller = controller;

            // Get the main canvas
            this.menuAnchor = GameObject.Find("MenuSelectActionAnchor");
            this.skillsMenuAnchor = GameObject.Find("MenuSkillsAnchor");

            this.AddDefaultMenuItems();

            enabled = true;
        }

        void Awake() {
            // Ensure the GameObject isn't active until Parameters have been set.
            this.enabled = false;
        }

        public void Hide() {

        }

        private void SetListener(GameObject buttonObject, int actionId) {
            buttonObject.GetComponentInChildren<Button>().onClick.AddListener(() => this.controller.ActionSelected(actionId));
        }

        private void OnEnable() {

            /*for(int i = 0; i < this.menuItems.Count; i++) {
                SetListener(this.menuItems[i], this.selectActionMenu.actionIds[i]);
            }*/
        }

        private void OnDisable() {

            if (menuItems != null) {
                foreach (GameObject obj in menuItems) {

                    if (obj != null) {
                        Button button = obj.GetComponentInChildren<Button>();

                        if (button != null)
                            button.onClick.RemoveAllListeners();
                    }
                }
            }
        }

        void OnDestroy() {
            foreach (GameObject obj in menuItems) {
                Destroy(obj);
            }
        }

        private void AddDefaultMenuItems() {

            // Add attack
            // Attach the object
            GameObject fightButton = Instantiate(Resources.Load("Prefabs/UI Prefabs/SelectActionButton"), menuAnchor.transform) as GameObject;

            BattleActionFactory.CreateAction(BattleActions.ATTACK);

            if (fightButton.GetComponentInChildren<Text>() != null) {
                fightButton.GetComponentInChildren<Text>().text = "Fight!";
                fightButton.GetComponentInChildren<Text>().fontSize = 28;
            }

            this.SetListener(fightButton, BattleActions.ATTACK);

            this.menuItems.Add(fightButton);

            GameObject skillsButton = Instantiate(Resources.Load("Prefabs/UI Prefabs/SelectActionButton"), menuAnchor.transform) as GameObject;

            if (skillsButton.GetComponentInChildren<Text>() != null) {
                skillsButton.GetComponentInChildren<Text>().text = "Skills";
                skillsButton.GetComponentInChildren<Text>().fontSize = 28;
            }

            skillsButton.GetComponent<RectTransform>().offsetMin = new Vector2(0, -120);

            skillsButton.GetComponentInChildren<Button>().onClick.AddListener(() => this.ShowSelectActionMenu());

            this.menuItems.Add(skillsButton);

            GameObject defendButton = Instantiate(Resources.Load("Prefabs/UI Prefabs/SelectActionButton"), menuAnchor.transform) as GameObject;

            if (defendButton.GetComponentInChildren<Text>() != null) {
                defendButton.GetComponentInChildren<Text>().text = "Defend";
                defendButton.GetComponentInChildren<Text>().fontSize = 28;
            }

            defendButton.GetComponent<RectTransform>().offsetMin = new Vector2(0, -240);

            this.menuItems.Add(defendButton);

            GameObject itemButton = Instantiate(Resources.Load("Prefabs/UI Prefabs/SelectActionButton"), menuAnchor.transform) as GameObject;

            if (itemButton.GetComponentInChildren<Text>() != null) {
                itemButton.GetComponentInChildren<Text>().text = "Item";
                itemButton.GetComponentInChildren<Text>().fontSize = 28;
            }

            itemButton.GetComponent<RectTransform>().offsetMin = new Vector2(0, -360);

            this.menuItems.Add(itemButton);
        }

        private void ShowSelectActionMenu() {

            foreach (int actionId in this.selectActionMenu.actionIds) {
                // Attach the object
                GameObject skillButton = Instantiate(Resources.Load("Prefabs/UI Prefabs/SelectActionButton"), skillsMenuAnchor.transform) as GameObject;

                BattleAction action = BattleActionFactory.CreateAction(actionId);

                if (skillButton.GetComponentInChildren<Text>() != null) {
                    skillButton.GetComponentInChildren<Text>().text = action.Name;
                    skillButton.GetComponentInChildren<Text>().fontSize = 28;
                }

                this.SetListener(skillButton, actionId);

                this.menuItems.Add(skillButton);
            }
        }
    }
}
