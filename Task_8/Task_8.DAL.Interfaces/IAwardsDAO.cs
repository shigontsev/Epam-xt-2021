using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.DAL.Interfaces
{
    public interface IAwardsDAO
    {
        List<Award> GetAllAwards();

        void AddAward(Award award);

        void RemoveAward(Guid id);

        void EditTitel(Guid id, string newTitle);
    }
}
