using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.CombatCharacterStatistics.Enemies.Strategies.Conditions {
    public interface IPlayerPartyCondition {

        void SetPlayerParty(Party playerParty);
    }
}
