using System.Collections.Generic;
using GamifyFitness.Data.Entities;

namespace GamifyFitness.Data
{
    public interface IGfRepository
    {
        IEnumerable<User> getAllUsers();
        User getUser(string userId);
        FitnessUser getUserByEmail(string email);

        UserLogin GetLoggedInUser();

        bool SaveAll();

        void AddUser(object model);
        void RemoveLoginUser(object model);
    }
}