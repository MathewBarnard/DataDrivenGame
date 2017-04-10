using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MVCGame.System.Configuration {

    /// <summary>
    /// An object that represents the Data Storage Configuration. This configuration manages the locations of files
    /// that hold in-game data for characters, enemies, etc.
    /// </summary>
    
    [Serializable]
    public class DataStorageConfiguration : Configuration {

        public DataStorageConfiguration() {

            Configurations = new KeyValuePair<string, string>[5];
            Configurations[0] = new KeyValuePair<string, string>("Test", "Test");

            filePath = "/Data/";
        }

        public DataStorageConfiguration(string name, string filepath) {
            this.name = name;
            this.filePath = filepath;
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string filePath;
        public string Filepath {
            get { return filePath; }
            set { filePath = value; }
        }


        public override string GetConfiguration(string configName) {
            foreach(KeyValuePair<string,string> config in Configurations) {
                if (config.Key == configName)
                    return config.Value;
            }

            return null;
        }

        [XmlArrayItem("Configuration")]
        public KeyValuePair<string, string>[] Configurations;
    } 
}
