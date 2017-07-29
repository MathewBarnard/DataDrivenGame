using Assets.Controller;
using MVCGame.MVC.Model.Encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.View.UserInterfaces.Battle.Party {
    public class PartyStatusUi : MonoBehaviour {

        public BattleController model;

        public List<Text> frontRow;
        public List<Text> backRow;

        private void Update() {

            for(int i = 0; i < frontRow.Count; i++) {
                frontRow[i].text = string.Format("{0}\n{1}\n{2}", model.RandomEncounterModel.PlayerParty.FrontRow[i].Name, model.RandomEncounterModel.PlayerParty.FrontRow[i].Stats.HealthPoints.CurrentValue, model.RandomEncounterModel.PlayerParty.FrontRow[i].Stats.Shield.CurrentValue);
            }

            for (int i = 0; i < frontRow.Count; i++) {
                backRow[i].text = string.Format("{0}\n{1}\n{2}", model.RandomEncounterModel.PlayerParty.BackRow[i].Name, model.RandomEncounterModel.PlayerParty.BackRow[i].Stats.HealthPoints.CurrentValue, model.RandomEncounterModel.PlayerParty.BackRow[i].Stats.Shield.CurrentValue);
            }
        }
    }
}
