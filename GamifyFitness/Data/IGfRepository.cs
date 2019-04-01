using System.Collections.Generic;
using GamifyFitness.Data.Entities;

namespace GamifyFitness.Data
{
    public interface IGfRepository
    {
        IEnumerable<User> getAllUsers();
        User getUser(string userId);

        bool SaveAll();
        void AddUser(object model);
    }
}