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
                Transform jobby = enemiesRoot.transform.GetChild(0).Find(possibleTargets[i].ID.ToString());

                // If we didn't find anything, check the back row.
                if (jobby == null)
                    jobby = enemiesRoot.transform.GetChild(1).Find(possibleTargets[i].ID.ToString());

                EnemyUI enemyTargetClicker = jobby.gameObject.transform.GetChild(0).gameObject.AddComponent<EnemyUI>();
                enemyTargetClicker.EnemyId = possibleTargets[i].ID;
                enemyTargetClicker.EnemyIdCallback = new GuidCallback(controller.TargetSelected);
                enemyTargetClickers.Add(enemyTargetClicker);
                /*
                GameObject obj = Instantiate(Resources.Load("Prefabs/UI Prefabs/TargetingPanelUI"), canvasAnchor.transform) as GameObject;

                Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, enemiesRoot.transform.GetChild(i).position);

                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasAnchor.GetComponent<RectTransform>(), 
                    pos, Camera.main, out pos);

                obj.GetComponent<RectTransform>().anchoredPosition = pos;

                // Explicitly set this to pass through to the listener. For some reason it wasn't working on the loop increment?
                int enemyId = i;

                obj.GetComponent<Button>().onClick.AddListener(() => controller.TargetSelected(enemyId));

                targetingPanels.Add(obj);*/
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
