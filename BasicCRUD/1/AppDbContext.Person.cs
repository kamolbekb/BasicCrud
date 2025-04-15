using _1.Models;
using Npgsql;

namespace _1;

public partial class AppDbContext
{
    /// <summary>
    /// Asynchronously adds a new person to the 'persons' table.
    /// </summary>
    /// <param name="person">The <see cref="Person"/> object containing the person's first name and age.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the number of rows affected (should be 1 if successful).
    /// </returns>

    public async Task<int> AddPersonAsync(Person person)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Asynchronously retrieves all persons from the 'persons' table.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of <see cref="Person"/> objects.
    /// </returns>

    public async Task<List<Person>> GetAllPeopleAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Asynchronously updates the information of an existing person in the 'persons' table.
    /// </summary>
    /// <param name="person">The <see cref="Person"/> object containing the updated data (must include a valid ID).</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the number of rows affected (should be 1 if successful).
    /// </returns>

    public async Task<int> UpdatePersonAsync(Person person)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Asynchronously deletes a person from the 'persons' table based on their ID.
    /// </summary>
    /// <param name="id">The ID of the person to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the number of rows affected (should be 1 if successful).
    /// </returns>

    public async Task<int> DeletePersonAsync(int id)
    {
        throw new NotImplementedException();
    }
}
