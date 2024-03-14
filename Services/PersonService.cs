using VicTest.Models;

namespace VicTest.Services;

public class PersonService
{
    private List<Person> PersonList = [];
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

    public void CreateNewPerson(Person target) {
        PersonList.Add(target);
    }

    public List<Person> GetPersonList()
    {
        return PersonList;
    }
}
