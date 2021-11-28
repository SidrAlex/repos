using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using UserRegistrationApp.EFEntity.DbContext.DbContexts;
using UserRegistrationApp.EFEntity.Models;

namespace UserRegistrationApp.BusinessLogic.Operations.Implementations
{
    public class UserService: IUserService
    {

        private readonly ILogger<UserService> _logger;
        private readonly UserContext _userContext;

        public UserService(UserContext userContext, ILogger<UserService> logger)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IQueryable<User> Query()
        {
            return ErrorProcessing<IQueryable<User>>(() => _userContext.Users);
        }

        public int Delete(int? id)
        {
            var removed = Query().FirstOrDefault(x => x.Id == id);
            if (removed != null)
            {
                var result = ErrorProcessing(() => _userContext.Remove(removed).Entity.Id);

                return result;
            }

            throw GetExceptionAndLog($"An error occurred while processing the deleted user with id:{id} not found.");
        }

        public int Create(User user)
        {
            if (user == null)
            {
                throw GetExceptionAndLog("An error occurred while user creating");
            }

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            var result = ErrorProcessing(() => _userContext.Add(user));

            return result.Entity.Id;
        }

        public IEnumerable<Tuple<string, string>> AdditionalValidation(User user)
        {
            if (Query().Any(x => x.Login == user.Login))
            {
                yield return new Tuple<string, string>(nameof(user.Login), "The user`s login already exists");
            }
        }

        // TODO: move into a separate interface and an abstract class for all services
        private T ErrorProcessing<T>(Func<T> operation)
        {
            try
            {
                var result = operation();
                _userContext.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                throw GetExceptionAndLog($"An error occurred while processing the request: {e.Message}");
            }
        }

        private InvalidOperationException GetExceptionAndLog(string errorMessage)
        {
            _logger.LogError(errorMessage);

            return new InvalidOperationException(errorMessage);
        }
    }
}
