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
using Assets.Model.Characters;
using MVCGame.MVC.Model.Characters;

namespace MVCGame.MVC.Model.DataStorage.XML {

    [Serializable]
    public class MoveSetDAL : XmlModel {

        public MoveSetDAL() {
        }

        [XmlArray(ElementName = "BattleActions")]
        [XmlArrayItem("BattleAction")]
        public int[] BattleActions;

        public override Model GetModel() {

            MoveSet moveSet = new MoveSet(this.BattleActions);

            return moveSet;
        }
    }
}
