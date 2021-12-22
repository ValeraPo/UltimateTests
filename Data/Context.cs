using System.Data.Entity;
using Data.Maps;

namespace Data
{
    public partial class Context : DbContext
    {
        public Context()
            : base(@"data source = STEPA-PC; initial catalog = MyTest; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework") { }

        public virtual DbSet<Answers>           Answers           {get; set;}
        public virtual DbSet<AppointmentQuizes> AppointmentQuizes {get; set;}
        public virtual DbSet<Attempts>          Attempts          {get; set;}
        public virtual DbSet<Feedbacks>         Feedbacks         {get; set;}
        public virtual DbSet<Groups>            Groups            {get; set;}
        public virtual DbSet<GroupsCategories>  GroupsCategories  {get; set;}
        public virtual DbSet<Questions>         Questions         {get; set;}
        public virtual DbSet<Quizes>            Quizes            {get; set;}
        public virtual DbSet<QuizzesCategories> QuizzesCategories {get; set;}
        public virtual DbSet<SetTags>           SetTags           {get; set;}
        public virtual DbSet<TeachingGroups>    TeachingGroups    {get; set;}
        public virtual DbSet<Users>             Users             {get; set;}
        public virtual DbSet<UserTypes>         UserTypes         {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attempts>()
                        .Property(e => e.TransitTime)
                        .HasPrecision(0);

            modelBuilder.Entity<Groups>()
                        .Property(e => e.NameOfGroup)
                        .IsFixedLength();

            modelBuilder.Entity<Groups>()
                        .HasMany(e => e.GroupsCategories)
                        .WithRequired(e => e.Groups)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                        .HasMany(e => e.TeachingGroups)
                        .WithRequired(e => e.Groups)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questions>()
                        .HasMany(e => e.Answers)
                        .WithRequired(e => e.Questions)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizes>()
                        .Property(e => e.TimeToComplete)
                        .HasPrecision(0);

            modelBuilder.Entity<Quizes>()
                        .HasMany(e => e.AppointmentQuizes)
                        .WithRequired(e => e.Quizes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizes>()
                        .HasMany(e => e.Attempts)
                        .WithRequired(e => e.Quizes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizes>()
                        .HasMany(e => e.Feedbacks)
                        .WithRequired(e => e.Quizes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizes>()
                        .HasMany(e => e.Questions)
                        .WithRequired(e => e.Quizes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizes>()
                        .HasMany(e => e.QuizzesCategories)
                        .WithRequired(e => e.Quizes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTags>()
                        .HasMany(e => e.GroupsCategories)
                        .WithRequired(e => e.SetTags)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTags>()
                        .HasMany(e => e.QuizzesCategories)
                        .WithRequired(e => e.SetTags)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.AppointmentQuizes)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.Attempts)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.Feedbacks)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.Quizes)
                        .WithRequired(e => e.Users)
                        .HasForeignKey(e => e.ID_UserCreateons)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.TeachingGroups)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTypes>()
                        .HasMany(e => e.Users)
                        .WithRequired(e => e.UserTypes)
                        .WillCascadeOnDelete(false);
        }
    }
}