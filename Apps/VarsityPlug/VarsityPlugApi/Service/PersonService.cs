using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Update.Internal;
using VarsityPlug.Models;

namespace VarsityPlugApi.Service
{
    public static class PersonService
    {
        static List<Person> People { get; }

        static PersonService() 
        {
            People = new List<Person>()
            {
                new Person { Name="Omphulusa",Surname="Mashau", Id=202244400, Cell="0783887879", Email="202244400@keyaka.ul.ac.za", Password="omphulusa"},
                new Person { Name="Ndivhuwo",Surname="Mashau", Id=202044400, Email="202044400@keyaka.ul.ac.za",Cell="0789190523", Password="ndivhuwo" }
            };
        }

        //Get person by id
        public static Person? Get(int id) => People.FirstOrDefault(p => p.Id == id);

        public static void Add(Person person)
        {
            /*
            Random random = new Random();
            person.Id = random.Next(201000000, 202999999);
            */
            People.Add(person);
        }
        public static void Delete(int id)
        {
            var person = Get(id);
            if (person is null) 
                return;
            People.Remove(person);
        }

        public static void Update(Person person)
        {
            var index = People.FindIndex(p => p.Id == person.Id);
            if (index == -1) 
                return;
            People[index] = person;
        }

    }
}
