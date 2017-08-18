using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Buffs {
    public class BuffFactory {

        public static Buff CreateBuff(Combatant combatant, int id) {

            switch(id) {
                case 0:
                    return new FrontRow(combatant);
                default:
                    return null;
            }
        }
    }
}
