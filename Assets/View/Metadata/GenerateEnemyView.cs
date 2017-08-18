using Assets.Controller;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.View.Metadata {
    public class GenerateEnemyView : MonoBehaviour {

        private Party party;

        public void SetGuids(Party party) {
            this.party = party;

            GameObject enemyParty = Instantiate(Resources.Load(string.Format("Prefabs/Battle/Formations/{0}", party.Formation)),this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform) as GameObject; 

            for(int i = 0; i < party.FrontRow.Count; i++) {

                // Get the front row
                GameObject frontRow = enemyParty.transform.GetChild(0).gameObject;

                GameObject sprite = Instantiate(Resources.Load(string.Format("Prefabs/Battle/Sprites/{0}", party.FrontRow[i].Name)), frontRow.transform.GetChild(i)) as GameObject;
                frontRow.transform.GetChild(i).gameObject.name = party.FrontRow[i].Id.ToString();
                sprite.name = party.FrontRow[i].Id.ToString();
            }

            for(int i = 0; i < party.BackRow.Count; i++) {

                GameObject backRow = enemyParty.transform.GetChild(1).gameObject;

                GameObject sprite = Instantiate(Resources.Load(string.Format("Prefabs/Battle/Sprites/{0}", party.BackRow[i].Name)), backRow.transform.GetChild(i)) as GameObject;
                backRow.transform.GetChild(i).gameObject.name = party.BackRow[i].Id.ToString();
                sprite.name = party.BackRow[i].Id.ToString();
            }
        }
    }
}
