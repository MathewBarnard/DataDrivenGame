using Assets.Controller;
using Assets.Model.Characters;
using Assets.System.Messaging;
using Assets.View.UserInterfaces.Battle.Enemy;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.View.UserInterfaces.Battle.SelectTargetUI {
    public class SelectTargetUI : MonoBehaviour {

        private List<Combatant> possibleTargets;
        private List<GameObject> targetingPanels;
        private List<EnemyUI> enemyTargetClickers;

        public void SetParameters(List<Combatant> possibleTargets, TakeTurnController controller) {

            this.possibleTargets = possibleTargets;

            // Get the main canvas
            GameObject enemiesRoot = GameObject.Find("Enemies");

            GameObject canvasAnchor = GameObject.Find("Canvas");

            this.enemyTargetClickers = new List<EnemyUI>();
            this.targetingPanels = new List<GameObject>();

            Debug.Log(string.Format("{0} possible targets.", possibleTargets.Count));

            for(int i = 0; i < possibleTargets.Count; i++) {

                // Get the base enemy object by its GUID. Try the front row first.
                Transform jobby = enemiesRoot.transform.GetChild(0).GetChild(0).Find(possibleTargets[i].Id.ToString());
                
                // If we didn't find anything, check the back row.
                if (jobby == null)
                    jobby = enemiesRoot.transform.GetChild(0).GetChild(1).Find(possibleTargets[i].Id.ToString());

                EnemyUI enemyTargetClicker = jobby.gameObject.transform.GetChild(0).GetChild(0).gameObject.AddComponent<EnemyUI>();
                enemyTargetClicker.EnemyId = possibleTargets[i].Id;
                enemyTargetClicker.EnemyIdCallback = new GuidCallback(controller.TargetSelected);
                enemyTargetClickers.Add(enemyTargetClicker);
            }

            enabled = true;
        }

        void Awake() {
            // Ensure the GameObject isn't active until Parameters have been set.
            this.enabled = false;
        }

        void OnDestroy() {
            //foreach(GameObject obj in targetingPanels) {
            //    Destroy(obj);
            //}

            foreach(EnemyUI enemyUi in this.enemyTargetClickers) {
                Destroy(enemyUi);
            }
        }
    }
}
