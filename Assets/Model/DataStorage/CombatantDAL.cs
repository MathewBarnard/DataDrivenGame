using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MVCGame.System.Configuration;
using System.IO;
using UnityEngine;
using Assets.Model.Characters;
using MVCGame.MVC.Model.Characters;
using Assets.Model.DataStorage;
using System.Xml;

namespace MVCGame.MVC.Model.DataStorage.XML {

    public enum CombatantType { PLAYER, ENEMY };

    [Serializable, XmlRoot(ElementName = "Combatant")]
    public class CombatantDAL : XmlModel {

        public CombatantDAL() {
            Name = string.Empty;
            Stats = new StatsDAL();
        }

        [XmlElement(ElementName = "ResourceId")]
        public Guid ResourceId;

        [XmlElement(ElementName = "Name")]
        public string Name;

        public StatsDAL Stats;

        public MoveSetDAL MoveSet;

        public BuffSetDAL Buffs;

        public override Model GetModel() {

            Characters.Combatant combatant = new Characters.Combatant();
            combatant.Id = Guid.NewGuid();
            combatant.ResourceId = this.ResourceId;
            combatant.Name = this.Name;
            combatant.Stats = (Characters.Stats)this.Stats.GetModel();
            combatant.MoveSet = (MoveSet)this.MoveSet.GetModel();
            combatant.BuffSet = (BuffSet)this.Buffs.GetModel();
            return combatant;
        }

        public static XmlModel ToModel(Combatant combatant) {

            CombatantDAL combatantDal = new CombatantDAL();

            combatantDal.Name = combatant.Name;
            combatantDal.Stats = StatsDAL.ToModel(combatant.Stats);

            return combatantDal;
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
            this.MoveSet = xmlCombatant.MoveSet;
            this.Buffs = xmlCombatant.Buffs;

            Characters.Combatant combatant = (MVCGame.MVC.Model.Characters.Combatant)xmlCombatant.GetModel();

            return combatant;
        }

        public void SaveModel(Combatant combatant) {

            XmlSerializer serializer = new XmlSerializer(typeof(CombatantDAL));

            using (StringWriter stringWriter = new StringWriter()) {

                using (XmlWriter writer = XmlWriter.Create(stringWriter)) {

                    serializer.Serialize(writer, combatant);
                    Debug.Log(stringWriter.ToString());
                }
            }
        }
    }
}
