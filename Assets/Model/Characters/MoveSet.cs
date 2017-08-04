using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {

    public class MoveSet : Model {

        private int[] battleActionIds;
        private int[] BattleActionIds {
            get { return battleActionIds; }
        }

        public MoveSet(int[] ids) {
            this.battleActionIds = ids;
        }
    }
}
