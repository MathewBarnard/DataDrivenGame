using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MVCGame.System.Configuration;
using System.IO;
using UnityEngine;

namespace MVCGame.MVC.Model.DataStorage.XML {

    [Serializable, XmlRoot(ElementName = "Combatant")]
    public class CombatantDAL : XmlModel {

        public CombatantDAL() {
            Name = string.Empty;
            Stats = new StatsDAL();
        }

        [XmlElement(ElementName = "Name")]
        public string Name;

        public StatsDAL Stats;

        public override Model GetModel() {

            Characters.Combatant combatant = new Characters.Combatant();
            combatant.Name = this.Name;
            combatant.Stats = (Characters.Stats)this.Stats.GetModel();

            return combatant;
        }

        public override Model LoadModel(string nameOfCombatant) {

            //// ARRANGE
            // Load the configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration dataStoreConfig = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);

            // Set the path of the CharacterDataStore configuration
            string path = Application.dataPath + dataStoreConfig.GetConfiguration("CharacterDataStore") + dataStoreConfig.GetConfiguration("PlayersStore") + nameOfCombatant + ".xml";

            //// ACT
            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(CombatantDAL));
            StreamReader reader = new StreamReader(path);
            CombatantDAL xmlCombatant = (CombatantDAL)serializer.Deserialize(reader);
            reader.Close();

            this.Name = xmlCombatant.Name;
            this.Stats = xmlCombatant.Stats;

            Characters.Combatant combatant = (MVCGame.MVC.Model.Characters.Combatant)xmlCombatant.GetModel();

            return combatant;
        }
    }
}
