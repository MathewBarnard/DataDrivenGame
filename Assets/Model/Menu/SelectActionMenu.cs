using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model.Menu
    {
    public class SelectActionMenu : Model {

        public int[] actionIds;

        public SelectActionMenu(int[] actionIds) {
            this.actionIds = actionIds;
        }
    }
}
