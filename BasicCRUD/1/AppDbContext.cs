using Npgsql;

namespace _1;

public partial class AppDbContext(string connectionString)
{

    private readonly string _connectionString = connectionString;

    /// <summary>
    /// Asynchronously creates the 'persons' table in the PostgreSQL database if it does not already exist.
    /// </summary>
    /// <remarks>
    /// The table includes the following columns:
    /// - id: Auto-incremented primary key (SERIAL)
    /// - firstname: A non-nullable string up to 100 characters
    /// - age: A non-nullable integer
    /// </remarks>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CreatePersonTableIfNotExistsAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates and returns a new <see cref="NpgsqlConnection"/> using the configured connection string.
    /// </summary>
    /// <returns>
    /// A new instance of <see cref="NpgsqlConnection"/> that is not yet opened.
    /// </returns>

    private NpgsqlConnection CreateConnection() =>
        throw new NotImplementedException();
}
