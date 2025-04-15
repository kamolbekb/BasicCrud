using System.Reflection;
using Npgsql;

namespace _2;

public partial class AppDbContext(string connectionString)
{
    private readonly string _connectionString = connectionString;

    /// <summary>
    /// Asynchronously creates a table in the database for the given type <typeparamref name="T"/>,
    /// using the class's properties to define the table schema.
    /// </summary>
    /// <typeparam name="T">The type representing the table structure. Must be a class.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task CreateTableIfNotExistsAsync<T>() where T : class
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates and returns a new <see cref="NpgsqlConnection"/> using the configured connection string.
    /// </summary>
    /// <returns>A new instance of <see cref="NpgsqlConnection"/>.</returns>
    private NpgsqlConnection CreateConnection() =>
        throw new NotImplementedException();

    /// <summary>
    /// Gets the SQL table name for the given type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type for which to get the table name.</typeparam>
    /// <returns>The table name derived from the class name, lowercased and pluralized.</returns>
    private static string GetTableName<T>() =>
        throw new NotImplementedException();

    /// <summary>
    /// Returns a list of properties of type <typeparamref name="T"/> excluding the one named "Id".
    /// </summary>
    /// <typeparam name="T">The type whose properties are inspected.</typeparam>
    /// <returns>A list of <see cref="PropertyInfo"/> objects excluding "Id".</returns>
    private static List<PropertyInfo> GetPropertiesWithoutId<T>() =>
        throw new NotImplementedException();

    /// <summary>
    /// Maps a .NET type to a PostgreSQL-compatible SQL data type.
    /// </summary>
    /// <param name="type">The .NET type to convert.</param>
    /// <returns>A string representing the corresponding SQL type.</returns>
    /// <exception cref="NotSupportedException">Thrown when the type is not supported.</exception>
    private static string GetSqlType(Type type)
    {
        throw new NotImplementedException();
    }

}
