using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    public class UsersAndAwardsDAO : IUsersAndAwardsDAO
    {
        public List<UsersAndAwards> GetAll()
        {
            var list = JsonDAO<UsersAndAwards>.Deserialize(FilePath.JsonUsersAndAwardsPath);

            return list ?? new List<UsersAndAwards>();
        }

        public List<Award> GetAwardsByUser(Guid idUser)
        {
            var idAwards = GetAll().FindAll(UaA => UaA.IdUser == idUser).Select(a=>a.IdAward).ToList();
            if(idAwards.Count == 0)
            {
                return new List<Award>();
            }
            var awards = JsonDAO<Award>.Deserialize(FilePath.JsonAwardsPath).FindAll(a=>idAwards.Contains(a.Id)).ToList();

            return awards;
        }

        public List<User> GetUsersByAward(Guid idAward)
        {
            var idUsers = GetAll().FindAll(UaA => UaA.IdAward == idAward).Select(a => a.IdUser).ToList();
            if(idUsers.Count == 0)
            {
                return new List<User>();
            }
            var users = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath).FindAll(a => idUsers.Contains(a.Id)).ToList();

            return users;
        }

        /// <summary>
        /// Присвоить награду пользователю
        /// </summary>
        /// <param name="idAward"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool AssignAwardToUser(Guid idAward, Guid idUser)
        {
            var list = GetAll();

            if (list.Count > 0)
            {
                var isContains = list.FirstOrDefault(x => (x.IdAward == idAward && x.IdUser == idUser));
                if (isContains != null)
                {
                    return false;
                }
                list.Add(new UsersAndAwards(list.Last().Id + 1, idUser, idAward));
            }
            else
            {
                list.Add(new UsersAndAwards(0, idUser, idAward));
            }

            JsonDAO<UsersAndAwards>.Serialize(FilePath.JsonUsersAndAwardsPath, list);

            return true;
        }

        /// <summary>
        /// Лишить пользователя награды
        /// </summary>
        /// <param name="idAward"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool UnAssignAwardToUser(Guid idAward, Guid idUser)
        {
            var list = GetAll();

            if (list.Count > 0)
            {
                var isContains = list.FirstOrDefault(x => (x.IdAward == idAward && x.IdUser == idUser));
                if (isContains == null)
                {
                    return false;
                }
                list.Remove(isContains);

                JsonDAO<UsersAndAwards>.Serialize(FilePath.JsonUsersAndAwardsPath, list);

                return true;
            }

            return false;
        }

        public List<Award> GetAwardsNotAvailableByUser(Guid idUser)
        {
            var idAwards = GetAll().FindAll(UaA => UaA.IdUser == idUser).Select(a => a.IdAward).ToList();
            if (idAwards.Count == 0)
            {
                return JsonDAO<Award>.Deserialize(FilePath.JsonAwardsPath)?? new List<Award>();//return list awards
            }
            var awards = JsonDAO<Award>.Deserialize(FilePath.JsonAwardsPath).FindAll(a => !idAwards.Contains(a.Id)).ToList();

            return awards;
        }

        public List<User> GetUsersNotAvailableByAward(Guid idAward)
        {
            var idUsers = GetAll().FindAll(UaA => UaA.IdAward == idAward).Select(a => a.IdUser).ToList();
            if (idUsers.Count == 0)
            {
                return JsonDAO<User>.Deserialize(FilePath.JsonUsersPath)?? new List<User>();//return list users
            }
            var users = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath).FindAll(a => !idUsers.Contains(a.Id)).ToList();

            return users;
        }
    }
}
