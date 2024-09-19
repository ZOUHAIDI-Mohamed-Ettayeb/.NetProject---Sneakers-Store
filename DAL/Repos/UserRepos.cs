using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepos
    {
        public List<User> All()
        {
            MyDbContext db = new MyDbContext();
            return db.Users.ToList();

        }

    }
}
