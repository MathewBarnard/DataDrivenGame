using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MVCGame.MVC.Model.DataStorage.XML {

    /// <summary>
    /// An abstract class that represents an object that has been created from an XML file through deserialization.
    /// Contains stubs for all helper methods that convert the XML object-model into an in-game model.
    /// </summary>
    public abstract class XmlModel {

        public virtual Model LoadModel() {
            throw new NotImplementedException();
        }

        public virtual Model LoadModel(string byName) {
            throw new NotImplementedException();
        }
    
        public virtual Model GetModel() {
            throw new NotImplementedException();
        }

        public virtual XmlModel ToModel() {
            throw new NotImplementedException();
        }
    }
}
