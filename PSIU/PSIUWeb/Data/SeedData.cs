using Microsoft.EntityFrameworkCore;
using PSIUWeb.Models;

namespace PSIUWeb.Data
{
    public static class SeedData
    {

        public static void EnsurePopulated(
            IApplicationBuilder app
        )
        {
            AppDbContext context =
                app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Pacients.Any())
            {
                context.Pacients.AddRange(

                    new Pacient
                    {
                        Name = "Mauricio",
                        BirthDate = new DateTime(1984, 7, 5),
                        Race = Race.Pardo,
                        Height = 180,
                        Weight = 88
                    },
                    new Pacient
                    {
                        Name = "Leonardo",
                        BirthDate = new DateTime(2001, 1, 24),
                        Race = Race.Branco,
                        Height = 187,
                        Weight = 100
                    }

                );
                if (!context.Psicos.Any())
                {
                    context.Psicos.AddRange(

                        new Psico
                        {
                            Name = "Mauricio",
                            CRP = "123456"
                        }
                    );

                    context.SaveChanges();
                }
            }

        }
    }
}