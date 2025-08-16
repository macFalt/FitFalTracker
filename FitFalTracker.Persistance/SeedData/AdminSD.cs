// using FitFalTracker.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
//
// namespace FitFalTracker.Persistance.SeedData;
//
// public static class AdminSD
// {
//     public static void SeedDataAdmin(this ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<AppUser>(a =>
//         {
//             a.HasData(new AppUser()
//             {
//                 Id = 1,
//                 Age = 18,
//                 Weight = 1.2f,
//                 Height=182
//             });
//             a.OwnsOne(a => a.UserName).HasData(new
//             {
//                 AppUserId = 1, //nazwa encji plus id. Jest to FK
//                 FirstName = "Michael",
//                 LastName = "Patrick",
//             });
//         });
//
//     }
// }