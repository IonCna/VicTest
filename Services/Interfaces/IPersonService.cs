using VicTest.Models;

namespace VicTest.Services.Interfaces;
public interface IPersonService
{
    Person FindByName(string name);
    List<Person> FindAll();
    List<Person> InsertOne(Person target);
}
