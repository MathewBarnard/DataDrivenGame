using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using MVCGame.System.Configuration;
using System.Xml.Serialization;
using System.IO;
using MVCGame.MVC.Model.DataStorage.XML;
using System.Collections.Generic;
using MVCGame.MVC.Model.Encounters;
using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.BattleActions;

public class RandomEncounterTests {

    [Test]
    public void Start_Random_Encounter_Test() {

        //// ARRANGE
        // Initialise our XmlModel to load data from
        RandomEncounter randomEncounter = new RandomEncounter("TestParty", "TestParty");

        //// ACT

        //// ASSERT
        Assert.IsNotNull(randomEncounter.PlayerParty);
        Assert.IsNotNull(randomEncounter.EnemyParty);
    }

    [Test]
    public void Process_Upkeep_Phase_Test() {

        //// ARRANGE
        // Initialise our XmlModel to load data from
        RandomEncounter randomEncounter = new RandomEncounter("TestParty", "TestParty");

        //// ACT
        //randomEncounter.BeginTurn();

        //// ASSERT
        Assert.IsNotNull(randomEncounter.PlayerParty);
        Assert.IsNotNull(randomEncounter.EnemyParty);
    }

    [Test]
    public void Process_Planning_Phase_Test() {

        //// ARRANGE
        // Initialise our XmlModel to load data from
        RandomEncounter randomEncounter = new RandomEncounter("TestParty", "TestParty");

        //// ACT
        //randomEncounter.BeginTurn();

        foreach(Combatant combatant in randomEncounter.PlayerParty.PartyMembers) {
            Attack attack = new MVCGame.MVC.Model.BattleActions.Attack("Attack");
            attack.SetActingCombatant(combatant);
            attack.SetTarget(randomEncounter.EnemyParty.PartyMembers[0]);
        }

        List<ActionResult> results = new List<ActionResult>();


        //// ASSERT
        foreach(ActionResult result in results) {

            SingleTargetActionResult castResult = (SingleTargetActionResult)result;
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, castResult.ShieldDamageDealt);
        }
    }
}
