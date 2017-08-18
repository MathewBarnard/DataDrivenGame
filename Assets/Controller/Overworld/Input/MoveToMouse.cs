using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Controller.Overworld.Input {
    public class MoveToMouse : MonoBehaviour {

        private Rigidbody rigidBody;

        private void Start() {
            this.rigidBody = this.gameObject.GetComponent<Rigidbody>();
        }

        private void Update() {

            if(UnityEngine.Input.GetMouseButton(0)) {

                // Get the raycast
                var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit)) {
                    if(hit.collider != null) {
                        this.rigidBody.MovePosition(Vector3.MoveTowards(this.gameObject.transform.position, hit.point, 0.2f));
                    }
                }
            }
        }
    }
}
