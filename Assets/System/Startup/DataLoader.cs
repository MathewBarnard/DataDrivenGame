using Assets.Data.System;
using MVCGame.MVC.Model.Characters;
using MVCGame.System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.System.Startup {
    public class DataLoader : MonoBehaviour {

        // Gather all the resources that we need for the game session to run.
        private void Start() {

            // Populate the DataRepository with persistent data for this game session.
            PersistentDataRepository repository = PersistentDataRepository.ActiveInstance();

            // Set battle parameters based on developer configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            BattleConfiguration config = (BattleConfiguration)configFactory.GetConfiguration(ConfigurationType.Battle);

            SceneManager.LoadSceneAsync("Overworld");
        }
    }
}
