using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.DataStorage.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.System {
    public class CombatantWrapper : IEntityWrapper<Combatant> {

        private CombatantDAL DAL;
        private List<Combatant> combatants;

        public CombatantWrapper() {
            this.combatants = new List<Combatant>();
            this.DAL = new CombatantDAL();
        }

        public Combatant GetById(Guid id) {
            return null;
        }

        public Combatant GetByName(string name) {

            // Poll memory for this combatant
            Combatant combatant = combatants.Where(c => c.Name == name).FirstOrDefault();

            // If they can't be found, load them and return.
            if(combatant == null) {
                combatant = (Combatant)this.DAL.LoadModel(name);
                this.combatants.Add(combatant);
                return combatant;
            }
            else {
                return combatant;
            }
        }

        public void Persist(Combatant combatant) {

            if(!this.combatants.Contains(combatant))
                this.combatants.Add(combatant);
        }

        public void PersistList(List<Combatant> combatants) {
            foreach (Combatant combatant in combatants) {
                this.Persist(combatant);
            }
        }
    }
}
