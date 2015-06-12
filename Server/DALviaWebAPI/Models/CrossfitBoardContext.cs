using DALviaWebAPI.Models.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models
{
    public class CrossfitBoardContext:DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Tack> Tacks { get; set; }

        public DbSet<TackInRound> TacksInRounds { get; set; }

        public DbSet<Wod> Wods { get; set; }

        public DbSet<WodResult> WodResults { get; set; }

        public DbSet<TrainerAndWard> TrainersAndWards { get; set; }

    }
}