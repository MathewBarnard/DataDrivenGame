using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Characters {
    public class BuffSet : Model {

        private int[] buffIds;
        private int[] BuffIds {
            get { return buffIds; }
        }

        public BuffSet(int[] ids) {
            this.buffIds = ids;
        }
    }
}
