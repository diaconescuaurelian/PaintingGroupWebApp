using Microsoft.AspNetCore.Identity;
using PaintingGroupWebApp.Data.Enum;
using PaintingGroupWebApp.Models;
using System.Diagnostics;

namespace PaintingGroupWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Painting Club 1",
                            Image = "https://lh6.googleusercontent.com/l4ayDrnhCY8H2sxvfz9cMHqpa6nwpqvib_QBBQPQwMeuHcCmBv7O_iYLu2g80AQ_xUI=w1200-h630-p",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Beginner,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Ramnicu Valcea",
                                County = "Valcea"
                            }
                         },
                        new Club()
                        {
                            Title = "Painting Club 2",
                            Image = "https://lh6.googleusercontent.com/l4ayDrnhCY8H2sxvfz9cMHqpa6nwpqvib_QBBQPQwMeuHcCmBv7O_iYLu2g80AQ_xUI=w1200-h630-p",
                            Description = "This is the description of the second club",
                            ClubCategory = ClubCategory.Intermediate,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Brasov",
                                County = "Brasov"
                            }
                        },
                        new Club()
                        {
                            Title = "Painting Club 3",
                            Image = "https://lh6.googleusercontent.com/l4ayDrnhCY8H2sxvfz9cMHqpa6nwpqvib_QBBQPQwMeuHcCmBv7O_iYLu2g80AQ_xUI=w1200-h630-p",
                            Description = "This is the description of the third club",
                            ClubCategory = ClubCategory.Advanced,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Sibiu",
                                County = "Sibiu"
                            }
                        },
                        new Club()
                        {
                            Title = "Painting Club 4",
                            Image = "https://lh6.googleusercontent.com/l4ayDrnhCY8H2sxvfz9cMHqpa6nwpqvib_QBBQPQwMeuHcCmBv7O_iYLu2g80AQ_xUI=w1200-h630-p",
                            Description = "This is the description of the forth club",
                            ClubCategory = ClubCategory.Pro,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Cluj-Napoca",
                                County = "Cluj"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Meetings
                if (!context.Meetings.Any())
                {
                    context.Meetings.AddRange(new List<Meeting>()
                    {
                        new Meeting()
                        {
                            Title = "Meeting 1",
                            Image = "https://lh6.googleusercontent.com/l4ayDrnhCY8H2sxvfz9cMHqpa6nwpqvib_QBBQPQwMeuHcCmBv7O_iYLu2g80AQ_xUI=w1200-h630-p",
                            Description = "This is the description of the first race",
                            MeetingCategory = MeetingCategory.Portrait,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Sibiu",
                                County = "Sibiu"
                            }
                        },
                        new Meeting()
                        {
                            Title = "Meeting 2",
                            Image = "https://lh6.googleusercontent.com/l4ayDrnhCY8H2sxvfz9cMHqpa6nwpqvib_QBBQPQwMeuHcCmBv7O_iYLu2g80AQ_xUI=w1200-h630-p",
                            Description = "This is the description of the first race",
                            MeetingCategory = MeetingCategory.Landcaping,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Cluj-Napoca",
                                County = "Cluj"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Sibiu",
        //                    County = "Sibiu"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Sibiu",
        //                    County = "Sibiu"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
