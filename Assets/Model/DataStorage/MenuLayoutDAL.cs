using MVCGame.System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MVCGame.System.Configuration;
using System.IO;
using UnityEngine;
using System.Xml;

namespace MVCGame.MVC.Model.DataStorage.XML {

    [Serializable, XmlRoot(ElementName = "MenuLayout")]
    public class MenuLayoutDAL : XmlModel {

        public override Model LoadModel(string nameOfCombatant) {

            //// ARRANGE
            // Load the configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration dataStoreConfig = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);

            // Set the path of the CharacterDataStore configuration
            string path = Application.dataPath + dataStoreConfig.GetConfiguration("MenuLayoutStore") + nameOfCombatant + ".xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return null;
        }
    }
}