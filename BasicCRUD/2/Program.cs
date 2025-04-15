using _2.Models;

namespace _2;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Ensure the database is created before running the application.
        var connectionString = "Host=localhost;Port=5432;Database=basic_crud_1;Username=postgres;Password=web@1234";

        var dbContext = new AppDbContext(connectionString);

        // 1. Create Table If Not Exists
        Console.WriteLine("Checking table...");
        await dbContext.CreateTableIfNotExistsAsync<Book>();
        Console.WriteLine("Table is ready!\n");

        // 2. Add Book
        var newBook = new Book
        {
            Name = "Clean Code",
            PageCount = 464
        };

        var addResult = await dbContext.AddAsync(newBook);
        Console.WriteLine($"AddAsync result: {addResult}");

        // 3. Get All Books
        Console.WriteLine("\nAll books in table:");
        var books = await dbContext.GetAllAsync<Book>();

        foreach (var book in books)
        {
            Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, PageCount: {book.PageCount}");
        }

        // 4. Update Book
        if (books.Count > 0)
        {
            var bookToUpdate = books[0];
            bookToUpdate.Name = "The Clean Coder";
            bookToUpdate.PageCount = 320;

            var updateResult = await dbContext.UpdateAsync(bookToUpdate);
            Console.WriteLine($"\nUpdateAsync result: {updateResult}");

            // Show updated books
            books = await dbContext.GetAllAsync<Book>();
            Console.WriteLine("\nBooks after update:");
            foreach (var book in books)
            {
                Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, PageCount: {book.PageCount}");
            }
        }

        // 5. Delete Book
        if (books.Count > 0)
        {
            var bookIdToDelete = books[0].Id;

            var deleteResult = await dbContext.DeleteAsync<Book>(bookIdToDelete);
            Console.WriteLine($"\nDeleteAsync result: {deleteResult}");

            // Show books after delete
            books = await dbContext.GetAllAsync<Book>();
            Console.WriteLine("\nBooks after delete:");
            foreach (var book in books)
            {
                Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, PageCount: {book.PageCount}");
            }
        }

        Console.WriteLine("\nProgram finished. Press any key to exit...");
        Console.ReadKey();
    }
}
