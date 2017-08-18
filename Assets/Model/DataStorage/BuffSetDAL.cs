using MVCGame.MVC.Model.DataStorage.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Model.Characters;

namespace MVCGame.MVC.Model.Characters {

    [Serializable]
    public class BuffSetDAL : XmlModel {

        public BuffSetDAL() {
        }

        [XmlArray(ElementName = "Buffs")]
        [XmlArrayItem("Buff")]
        public int[] Buffs;

        public override Model GetModel() {

            BuffSet moveSet = new Characters.BuffSet(this.Buffs);

            return moveSet;
        }
    }
}
