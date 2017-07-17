using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MVCGame.System.Configuration;
using System.IO;
using UnityEngine;

namespace MVCGame.MVC.Model.DataStorage.XML {

    [Serializable, XmlRoot(ElementName = "Party")]
    public class PartyDAL : XmlModel {

        public PartyDAL() {}

        [XmlArrayItem("Character")]
        public string[] Characters;

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

            foreach(string combatant in xmlParty.Characters) {

                CombatantDAL xmlCombatant = new CombatantDAL();
                Characters.Combatant combatantModel = (Characters.Combatant)xmlCombatant.LoadModel(combatant);
                party.PartyMembers.Add(combatantModel);
            }

            return party;
        }
    }
}
