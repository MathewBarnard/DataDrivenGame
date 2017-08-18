using Assets.Controller;
using MVCGame.MVC.Model.Characters;
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

        public List<GameObject> frontRow;
        public List<GameObject> backRow;

        public void Awake() {
            enabled = false;
            BattleEvents.ActiveInstance().battleStartEventHandler += Activate;
        }

        public void Activate() {
            enabled = true;
            BattleEvents.ActiveInstance().battleStartEventHandler -= Activate;
        }

        private void Update() {

            if (model != null) {
                for (int i = 0; i < model.RandomEncounterModel.PlayerParty.FrontRow.Count; i++) {
                    frontRow[i].transform.gameObject.GetComponentsInChildren<Text>().Where(obj => obj.name == "Name").FirstOrDefault().text = model.RandomEncounterModel.PlayerParty.FrontRow[i].Name;
                    frontRow[i].transform.gameObject.GetComponentsInChildren<Text>().Where(obj => obj.name == "HP").FirstOrDefault().text = "HP: " + Convert.ToString(model.RandomEncounterModel.PlayerParty.FrontRow[i].Stats.HealthPoints.CurrentValue);

                    int shield = model.RandomEncounterModel.PlayerParty.FrontRow[i].Stats.Shield.CurrentValue;

                    string shieldOutput = string.Empty;
                    for (int j = 0; j < shield; j++) {
                        shieldOutput += "Ø";
                    }
                    frontRow[i].transform.gameObject.GetComponentsInChildren<Text>().Where(obj => obj.name == "Shield").FirstOrDefault().text = shieldOutput;
                }

                for (int i = 0; i < model.RandomEncounterModel.PlayerParty.BackRow.Count; i++) {
                    backRow[i].transform.gameObject.GetComponentsInChildren<Text>().Where(obj => obj.name == "Name").FirstOrDefault().text = model.RandomEncounterModel.PlayerParty.BackRow[i].Name;
                    backRow[i].transform.gameObject.GetComponentsInChildren<Text>().Where(obj => obj.name == "HP").FirstOrDefault().text = "HP: " + Convert.ToString(model.RandomEncounterModel.PlayerParty.BackRow[i].Stats.HealthPoints.CurrentValue);

                    int shield = model.RandomEncounterModel.PlayerParty.BackRow[i].Stats.Shield.CurrentValue;

                    string shieldOutput = string.Empty;
                    for (int j = 0; j < shield; j++) {
                        shieldOutput += "Ø";
                    }

                    backRow[i].transform.gameObject.GetComponentsInChildren<Text>().Where(obj => obj.name == "Shield").FirstOrDefault().text = shieldOutput;
                }
            }
        }
    }
}
