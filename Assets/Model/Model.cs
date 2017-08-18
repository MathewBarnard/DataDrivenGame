using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCGame.MVC.Model {

    /// <summary>
    /// The base class that represents a Model Object in-game once it has been loaded in from data.
    /// </summary>
    public abstract class Model {

        // The persistent ID of the entity in the game.
        protected Guid id;
        public Guid Id {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Returns the resource ID that this entity was created from
        /// </summary>
        protected Guid resourceId;
        public Guid ResourceId {
            get { return resourceId; }
            set { resourceId = value; }
        }

        /// <summary>
        /// The user readable name of the resource.
        /// </summary>
        protected string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }
    }
}
