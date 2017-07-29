using MVCGame.MVC.Model.BattleActions;
using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.System.Messaging {

    public delegate void BattleActionCallback(BattleAction action);

    public delegate void CombatantCallback(Combatant combatant);

    public delegate void IntegerCallback(int integer);

    public delegate void GuidCallback(Guid guid);
}
