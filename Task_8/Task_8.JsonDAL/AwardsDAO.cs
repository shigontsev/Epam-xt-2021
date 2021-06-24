using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    public class AwardsDAO : IAwardsDAO
    {
        public void AddAward(Award award)
        {
            var awards = GetAllAwards();

            var isContains = awards.FirstOrDefault(a => a.Title == award.Title);
            if (isContains != null)
            {
                throw new ArgumentException(nameof(award.Title), $"Award with Title \'{award.Title}\' already exists");
            }

            awards.Add(award);
            JsonDAO<Award>.Serialize(FilePath.JsonAwardsPath, awards);
        }

        public List<Award> GetAllAwards()
        {
            var awards = JsonDAO<Award>.Deserialize(FilePath.JsonAwardsPath);

            return awards;
        }

        public void RemoveAward(Guid id)
        {
            var awards = GetAllAwards();

            var isContains = awards.FirstOrDefault(a => a.Id == id);
            if (isContains == null)
            {
                throw new ArgumentNullException(nameof(id), $"Award at Id {id} doesn't exist");
            }

            awards.Remove(isContains);
            JsonDAO<Award>.Serialize(FilePath.JsonAwardsPath, awards);
        }
    }
}
