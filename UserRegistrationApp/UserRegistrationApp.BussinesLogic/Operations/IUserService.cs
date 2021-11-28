using System;
using System.Collections.Generic;
using System.Linq;
using UserRegistrationApp.EFEntity.Models;

// TODO: Add tests for all operations
namespace UserRegistrationApp.BusinessLogic.Operations
{
    // Services with CRUD operations for user
    public interface IUserService
    {
        /// <summary>
        /// Query operations for get all users
        /// </summary>
        /// <returns>Returns all user`s records</returns>
        IQueryable<User> Query();

        /// <summary>
        /// Remove user by Id
        /// </summary>
        /// <param name="id">User`s primary key</param>
        /// <returns>Returns key of deleted user</returns>
        int Delete(int? id);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">User entity with data</param>
        /// <returns>Returns key of created user</returns>
        int Create(User user);

        //TODO: Perhaps it should be move to a separate service
        /// <summary>
        /// Validation for login
        /// </summary>
        /// <param name="login">User`s login</param>
        /// <returns>Returns false if login incorrect</returns>
        IEnumerable<Tuple<string, string>> AdditionalValidation(User user);
    }
}
