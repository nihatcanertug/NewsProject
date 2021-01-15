using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.DataAccessLayer.Repositories.Concrete.EfRepository
{
    public class EfAppUserRepository:BaseRepository<AppUser>
    {
        public bool CheckCredential(string userName, string password) => Any(x => x.UserName == userName && x.Password == password);

        public AppUser FindByUserName(string userName) => GetByDefault(x => x.UserName == userName);
    }
}
