using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Database.Reositories
{
    public class BaseRepository<T> where T : class
    {
        public List<T> GetAll()
        {
            using (var dbContext = new DbContextRandom())
            {
                return dbContext.Set<T>().ToList();
            }
        }
    }
}
