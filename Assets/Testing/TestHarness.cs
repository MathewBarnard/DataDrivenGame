using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVCGame.Testing {

    /// <summary>
    /// The test harness is a script that attaches to a GameObject. We can use it to test functionality in game by attaching necessary
    /// behaviours to it.
    /// </summary>
    public class TestHarness : MonoBehaviour {

        private Test activeTest;

        // Use this for initialization
        void Start() {

            //activeTest = new XMLDataReadTester();
            activeTest = new XMLSerializeTest();
            activeTest.Execute();
        }

        // Update is called once per frame
        void Update() {

        }
    }

}