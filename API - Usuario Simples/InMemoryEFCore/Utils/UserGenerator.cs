﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMemoryEFCore.DataContext;
using InMemoryEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InMemoryEFCore.Utils
{
    public class UserGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserLoginDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<UserLoginDBContext>>()))
            {
                // Look for any points of interest already in database
                if (context.UserLogin.Any())
                {
                    return; // Database has been seeded
                }

                context.UserLogin.AddRange(
                    new UserLoginModel()
                    {
                        id = 1,
                        name = "fecorba"
                    },
                    new UserLoginModel()
                    {
                        id = 2,
                        name = "hyanvin"
                    });

                context.SaveChanges();
            }
        }
    }
}
