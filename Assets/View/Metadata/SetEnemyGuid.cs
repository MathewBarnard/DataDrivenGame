using Assets.Controller;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.View.Metadata {
    public class SetEnemyGuid : MonoBehaviour {

        public BattleController controller;

        public GameObject enemy1;
        public GameObject enemy2;
        public GameObject enemy3;
        public GameObject enemy4;
        public GameObject enemy5;
        public GameObject enemy6;

        void Start() {

            List<Combatant> combatants = controller.RandomEncounterModel.EnemyParty.PartyMembers;

            enemy1.name = combatants[0].ID.ToString();
            enemy2.name = combatants[1].ID.ToString();
            enemy3.name = combatants[2].ID.ToString();
            enemy4.name = combatants[3].ID.ToString();
            enemy5.name = combatants[4].ID.ToString();
            enemy6.name = combatants[5].ID.ToString();
        }
    }


}
