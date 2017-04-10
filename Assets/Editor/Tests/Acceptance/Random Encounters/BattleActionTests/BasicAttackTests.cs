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
using MVCGame.System.Math;

public class BasicAttackTests {

    [Test]
    public void Basic_Attack_Base_Damage_Test() {

        // ARRANGE
        CombatantDAL combatantDAL = new CombatantDAL();
        Combatant actingCombatant = (Combatant)combatantDAL.LoadModel("Test-1");
        Combatant targetCombatant = (Combatant)combatantDAL.LoadModel("Test-2");

        BasicAttack basicAttack = new BasicAttack();
        basicAttack.SetTarget(targetCombatant);
        basicAttack.SetActingCombatant(actingCombatant);

        // ACT
        SingleTargetActionResult result = (SingleTargetActionResult)basicAttack.ProcessAction();

        // ASSERT
        Assert.AreNotEqual(targetCombatant.Stats.HealthPoints.CurrentValue, targetCombatant.Stats.HealthPoints.MaxValue);
        Assert.AreNotEqual(0, result.DamageDealt);
    }
}
