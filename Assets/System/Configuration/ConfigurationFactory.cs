using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace MVCGame.System.Configuration {

    /// <summary>
    /// A factory for configuration files used by the game. A parameter can be passed to specify the required
    /// configuration, and this class will return an object that represents that XML configuration.
    /// </summary>
    public class ConfigurationFactory {

        public Configuration GetConfiguration(string configName) {

            XmlSerializer serializer = null;
            FileStream fileStream = null;

            switch (configName) {

                case "DataStorageConfiguration":

                    // Load the config
                    serializer = new XmlSerializer(typeof(DataStorageConfiguration));
                    fileStream = new FileStream(String.Format("{0}{1}/DataStorageConfiguration.xml", Application.dataPath, Configuration.FilePath), FileMode.Open);
                    DataStorageConfiguration dataStoreConfig = (DataStorageConfiguration)serializer.Deserialize(fileStream);
                    fileStream.Close();
                    return dataStoreConfig;

                case "BattleConfiguration":
                    // Load the config
                    serializer = new XmlSerializer(typeof(BattleConfiguration));
                    fileStream = new FileStream(String.Format("{0}{1}/BattleConfiguration.xml", Application.dataPath, Configuration.FilePath), FileMode.Open);
                    BattleConfiguration battleConfig = (BattleConfiguration)serializer.Deserialize(fileStream);
                    fileStream.Close();
                    return battleConfig;

                default:
                    break;
            }

            // No config found.
            return null;
        }
    }
}
