using System;
using Microsoft.EntityFrameworkCore.Internal;
using UserRegistrationApp.EFEntity.DbContext.DbContexts;
using UserRegistrationApp.EFEntity.Models;

namespace UserRegistrationApp.EFEntity.DbContext.Initializers
{
    public class UserInitializer
    {
        public static void Initialize(UserContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            context.Users.AddRange(
                new User
                {
                    Login = "Login1",
                    Password = "12345678",
                    ConfirmPassword = "12345678",
                    FullName = "Ivan Ivanovich Ivanov",
                    BirthAt = new DateTime(2000, 01, 01),
                    Email = "login1@gmail.com",
                    Phone = "89161111111",
                    CreatedAt = new DateTime(2002, 02, 02),
                    UpdatedAt = new DateTime(2003, 03, 03),
                },
                new User
                {
                    Login = "Login2",
                    Password = "87654321",
                    ConfirmPassword = "87654321",
                    FullName = "Petr Petrovich Petrov",
                    BirthAt = new DateTime(1999, 12, 12),
                    Email = "Login2@gmail.com",
                    Phone = "89162222222",
                    CreatedAt = new DateTime(1998, 01, 15),
                    UpdatedAt = new DateTime(1997, 02, 10)
                }
            );
            context.SaveChanges();
        }
    }
}
