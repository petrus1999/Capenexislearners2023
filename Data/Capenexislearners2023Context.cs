using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capenexislearners2023.Models;

namespace Capenexislearners2023.Data
{
    public class Capenexislearners2023Context : DbContext
    {
        public Capenexislearners2023Context (DbContextOptions<Capenexislearners2023Context> options)
            : base(options)
        {
        }

        public DbSet<Capenexislearners2023.Models.Learners> Learners { get; set; } = default!;

        public DbSet<Capenexislearners2023.Models.Facilitators> Facilitators { get; set; } = default!;

        public DbSet<Capenexislearners2023.Models.Courses> Courses { get; set; } = default!;
    }
}
