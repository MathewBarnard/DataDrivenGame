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
    /// Will serialize an object into XML so that we can check formatting.
    /// </summary>
    public class XMLSerializeTest : Test {

        private XmlDocument output;

        public bool Execute() {

            DataStorageConfiguration dataStorageConfig = new DataStorageConfiguration();

            XmlSerializer serializer = new XmlSerializer(typeof(DataStorageConfiguration));

            using (StringWriter stringWriter = new StringWriter()) {

                using (XmlWriter writer = XmlWriter.Create(stringWriter)) {

                    serializer.Serialize(writer, dataStorageConfig);
                    Debug.Log(stringWriter.ToString());
                }
            }

            CombatantDAL combatant = new CombatantDAL();

            serializer = new XmlSerializer(typeof(CombatantDAL));

            using (StringWriter stringWriter = new StringWriter()) {

                using (XmlWriter writer = XmlWriter.Create(stringWriter)) {

                    serializer.Serialize(writer, combatant);
                    Debug.Log(stringWriter.ToString());
                }
            }
            return true;
        }
    }
}
