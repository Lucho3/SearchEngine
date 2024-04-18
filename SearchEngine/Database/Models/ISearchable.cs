using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Database.Models
{
    public interface ISearchable
    {
        Dictionary<string, object> GetProperties();
    }
}
