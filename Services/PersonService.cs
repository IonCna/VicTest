using VicTest.Models;
using VicTest.Handlers;
using VicTest.Services.Interfaces;
using System.Net;

namespace VicTest.Services;

public class PersonService : IPersonService
{
    private readonly List<Person> PersonList = [];
    public PersonService() {
        Person Jose = new()
        {
            Id = 0,
            Age = 18,
            Name = "José",
            LastName = "Backero"
        };

        Person Maria = new()
        {
            Id = 1,
            Age = 22,
            Name = "Maria",
            LastName = "Perez"
        };

        Person Alex = new()
        {
            Id = 2,
            Age = 24,
            Name = "Alex",
            LastName = "Flores"
        };

        PersonList.Add(Jose);
        PersonList.Add(Maria);
        PersonList.Add(Alex);
    }

    public Person FindByName(string name)
    {
        var result = PersonList.Where((person) => person.Name == name).FirstOrDefault();
        return result ?? throw new Exception("persona no encontrada");
    }

    public List<Person> FindAll() => [.. PersonList];

    public List<Person> InsertOne(Person target)
    {

        var itExist = PersonList.Where((person) => person.Id == target.Id);

        if(itExist.Any())
        {
            throw new ErrorHandler(HttpStatusCode.Conflict, "Id duplicada");
        }

        PersonList.Add(target);
        return PersonList;
    }
}
