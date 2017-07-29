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

        private SelectActionMenu selectActionMenu;

        private List<GameObject> menuItems;

        private TakeTurnController controller;

        public void SetParameters(SelectActionMenu selectActionMenu, TakeTurnController controller) {

            this.menuItems = new List<GameObject>();

            this.selectActionMenu = selectActionMenu;
            this.controller = controller;

            // Get the main canvas
            this.menuAnchor = GameObject.Find("MenuSelectActionAnchor");

            float pos = 0;

            foreach(int actionId in selectActionMenu.actionIds) {

                // Attach the object
                GameObject obj = Instantiate(Resources.Load("Prefabs/UI Prefabs/SelectActionButton"), menuAnchor.transform) as GameObject;

                BattleActionFactory.CreateAction(actionId);

                if (obj.GetComponentInChildren<Text>() != null) {
                    obj.GetComponentInChildren<Text>().text = BattleActionFactory.CreateAction(actionId).Name;
                    obj.GetComponentInChildren<Text>().fontSize = 28;
                }

                obj.GetComponent<RectTransform>().offsetMin = new Vector2(0, pos);

                pos -= 120;

                this.menuItems.Add(obj);
            }

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

            for(int i = 0; i < this.menuItems.Count; i++) {
                SetListener(this.menuItems[i], this.selectActionMenu.actionIds[i]);
            }
        }

        private void OnDisable() {

            if (menuItems != null) {
                foreach (GameObject obj in menuItems) {
                    obj.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                }
            }
        }

        void OnDestroy() {
            foreach (GameObject obj in menuItems) {
                Destroy(obj);
            }
        }
    }
}
