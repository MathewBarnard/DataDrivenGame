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
        }

        [XmlElement(ElementName = "MaxHealth")]
        public int MaxHealth;

        [XmlElement(ElementName = "BaseAttack")]
        public int BaseAttack;

        [XmlElement(ElementName = "BaseDefense")]
        public int BaseDefense;

        [XmlElement(ElementName = "BaseSpeed")]
        public int BaseSpeed;

        public override string ToString() {
            return String.Format("{0}, {1}, {2}, {3}", MaxHealth, BaseAttack, BaseDefense, BaseSpeed);
        }

        public override Model GetModel() {

            Characters.Stats stats = new Characters.Stats(MaxHealth, BaseAttack, BaseDefense, BaseSpeed);

            return stats;
        }
    }
}
