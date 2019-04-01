using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamifyFitness.Data.Entities;

namespace GamifyFitness.Data
{
    public class GfRepository : IGfRepository
    {

        private GfContext _ctx { get; }

        public GfRepository(GfContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> getAllUsers()
        {
            return _ctx
                .Users.
                OrderBy(p => p.name)
                .ToList();
        }

        public User getUser(String userId)
        {
            return _ctx.Users.Find(userId);
                
                
        }

        public FitnessUser getUserByEmail(String email)
        {
            return _ctx
                .fitUsers
                .Where(o => o.Email == email)
                .FirstOrDefault();
            
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges()>0;
        }

        public void AddUser(object model)
        {
            _ctx.Add(model);
        }

        public void RemoveLoginUser(object model)
        {
            _ctx.Remove(model);
        }

        public UserLogin GetLoggedInUser()
        {
            var user = _ctx.Logins.ToList().FirstOrDefault();
            return user;
        }
    }
}
