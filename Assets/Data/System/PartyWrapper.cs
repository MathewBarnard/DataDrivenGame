using MVCGame.MVC.Model.Characters;
using MVCGame.MVC.Model.DataStorage.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.System {
    public class PartyWrapper : IEntityWrapper<Party> {

        private PartyDAL DAL;
        private List<Party> parties;

        public Party GetById(Guid id) {
            return null;
        }

        public Party GetByName(string name) {
            return null;
        }

        public void Persist(Party party) { }

        public void PersistList(List<Party> parties) { }
    }
}
