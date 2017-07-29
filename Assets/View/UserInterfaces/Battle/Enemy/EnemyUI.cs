using Assets.System.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.View.UserInterfaces.Battle.Enemy {
    public class EnemyUI : MonoBehaviour {

        private Guid enemyId;
        public Guid EnemyId {
            set { enemyId = value; }
        }

        private GuidCallback enemyIdCallback;
        public GuidCallback EnemyIdCallback {
            set { enemyIdCallback = value; }
        }

        private Color original;

        void Start() {
            original = this.gameObject.GetComponent<SpriteRenderer>().color;
        }

        //private void Update() {

        //    Ray ray;
        //    RaycastHit hit;

        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.collider.gameObject == this.gameObject) {
        //            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //        }
        //        else {
        //            this.gameObject.GetComponent<SpriteRenderer>().color = original;
        //        }
        //    }
        //}

        private void OnMouseOver() {

            if(Input.GetMouseButtonDown(0)) {
                enemyIdCallback(enemyId);
            }
        }

        private void OnMouseEnter() {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        private void OnMouseExit() {
            this.gameObject.GetComponent<SpriteRenderer>().color = original;
        }

        private void OnDestroy() {
            this.gameObject.GetComponent<SpriteRenderer>().color = original;
        }
    }
}
