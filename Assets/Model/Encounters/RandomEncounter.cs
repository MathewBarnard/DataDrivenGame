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

        // Determines whose turn it is
        private enum TurnOrder { PLAYER, ENEMY };
        private TurnOrder turnOrder;

        // The number of action points needed to act on this turn
        private static int actionPointCap;
        public static int ActionPointCap {
            get { return actionPointCap; }
        }

        // The number of turns taken. 1 turn is a player action, and an enemy action.
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
            turnOrder = TurnOrder.PLAYER;
            turnsTaken = 0;

            // Set battle parameters based on developer configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            BattleConfiguration config = (BattleConfiguration)configFactory.GetConfiguration("BattleConfiguration");
            actionPointCap = Convert.ToInt32(config.GetConfiguration("ActionPointThreshold"));

            // Load the players current party configuration and the enemy party from storage. 
            DataStorage.XML.PartyDAL partyDao = new DataStorage.XML.PartyDAL();
            this.playerParty = (Party)partyDao.LoadModel(playerParty);
            this.enemyParty = (Party)partyDao.LoadModel(enemyParty);
        }

        public void BeginTurn() {

            this.currentTurn = null;

            // Begin the turn
            if (turnOrder == TurnOrder.PLAYER) {
                this.currentTurn = new Turn(playerParty.PartyMembers);
            }
            else {
                this.currentTurn = new Turn(enemyParty.PartyMembers);
            }

            // Begin the turn
            this.currentTurn.BeginTurn();
        }
    }
}