using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;
using UBTeach.Data.Models;

namespace UBTeach.Data.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        //Any special person queries 
      
    }
}