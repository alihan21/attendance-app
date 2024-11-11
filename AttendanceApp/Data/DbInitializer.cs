namespace AttendanceApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Resolve the DbContext within the scope
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (context != null)
                {
                    if (!context.Players.Any())
                    {
                        context.AddRange(
                            new Player { Name = "Alihan Fevziev", PlayerImage = "none" },
                            new Player { Name = "Staf Lautsnay", PlayerImage = "none" },
                            new Player { Name = "Yves De Backer", PlayerImage = "none" }
                        );
                    }

                    if (!context.Games.Any())
                    {
                        context.AddRange(
                            new Game { Title = "Kavok vs Belsele", Date = "10/11/2024 19:00:00", Address = "Overmerestraat 1, 9260 Overmere", Attendees = [] },
                            new Game { Title = "Stacco vs Kavok", Date = "21/11/2024 18:00:00", Address = "Wetterenalaan 2, 9260 Wetteren", Attendees = [] },
                            new Game { Title = "Willyboys vs Kavok", Date = "11/12/2024 20:00:00", Address = "Willyboysstraat 23, 9234 Willys", Attendees = [] }
                    );
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
