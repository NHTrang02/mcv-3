using System.Collections.Generic;
using Models;
namespace as2.Services{
   public interface IPersonService
{
   List<Person> GetAll();
   Person GetOne(int id);
   void Create(Person model);
   void Update(Person model);
   void Delete(int id);
    
}
}
