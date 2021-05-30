using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftNotes.Web.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DraftNotesDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<DraftNotesDbContext>>()))
            {
                // Look for any board games.
                if (context.Notes.Any())
                {
                    return;   // Data was already seeded
                }

                context.Notes.AddRange(
                    new Note
                    {
                        Id = 1,
                        Description = "Sample Draft notes."
                    },
                    new Note
                    {
                        Id = 2,
                        Description = "Create your own notes."

                    });
                context.SaveChanges();
               
            }
        }
    }
}
