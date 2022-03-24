#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using razor_of_2022.Model;

    public class StoreGameContext : DbContext
    {
        public StoreGameContext (DbContextOptions<StoreGameContext> options)
            : base(options)
        {
        }

        public DbSet<razor_of_2022.Model.Game> Game { get; set; }
    }
