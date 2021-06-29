using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace as2.Services{
    public class PersonService : IPersonService
    {
        static List<Person> members = new List<Person>
        {
                new Person()
                {
                    Id = 1,
                    FirstName = "Trang ",
                    LastName = "Nguyen Huyen",
                    Gender = "famela",
                    DateOfBirth = new DateTime(2002,7,14),
                    BirthPlace = "Hai Duong",
                    Age = 19,
                    IsGraduated = false
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Hoang",
                    LastName = "Nguyen",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000,1,1),
                    BirthPlace = "Ha Noi",
                    Age = 21,
                    IsGraduated = false
                },
                new Person()
                {
                    Id =3,
                    FirstName = "Hoa",
                    LastName = "Nguyen",
                    Gender = "famela",
                    DateOfBirth = new DateTime(1999,1,1),
                    BirthPlace = "Ha Noi",
                    Age = 22,
                    IsGraduated = false
                },
                new Person(){
                    Id = 4,
                    FirstName = "Vy",
                    LastName = "Tran Thi",
                    Gender = "famela",
                    DateOfBirth = new DateTime(1999,2,12),
                    BirthPlace = "Ha Noi",
                    Age = 22,
                    IsGraduated = false
                },
                new Person(){
                    Id = 5,
                    FirstName = "Son",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2001,2,12),
                    BirthPlace = "Ha Noi",
                    Age = 20,
                    IsGraduated = false
                },
        };
        public List<Person> GetAll()
        {
            return members;
        }
        public void Create(Person model)
        {
            members.Add(model);
        }
         public void Update(Person model)
        {
            var list = members.Where(m => m.Id != model.Id).ToList();
            list.Insert(0, model);
            members=list;
        }

        public void Delete(int id)
        {
            var list = members.Where(m => m.Id != id).ToList();
            members = list;
        }

        public Person GetOne(int id)
        {
            return members.FirstOrDefault(m => m.Id == id);
        }
    }
}