using _2.Models;
using Npgsql;

namespace _2;

public partial class AppDbContext
{
    /// <summary>
    /// Inserts a new entity into the corresponding SQL table based on type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The entity type. Must be a class.</typeparam>
    /// <param name="entity">The entity to insert.</param>
    /// <returns>Number of rows affected.</returns>
    public async Task<int> AddAsync<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves all records from the table that corresponds to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type representing the table structure. Must have a parameterless constructor.</typeparam>
    /// <returns>List of all entities of type <typeparamref name="T"/>.</returns>
    public async Task<List<T>> GetAllAsync<T>() where T : class, new()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates an existing record in the table that corresponds to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity. Must implement <see cref="IEntity"/>.</typeparam>
    /// <param name="entity">The entity to update (must contain a valid Id).</param>
    /// <returns>Number of rows affected.</returns>
    public async Task<int> UpdateAsync<T>(T entity) where T : class, IEntity
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a record from the table that corresponds to type <typeparamref name="T"/> based on its Id.
    /// </summary>
    /// <typeparam name="T">The type of entity. Must implement <see cref="IEntity"/>.</typeparam>
    /// <param name="id">The Id of the entity to delete.</param>
    /// <returns>Number of rows affected.</returns>
    public async Task<int> DeleteAsync<T>(int id) where T : class, IEntity
    {
        throw new NotImplementedException();
    }

}
