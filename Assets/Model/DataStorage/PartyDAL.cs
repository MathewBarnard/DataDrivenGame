using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MVCGame.System.Configuration;
using System.IO;
using UnityEngine;
using MVCGame.MVC.Model.Characters;

namespace MVCGame.MVC.Model.DataStorage.XML {

    public enum PartyType { PLAYER, AI };

    [Serializable, XmlRoot(ElementName = "Party")]
    public class PartyDAL : XmlModel {

        public PartyDAL() {}

        [XmlElement(ElementName = "ResourceId")]
        public Guid ResourceId;

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement("Formation")]
        public string Formation;

        [XmlArrayItem("Character")]
        public string[] FrontRow;

        [XmlArrayItem("Character")]
        public string[] BackRow;

        public override Model GetModel() {

            throw new NotImplementedException();
        }

        public override Model LoadModel(string nameOfParty) {

            //// ARRANGE
            // Load the configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration dataStoreConfig = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);

            // Set the path of the CharacterDataStore configuration
            string path = Application.dataPath + dataStoreConfig.GetConfiguration("PartyDataStore") + nameOfParty + ".xml";

            //// ACT
            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(PartyDAL));
            StreamReader reader = new StreamReader(path);
            PartyDAL xmlParty = (PartyDAL)serializer.Deserialize(reader);
            reader.Close();

            // Instantiate the party for population
            Characters.Party party = new Characters.Party();

            party.Id = new Guid();
            party.ResourceId = this.ResourceId;
            party.Name = xmlParty.Name;
            party.Formation = xmlParty.Formation;

            foreach(string combatant in xmlParty.FrontRow) {

                CombatantDAL xmlCombatant = new CombatantDAL();
                Characters.Combatant combatantModel = (Characters.Combatant)xmlCombatant.LoadModel(combatant);
                party.FrontRow.Add(combatantModel);
            }

            foreach(string combatant in xmlParty.BackRow) {
                CombatantDAL xmlCombatant = new CombatantDAL();
                Characters.Combatant combatantModel = (Characters.Combatant)xmlCombatant.LoadModel(combatant);
                party.BackRow.Add(combatantModel);
            }

            return party;
        }

        public void SaveModel(Party party) {

            CombatantDAL combatantDAL = new CombatantDAL();

            foreach(Combatant combatant in party.PartyMembers) {

                combatantDAL.SaveModel(combatant);
            }
        }
    }
}
