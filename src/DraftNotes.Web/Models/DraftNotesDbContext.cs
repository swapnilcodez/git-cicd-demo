using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftNotes.Web.Models
{
    public class DraftNotesDbContext : DbContext
    {

        public DraftNotesDbContext(DbContextOptions<DraftNotesDbContext> options)
            :base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }

       


    }
}
