using _1.Models;

namespace _1;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Ensure the database is created before running the application.
        var connectionString = "Host=localhost;Port=5432;Database=basic_crud_1;Username=postgres;Password=web@1234";

        var dbContext = new AppDbContext(connectionString);

        // 1. Create Table
        Console.WriteLine("Checking table...");
        await dbContext.CreatePersonTableIfNotExistsAsync();
        Console.WriteLine("Table is ready!\n");

        // 2. Add Person
        var newPerson = new Person
        {
            FirstName = "John",
            Age = 30
        };

        var addResult = await dbContext.AddPersonAsync(newPerson);
        Console.WriteLine($"AddPersonAsync result: {addResult}");

        // 3. Get All People
        Console.WriteLine("\nAll persons  in table:");
        var persons = await dbContext.GetAllPeopleAsync();

        foreach (var person in persons)
        {
            Console.WriteLine($"Id: {person.Id}, Name: {person.FirstName}, Age: {person.Age}");
        }

        // 4. Update Person
        if (persons.Count > 0)
        {
            var personToUpdate = persons[0];
            personToUpdate.FirstName = "Updated John";
            personToUpdate.Age = 35;

            var updateResult = await dbContext.UpdatePersonAsync(personToUpdate);
            Console.WriteLine($"\nUpdatePersonAsync result: {updateResult}");

            // Show updated persons 
            persons = await dbContext.GetAllPeopleAsync();
            Console.WriteLine("\nPeople after update:");
            foreach (var person in persons)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.FirstName}, Age: {person.Age}");
            }
        }

        //5.Delete Person
        if (persons.Count > 0)
        {
            var personIdToDelete = persons[0].Id;

            var deleteResult = await dbContext.DeletePersonAsync(personIdToDelete);
            Console.WriteLine($"\nDeletePersonAsync result: {deleteResult}");

            // Show persons  after delete
            persons = await dbContext.GetAllPeopleAsync();
            Console.WriteLine("\nPeople after delete:");
            foreach (var person in persons)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.FirstName}, Age: {person.Age}");
            }
        }

        Console.WriteLine("\nProgram finished. Press any key to exit...");
        Console.ReadKey();
    }
}
