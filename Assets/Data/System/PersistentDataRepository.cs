using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.DataStorage.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.System {
    public class PersistentDataRepository {

        private static PersistentDataRepository dataRepository;

        // The current party
        private Party playerParty;
        public Party PlayerParty {
            get { return playerParty; }
        }

        public CombatantWrapper Combatants;
        public PartyWrapper Parties;

        public static PersistentDataRepository ActiveInstance() {

            if(dataRepository == null) {
                dataRepository = new PersistentDataRepository();
            }

            return dataRepository;
        }

        public PersistentDataRepository() {

            this.Combatants = new CombatantWrapper();
            this.Parties = new PartyWrapper();

            // Load the players current party configuration and the enemy party from storage. 
            MVCGame.MVC.Model.DataStorage.XML.PartyDAL partyDao = new MVCGame.MVC.Model.DataStorage.XML.PartyDAL();
            this.playerParty = (Party)partyDao.LoadModel("TestPartySolo");

            this.Combatants.PersistList(this.playerParty.PartyMembers);
            this.Combatants.GetByName("Xan");
            this.Combatants.GetByName("Tazara");
            this.Combatants.GetByName("Nekra");
            this.Combatants.GetByName("Rode");
            this.Combatants.GetByName("Ixis");

            Combatant combatant = this.Combatants.GetByName("Xan");

            Console.WriteLine("");

            // Load the party configuration using the results above
        }
    }
}
