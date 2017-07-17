using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MVCGame.System.Configuration {

    public enum ConfigurationType {

        DataStorage,
        Battle
    };

    /// <summary>
    /// An object representation of a base XML configuration.
    /// </summary>
    [Serializable]
    public abstract class Configuration {

        private static string filePath = "/System/Configuration/";
        public static string FilePath {
            get { return filePath; }
        }

        public abstract string GetConfiguration(string configName);
    }
}
