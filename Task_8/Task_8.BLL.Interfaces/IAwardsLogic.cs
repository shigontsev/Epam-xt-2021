using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.BLL.Interfaces
{
    public interface IAwardsLogic
    {
        List<Award> GetAllAwards();

        void AddAward(Award award);

        void RemoveAward(Guid id);

        void RemoveAward(Award award);

        void EditTitel(Guid id, string newTitle);
    }
}
