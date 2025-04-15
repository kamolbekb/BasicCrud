using _1;
using _1.Models;
using Npgsql;
using Xunit;

namespace BasicCrudEasy.Tests;

public class PersonRepositoryTests
{
    private readonly string _testConnectionString =
        "Host=localhost;Port=5432;Username=postgres;Password=yourpassword;Database=testdb";

    private AppDbContext CreateRepository() => new AppDbContext(_testConnectionString);

    private async Task ClearTableAsync()
    {
        using var connection = new NpgsqlConnection(_testConnectionString);
        await connection.OpenAsync();
        var cmd = new NpgsqlCommand("DELETE FROM persons", connection);
        await cmd.ExecuteNonQueryAsync();
    }

    [Fact]
    public async Task CreatePersonTableIfNotExistsAsync_ShouldCreatePersonsTable()
    {
        // Arrange
        using var connection = new NpgsqlConnection(_testConnectionString);
        await connection.OpenAsync();

        var command = new NpgsqlCommand(@"
        CREATE TABLE IF NOT EXISTS persons (
            id SERIAL PRIMARY KEY,
            firstname VARCHAR(100) NOT NULL,
            age INT NOT NULL
        );", connection);

        // Act
        await command.ExecuteNonQueryAsync();

        // Assert
        var checkCommand = new NpgsqlCommand(
            "SELECT COUNT(*) FROM information_schema.tables WHERE table_name = 'persons';",
            connection);

        var count = (long)await checkCommand.ExecuteScalarAsync();

        Assert.Equal(1, count);
    }


    [Fact]
    public async Task AddPersonAsync_ShouldInsertPerson()
    {
        var repo = CreateRepository();
        await ClearTableAsync();
        await repo.CreatePersonTableIfNotExistsAsync();

        var person = new Person { FirstName = "John", Age = 30 };
        var result = await repo.AddPersonAsync(person);

        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetAllPeopleAsync_ShouldReturnInsertedPerson()
    {
        var repo = CreateRepository();
        await ClearTableAsync();
        await repo.CreatePersonTableIfNotExistsAsync();

        var person = new Person { FirstName = "Jane", Age = 25 };
        await repo.AddPersonAsync(person);

        var people = await repo.GetAllPeopleAsync();

        Assert.Single(people);
        Assert.Equal("Jane", people[0].FirstName);
        Assert.Equal(25, people[0].Age);
    }

    [Fact]
    public async Task UpdatePersonAsync_ShouldUpdateExistingPerson()
    {
        var repo = CreateRepository();
        await ClearTableAsync();
        await repo.CreatePersonTableIfNotExistsAsync();

        var person = new Person { FirstName = "Mike", Age = 40 };
        await repo.AddPersonAsync(person);
        var people = await repo.GetAllPeopleAsync();

        var toUpdate = people[0];
        toUpdate.FirstName = "Michael";
        toUpdate.Age = 41;

        var result = await repo.UpdatePersonAsync(toUpdate);
        var updatedPeople = await repo.GetAllPeopleAsync();

        Assert.Equal(1, result);
        Assert.Equal("Michael", updatedPeople[0].FirstName);
        Assert.Equal(41, updatedPeople[0].Age);
    }

    [Fact]
    public async Task DeletePersonAsync_ShouldRemovePerson()
    {
        var repo = CreateRepository();
        await ClearTableAsync();
        await repo.CreatePersonTableIfNotExistsAsync();

        var person = new Person { FirstName = "Alice", Age = 35 };
        await repo.AddPersonAsync(person);

        var people = await repo.GetAllPeopleAsync();
        var idToDelete = people[0].Id;

        var result = await repo.DeletePersonAsync(idToDelete);
        var remaining = await repo.GetAllPeopleAsync();

        Assert.Equal(1, result);
        Assert.Empty(remaining);
    }
}
