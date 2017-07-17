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
        randomEncounter.BeginTurn();

        //// ASSERT
        Assert.IsNotNull(randomEncounter.PlayerParty);
        Assert.IsNotNull(randomEncounter.EnemyParty);

        // Check that the turn has moved onto the planning phase
        Assert.AreEqual(Phase.PhaseName.PLANNING, randomEncounter.CurrentTurn.CurrentPhase.Name);
    }

    [Test]
    public void Process_Planning_Phase_Test() {

        //// ARRANGE
        // Initialise our XmlModel to load data from
        RandomEncounter randomEncounter = new RandomEncounter("TestParty", "TestParty");

        //// ACT
        randomEncounter.BeginTurn();

        foreach(Combatant combatant in randomEncounter.PlayerParty.PartyMembers) {
            ValiantStrike attack = new MVCGame.MVC.Model.BattleActions.ValiantStrike();
            attack.SetActingCombatant(combatant);
            attack.SetTarget(randomEncounter.EnemyParty.PartyMembers[0]);
            randomEncounter.CurrentTurn.PlanningPhase.ActionsToPerform.Add(attack);
        }

        List<ActionResult> results = new List<ActionResult>();

        foreach(BattleAction action in randomEncounter.CurrentTurn.PlanningPhase.ActionsToPerform) {
            results.Add(action.ProcessAction());
        }

        //// ASSERT
        foreach(ActionResult result in results) {

            SingleTargetActionResult castResult = (SingleTargetActionResult)result;
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, castResult.ShieldDamageDealt);
        }
    }
}
