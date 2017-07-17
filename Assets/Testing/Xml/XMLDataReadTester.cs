using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using UnityEngine;
using MVCGame.System.Configuration;
using System.Xml.Serialization;
using System.IO;
using MVCGame.MVC.Model.DataStorage.XML;

namespace MVCGame.Testing {

    /// <summary>
    /// A class responsible for running XML read tests, ensuring that data is parsed into the scene correctly.
    /// </summary>
    public class XMLDataReadTester : Test {

        public bool Execute() {

            // Load the configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration dataStoreConfig = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);

            // Set the path of the CharacterDataStore configuration
            string path = Application.dataPath + dataStoreConfig.GetConfiguration("CharacterDataStore") + "/Enemies/Goblin.xml";
        
            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(StatsDAL));
            StreamReader reader = new StreamReader(path);
            StatsDAL xmlStats = (StatsDAL)serializer.Deserialize(reader);

            // Once we have loaded the data from Xml, we want to translate it into an in-game model object, rather than this XML version.
            MVCGame.MVC.Model.Characters.Stats stats = (MVC.Model.Characters.Stats)xmlStats.GetModel();

            Debug.Log(String.Format("{0}, {1}, {2}, {3}", stats.HealthPoints.CurrentValue, stats.Attack.CurrentValue, stats.Defense.CurrentValue, stats.Speed.CurrentValue));

            return true;
        }
    }
}
