using MVCGame.MVC.Model.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCGame.System.Configuration;
using System;

namespace MVCGame.MVC.Model.Encounters {

    /// <summary>
    /// A Model for a encounters. 'Random' is just for flavour; this represents every battle.
    /// </summary>
    public class RandomEncounter {

        // The number of turns elapsed.
        private int turnsTaken;

        private Party playerParty;
        public Party PlayerParty {
            get { return playerParty; }
        }

        private Party enemyParty;
        public Party EnemyParty {
            get { return enemyParty; }
        }

        private Turn currentTurn;
        public Turn CurrentTurn {
            get { return currentTurn; }
            set { currentTurn = value; }
        }

        public RandomEncounter(string playerParty, string enemyParty) {
            currentTurn = null;
            turnsTaken = 0;

            // Set battle parameters based on developer configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            BattleConfiguration config = (BattleConfiguration)configFactory.GetConfiguration(ConfigurationType.Battle);

            // Load the players current party configuration and the enemy party from storage. 
            DataStorage.XML.PartyDAL partyDao = new DataStorage.XML.PartyDAL();
            this.playerParty = (Party)partyDao.LoadModel(playerParty);
            this.enemyParty = (Party)partyDao.LoadModel(enemyParty);
        }

        public void BeginTurn() {

            this.currentTurn = null;

            this.currentTurn = new Turn();

            // Begin the turn
            this.currentTurn.BeginTurn();
        }
    }
}