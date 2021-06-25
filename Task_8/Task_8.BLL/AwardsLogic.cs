using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.BLL.Interfaces;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.BLL
{
    public class AwardsLogic : IAwardsLogic
    {
        private IAwardsDAO _awardsDAO;

        public AwardsLogic(IAwardsDAO awardsDAO)
        {
            _awardsDAO = awardsDAO;
        }

        public void AddAward(Award award)
        {
            _awardsDAO.AddAward(award);
        }

        public List<Award> GetAllAwards()
        {
            return _awardsDAO.GetAllAwards();
        }

        public void RemoveAward(Guid id)
        {
            _awardsDAO.RemoveAward(id);
        }

        public void RemoveAward(Award award) => RemoveAward(award.Id);

        public void EditTitel(Guid id, string newTitle)
        {
            _awardsDAO.EditTitel(id, newTitle);
        }
    }
}
