using System.Collections;
using System.Collections.Generic;

namespace MVCGame.Testing {

    /// <summary>
    /// A Test is attached to the TestHarness which exists within the Unity scene. The TestHarness manages the execution of the test,
    /// whereas this Test class contains all the logic for that test.
    /// </summary>
    public interface Test {

        /// <summary>
        /// Begins the test. Returns true if it passes, false if it failed.
        /// </summary>
        bool Execute();
    }
}