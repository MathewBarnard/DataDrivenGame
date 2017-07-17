using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using MVCGame.System.Configuration;
using System.Xml.Serialization;
using System.IO;
using MVCGame.MVC.Model.DataStorage.XML;
using System.Collections.Generic;

public class ReadDataFromXmlTests {

    [Test]
    public void Load_Xml_Combatant_To_Model() {

        //// ARRANGE
        // Initialise our XmlModel to load data from
        CombatantDAL xmlCombatant = new CombatantDAL();

        //// ACT
        MVCGame.MVC.Model.Characters.Combatant combatant = (MVCGame.MVC.Model.Characters.Combatant)xmlCombatant.LoadModel("Test-1");

        //// ASSERT
        Assert.IsNotNull(combatant.Name);
        Assert.IsNotNull(combatant.Stats.Attack);
        Assert.IsNotNull(combatant.Stats.Defense);
        Assert.IsNotNull(combatant.Stats.HealthPoints);
        Assert.IsNotNull(combatant.Stats.Speed);
        Assert.IsNotNull(combatant.Stats.Shield);
    }

    [Test]
    public void Load_Xml_Party_To_Model_Test() {

        //// ARRANGE
        PartyDAL xmlParty = new PartyDAL();

        //// ACT
        MVCGame.MVC.Model.Characters.Party party = (MVCGame.MVC.Model.Characters.Party)xmlParty.LoadModel("TestParty");

        //// ASSERT
        Assert.AreEqual(4, party.PartyMembers.Count);
        
        foreach(MVCGame.MVC.Model.Characters.Combatant combatant in party.PartyMembers) {

            Assert.IsNotNull(combatant.Name);
            Assert.IsNotNull(combatant.Stats.Attack);
            Assert.IsNotNull(combatant.Stats.Defense);
            Assert.IsNotNull(combatant.Stats.HealthPoints);
            Assert.IsNotNull(combatant.Stats.Speed);
            Assert.IsNotNull(combatant.Stats.Shield);
        }
    }

    [Test]
    public void Load_Random_Encounter_Model_Test() {

        //// ARRANGE

        //// ACT
        MVCGame.MVC.Model.Encounters.RandomEncounter randomEncounter = new MVCGame.MVC.Model.Encounters.RandomEncounter("TestParty", "TestParty");

        //// ASSERT
        Assert.IsNotNull(randomEncounter.PlayerParty);
        Assert.IsNotNull(randomEncounter.EnemyParty);
    }


    [Test]
    public void Load_Menu_Layout_Model_Test() {

        //// ARRANGE

        //// ACT
        MVCGame.MVC.Model.DataStorage.XML.MenuLayoutDAL menuLayoutDAL = new MVCGame.MVC.Model.DataStorage.XML.MenuLayoutDAL();

        menuLayoutDAL.LoadModel("Test-1");
    }
}
