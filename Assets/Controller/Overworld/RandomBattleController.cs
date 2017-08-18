using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Controller.Overworld {

    /// <summary>
    /// Controls the generation of random battles.
    /// </summary>
    public class RandomBattleController : MonoBehaviour {

        float timer = 0.0f;

        void Update() {

            timer += Time.deltaTime;

            if(timer > 5.0f) {
                SceneManager.LoadSceneAsync("Battle");
            }
        }
    }
}
