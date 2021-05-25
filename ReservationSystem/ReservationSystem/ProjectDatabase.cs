using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem
{
    public class ProjectDatabase : DbContext
    {
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PartyRequest> PartyRequests { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TablesArrangement> TablesArrangements { get; set; }
        public DbSet<OrganizierTask> OrganizierTasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
