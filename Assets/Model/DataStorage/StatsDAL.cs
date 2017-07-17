using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MVCGame.MVC.Model.DataStorage.XML {

    [Serializable]
    public class StatsDAL : XmlModel {

        public StatsDAL() {
            MaxHealth = 0;
            BaseAttack = 0;
            BaseDefense = 0;
            BaseSpeed = 0;
            BaseShield = 0;
            BaseHits = 0;
        }

        [XmlElement(ElementName = "MaxHealth")]
        public int MaxHealth;

        [XmlElement(ElementName = "BaseAttack")]
        public int BaseAttack;

        [XmlElement(ElementName = "BaseDefense")]
        public int BaseDefense;

        [XmlElement(ElementName = "BaseSpeed")]
        public int BaseSpeed;

        [XmlElement(ElementName = "BaseShield")]
        public int BaseShield;

        [XmlElement(ElementName = "BaseHits")]
        public int BaseHits;

        public override string ToString() {
            return String.Format("{0}, {1}, {2}, {3}, {4}, {5}", MaxHealth, BaseAttack, BaseDefense, BaseSpeed, BaseShield, BaseHits);
        }

        public override Model GetModel() {

            Characters.Stats stats = new Characters.Stats(MaxHealth, BaseAttack, BaseDefense, BaseSpeed, BaseShield, BaseHits);

            return stats;
        }
    }
}
