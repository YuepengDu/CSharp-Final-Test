using FinalTest_s3698728.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest_s3698728.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BookingContext>();
            if (context.Rooms.Any())
                return; // DB has already been seeded.
            context.Rooms.AddRange(
                new Rooms
                {
                    RoomID = "14.10.31",
                    Capacity = 2,
                    HasProjector = true
                },
                new Rooms
                {
                    RoomID = "14.09.15",
                    Capacity = 20,
                    HasProjector = true
                }
                );

          
            context.Staff.AddRange(
                new Staff
                {
                    StaffID = "e12345",
                    FirstName = "Alan",
                    LastName = "Du",
                    Email = "AlanDu323@gmail.com",
                    MobilePhone = "0488888888"
                },
                new Staff
                {
                    StaffID = "e54321",
                    FirstName = "Barry",
                    LastName = "Alan",
                    Email = "TheFlash777@gmail.com"
                }
               );
            context.SaveChanges();
        }
    }
}
