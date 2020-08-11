using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UBTeach.Data.Models;

namespace UBTeach.Service.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Task<Person> GetById(int id);
        Task<Person> Add(Person newCustomer);
        Task<List<Person>> Find(Expression<Func<Person, bool>> predicate);
    }
}