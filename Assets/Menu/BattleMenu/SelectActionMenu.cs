using Assets.Menu;
using MVCGame.MVC.Model.BattleActions;
using MVCGame.System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

namespace MVCGame.System.Menus {

    public class SelectActionMenu: BaseMenu {

        private MenuCallback callback;

        /// <summary>
        /// The current selection within the Menu.
        /// </summary>
        private XmlNode currentSelection;

        /// <summary>
        /// The XML Document that represent the menu tree that the player can cycle through.
        /// </summary>
        private XmlDocument menuTree;

        public SelectActionMenu(string menuToLoad, MenuCallback callback) {
            this.callback = callback;
            menuTree = new XmlDocument();
            ConfigurationFactory configFactory = new ConfigurationFactory();
            DataStorageConfiguration config = (DataStorageConfiguration)configFactory.GetConfiguration(ConfigurationType.DataStorage);
            this.menuTree.Load(Application.dataPath + config.GetConfiguration(DataStorageConfiguration.MENU_LAYOUTS) + menuToLoad + ".xml");

            currentSelection = menuTree.SelectSingleNode("MenuLayout/RootCommands");
            currentSelection = currentSelection.FirstChild;
        }

        public override void MoveUp() {
            
            if(currentSelection.PreviousSibling != null)
                currentSelection = currentSelection.PreviousSibling;
            Debug.Log(currentSelection.Attributes.GetNamedItem("value").Value);
        }

        public override void MoveDown() {
            if(currentSelection.NextSibling != null) 
                currentSelection = currentSelection.NextSibling;
            Debug.Log(currentSelection.Attributes.GetNamedItem("value").Value);
        }

        public override void MoveRight() {
            throw new NotImplementedException();
        }

        public override void MoveLeft() {
            throw new NotImplementedException();
        }

        public override void Select() {

            BattleAction action = null;

            // Determine if Command or Dynamic Menu
            switch (currentSelection.Name) 
            {
                case "Command":
                    action = BattleActionFactory.CreateAction(Convert.ToInt32(currentSelection.Attributes.GetNamedItem("id").Value));
                    callback(action);
                    break;
                case "DynamicMenu":
                    currentSelection = currentSelection.FirstChild;
                    break;
                default:
                    break;
            }

            Debug.Log(currentSelection.Attributes.GetNamedItem("value").Value);
        }

        public override void Cancel() {

            if (currentSelection.ParentNode != null && currentSelection.ParentNode.Name != "RootCommands") {
                currentSelection = currentSelection.ParentNode;
            }
        }
    }
}
