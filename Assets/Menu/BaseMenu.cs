using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Menu {
    public abstract class BaseMenu {

        public delegate void MenuCallback(object selection);

        protected bool menuToClose = false;

        public abstract void MoveUp();

        public abstract void MoveDown();

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public abstract void Select();

        public abstract void Cancel();
    }
}
