namespace BaasicCrudAdvanced.Tests;

using _2;
using _2.Models;
using Npgsql;
using System.Threading.Tasks;
using Xunit;

public class GenericCrudTests
{
    private readonly string _connStr = "Host=localhost;Port=5432;Username=postgres;Password=yourpassword;Database=testdb";

    private AppDbContext CreateRepo() => new AppDbContext(_connStr);

    private async Task ClearTableAsync(string tableName)
    {
        using var connection = new NpgsqlConnection(_connStr);
        await connection.OpenAsync();
        var cmd = new NpgsqlCommand($"DELETE FROM {tableName};", connection);
        await cmd.ExecuteNonQueryAsync();
    }

    [Fact]
    public async Task CreateTableIfNotExistsAsync_ShouldCreateTable()
    {
        var repo = CreateRepo();

        await repo.CreateTableIfNotExistsAsync<Book>();

        using var connection = new NpgsqlConnection(_connStr);
        await connection.OpenAsync();

        var cmd = new NpgsqlCommand(
            "SELECT COUNT(*) FROM information_schema.tables WHERE table_name = 'books';",
            connection);

        var count = (long)await cmd.ExecuteScalarAsync();

        Assert.Equal(1, count);
    }

    [Fact]
    public async Task AddAsync_ShouldInsertBook()
    {
        var repo = CreateRepo();
        await repo.CreateTableIfNotExistsAsync<Book>();
        await ClearTableAsync("books");

        var book = new Book
        {
            Name = "Clean Architecture",
            PageCount = 352
        };

        var result = await repo.AddAsync(book);

        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnInsertedBooks()
    {
        var repo = CreateRepo();
        await repo.CreateTableIfNotExistsAsync<Book>();
        await ClearTableAsync("books");

        await repo.AddAsync(new Book
        {
            Name = "Domain-Driven Design",
            PageCount = 560
        });

        var all = await repo.GetAllAsync<Book>();

        Assert.Single(all);
        Assert.Equal("Domain-Driven Design", all[0].Name);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateBook()
    {
        var repo = CreateRepo();
        await repo.CreateTableIfNotExistsAsync<Book>();
        await ClearTableAsync("books");

        await repo.AddAsync(new Book
        {
            Name = "Old Title",
            PageCount = 100
        });

        var book = (await repo.GetAllAsync<Book>())[0];
        book.Name = "Updated Title";
        book.PageCount = 250;

        var result = await repo.UpdateAsync(book);
        var updated = (await repo.GetAllAsync<Book>())[0];

        Assert.Equal(1, result);
        Assert.Equal("Updated Title", updated.Name);
        Assert.Equal(250, updated.PageCount);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveBook()
    {
        var repo = CreateRepo();
        await repo.CreateTableIfNotExistsAsync<Book>();
        await ClearTableAsync("books");

        await repo.AddAsync(new Book
        {
            Name = "To Be Deleted",
            PageCount = 123
        });

        var book = (await repo.GetAllAsync<Book>())[0];

        var result = await repo.DeleteAsync<Book>(book.Id);
        var all = await repo.GetAllAsync<Book>();

        Assert.Equal(1, result);
        Assert.Empty(all);
    }
}
