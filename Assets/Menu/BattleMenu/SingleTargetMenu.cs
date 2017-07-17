using MVCGame.MVC.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Menu.BattleMenu {

    public class SingleTargetMenu : BaseMenu {

        private MenuCallback callback;

        private int targetIndex;

        // The list of possible targets
        private List<Combatant> possibleTargets;

        // Inject the possible targets into the constructor.
        public SingleTargetMenu(List<Combatant> possibleTargets, MenuCallback callback) {
            this.callback = callback;
            this.possibleTargets = possibleTargets;
            targetIndex = 0;
        }

        public override void Cancel() {
            throw new NotImplementedException();
        }

        public override void MoveDown() {
            if(targetIndex < possibleTargets.Count)
                targetIndex += 1;

            Debug.Log(targetIndex + ": " + possibleTargets[targetIndex].Name);
        }

        public override void MoveLeft() {
            throw new NotImplementedException();
        }

        public override void MoveRight() {
            throw new NotImplementedException();
        }

        public override void MoveUp() {
            if (targetIndex > 0)
                targetIndex -= 1;

            Debug.Log(targetIndex + ": " + possibleTargets[targetIndex].Name);
        }

        public override void Select() {
            callback(possibleTargets[targetIndex]);
        }
    }
}
