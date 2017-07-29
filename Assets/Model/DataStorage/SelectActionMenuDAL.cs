using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MVCGame.System.Configuration;
using System.IO;
using UnityEngine;
using System.Xml;
using MVCGame.MVC.Model.Menu;

namespace MVCGame.MVC.Model.DataStorage.XML {

    [Serializable, XmlRoot(ElementName = "SelectActionMenu")]
    public class SelectActionMenuDAL : XmlModel {

        public SelectActionMenuDAL() {
        }

        [XmlArray(ElementName = "Actions")]
        [XmlArrayItem("Action")]
        public int[] Actions;


        public override Model GetModel() {

            SelectActionMenu menu = new SelectActionMenu(this.Actions);

            return menu;
        }

        public override Model LoadModel(string menuName) {

            // Load the configuration
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration dataStoreConfig = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);

            // Set the path of the CharacterDataStore configuration
            string path = Application.dataPath + dataStoreConfig.GetConfiguration("MenuLayoutStore") + menuName + ".xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            //// ACT
            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(SelectActionMenuDAL));
            StreamReader reader = new StreamReader(path);
            SelectActionMenuDAL xmlActionMenu = (SelectActionMenuDAL)serializer.Deserialize(reader);
            reader.Close();

            this.Actions = xmlActionMenu.Actions;

            return this.GetModel();
        }
    }
}
